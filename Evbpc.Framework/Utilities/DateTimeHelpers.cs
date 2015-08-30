using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Utilities
{
    /// <summary>
    /// A collection of methods which may be used with the <code>DateTime</code> structure.
    /// </summary>
    public class DateTimeHelpers
    {
        /// <summary>
        /// Converts an <code>IList&lt;DateTime&gt;</code> to the <code>IList&lt;long&gt;</code> equivalent.
        /// </summary>
        /// <param name="dateList">An <code>IList&lt;DateTime&gt;</code> to be converted.</param>
        /// <returns>An <code>IList&lt;long&gt;</code> representing the input list.</returns>
        public static IList<long> ToBinaryList(IList<DateTime> dateList)
        {
            return dateList.Select(x => x.ToBinary()).ToList();
        }

        /// <summary>
        /// Converts an <code>IList&lt;long&gt;</code> to the <code>IList&lt;DateTime&gt;</code> equivalent.
        /// </summary>
        /// <param name="binaryList">An <code>IList&lt;long&gt;</code> to be converted.</param>
        /// <returns>An <code>IList&lt;DateTime&gt;</code> representing the input list.</returns>
        public static IList<DateTime> FromBinaryList(IList<long> binaryList)
        {
            return binaryList.Select(x => DateTime.FromBinary(x)).ToList();
        }
    }
}
