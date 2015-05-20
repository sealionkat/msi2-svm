using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSVM.Classifier
{
    public abstract class Kernel
    {
        public abstract Func<SparseVector<double>, SparseVector<double>, double> GetFunc();
    }
}
