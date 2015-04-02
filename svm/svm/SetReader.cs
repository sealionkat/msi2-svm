using CsvHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSVM.SVM
{
    class SetReader
    {
        public double[,] Read(string filename, string delimiter = ",")
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
    }
}
