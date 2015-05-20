using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MiniSVM.Classifier
{
    public class SparseVector<TValue>
    {
        public SparseVector()
        {
            NullValue = default(TValue);
            Items = new SortedDictionary<int, TValue>();
        }

        public SparseVector(TValue nullValue)
        {
            NullValue = nullValue;
            Items = new SortedDictionary<int, TValue>();
        }

        [XmlIgnore]
        public TValue NullValue { get; protected set; }

        [XmlIgnore]
        public SortedDictionary<int, TValue> Items { get; set; }

        [XmlIgnore]
        public int Length { get; protected set; }

        [XmlElement]
        public SerializableSparseVector<TValue> Serializable 
        {
            get
            {
                return this.AsSerializable();
            }
            set
            {
                InitFromSerializable(value);
            }
        }

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

        public IEnumerable<KeyValuePair<int, TValue>> Elements()
        {
            foreach (var item in Items)
            {
                yield return item;
            }
        }

        public SerializableSparseVector<TValue> AsSerializable()
        {
            var result = new SerializableSparseVector<TValue>()
            {
                Items = this.Items.Select(s=>new SerializableSparseVector<TValue>.Item()
                    {
                        Key = s.Key,
                        Value = s.Value
                    }).ToArray(),
                NullValue = this.NullValue
            };
            return result;
        }

        private void InitFromSerializable(SerializableSparseVector<TValue> source)
        {
            var resultItems = new SortedDictionary<int, TValue>(
                   source.Items.Where(s => !EqualityComparer<TValue>.Default.Equals(s.Value, source.NullValue))
                   .ToDictionary(s => s.Key, s => s.Value));
            NullValue = source.NullValue;
            Items = resultItems;
            Length = (resultItems.Count > 0) ? resultItems.Max(s => s.Key) : 0;
        }

        public static SparseVector<TValue> FromSerializable(SerializableSparseVector<TValue> source)
        {
            var result = new SparseVector<TValue>();
            result.InitFromSerializable(source);
            return result;
        }

        public static void LookupElements(SparseVector<TValue> first,
            SparseVector<TValue> second,
            LookupElementsCallback<TValue> callback)
        {
            var me = first.Items.GetEnumerator();
            var oe = second.Items.GetEnumerator();
            bool meundone = me.MoveNext();
            bool oeundone = oe.MoveNext();
            while (oeundone && meundone)
            {
                while (oeundone && meundone && me.Current.Key > oe.Current.Key)
                {
                    callback(oe.Current.Key, first.NullValue, oe.Current.Value);
                    oeundone = oe.MoveNext();
                }
                while (oeundone && meundone && me.Current.Key < oe.Current.Key)
                {
                    callback(me.Current.Key, me.Current.Value, first.NullValue);
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
                callback(oe.Current.Key, first.NullValue, oe.Current.Value);
                oeundone = oe.MoveNext();
            }
            while (meundone)
            {
                callback(me.Current.Key, me.Current.Value, first.NullValue);
                meundone = me.MoveNext();
            }
        }

        public TValue[] ToArray()
        {
            var result = Enumerable.Repeat(NullValue, Length).ToArray();
            foreach (var item in this.Items)
            {
                result[item.Key] = item.Value;
            }
            return result;
        }
    }

    public static class DoubleSparseVectorExtensions
    {
        public static double Multiply(this SparseVector<double> first, SparseVector<double> second)
        {
            double result = 0;
            SparseVector<double>.LookupElements(first, second,
                (i, fv, sv) => { result += fv * sv; });
            return result;
        }

        public static double Distance2(SparseVector<double> first, SparseVector<double> second)
        {
            double result = 0;
            SparseVector<double>.LookupElements(first, second,
                (i, fv, sv) => { result += (fv - sv) * (fv - sv); });
            return result;
        }
        public static double Distance(SparseVector<double> first, SparseVector<double> second)
        {
            return Math.Sqrt(Distance2(first, second));
        }

        public static double GaussianDistance(SparseVector<double> first, SparseVector<double> second, double gamma)
        {
            return Math.Exp(-gamma*Distance2(first, second));
        }

        public static Func<SparseVector<double>, SparseVector<double>, double> GaussianDistance(double gamma)
        {
            return (f, s) => GaussianDistance(f, s, gamma);
        }
    }

    public delegate void LookupElementsCallback<TValue>(int col, TValue meVal, TValue otherVal);

    public class SerializableSparseVector<TValue>
    {
        public SerializableSparseVector()
        {
            Items = new Item[0];
            NullValue = default(TValue);
        }

        private Item[] items;

        [XmlElement]
        public Item[] Items
        {
            get { return items; }
            set 
            {
                items = value ?? new Item[0]; 
            }
        }


        [XmlElement]
        public TValue NullValue { get; set; }

        public class Item
        {
            [XmlElement]
            public int Key { get; set; }

            [XmlElement]
            public TValue Value { get; set; }
        }
    }
}
