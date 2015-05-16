using LibSvm;
using MiniSVM.Classifier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSVMPort
{
    internal class LibSVMHypothesis<TData> : IHypothesis<TData>
    {
        internal SvmModel<TData> Model { get; set; }

        internal LibSVMHypothesis(SvmModel<TData> model)
        {
            Model = model;
        }

        public int Predict(TData features)
        {
            return (int)Model.Predict(features);
        }
    }
}
