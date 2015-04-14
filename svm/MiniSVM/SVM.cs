﻿using Accord.Math;
using Accord.Math.Optimization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSVM.Classifier
{
    public class SVM : IClassifier
    {
        public SVM(IKernel kernel, double C)
        {
            this.Kernel = kernel;
            this.C = C;
        }

        private double[,] X;

        private double[] Y;

        private double[,] GetHessian()
        {
            var n = Y.Length;
            var h = new double[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    var xi = X.GetRow(i);
                    var xj = X.GetRow(j);
                    h[i, j] = Y[i] * Y[j] * Kernel.Compute(xi, xj);
                }
            return h;
        }

        private bool InternalCalculateHypothesis(double[,] trainingData, double[] trainingLabels, out double[] w, out double b)
        {
            w = null;
            b = Double.NaN;
            X = trainingData;
            Y = trainingLabels;
            var h = GetHessian();
            double[] alphas;
            var linearTerms = Matrix.Vector<double>(Y.Length, -1);
            var result = InternalSolve(h, linearTerms, out alphas);
            if (!result)
                return false;
            w = GetW(alphas);
            b = GetB(alphas);
            return true;
        }

        public IKernel Kernel { get; set; }

        public double C { get; set; }

        private List<LinearConstraint> GetConstraints()
        {
            // count of trainingLabels should be equal to count of linear terms
            var constraints = new List<LinearConstraint>();
            for (int i = 0; i < Y.Length; i++)
            {
                constraints.Add(new LinearConstraint(numberOfVariables: 1)
                {
                    VariablesAtIndices = new int[] { i },
                    ShouldBe = ConstraintType.GreaterThanOrEqualTo,
                    Value = 0
                });
                constraints.Add(new LinearConstraint(numberOfVariables: 1)
                {
                    VariablesAtIndices = new int[] { i },
                    ShouldBe = ConstraintType.LesserThanOrEqualTo,
                    Value = C
                });
            }
            double[] sumConstraint = Y;
            constraints.Add(new LinearConstraint(numberOfVariables: Y.Length)
            {
                VariablesAtIndices = Enumerable.Range(0, Y.Length).ToArray(),
                CombinedAs = sumConstraint,
                ShouldBe = ConstraintType.EqualTo,
                Value = 0
            });
            return constraints;
        }

        private bool InternalSolve(double[,] h, double[] linearTerms, out double[] alphas)
        {
            var function = new QuadraticObjectiveFunction(h, linearTerms);
            var constraints = GetConstraints();
            var solver = new GoldfarbIdnani(function, constraints);
            // minimize: 0.5*alphaT*H*alpha - sum(alpha_i)
            // so that InnerProduct(alpha, Y) == 0
            var result = solver.Minimize();
            alphas = solver.Solution;
            return result;
        }

        private double[] GetW(double[] alphas)
        {
            var w = new double[alphas.Length];
            for (int i = 0; i < w.Length; i++)
            {
                w = w.Add(X.GetRow(i).Multiply(alphas[i] * Y[i]));
            }
            return w;
        }

        private double GetB(double[] alphas)
        {
            var S = alphas.Find(a => a > 0);
            var Ns = S.Length;
            double b = 0;
            foreach (var s in S)
            {
                b += Y[s];
                foreach (var m in S)
                {
                    b -= alphas[m] * Y[m] * Matrix.InnerProduct(X.GetRow(m), X.GetRow(s));
                }
            }
            return b;
        }

        private double[,] AddBias(double[,] matrix)
        {
            return Matrix.Concatenate(Matrix.ColumnVector<double>(Matrix.Vector<double>(matrix.GetLength(0), 1)), matrix);
        }

        public IHypothesis CalculateHypothesis(double[,] trainingData, double[] trainingLabels)
        {
            double[] w;
            double b;
            var result = InternalCalculateHypothesis(trainingData, trainingLabels, out w, out b);
            return result ? new SVMHypothesis(w, b) : null;
        }

        private class SVMHypothesis : IHypothesis
        {
            private double[] W;

            private double b;
            
            // should I pass kernel here?
            public SVMHypothesis(double[] w, double b)
            {
                this.W = w;
                this.b = b;
            }

            public int Test(double[] features)
            {
                return Math.Sign(Matrix.InnerProduct(W, features) + b);
            }
        }
    }
}
