using Accord.Math;
using Accord.Math.Optimization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSVM.SVM
{
    public class SVM
    {
        private double[,] GetHessian(double[,] data)
        {
            if (data.GetLength(0) == 0 || data.GetLength(1) == 0)
                return null;
            var X = data.Submatrix(null, 0, data.GetLength(1)-2);
            var Y = data.GetColumn(data.GetLength(1)-1);
            var n = data.GetLength(0);
            var H = new double[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    H[i, j] = Y[i] * Y[j] * Matrix.InnerProduct(X.GetRow(i), X.GetRow(j));
            return H;
        }

        public static void Main()
        {
            var me = new SVM();
            var dt = new SetReader().Read(@"C:\Users\TrolleY\Desktop\data.csv");
            var H = me.GetHessian(dt);
            for (int i = 0; i < H.GetLength(0); i++)
            {
                for (int j = 0; j < H.GetLength(1); j++)
                {
                    Console.Write("{0: 00;-00; 00} ", H[i, j]);
                }
                Console.WriteLine();
            }
            double x = 0, y = 0;
            //var f = new QuadraticObjectiveFunction(new double[,] { { 1, 0 }, { 0, 1 } }, new double[2], "x", "y");
            var f = new QuadraticObjectiveFunction(() => 0.5 * (x * x) + 0.5 * (y * y));

            var constraints = new List<LinearConstraint>();
            /*constraints.Add(new LinearConstraint(f, () => 2 * x + 2 * y + b - 1 >= 0));
            constraints.Add(new LinearConstraint(f, () => x + 3 * y + b - 1 >= 0));
            constraints.Add(new LinearConstraint(f, () => 2 * x + 4 * y + b - 1 >= 0));
            constraints.Add(new LinearConstraint(f, () => -4 * x - 2 * y + b - 1 >= 0));
            constraints.Add(new LinearConstraint(f, () => -4 * x - 4 * y + b - 1 >= 0));
            constraints.Add(new LinearConstraint(f, () => -6 * x - 2 * y + b - 1 >= 0));*/

            var solver = new GoldfarbIdnani(f, constraints);
            var result = solver.Minimize();
            var solution = solver.Solution;
        }
    }
}
