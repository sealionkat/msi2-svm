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
        public double Multiply(DoubleSparseVector other)
        {
            double result = 0;
            var me = this.Items.GetEnumerator();
            var oe = other.Items.GetEnumerator();
            bool undone = me.MoveNext() && oe.MoveNext();
            while (undone)
            {
                while (undone && me.Current.Key > oe.Current.Key)
                {
                    undone = oe.MoveNext();
                }
                while (undone && me.Current.Key < oe.Current.Key)
                {
                    undone = me.MoveNext();
                }
                if (undone && me.Current.Key == oe.Current.Key)
                {
                    result += me.Current.Value * oe.Current.Value;
                    undone = me.MoveNext() && oe.MoveNext();
                }
            }
            return result;
        }

        public static double Multiply(DoubleSparseVector first, DoubleSparseVector second)
        {
            return first.Multiply(second);
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
}
