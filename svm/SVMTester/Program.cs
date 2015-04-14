﻿using MiniSVM.Classifier;
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
            var svm = new SVM(new LinearKernel(), 1);
            var reader = new SetReader();
            var dt = reader.ReadRaw(@"C:\Users\TrolleY\Desktop\data2.csv");
            var X = reader.GetTrainingData(dt);
            var Y = reader.GetTrainingLabels(dt);
            svm.Compute(X, Y);
            var hypothesis = svm.Hypothesis;
            Console.WriteLine(hypothesis.Predict(new double[] { 2, 0 }));
        }
    }
}
