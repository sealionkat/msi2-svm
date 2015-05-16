using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSVM.Classifier
{
    public class SVMParams<TData>
    {
        public Func<TData, TData, double> Kernel { get; set; }

        public double Gamma { get; set; }

        public double Cost { get; set; }
    }
}
