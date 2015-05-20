using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSVM.Classifier
{
    public class LinearKernel : Kernel
    {
        public override Func<SparseVector<double>, SparseVector<double>, double> GetFunc()
        {
            return DoubleSparseVectorExtensions.Multiply;
        }
    }
}
