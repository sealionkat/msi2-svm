using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSVM.Classifier
{
    public class GaussianKernel : Kernel
    {
        public GaussianKernel()
        {
        }
        public GaussianKernel(double gamma)
        {
            Gamma = gamma;
        }
        public double Gamma { get; set; }

        public override Func<SparseVector<double>, SparseVector<double>, double> GetFunc()
        {
            return DoubleSparseVectorExtensions.GaussianDistance(Gamma);
        }
    }
}
