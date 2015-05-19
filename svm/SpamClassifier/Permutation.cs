using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSVM.SpamClassifier
{
    public static class Permutation
    {
        public static IEnumerable<int> Sequence(int maxVal)
        {
            return Sequence(0, maxVal);
        }

        public static IEnumerable<int> Sequence(int minVal, int maxVal)
        {
            int[] permutation = Enumerable.Range(minVal, maxVal).ToArray();
            var random = new Random();
            for (int i = 0; i < permutation.Length; i++)
            {
                var nextIndex = random.Next(permutation.Length - i);
                var tmpVal = permutation[nextIndex];
                permutation[nextIndex] = permutation[permutation.Length - i - 1];
                yield return tmpVal;
            }
        }
    }
}
