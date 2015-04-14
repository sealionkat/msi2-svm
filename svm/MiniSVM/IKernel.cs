using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSVM.Classifier
{
    public interface IKernel
    {
        double Compute(double[] x1, double[] x2);
    }
}
