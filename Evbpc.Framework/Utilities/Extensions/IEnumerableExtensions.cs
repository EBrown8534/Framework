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
        /// Neither of the <code>IEnumerable{T}</code>s need be ordered in any particular manner.
        /// </remarks>
        public static IEnumerable<T> ExceptExact<T>(this IEnumerable<T> source, IEnumerable<T> exceptions)
        {
            var tExceptions = new List<T>();
            tExceptions.AddRange(exceptions);

            var result = new List<T>();

            foreach (var el in source)
            {
                if (tExceptions.Contains(el))
                {
                    tExceptions.RemoveAt(tExceptions.IndexOf(el));
                }
                else
                {
                    result.Add(el);
                }
            }

            return result;
        }
    }
}
