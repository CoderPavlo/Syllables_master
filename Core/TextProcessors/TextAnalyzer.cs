﻿using Core.Helpers;
using Sklady.Export;
using Sklady.Models;
using Sklady.TextProcessors;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Sklady
{
    public partial class TextAnalyzer
    {
        private Stopwatch _stopWatch = new Stopwatch();
        public long ElapsedToCountWords { get { return _stopWatch.ElapsedMilliseconds; } }
        //private string _text;
        private string[] _words;
        private WordAnalyzer _wordAnalyzer;
        private CharactersTable table;
        private PhoneticProcessorBase _phoneticProcessor;// = new PhoneticProcessor();        
        Settings settings;
        ResultsExporter exporter;

        public string FileName { get; private set; }
        public int TextLength { get; private set; }

        public event Action<int, int, string> OnWordAnalyzed;
        public event Action<Exception, string, string> OnErrorOccured;

        public TextAnalyzer(string text, string fileName, Settings settings, ResultsExporter exporter, bool[] isCheckBox)
        {
            this.table = settings.CharactersTable;
            this.settings = settings;
            this.exporter = exporter;

            switch (settings.Language)
            {
                case Languages.Ukrainian:
                    _phoneticProcessor = new UkrainePhoneticProcessor(table, isCheckBox);
                    break;
                case Languages.Russian:
                    _phoneticProcessor = new RussianPhoneticProcessor(table, isCheckBox);
                    break;
                case Languages.Ancient:
                    _phoneticProcessor = new AncientPhoneticProcessor(table, isCheckBox);
                    break;
                case Languages.English:
                    _phoneticProcessor = new EnglishPhoneticProcessor(table, isCheckBox);
                    break;
                case Languages.Polish:
                    _phoneticProcessor = new PolishPhoneticProcessor(table, isCheckBox);
                    break;
                case Languages.Bulgarian:
                    _phoneticProcessor = new BulgraianProneticProcessor(table, isCheckBox);
                    break;
            }
            
            FileName = fileName;
            _wordAnalyzer = new WordAnalyzer(table, settings);
            table = null;
            PrepareText(text);
        }

        private void PrepareText(string inputText)
        {            
            var sb = new StringBuilder(inputText.ToLower());

            for (var i = 0; i < settings.CharactersToRemove.Count; i++) // Remove all unnecesarry characters
            {
                sb.Replace(settings.CharactersToRemove[i], "");
            }

            var text = sb.ToString();
            text = Regex.Replace(text, "([0-9][а-яА-Я])", "");//Remove chapter number (for vk)
            text = Regex.Replace(text, "([0-9][a-zA-Z])", "");
            text = Regex.Replace(text, "([0-9][a-żA-Ż])", ""); //polish
           // _text = Regex.Replace(_text, RegexHelper.RemoveAllLatinExcept(settings.CharsToSkip), "");
            text = Regex.Replace(text, @"/\t|\n|\r", " "); // remove new line, tabulation and other literals

            text = Regex.Replace(text, @"(\- )", ""); // Handle word hyphenations            
            text = Regex.Replace(text, @"и́| ̀и|ù|ѝ̀̀| ̀̀и|ѝ|́и", "й");

            _words = text.Split(new[] { " ", " " }, StringSplitOptions.RemoveEmptyEntries).ToArray(); // Split text by words

        }

        public FileProcessingResult GetResults(bool[] isCheckbox)
        {
            var result = new FileProcessingResult(exporter)
            {
                CvvResults = new List<AnalyzeResults>(_words.Length),
                ReadableResults = new List<AnalyzeResults>(_words.Length),
                TranscribedToUkrainianSpellingWords = new List<string>(_words.Length)
            };

            foreach (var word in _words)
            {
                result.CvvResults.Add(new AnalyzeResults());
                result.ReadableResults.Add(new AnalyzeResults());
                result.TranscribedToUkrainianSpellingWords.Add("");
            }

            var invokeStep = _words.Length / 10;

            Parallel.For(0, _words.Length, i =>
            {
                try
                {
                    UpdateRepetitions(result.Repetitions, _words[i]);


                    if (settings.PhoneticsMode)
                        _words[i] = _phoneticProcessor.Process(_words[i], isCheckbox); // In case of phonetics mode make corresponding replacements

                    _words[i] = _phoneticProcessor.ProcessNonStableCharacters(_words[i], settings.PhoneticsMode); // Replace some chars according to their power

                    // if lang = bulgarian and current word is 'в' - pass current word and the next char the new word starts with
                    if (settings.Language == Languages.Bulgarian && _words[i] == "ф")
                        _words[i] = ProcessBulgarianCase(_words[i], _phoneticProcessor.Process(_words[i + 1], isCheckbox)[0]);

                    //UpdateLetters(result.Letters, _words[i]);

                    //var tempWord = RemoveAposWord(ref _words[i]);

                    result.TranscribedToUkrainianSpellingWords[i] = TranscribeWord(RemoveAposWord(ref _words[i]));

                    //GetSyllables method gets transcribed to ukrainian word converted to lowercase (excluding 'Y' - it is in lowercase)
                    var syllables = _wordAnalyzer.GetSyllables(new string(result.TranscribedToUkrainianSpellingWords[i].Select(c => c != 'Y' ? char.ToLower(c) : c).ToArray()));

                    _words[i] = result.TranscribedToUkrainianSpellingWords[i].ToLower();

                    UpdateLetters(result.Letters, _words[i]);

                    result.CvvResults[i].Word = _words[i];
                    result.CvvResults[i].Syllables = RemoveApos(syllables);

                    result.ReadableResults[i].Word = _words[i];
                    result.ReadableResults[i].Syllables = settings.PhoneticsMode ? syllables : UnprocessPhonetics(syllables);

                    if (result.ReadableResults[i].Syllables == null)
                    {
                        throw new Exception("Syllables are null");
                    }

                    if (i % invokeStep == 0)
                    {
                        OnWordAnalyzed?.Invoke(i + 1, _words.Length, FileName);
                    }
                    OnWordAnalyzed?.Invoke(i + 1, _words.Length, FileName);
                }
                catch (Exception ex)
                {
                    if (ex.Message != "Sequence contains no elements")
                    {
                        OnErrorOccured?.Invoke(ex, _words[i], FileName);
                    }
                }
             });

            OnWordAnalyzed?.Invoke(_words.Length, _words.Length, FileName);
            _words = new string[1];
            _wordAnalyzer = null;
            _phoneticProcessor = null;
            result.FileName = FileName;
            return result;
        }
        
        private string TranscribeWord(string word) => _phoneticProcessor.TranscribeToUkrainianSpelling(word, settings.Language);

        private string ProcessBulgarianCase(string currentWordF, char charTheNextWordStartsWith)
        {
            var processor = _phoneticProcessor as BulgraianProneticProcessor;
            if (processor != null) 
            {
                return processor.ProcessSingleV(currentWordF, charTheNextWordStartsWith);
            }
            return currentWordF;
        }

        private void UpdateLetters(Dictionary<char, int> letters, string word)
        {
            _stopWatch.Start();           
            char[] charsToSkip = { '\'', '-', '\n', '\r', '\t' };
            for (var i = 0; i < word.Length; i++)
            { 
                if (Array.IndexOf(charsToSkip, word[i]) != -1)
                {
                    continue;
                }

                var key = GetKeyForLetter(word[i]);

                lock(letters)
                {
                    letters[key] = letters.TryGetValue(key, out int value) ? value + 1 : 1;
                }
            }
            _stopWatch.Stop();
        }

        private char GetKeyForLetter(char letter)
        {
            var predefinedPairs = new Dictionary<char, char>
            {
                { 'я', 'а' },
                { 'є', 'е' },
                { 'ю', 'у' },
                { 'ї', 'і' },
                { 'ё', 'о' }
            };

            /*if (settings.Language == Languages.Russian)//
                predefinedPairs.Add('е', 'э');*/

            return predefinedPairs.TryGetValue(letter, out char value) ? value : letter;
        }

        private void UpdateRepetitions(Dictionary<string, int> repetitions, string word)
        {
            //var match = MyRegex1().Match(word);
            var match = Regex.Match(word, @"([а-яА-Я])\1+");

            if (match.Success)
            {
                if (!repetitions.TryGetValue(match.Value, out int value))
                {
                    repetitions.Add(match.Value, 1);
                }
                else
                {
                    repetitions[match.Value] = ++value;
                }
            }                     
        }

        private string[] UnprocessPhonetics(string[] syllabeles)
        {
            for (var i = 0; i < syllabeles.Length; i++)
            {
                syllabeles[i] = _phoneticProcessor.RemoveTechnicalCharacters(syllabeles[i]);
            }

            return syllabeles;
        }

        private string[] RemoveApos(string[] input)
        {
            var result = new string[input.Length];
            for (var i = 0; i < input.Length; i++)
            {
                result[i] = input[i].Replace("'", "");
            }

            return result;
        }

        private string RemoveAposWord(ref string input)
        {
            input = input.Replace("'", "");//return MyRegex().Replace(input, "");
            return input;
        }

        //[GeneratedRegex(@"\'")]
        //private static partial Regex MyRegex();
        //[GeneratedRegex(@"([а-яА-Я])\1+")]
        //private static partial Regex MyRegex1();
    }
}
