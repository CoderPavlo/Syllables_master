using OfficeOpenXml;
using Sklady.ENStatistics;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static OfficeOpenXml.ExcelErrorValue;
using static System.Windows.Forms.AxHost;


namespace Core.ENStatistics
{
    public class WordsStatisticsEN
    {
        static public readonly HashSet<char> vowels = new HashSet<char> { 'ʌ', 'e', 'ɪ', 'ɑ', 'ɛ', 'ɔ', 'æ', 'o', 'u', 'ə', 'ɒ', 'a', 'ʌ', 'i', 'ɚ' };
        // Array with consonant phonemes
        static public readonly HashSet<char> consonants = new HashSet<char> { 'j', 'z', 't', 'r', 'p', 'l', 'b', 'g', 'k', 'n', 's', 'θ', 'm', 'd', 'v', 'f', 'ŋ', 'ʃ', 'ʒ', 'h', 'ʤ', 'ʧ', 'ð', 'w', 'ʊ' };

        // Digraphs and trigraphs that have a specific sound
        static readonly HashSet<string> specialCombinations = new HashSet<string>
        {
            "ch", "sh", "th", "ph", "wh", "qu", "ng", "kn", "tch", "sch"
        };
        static readonly HashSet<char> vowelsLetter = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'y' };
        static readonly HashSet<char> consonantLetter = new HashSet<char> { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'z' };

        string fileName = "";
        string folderName = "";
        ProgressBar progressBar;
        private object updateLock = new object();
        public WordsStatisticsEN(ProgressBar progressBar)
        {
            this.progressBar = progressBar;
        }
        string ConvertToCVPatternPhoneme(string word)
        {
            string syll = "";
            foreach (char c in word)
            {
                if (vowels.Contains(c)) syll += 'v';
                else if (c != 'ʊ') syll += 'c';
            }
            return syll;
        }
        string ConvertToCVPattern(string word)
        {
            StringBuilder result = new StringBuilder(word);
            foreach (string sComb in specialCombinations)
                result.Replace(sComb, "@");
            int i = 1;
            while (i < result.Length)
            {
                if (consonantLetter.Contains(result[i]) && result[i] == result[i - 1])
                {
                    result.Remove(i - 1, 2);
                    result.Insert(i - 1, '@');
                }
                else if (vowelsLetter.Contains(result[i - 1]) && vowelsLetter.Contains(result[i]))
                {
                    result.Remove(i - 1, 2);
                    result.Insert(i - 1, '#');
                }
                else
                    i += 1;
            }
            i = 0;
            while (i < result.Length)
            {
                if (vowelsLetter.Contains(result[i]))
                {
                    result.Remove(i, 1);
                    result.Insert(i, 'v');
                }
                else if (consonantLetter.Contains(result[i]))
                {
                    result.Remove(i, 1);
                    result.Insert(i, 'c');
                }
                i++;
            }
            result.Replace('@', 'c');
            result.Replace('#', 'v');
            if (word.EndsWith("e") && word.Length > 1 && !word.EndsWith("ee"))
            {
                result.Remove(result.Length - 1, 1);
            }
            return result.ToString();
        }

        static int CountSyllables(string cvPattern)
        {
            return Math.Max(cvPattern.Count(c => c == 'v'), 1);
        }

