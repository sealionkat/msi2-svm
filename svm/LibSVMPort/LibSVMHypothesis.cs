using LibSvm;
using MiniSVM.Classifier;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSVMPort
{
    public class LibSVMHypothesis : IHypothesis
    {
        public MiniSVM.Classifier.Kernel Kernel { get; set; }

        public SvmModel<SparseVector<double>> Model { get; set; }

        public LibSVMHypothesis()
        {
            Model = new SvmModel<SparseVector<double>>();
        }

        public LibSVMHypothesis(SvmModel<SparseVector<double>> model, Kernel kernel)
        {
            Model = model;
            Kernel = kernel;
        }

        public int Predict(SparseVector<double> features)
        {
            return (int)Model.Predict(features);
        }


        public void Save(string filename)
        {
            LibSVMModel.SaveModel(filename, Model, Kernel);
        }

        public void Load(string filename)
        {
            Model = LibSVMModel.LoadModel(filename);
        }
    }
}
