using LibSvm;
using MiniSVM.Classifier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSVMPort
{
    internal class LibSVMHypothesis : IHypothesis
    {
        internal SvmModel<double[]> Model { get; set; }

        internal LibSVMHypothesis(SvmModel<double[]> model)
        {
            Model = model;
        }

        public int Predict(double[] features)
        {
            return (int)Model.Predict(features);
        }
    }
}
