using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSVM.Classifier
{
    public interface IClassifier<TData>
    {
        bool Compute(TData[] trainingData, double[] trainingLabels);

        IHypothesis<TData> GetHypothesis();
    }
}
