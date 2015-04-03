using Accord.Math;
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
        private double[] alphas;

        private double[] w;

        private double b;

        private double[,] h;

        private double[] linearTerms;

        private double[,] X;

        private double[] Y;

        private void GetHessian()
        {
            var n = Y.Length;
            h = new double[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    var xi = X.GetRow(i);
                    var xj = X.GetRow(j);
                    var cdot = Matrix.InnerProduct(xi, xj);
                    h[i, j] = Y[i] * Y[j] * cdot;
                }
        }

        private bool InternalCalculateHypothesis(double[,] trainingData, double[] trainingLabels)
        {
            X = trainingData;
            Y = trainingLabels;
            GetHessian();
            linearTerms = Matrix.Vector<double>(Y.Length, -1);
            var result = InternalSolve();
            if (!result)
                return false;
            GetW();
            GetB();
            return true;
        }

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

        private bool InternalSolve()
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

        private void GetW()
        {
            w = new double[alphas.Length];
            for (int i = 0; i < w.Length; i++)
            {
                w = w.Add(X.GetRow(i).Multiply(alphas[i] * Y[i]));
            }
        }

        private void GetB()
        {
            var S = alphas.Find(a => a > 0);
            var Ns = S.Length;
            b = 0;
            foreach (var s in S)
            {
                b += Y[s];
                foreach (var m in S)
                {
                    b -= alphas[m] * Y[m] * Matrix.InnerProduct(X.GetRow(m), X.GetRow(s));
                }
            }
        }

        private double[,] AddBias(double[,] matrix)
        {
            return Matrix.Concatenate(Matrix.ColumnVector<double>(Matrix.Vector<double>(matrix.GetLength(0), 1)), matrix);
        }

        public IHypothesis CalculateHypothesis(double[,] trainingData, double[] trainingLabels)
        {
            var result = InternalCalculateHypothesis(trainingData, trainingLabels);
            return result ? new SVMHypothesis(this) : null;
        }

        private class SVMHypothesis : IHypothesis
        {
            private double[] W;

            private double b;

            public SVMHypothesis(SVM parent)
            {
                W = parent.w;
                b = parent.b;
            }

            public int Test(double[] features)
            {
                return Math.Sign(Matrix.InnerProduct(W, features) + b);
            }
        }
    }
}
