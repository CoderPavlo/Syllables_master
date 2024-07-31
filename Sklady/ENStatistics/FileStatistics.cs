using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklady.ENStatistics
{
    public class FileStatistics
    {
        public string Name { get; set; }
        public int LengthSum { get; set; }
        public int SyllCountSum { get; set; }
        public double SyllLengthSum { get; set; }
        public double LengthAvg { get; set; }
        public double SyllCountAvg { get; set; }
        public double SyllLengthAvg { get; set; }
        public double LengthStd { get; set; }
        public double SyllCountStd { get; set; }
        public double SyllLengthStd { get; set; }

        public FileStatistics(string name, List<int> lengths, List<int> syllablesCounts, List<double> syllablesLengths)
        {
            this.Name = name;
            this.LengthSum = lengths.Sum();
            this.SyllCountSum = syllablesCounts.Sum();
            this.SyllLengthSum = syllablesLengths.Sum();
            this.LengthAvg = lengths.Average();
            this.SyllCountAvg = syllablesCounts.Average();
            this.SyllLengthAvg = syllablesLengths.Average();
            this.LengthStd = Std(lengths);
            this.SyllCountStd = Std(syllablesCounts);
            this.SyllLengthStd = Std(syllablesLengths);
        }

        public double Std<T>(List<T> list) where T : struct
        {
            double mean = 0;
            double sumOfSquares = 0;

            foreach (var item in list)
            {
                double value = Convert.ToDouble(item);
                mean += value;
                sumOfSquares += value * value;
            }

            mean /= list.Count;
            return Math.Sqrt(sumOfSquares / list.Count - mean * mean);
        }
    }
}
