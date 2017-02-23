using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Utilities.Extensions
{
    /// <summary>
    /// Provides general extensions on <code>IEnumerable{T}</code> types.
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Determins if both <see cref="IEnumerable{T}"/> instances have the same items in the same order.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first">The first <see cref="IEnumerable{T}"/> to test.</param>
        /// <param name="second">The second <see cref="IEnumerable{T}"/>to test.</param>
        /// <returns>True if both <see cref="IEnumerable{T}"/> instances have the same items in the same order.</returns>
        public static bool EquivalentTo<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            var firstList = first.ToList();
            var secondList = second.ToList();

            if (firstList.Count != secondList.Count)
            {
                return false;
            }

            for (int i = 0; i < firstList.Count; i++)
            {
                if (!firstList[i].Equals(secondList[i]))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Removes all elements from the source <code>IEnumerable{T}</code> that are present in the exceptions <code>IEnumerable{T}</code>.
        /// </summary>
        /// <typeparam name="T">The type of the source and exception parameters.</typeparam>
        /// <param name="source">The <code>IEnumerable{T}</code> containing the elements to be excepted.</param>
        /// <param name="exceptions">The <code>IEnumerable</code> containing the elements to except out.</param>
        /// <returns>An <code>IEnumerable{T}</code> that is the source <code>IEnumerable{T}</code> remove the exceptions <code>IEnumerable{T}</code>.</returns>
        /// <remarks>
        /// If an element appears multiple times in the exceptions <code>IEnumerable{T}</code>, that many copies of it will be removed from the source <code>IEnumerable{T}</code>.
        /// 
        /// Example:
        /// 
        /// Source: { 2, 2, 2, 6 }
        /// Exceptions: { 2, 2, 3, 4, 5 }
        /// Result: { 2, 6 }
        /// 
        /// Neither of the <code>IEnumerable{T}</code>s need be ordered in any particular manner. The order of the resultant <code>IEnumerable{T}</code> will be identical to the order of the <code>source</code> parameter, excepting exactly the <code>exceptions</code> parameter.
        /// </remarks>
        public static IEnumerable<T> ExceptExact<T>(this IEnumerable<T> source, IEnumerable<T> exceptions)
        {
            var tExceptions = exceptions.ToList();

            foreach (var el in source)
            {
                var index = tExceptions.IndexOf(el);

                if (index >= 0)
                {
                    tExceptions.RemoveAt(index);
                    continue;
                }

                yield return el;
            }
        }

        /// <summary>
        /// Returns the key that first matches a predicate in the <code>IEnumerable{KeyValuePair{TKey, Predicate{TValue}}}</code>.
        /// </summary>
        /// <typeparam name="TValue">The type of the input.</typeparam>
        /// <typeparam name="TKey">The type of the result.</typeparam>
        /// <param name="source">The <code>IEnumerable{KeyValuePair{TKey, Predicate{TValue}}}</code> to search.</param>
        /// <param name="input">The value to be passed to each <code>Predicate{TValue}</code>.</param>
        /// <returns>The first Key from the <code>source</code> with a Value that returns true for the <code>input</code>.</returns>
        public static TKey FindKey<TValue, TKey>(this IEnumerable<KeyValuePair<TKey, Predicate<TValue>>> source, TValue input) => source.FirstOrDefault(item => item.Value(input)).Key;

        /// <summary>
        /// Returns an `IEnumerable<int>` which consists of all the numbers missing from the input. Complexity is O(n) where n is the difference between the last element value and the first.
        /// </summary>
        /// <param name="input">Must be an ordered `IEnumerable<int>` with no duplicates.</param>
        /// <returns>A lazy `IEnumerable<int>` consisting of all numbers missing from the input. This method uses `yield return`, which means it can be used lazily to see if any numbers are missing from the input without necessarily calculating all missing numbers.</returns>
        public static IEnumerable<int> GetMissingNumbers(this IEnumerable<int> input)
        {
            const uint minValuePos = (uint)int.MaxValue + 1;
            int lastNumber = input.First();
            bool firstLoop = true;

            foreach (var number in input)
            {
                if (!firstLoop && number <= lastNumber)
                {
                    throw new ArgumentException($"The {nameof(input)} contained an invalid set of elements. Elements must be ordered with no duplicate values.");
                }

                while ((number + minValuePos) - (lastNumber + minValuePos) > 1)
                {
                    lastNumber++;
                    yield return lastNumber;
                }

                lastNumber = number;
                firstLoop = false;
            }
        }
    }
}
