using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ExtendIt
{
    public static class CollectionExtensions
    {
        public static T MaxBy<T, R>(this IEnumerable<T> en, Func<T, R> evaluate) where R : IComparable<R>
        {
            return en.Select(t => new Tuple<T, R>(t, evaluate(t)))
                .Aggregate((max, next) => next.Item2.CompareTo(max.Item2) > 0 ? next : max).Item1;
        }

        public static T MinBy<T, R>(this IEnumerable<T> en, Func<T, R> evaluate) where R : IComparable<R>
        {
            return en.Select(t => new Tuple<T, R>(t, evaluate(t)))
                .Aggregate((max, next) => next.Item2.CompareTo(max.Item2) < 0 ? next : max).Item1;
        }

        public static List<T> DequeueMany<T>(this Queue<T> queue, int chunkSize)
        {
            var values = new List<T>();

            for (int i = 0; i < chunkSize && queue.Count > 0; i++)
            {
                values.Add(queue.Dequeue());
            }

            return values;
        }
        public static string Get(this Dictionary<string, object> d, string key)
        {
            return d.ContainsKey(key) ? d[key]?.ToString() : string.Empty;
        }
        public static List<KeyValuePair<int, int>> ToKeyValuePair(this int[,] array)
        {
            var result = new List<KeyValuePair<int, int>>();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                result.Add(new KeyValuePair<int, int>(array[i, 0], array[i, 1]));
            }

            return result;
        }
        public static List<int> Enumerator(this int i)
        {
            return Enumerable.Range(0, Math.Abs(i)).ToList().Select(j => i < 0 ? j * -1 : j).ToList();
        }
        public static bool IsDistinct(this List<string> s)
        {
            return s?.Distinct().Count() == s?.Count();
        }
        public static IDictionary<TKey, TValue> AsReadOnly<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            return new ReadOnlyDictionary<TKey, TValue>(dictionary);
        }
    }
}