        static Dictionary<string, string> getDictionary()
        {
            string filePath = "dictionary.txt";
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;

                // Читаємо кожен рядок до тих пір, поки не буде кінець файлу
                while ((line = sr.ReadLine()) != null)
                {
                    // Розділяємо рядок на слово і значення за допомогою коми
                    string[] parts = line.Split(',');

                    // Видаляємо зайві пробіли
                    string word = parts[0].Trim();
                    string value = parts[1].Trim();


                    // Додаємо пару слово-значення до словника
                    dictionary.Add(word, value);
                }
            }
            return dictionary;
        }

        public void clear()
        {
            fileName = "";
            folderName = "";
        }
        DataTable resultToTable(string[] result, Dictionary<string, string> dictionary)
        {
            DataTable dtab = new DataTable();
            DataColumn col1 = new DataColumn("word", typeof(string));
            DataColumn col2 = new DataColumn("length", typeof(int));
            DataColumn col3 = new DataColumn("syllables  count", typeof(int));
            DataColumn col4 = new DataColumn("syllable length", typeof(double));
            DataColumn col5 = new DataColumn("transcription", typeof(string));
            DataColumn col6 = new DataColumn("CV", typeof(string));
            dtab.Columns.Add(col1);
            dtab.Columns.Add(col2);
            dtab.Columns.Add(col3);
            dtab.Columns.Add(col4);
            dtab.Columns.Add(col5);
            dtab.Columns.Add(col6);
            Array.Sort(result);
            for (int i = 0; i < result.Length; i++)
            {
                int syllables;
                string phoneme = "";
                string syll = "";
                if (dictionary.TryGetValue(result[i], out string value))
                {
                    phoneme = value;
                    syll = ConvertToCVPatternPhoneme(phoneme);
                }
                else
                {
                    syll = ConvertToCVPattern(result[i]);
                }
                syllables = CountSyllables(syll);
                dtab.Rows.Add(
                    result[i],
                    result[i].Length,
                    syllables,
                    Math.Round((double)result[i].Length / syllables, 10),
                    phoneme,
                    syll
                );
            }
            return dtab;
        }

        HashSet<string> getWords(string fileName)
        {
            HashSet<string> result = new HashSet<string>();

            if (string.IsNullOrWhiteSpace(fileName) || !File.Exists(fileName))
                return result;
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine().ToLower();
                    string[] words = Regex.Split(line, @"[^a-zA-Z]+");

                    foreach (var word in words)
                    {
                        if (!string.IsNullOrWhiteSpace(word))
                            result.Add(word);
                    }
                }
            }
            return result;
        }

        public DataTable selectFile(string fileName)
        {
            progressBar.Invoke((MethodInvoker)delegate
            {
                progressBar.Maximum = 1;
                progressBar.Value = 0; // Скидання прогресу
            });
            this.fileName = fileName;
            var result = getWords(fileName);
            Dictionary<string, string> dictionary = getDictionary();
            UpdateProgress();
            return resultToTable(result.ToArray(), dictionary);
        }

        public DataTable selectFolder(string folderName)
        {
            this.folderName = folderName;
            // Отримання всіх .txt файлів у вибраній папці
            string[] txtFiles = Directory.GetFiles(folderName, "*.txt");
            progressBar.Invoke((MethodInvoker)delegate
            {
                progressBar.Maximum = txtFiles.Length + 1;
                progressBar.Value = 0; // Скидання прогресу
            });
            ConcurrentBag<HashSet<string>> results = new ConcurrentBag<HashSet<string>>();
            Parallel.ForEach(txtFiles, txtFile =>
            {
                results.Add(getWords(txtFile));
                UpdateProgress();
            });
            HashSet<string> result = new HashSet<string>();

            foreach (var set in results)
            {
                foreach (var word in set)
                {
                    result.Add(word);
                }
            }

            // Отримання словника
            Dictionary<string, string> dictionary = getDictionary();
            UpdateProgress();
            // Обробка результатів та додавання до таблиці
            return resultToTable(result.ToArray(), dictionary);

        }
        private FileStatistics exportFileResult(string file, string dataDir, string phonemesDir, string syllablesDir, Dictionary<string, string> dictionary)
        {
            string fileName = Path.GetFileNameWithoutExtension(file);
            List<string> resultWords = new List<string>();
            using (StreamReader reader = new StreamReader(file))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine().ToLower();
                    string[] words = Regex.Split(line, @"[^a-zA-Z]+");

                    foreach (var word in words)
                    {
                        if (!string.IsNullOrWhiteSpace(word))
                            resultWords.Add(word);
                    }
                }
            }
            UpdateProgress();
            StringBuilder phonemes = new StringBuilder();
            StringBuilder cvs = new StringBuilder();
            for (int i = 0; i < resultWords.Count; i++)
            {
                string phoneme = "$";
                string cv = "";
                if (dictionary.TryGetValue(resultWords[i], out string value))
                {
                    phoneme = value;
                    cv = ConvertToCVPatternPhoneme(phoneme);
                }
                else
                {
                    cv = ConvertToCVPattern(resultWords[i]);
                }
                cvs.Append(cv).Append(" ");
                phonemes.Append(phoneme).Append(" ");
            }
            File.WriteAllText(Path.Combine(phonemesDir, "phon_" + fileName + ".txt"), phonemes.ToString(), Encoding.UTF8);
            File.WriteAllText(Path.Combine(syllablesDir, "ccv_" + fileName + ".txt"), cvs.ToString(), Encoding.UTF8);
            UpdateProgress();
            FileStatistics stats;
            // Встановлення ліцензійного контексту
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            // Створення файлу Excel та робота з ним
            using (var package = new ExcelPackage())
            {
                string[] uniqueWords = resultWords.Distinct().OrderBy(item => item).ToArray();
                List<int> lengths = new List<int>(uniqueWords.Length);
                List<int> syllablesCounts = new List<int>(uniqueWords.Length);
                List<double> syllablesLengths = new List<double>(uniqueWords.Length);

                // Додавання нового аркуша у книгу Excel
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // Додавання даних до робочого аркуша
                worksheet.Cells["A1"].Value = "word";
                worksheet.Cells["B1"].Value = "length";
                worksheet.Cells["C1"].Value = "syllables  count";
                worksheet.Cells["D1"].Value = "syllable length";
                worksheet.Cells["E1"].Value = "phoneme";
                worksheet.Cells["F1"].Value = "CV";

                int i = 0;

                for(; i< uniqueWords.Length; i++)
                {
                    int syllables;
                    string phoneme = "";
                    string syll = "";
                    if (dictionary.TryGetValue(uniqueWords[i], out string value))
                    {
                        phoneme = value;
                        syll = ConvertToCVPatternPhoneme(phoneme);
                    }
                    else
                    {
                        syll = ConvertToCVPattern(uniqueWords[i]);
                    }
                    syllables = CountSyllables(syll);
                    double syllLength = Math.Round((double)uniqueWords[i].Length / syllables, 10);
                    worksheet.Cells["A" + (i + 2).ToString()].Value = uniqueWords[i];
                    worksheet.Cells["B" + (i + 2).ToString()].Value = uniqueWords[i].Length;
                    worksheet.Cells["C" + (i + 2).ToString()].Value = syllables;
                    worksheet.Cells["D" + (i + 2).ToString()].Value = syllLength;
                    worksheet.Cells["E" + (i + 2).ToString()].Value = phoneme;
                    worksheet.Cells["F" + (i + 2).ToString()].Value = syll;

                    lengths.Add(uniqueWords[i].Length);
                    syllablesCounts.Add(syllables);
                    syllablesLengths.Add(syllLength);
                }
                i += 3;

                stats = new FileStatistics(fileName, lengths, syllablesCounts, syllablesLengths);

                worksheet.Cells["A" + i.ToString()].Value = "sum";
                worksheet.Cells["B" + i.ToString()].Value = stats.LengthSum;
                worksheet.Cells["C" + i.ToString()].Value = stats.SyllCountSum;
                worksheet.Cells["D" + i.ToString()].Value = stats.SyllLengthSum;

                worksheet.Cells["A" + (i+1).ToString()].Value = "average";
                worksheet.Cells["B" + (i + 1).ToString()].Value = stats.LengthAvg;
                worksheet.Cells["C" + (i + 1).ToString()].Value = stats.SyllCountAvg;
                worksheet.Cells["D" + (i + 1).ToString()].Value = stats.SyllLengthAvg;

                worksheet.Cells["A" + (i+2).ToString()].Value = "standard deviation";
                worksheet.Cells["B" + (i + 2).ToString()].Value = stats.LengthStd;
                worksheet.Cells["C" + (i + 2).ToString()].Value = stats.SyllCountStd;
                worksheet.Cells["D" + (i + 2).ToString()].Value = stats.SyllLengthStd;

                // Збереження файлу Excel на диск
                FileInfo excelFile = new FileInfo(Path.Combine(dataDir, "data_" + fileName + ".xlsx"));
                package.SaveAs(excelFile);
            }
            UpdateProgress();
            return stats;
        }

        public void exportResults(string directory)
        {
            var dataDirectory = Directory.CreateDirectory(Path.Combine(directory, "data")).FullName;
            var phonemesDirectory = Directory.CreateDirectory(Path.Combine(directory, "phonemes")).FullName;
            var syllablesDirectory = Directory.CreateDirectory(Path.Combine(directory, "CV")).FullName;
            var dictionary = getDictionary();
            if (fileName!="")
            {
                progressBar.Invoke((MethodInvoker)delegate
                {
                    progressBar.Maximum = 3;
                    progressBar.Value = 0; // Скидання прогресу
                });
                exportFileResult(fileName, dataDirectory, phonemesDirectory, syllablesDirectory, dictionary);
            }
            else if (folderName != "")
            {
                // Отримання всіх .txt файлів у вибраній папці
                string[] txtFiles = Directory.GetFiles(folderName, "*.txt");
                progressBar.Invoke((MethodInvoker)delegate
                {
                    progressBar.Maximum = 4 * txtFiles.Length;
                    progressBar.Value = 0; // Скидання прогресу
                });

                ConcurrentBag<FileStatistics> results = new ConcurrentBag<FileStatistics>();
                Parallel.ForEach(txtFiles, txtFile =>
                {
                    results.Add(exportFileResult(txtFile, dataDirectory, phonemesDirectory, syllablesDirectory, dictionary));
                });

                // Встановлення ліцензійного контексту
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                // Створення файлу Excel та робота з ним
                using (var package = new ExcelPackage())
                {
                    // Додавання нового аркуша у книгу Excel
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

                    // Додавання даних до робочого аркуша
                    worksheet.Cells["A1"].Value = "№";
                    worksheet.Cells["B1"].Value = "name";
                    worksheet.Cells["C1"].Value = "text length";
                    worksheet.Cells["D1"].Value = "syllable count";
                    worksheet.Cells["E1"].Value = "syll-length sum";
                    worksheet.Cells["F1"].Value = "length average";
                    worksheet.Cells["G1"].Value = "length std";
                    worksheet.Cells["H1"].Value = "syll-count average";
                    worksheet.Cells["I1"].Value = "syll-count std";
                    worksheet.Cells["J1"].Value = "syll-length average";
                    worksheet.Cells["K1"].Value = "syll-length std";

                    int i = 2;
                    foreach(var stats in results)
                    {
                        worksheet.Cells["A" + i.ToString()].Value = i - 1;
                        worksheet.Cells["B" + i.ToString()].Value = stats.Name;
                        worksheet.Cells["C" + i.ToString()].Value = stats.LengthSum;
                        worksheet.Cells["D" + i.ToString()].Value = stats.SyllCountSum;
                        worksheet.Cells["E" + i.ToString()].Value = stats.SyllLengthSum;
                        worksheet.Cells["F" + i.ToString()].Value = stats.LengthAvg;
                        worksheet.Cells["G" + i.ToString()].Value = stats.LengthStd;
                        worksheet.Cells["H" + i.ToString()].Value = stats.SyllCountAvg;
                        worksheet.Cells["I" + i.ToString()].Value = stats.SyllCountStd;
                        worksheet.Cells["J" + i.ToString()].Value = stats.SyllLengthAvg;
                        worksheet.Cells["K" + i.ToString()].Value = stats.SyllLengthStd;
                        i++;
                        UpdateProgress();
                    }
                    i++;
                    var statistics = new FolderStatistics(results);
                    worksheet.Cells["B" + i.ToString()].Value = "Average";
                    worksheet.Cells["C" + i.ToString()].Value = statistics.LengthSum_Avg;
                    worksheet.Cells["D" + i.ToString()].Value = statistics.SyllCountSum_Avg;
                    worksheet.Cells["E" + i.ToString()].Value = statistics.SyllLengthSum_Avg;
                    worksheet.Cells["F" + i.ToString()].Value = statistics.LengthAvg_Avg;
                    worksheet.Cells["G" + i.ToString()].Value = statistics.LengthStd_Avg;
                    worksheet.Cells["H" + i.ToString()].Value = statistics.SyllCountAvg_Avg;
                    worksheet.Cells["I" + i.ToString()].Value = statistics.SyllCountStd_Avg;
                    worksheet.Cells["J" + i.ToString()].Value = statistics.SyllLengthAvg_Avg;
                    worksheet.Cells["K" + i.ToString()].Value = statistics.SyllLengthStd_Avg;

                    worksheet.Cells["B" + (i + 1).ToString()].Value = "Weighted std";
                    worksheet.Cells["C" + (i + 1).ToString()].Value = statistics.LengthSum_WStd;
                    worksheet.Cells["D" + (i + 1).ToString()].Value = statistics.SyllCountSum_WStd;
                    worksheet.Cells["E" + (i + 1).ToString()].Value = statistics.SyllLengthSum_WStd;
                    worksheet.Cells["F" + (i + 1).ToString()].Value = statistics.LengthAvg_WStd;
                    worksheet.Cells["G" + (i + 1).ToString()].Value = statistics.LengthStd_WStd;
                    worksheet.Cells["H" + (i + 1).ToString()].Value = statistics.SyllCountAvg_WStd;
                    worksheet.Cells["I" + (i + 1).ToString()].Value = statistics.SyllCountStd_WStd;
                    worksheet.Cells["J" + (i + 1).ToString()].Value = statistics.SyllLengthAvg_WStd;
                    worksheet.Cells["K" + (i + 1).ToString()].Value = statistics.SyllLengthStd_WStd;

                    // Збереження файлу Excel на диск
                    FileInfo excelFile = new FileInfo(Path.Combine(directory, "Statistics.xlsx"));
                    package.SaveAs(excelFile);
                }
             }

        }
        void UpdateProgress()
        {
            if (progressBar.InvokeRequired)
            {
                progressBar.BeginInvoke((MethodInvoker)delegate
                {
                    progressBar.Value += 1;
                });
            }
            else
            {
                progressBar.Value += 1;
            }
        }

    }
}
