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
            SVMParameters = new SVMParams()
            {
                Cost = 1
            };
        }
        private SvmModel<SparseVector<double>> SVMModel { get; set; }

        private SvmParameter<SparseVector<double>> InternalParameter { get; set; }

        public SVMParams SVMParameters { get; set; }

        public bool Compute(SparseVector<double>[] trainingData, double[] trainingLabels)
        {
            InternalParameter = new SvmParameter<SparseVector<double>>()
            {
                KernelFunc = SVMParameters.Kernel.GetFunc(),
                SvmType = SvmType.C_SVC,
                CacheSize = 128,
                C = 1,
                Eps = 1e-3,
                Shrinking = true,
                Probability = false
            };
            var problem = new SvmProblem<SparseVector<double>>()
            {
                X = trainingData,
                Y = trainingLabels
            };
            InternalParameter.Check(problem);
            SVMModel = Svm.Train(problem, InternalParameter);
            return SVMModel != null;
        }

        public IHypothesis GetHypothesis()
        {
            return new LibSVMHypothesis(SVMModel, SVMParameters.Kernel);
        }
    }
}
