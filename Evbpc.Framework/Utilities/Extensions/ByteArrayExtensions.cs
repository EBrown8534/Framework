using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Utilities.Extensions
{
    /// <summary>
    /// Provides certian extensions for byte-array types.
    /// </summary>
    public static class ByteArrayExtensions
    {
        /// <summary>
        /// Appends a <code>byte[]</code> to another <code>byte[]</code>.
        /// </summary>
        /// <param name="source">The <code>byte[]</code> to be appended to.</param>
        /// <param name="value">The <code>byte[]</code> to be appended.</param>
        /// <returns>A new <code>byte[]</code> which is a combination of the two arrays.</returns>
        public static byte[] Append(this byte[] source, byte[] value)
        {
            byte[] result = new byte[source.Length + value.Length];

            for (int i = 0; i < source.Length; i++)
            {
                result[i] = source[i];
            }

            for (int i = 0; i < value.Length; i++)
            {
                result[i + source.Length] = value[i];
            }

            return result;
        }
    }
}
