using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Evbpc.Framework.Utilities.Extensions
{
    /// <summary>
    /// Provides methods to extend the built-in <c>BigInteger</c> class.
    /// </summary>
    public static class BigIntegerExtensions
    {
        /// <summary>
        /// Converts the current <see cref="BigInteger"/> object to a uint array.
        /// </summary>
        /// <param name="b">The current <see cref="BigInteger"/> object.</param>
        /// <returns>A <c>uint[]</c> representing the current <see cref="BigInteger"/> object.</returns>
        public static uint[] ToUIntArray(this BigInteger b)
        {
            var bytes = b.ToByteArray();

            if (bytes.Length % 4 != 0)
            {
                Array.Resize(ref bytes, bytes.Length + (4 - bytes.Length % 4));
            }

            var size = (int)Math.Ceiling(bytes.Length / 4.0);
            var result = new uint[size];

            for (int i = 0; i < size * 4; i += 4)
            {
                result[i / 4] = (uint)bytes[i + 0] | ((uint)bytes[i + 1] << 8) | ((uint)bytes[i + 2] << 16) | ((uint)bytes[i + 3] << 24);
            }

            return result;
        }
    }
}
