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
    public class LibSVM<TData> : IClassifier<TData>
    {
        public LibSVM()
        {
            Svm.SetPrintStringFunction((s) => { });
            SVMParameters = new SVMParams<TData>()
            {
                Cost = 1,
                Gamma = 1,
                Kernel = (f, s) => 0
            };
        }
        private SvmModel<TData> SVMModel { get; set; }

        private SvmParameter<TData> InternalParameter { get; set; }

        public SVMParams<TData> SVMParameters { get; set; }
        
        public bool Compute(TData[] trainingData, double[] trainingLabels)
        {
            InternalParameter = new SvmParameter<TData>()
            {
                KernelFunc = SVMParameters.Kernel,
                SvmType = SvmType.C_SVC,
                CacheSize = 128,
                C = 1,
                Eps = 1e-3,
                Shrinking = true,
                Probability = false
            };
            var problem = new SvmProblem<TData>()
            {
                X = trainingData,
                Y = trainingLabels
            };
            InternalParameter.Check(problem);
            SVMModel = Svm.Train(problem, InternalParameter);
            return SVMModel != null;
        }

        public IHypothesis<TData> GetHypothesis()
        {
            return new LibSVMHypothesis<TData>(SVMModel);
        }
    }
}
