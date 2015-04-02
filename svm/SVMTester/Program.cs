using MiniSVM.Classifier;
using MiniSVM.Classifier.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSVM.Tester
{
    class Program
    {
        public static void Main()
        {
            var svm = new SVM();
            var reader = new SetReader();
            var dt = reader.ReadRaw(@"C:\Users\TrolleY\Desktop\data.csv");
            var X = reader.GetTrainingData(dt);
            var Y = reader.GetTrainingLabels(dt);
            var result = svm.CalculateHypothesis(X, Y);
            Console.WriteLine(result);
        }
    }
}
