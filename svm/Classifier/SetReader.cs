using CsvHelper;
using Accord.Math;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSVM.Classifier.IO
{
    public class SetReader
    {
        public double[,] ReadRaw(string filename, string delimiter = ",")
        {
            var rows = new List<double[]>();
            var conv = new Converter<string, double>(Double.Parse);
            int maxcol = 0;
            using (var textReader = File.OpenText(filename))
            {
                using (var reader = new CsvReader(textReader))
                {
                    reader.Configuration.Delimiter = delimiter;
                    while(reader.Read())
                    {
                        var record = Array.ConvertAll(reader.CurrentRecord, conv);
                        maxcol = Math.Max(maxcol, record.Length);
                        rows.Add(record);
                    }
                }
            }
            var result = new double[rows.Count, maxcol];
            for (int i = 0; i < rows.Count; i++)
            {
                for (int j = 0; j < rows[i].Length; j++)
                {
                    result[i, j] = rows[i][j];
                }
            }
            return result;
        }

        public double[,] GetTrainingData(double[,] rawData)
        {
            return rawData.Submatrix(null, 0, rawData.GetLength(1) - 2);
        }
        public double[] GetTrainingLabels(double[,] rawData)
        {
            return rawData.GetColumn(rawData.GetLength(1) - 1);
        }
    }
}
