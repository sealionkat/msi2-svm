using LibSVMPort;
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
            /*var svm = new SVM(new LinearKernel(), 1);
            //var svm = new LibSVM();
            var reader = new SetReader();
            var dt = reader.ReadRaw(@"C:\Users\TrolleY\Desktop\Studia 1\MSI2\data3.csv");
            var X = reader.GetTrainingData(dt);
            var Y = reader.GetTrainingLabels(dt);
            svm.Compute(X, Y);
            var hypothesis = svm.GetHypothesis();
            Console.WriteLine(hypothesis.Predict(new double[] { 2, 0 }));*/
            /*SparseVector<double> first = new SparseVector<double>();
            first[1] = 1;
            var ser = first.AsSerializable();
            var str = ser.ToXmlString();
            Console.WriteLine(str);
            SparseVector<double> second = SparseVector<double>.FromSerializable(str.FromXmlString<SerializableSparseVector<double>>());
            Console.WriteLine(second);*/
        }
    }
}
