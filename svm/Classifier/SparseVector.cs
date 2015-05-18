using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSVM.Classifier
{
    public class SparseVector<TValue> : IEnumerable<KeyValuePair<int, TValue>>
    {
        public SparseVector(TValue nullValue = default(TValue))
        {
            NullValue = nullValue;
            Items = new SortedDictionary<int, TValue>();
        }

        public TValue NullValue { get; protected set; }

        protected SortedDictionary<int, TValue> Items { get; set; }

        public int Length { get; protected set; }

        public TValue this[int col]
        {
            get
            {
                return (Items.ContainsKey(col)) ? Items[col] : NullValue;
            }
            set
            {
                if (!value.Equals(NullValue))
                {
                    if (Items.ContainsKey(col))
                    {
                        Items[col] = value;
                    }
                    else Items.Add(col, value);
                    if (col>=Length)
                    {
                        Length = col+1;
                    }
                }
            }
        }

        public IEnumerator<KeyValuePair<int,TValue>> GetEnumerator()
        {
            foreach (var item in Items)
            {
                yield return item;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            foreach (var item in Items)
            {
                yield return item;
            }
        }
    }

    public class DoubleSparseVector : SparseVector<double>
    {
        public static void LookupElements(DoubleSparseVector first,
            DoubleSparseVector second,
            LookupElementsCallback callback)
        {
            var me = first.Items.GetEnumerator();
            var oe = second.Items.GetEnumerator();
            bool meundone = me.MoveNext();
            bool oeundone = oe.MoveNext();
            while (oeundone && meundone)
            {
                while (oeundone && meundone && me.Current.Key > oe.Current.Key)
                {
                    callback(oe.Current.Key, 0, oe.Current.Value);
                    oeundone = oe.MoveNext();
                }
                while (oeundone && meundone && me.Current.Key < oe.Current.Key)
                {
                    callback(me.Current.Key, me.Current.Value, 0);
                    meundone = me.MoveNext();
                }
                if (oeundone && meundone && me.Current.Key == oe.Current.Key)
                {
                    callback(me.Current.Key, me.Current.Value, oe.Current.Value);
                    meundone = me.MoveNext();
                    oeundone = oe.MoveNext();
                }
            }
            while (oeundone)
            {
                callback(oe.Current.Key, 0, oe.Current.Value);
                oeundone = oe.MoveNext();
            }
            while (meundone)
            {
                callback(me.Current.Key, me.Current.Value, 0);
                meundone = me.MoveNext();
            }
        }
        
        public static double Multiply(DoubleSparseVector first, DoubleSparseVector second)
        {
            double result = 0;
            LookupElements(first, second,
                (i, fv, sv) => { result += fv * sv; });
            return result;
        }

        public static double Distance2(DoubleSparseVector first, DoubleSparseVector second)
        {
            double result = 0;
            LookupElements(first, second,
                (i, fv, sv) => { result += (fv - sv) * (fv - sv); });
            return result;
        }
        public static double Distance(DoubleSparseVector first, DoubleSparseVector second)
        {
            return Math.Sqrt(Distance2(first, second));
        }

        public static double GaussianDistance(DoubleSparseVector first, DoubleSparseVector second, double gamma)
        {
            return Math.Exp(-gamma*Distance2(first, second));
        }

        public static Func<DoubleSparseVector, DoubleSparseVector, double> GaussianDistance(double gamma)
        {
            return (f, s) => GaussianDistance(f, s, gamma);
        }

        public double[] ToArray()
        {
            var result = new double[this.Length];
            foreach (var item in this.Items)
            {
                result[item.Key] = item.Value;
            }
            return result;
        }
    }

    public delegate void LookupElementsCallback(int col, double meVal, double otherVal);
}
