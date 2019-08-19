using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ExtendFurther
{
    /// <summary>
    /// 
    /// </summary>
    public static class CollectionExtensions
    {

        /// <summary>
        /// Returns the element in the collection with the Max() of the property specified
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="R"></typeparam>
        /// <param name="en">The enumerable collection</param>
        /// <param name="evaluate">The function with which to evaluate i.e. the property to find the Max() of</param>
        /// <returns></returns>
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

        /// <summary>
        /// Determines if a list of <typeparam name="T"></typeparam> is a distinct list. An empty list is considered distinct.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsDistinct<T>(this IEnumerable<T> s)
        {
            return s?.Distinct()?.Count() == s?.Count();
        }

        public static IDictionary<TKey, TValue> AsReadOnly<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            return new ReadOnlyDictionary<TKey, TValue>(dictionary);
        }

        /// <summary>
        /// Splits a collection into N parts
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The collection to split</param>
        /// <param name="parts">How many sub-collections to split by</param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> list, int parts)
        {
            return list.Select((item, index) => new { index, item })
                       .GroupBy(x => x.index % parts)
                       .Select(x => x.Select(y => y.item));
        }

        /// <summary>
        /// Returns a random <typeparam name="T"></typeparam> from the collection of <typeparam name="T"></typeparam> provided
        /// </summary>
        /// <param name="values">The list of <typeparam name="T"></typeparam> from which to pick a random entry</param>
        /// <returns>A <typeparam name="T"></typeparam> randomly from the collection</returns>
        public static T Rand<T>(this IEnumerable<T> values) 
        {
            return values.ElementAt(0.RandBetween(values.Count() - 1));
        }

        /// <summary>
        /// Joins a collection of strings by the specified separator
        /// </summary>
        /// <param name="list">The collection of strings to join</param>
        /// <param name="separator">The string to join with</param>
        /// <returns>The collection as a single string joined by the separator</returns>
        public static string JoinBy(this IEnumerable<string> list, string separator)
        {
            return list != null && list.Count() > 0 ? string.Join(separator, list) : string.Empty;
        }

        /// <summary>
        /// Takes a collection of tokenized strings and safely splits each string returning the string from the specified index
        /// </summary>
        /// <param name="list"></param>
        /// <param name="splitBy"></param>
        /// /// <param name="index"></param>
        /// <returns></returns>
        public static IEnumerable<string> SafeSplit(this IEnumerable<string> list, string splitBy, int index)
        {
            if (list != null && !string.IsNullOrEmpty(splitBy) && list.Count() > 0 && index >= 0)
            {
                return list.Select(s =>
                    {
                        var x = s.Split(splitBy.ToCharArray()[0]);
                        return x.Count() > index ? x[index] : s;
                    });
            }
            else
            {
                return list;
            }
        }

    }
}
