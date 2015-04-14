using Accord.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSVM.Classifier
{
    public class LinearKernel : IKernel
    {
        public double Compute(double[] x1, double[] x2)
        {
            return Matrix.InnerProduct(x1, x2);
        }
    }
}
