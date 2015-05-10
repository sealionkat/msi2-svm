using MiniSVM.Classifier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Math;
using LibSvm;

namespace LibSVMPort
{
    public class LibSVM : IClassifier
    {
        public LibSVM()
        {
            Svm.SetPrintStringFunction((s) => { });
            SVMParameter = new SvmParameter<double[]>()
            {
                KernelFunc = Kernels.Linear(),
                SvmType = SvmType.C_SVC,
                CacheSize = 128,
                C = 1,
                Eps = 1e-3,
                Shrinking = true,
                Probability = false
            };
        }
        private SvmModel<double[]> SVMModel { get; set; }

        public SvmParameter<double[]> SVMParameter { get; set; }

        public bool Compute(double[,] trainingData, double[] trainingLabels)
        {
            return Compute(trainingData.ToArray(), trainingLabels);
        }

        public bool Compute(double[][] trainingData, double[] trainingLabels)
        {
            var problem = new SvmProblem<double[]>()
            {
                X = trainingData,
                Y = trainingLabels
            };
            SVMParameter.Check(problem);
            SVMModel = Svm.Train(problem, SVMParameter);
            return SVMModel != null;
        }

        public IHypothesis GetHypothesis()
        {
            return new LibSVMHypothesis(SVMModel);
        }
    }
}
