using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSVM.Classifier
{
    public interface IHypothesis
    {
        int Predict(SparseVector<double> features);

        void Save(string filename);

        void Load(string filename);
    }
}
