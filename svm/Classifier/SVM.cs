using Accord.Math;
using Accord.Math.Optimization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSVM.Classifier
{
    public class SVM
    {
        public double[,] GetHessian(double[,] X, double[] Y)
        {
            var n = Y.Length;
            var H = new double[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    H[i, j] = Y[i] * Y[j] * Matrix.InnerProduct(X.GetRow(i), X.GetRow(j));
            return H;
        }

        public double[] CalculateHypothesis(double[,] trainingData, double[] trainingLabels)
        {
            var X = trainingData;
            var Y = trainingLabels;
            var H = GetHessian(X, Y).Multiply(-1);
            var linearTerms = Matrix.Vector<double>(Y.Length, 1);
            return InternalSolve(H, linearTerms, trainingLabels);
        }

        private List<LinearConstraint> GetConstraints(double[] trainingLabels)
        {
            // count of trainingLabels should be equal to count of linear terms
            var constraints = new List<LinearConstraint>();
            double[] sumConstraint = trainingLabels.Multiply(-1, false);
            for (int i = 0; i < trainingLabels.Length; i++)
            {
                constraints.Add(new LinearConstraint(numberOfVariables: 1)
                {
                    VariablesAtIndices = new int[] { i },
                    CombinedAs = new double[] { -1 },
                    ShouldBe = ConstraintType.GreaterThanOrEqualTo,
                    Value = 0
                });
            }
            constraints.Add(new LinearConstraint(numberOfVariables: trainingLabels.Length)
            {
                VariablesAtIndices = Enumerable.Range(0, trainingLabels.Length).ToArray(),
                CombinedAs = sumConstraint,
                ShouldBe = ConstraintType.EqualTo,
                Value = 0
            });
            return constraints;
        }

        private double[] InternalSolve(double[,] hessian, double[] linearTerms, double[] trainingLabels)
        {
            var function = new QuadraticObjectiveFunction(hessian, linearTerms);
            var constraints = new List<LinearConstraint>();// GetConstraints(trainingLabels);
            var solver = new GoldfarbIdnani(function, constraints);
            var result = solver.Minimize();
            return solver.Solution;
        }
    }
}
