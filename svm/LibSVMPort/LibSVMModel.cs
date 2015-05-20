using LibSvm;
using MiniSVM.Classifier;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LibSVMPort
{
    public class LibSVMModel
    {
        [XmlElement]
        public int NrClass { get; set; }

        [XmlElement]
        public int TotalSupportVectorsNumber { get; set; }

        [XmlElement]
        public SparseVector<double>[] SupportVectors { get; set; }

        public DoubleArray[] SupportVectorsCoefficients { get; set; }

        [XmlElement]
        public double[] Rho { get; set; }

        [XmlElement]
        public double[] ProbA { get; set; }

        [XmlElement]
        public double[] ProbB { get; set; }

        [XmlElement]
        public int[] Label { get; set; }

        [XmlElement]
        public int[] SupportVectorsIndices { get; set; }

        [XmlElement]
        public int[] SupportVectorsNumbers { get; set; }

        [XmlElement(Type = typeof(AbstractXmlSerializer<MiniSVM.Classifier.Kernel>))]
        public MiniSVM.Classifier.Kernel Kernel { get; set; }

        [XmlElement]
        public LibSVMModelParameter<SparseVector<double>> Param { get; set; }

        public static SvmModel<SparseVector<double>> LoadModel(string filename)
        {
            var lModel = File.ReadAllText(filename).FromXmlString<LibSVMModel>();
            SvmModel<SparseVector<double>> model = lModel.CreateModel();
            return model;
        }

        public static void SaveModel(string filename, SvmModel<SparseVector<double>> model, MiniSVM.Classifier.Kernel kernel)
        {
            var lModel = new LibSVMModel();
            lModel.ReadModel(model);
            lModel.Kernel = kernel;
            File.WriteAllText(filename, lModel.ToXmlString());
        }

        private void ReadModel(SvmModel<SparseVector<double>> model)
        {
            NrClass = model.NrClass;
            TotalSupportVectorsNumber = model.TotalSupportVectorsNumber;
            SupportVectors = model.SupportVectors;
            Rho = model.Rho;
            SupportVectorsCoefficients = DoubleArray.ConvertTwoDimArray(model.SupportVectorsCoefficients);
            ProbA = model.ProbA;
            ProbB = model.ProbB;
            Label = model.Label;
            SupportVectorsIndices = model.SupportVectorsIndices;
            SupportVectorsNumbers = model.SupportVectorsNumbers;
            Param = model.Param;
        }

        private SvmModel<SparseVector<double>> CreateModel()
        {
            var result = new SvmModel<SparseVector<double>>();
            SetProperty<int>(result, "NrClass", this.NrClass);
            SetProperty<int>(result, "TotalSupportVectorsNumber", this.TotalSupportVectorsNumber);
            SetProperty<SparseVector<double>[]>(result, "SupportVectors", this.SupportVectors);
            SetProperty<double[]>(result, "Rho", this.Rho);
            SetProperty<double[][]>(result, "SupportVectorsCoefficients",
                DoubleArray.ConvertTwoDimArray(this.SupportVectorsCoefficients));
            SetProperty<double[]>(result, "ProbA", this.ProbA);
            SetProperty<double[]>(result, "ProbB", this.ProbB);
            SetProperty<int[]>(result, "Label", this.Label);
            SetProperty<int[]>(result, "SupportVectorsIndices", this.SupportVectorsIndices);
            SetProperty<int[]>(result, "SupportVectorsNumbers", this.SupportVectorsNumbers);
            SetProperty<SvmParameter<SparseVector<double>>>(result, "Param", (SvmParameter<SparseVector<double>>)this.Param);
            result.Param.KernelFunc = this.Kernel.GetFunc();
            return result;
        }

        private void SetProperty<T>(SvmModel<SparseVector<double>> model, string propertyName, object value)
        {
            if (value!=null)
            {
                var type = model.GetType();
                var property = type.GetProperty(propertyName, typeof(T));
                var setmethod = property.GetSetMethod(true);
                setmethod.Invoke(model, new object[] { value });
            }
        }

        public class DoubleArray
        {
            public static implicit operator double[](DoubleArray array)
            {
                return array.Items;
            }
            public static implicit operator DoubleArray(double[] array)
            {
                return new DoubleArray() { Items = array };
            }

            public static double[][] ConvertTwoDimArray(DoubleArray[] array)
            {
                var result = new double[array.Length][];
                for (int i = 0; i < array.Length; i++)
                {
                    result[i] = array[i];
                }
                return result;
            }

            public static DoubleArray[] ConvertTwoDimArray(double[][] array)
            {
                var result = new DoubleArray[array.Length];
                for (int i = 0; i < array.Length; i++)
                {
                    result[i] = array[i];
                }
                return result;
            }

            [XmlElement]
            public double[] Items { get; set; }
        }

        public class LibSVMModelParameter<TValue>
        {
            public static implicit operator SvmParameter<TValue>(LibSVMModelParameter<TValue> other)
            {
                var result = new SvmParameter<TValue>();
                result.C = other.C;
                result.CacheSize = other.CacheSize;
                result.Eps = other.Eps;
                result.Nu = other.Nu;
                result.P = other.P;
                result.Probability = other.Probability;
                result.Shrinking = other.Shrinking;
                result.SvmType = other.SvmType;
                result.Weight = other.Weight;
                result.WeightLabel = other.WeightLabel;
                return result;
            }

            public static implicit operator LibSVMModelParameter<TValue>(SvmParameter<TValue> other)
            {
                var result = new LibSVMModelParameter<TValue>();
                result.C = other.C;
                result.CacheSize = other.CacheSize;
                result.Eps = other.Eps;
                result.Nu = other.Nu;
                result.P = other.P;
                result.Probability = other.Probability;
                result.Shrinking = other.Shrinking;
                result.SvmType = other.SvmType;
                result.Weight = other.Weight;
                result.WeightLabel = other.WeightLabel;
                return result;
            }

            [XmlElement]
            public SvmType SvmType { get; set; }
            [XmlElement]
            public double CacheSize { get; set; }
            [XmlElement]
            public double Eps { get; set; }
            [XmlElement]
            public double C { get; set; }
            [XmlElement]
            public int[] WeightLabel { get; set; }
            [XmlElement]
            public double[] Weight { get; set; }
            [XmlElement]
            public double Nu { get; set; }
            [XmlElement]
            public double P { get; set; }
            [XmlElement]
            public bool Shrinking { get; set; }
            [XmlElement]
            public bool Probability { get; set; }
        }
    }
}
