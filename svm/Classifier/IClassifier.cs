using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSVM.Classifier
{
    public interface IClassifier
    {
        bool Compute(double[,] trainingData, double[] trainingLabels);

        IHypothesis GetHypothesis();
    }
}
