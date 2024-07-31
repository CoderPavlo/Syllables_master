using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklady.ENStatistics
{
    public class FolderStatistics
    {
        public double LengthSum_Avg { get; set; }
        public double SyllCountSum_Avg { get; set; }
        public double SyllLengthSum_Avg { get; set; }
        public double LengthAvg_Avg { get; set; }
        public double SyllCountAvg_Avg { get; set; }
        public double SyllLengthAvg_Avg { get; set; }
        public double LengthStd_Avg { get; set; }
        public double SyllCountStd_Avg { get; set; }
        public double SyllLengthStd_Avg { get; set; }

        public double LengthSum_WStd { get; set; }
        public double SyllCountSum_WStd { get; set; }
        public double SyllLengthSum_WStd { get; set; }
        public double LengthAvg_WStd { get; set; }
        public double SyllCountAvg_WStd { get; set; }
        public double SyllLengthAvg_WStd { get; set; }
        public double LengthStd_WStd { get; set; }
        public double SyllCountStd_WStd { get; set; }
        public double SyllLengthStd_WStd { get; set; }

        public FolderStatistics(ConcurrentBag<FileStatistics> fileStatistics)
        {
            double lengthSum = 0, syllCountSum = 0, syllLengthSum = 0, lengthAvg = 0, syllCountAvg = 0, syllLengthAvg = 0, lengthStd = 0, syllCountStd = 0, syllLengthStd = 0;
            foreach (var stats in fileStatistics)
            {
                lengthSum += stats.LengthSum;
                syllCountSum += stats.SyllCountSum;
                syllLengthSum += stats.SyllLengthSum;
                lengthAvg += stats.LengthAvg;
                syllCountAvg += stats.SyllCountAvg;
                syllLengthAvg += stats.SyllLengthAvg;
                lengthStd += stats.LengthStd;
                syllCountStd += stats.SyllCountStd;
                syllLengthStd += stats.SyllLengthStd;
            }

            LengthSum_Avg = lengthSum / fileStatistics.Count;
            SyllCountSum_Avg = syllCountSum / fileStatistics.Count;
            SyllLengthSum_Avg = syllLengthSum / fileStatistics.Count;
            LengthAvg_Avg = lengthAvg / fileStatistics.Count;
            SyllCountAvg_Avg = syllCountAvg / fileStatistics.Count;
            SyllLengthAvg_Avg = syllLengthAvg / fileStatistics.Count;
            LengthStd_Avg = lengthStd / fileStatistics.Count;
            SyllCountStd_Avg = syllCountStd / fileStatistics.Count;
            SyllLengthStd_Avg = syllLengthStd / fileStatistics.Count;

            double lengthSum_m = 0, syllCountSum_m = 0, syllLengthSum_m = 0, lengthAvg_m = 0, syllCountAvg_m = 0, syllLengthAvg_m = 0, lengthStd_m = 0, syllCountStd_m = 0, syllLengthStd_m = 0;
            foreach (var stats in fileStatistics)
            {
                double p = stats.LengthSum / lengthSum;

                lengthSum_m += stats.LengthSum * p;
                syllCountSum_m += stats.SyllCountSum * p;
                syllLengthSum_m += stats.SyllLengthSum * p;
                lengthAvg_m += stats.LengthAvg * p;
                syllCountAvg_m += stats.SyllCountAvg * p;
                syllLengthAvg_m += stats.SyllLengthAvg * p;
                lengthStd_m += stats.LengthStd * p;
                syllCountStd_m += stats.SyllCountStd * p;
                syllLengthStd_m += stats.SyllLengthStd * p;
            }
            double lengthSum_std = 0, syllCountSum_std = 0, syllLengthSum_std = 0, lengthAvg_std = 0, syllCountAvg_std = 0, syllLengthAvg_std = 0, lengthStd_std = 0, syllCountStd_std = 0, syllLengthStd_std = 0;
            foreach (var stats in fileStatistics)
            {
                double p = stats.LengthSum / lengthSum;

                lengthSum_std += Math.Pow(stats.LengthSum - lengthSum_m, 2) * p;
                syllCountSum_std += Math.Pow(stats.SyllCountSum - syllCountSum_m, 2) * p;
                syllLengthSum_std += Math.Pow(stats.SyllLengthSum - syllLengthSum_m, 2) * p;
                lengthAvg_std += Math.Pow(stats.LengthAvg - lengthAvg_m, 2) * p;
                syllCountAvg_std += Math.Pow(stats.SyllCountAvg - syllCountAvg_m, 2) * p;
                syllLengthAvg_std += Math.Pow(stats.SyllLengthAvg - syllLengthAvg_m, 2) * p;
                lengthStd_std += Math.Pow(stats.LengthStd - lengthStd_m, 2) * p;
                syllCountStd_std += Math.Pow(stats.SyllCountStd - syllCountStd_m, 2) * p;
                syllLengthStd_std += Math.Pow(stats.SyllLengthStd - syllLengthStd_m, 2) * p;
            }

            LengthSum_WStd = Math.Sqrt(lengthSum_std);
            SyllCountSum_WStd = Math.Sqrt(syllCountSum_std);
            SyllLengthSum_WStd = Math.Sqrt(syllLengthSum_std);
            LengthAvg_WStd = Math.Sqrt(lengthAvg_std);
            SyllCountAvg_WStd = Math.Sqrt(syllCountAvg_std);
            SyllLengthAvg_WStd = Math.Sqrt(syllLengthAvg_std);
            LengthStd_WStd = Math.Sqrt(lengthStd_std);
            SyllCountStd_WStd = Math.Sqrt(syllCountStd_std);
            SyllLengthStd_WStd = Math.Sqrt(syllLengthStd_std);

        }
    }
}
