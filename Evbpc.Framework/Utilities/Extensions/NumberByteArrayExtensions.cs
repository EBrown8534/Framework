using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Utilities.Extensions
{
    /// <summary>
    /// Provides extension methods to convert certian base types to and from a byte-array.
    /// </summary>
    public static class NumberByteArrayExtensions
    {
        /// <summary>
        /// Converts a <code>uint</code> value to a <code>byte[]</code>.
        /// </summary>
        /// <param name="value">The <code>uint</code> value to convert.</param>
        /// <returns>A <code>byte[]</code> representing the <code>uint</code> value.</returns>
        public static byte[] ToByteArray(this uint value)
        {
            var size = 4;

            var result = new byte[size];

            for (var i = 0; i < size; i++)
            {
                var bitOffset = (size - (i + 1)) * 8;
                result[i] = (byte)((value & ((ulong)0xFF << bitOffset)) >> bitOffset);
            }

            return result;
        }

        /// <summary>
        /// Converts a <code>byte[]</code> to a <code>uint</code> value.
        /// </summary>
        /// <param name="data">The <code>byte[]</code> to convert.</param>
        /// <returns>A <code>uint</code> that represents the converted <code>byte[]</code>.</returns>
        public static uint ToUInt32(this byte[] data)
        {
            var requiredSize = 4;

            if (data.Length != requiredSize)
            {
                throw new ArgumentException($"The byte-array \"{nameof(data)}\" must be exactly {requiredSize} bytes.");
            }

            var result = 0u;

            for (var i = 0; i < requiredSize; i++)
            {
                result |= ((uint)data[i] << ((requiredSize - (i + 1)) * 8));
            }

            return result;
        }

        /// <summary>
        /// Converts an <code>int</code> value to a <code>byte[]</code>.
        /// </summary>
        /// <param name="value">The <code>int</code> to convert.</param>
        /// <returns>A <code>byte[]</code> representing the <code>int</code> value.</returns>
        public static byte[] ToByteArray(this int value)
        {
            var t = (uint)value;

            return t.ToByteArray();
        }

        /// <summary>
        /// Converts a <code>byte[]</code> to an <code>int</code> value.
        /// </summary>
        /// <param name="data">The <code>byte[]</code> to convert.</param>
        /// <returns>An <code>int</code> value representing the <code>byte[]</code>.</returns>
        public static int ToInt32(this byte[] data)
        {
            var requiredSize = 4;

            if (data.Length != requiredSize)
            {
                throw new ArgumentException($"The byte-array \"{nameof(data)}\" must be exactly {requiredSize} bytes.");
            }

            return (int)data.ToUInt32();
        }

        /// <summary>
        /// Converts a <code>ulong</code> to a <code>byte[]</code>.
        /// </summary>
        /// <param name="value">The <code>ulong</code> to convert.</param>
        /// <returns>A <code>byte[]</code> representing the <code>ulong</code>.</returns>
        public static byte[] ToByteArray(this ulong value)
        {
            var size = 8;

            var result = new byte[size];

            for (var i = 0; i < size; i++)
            {
                var bitOffset = (size - (i + 1)) * 8;
                result[i] = (byte)((value & ((ulong)0xFF << bitOffset)) >> bitOffset);
            }

            return result;
        }

        /// <summary>
        /// Converts a <code>byte[]</code> to a <code>ulong</code>.
        /// </summary>
        /// <param name="data">The <code>byte[]</code> to convert.</param>
        /// <returns>A <code>ulong</code> reprented by the <code>byte[]</code>.</returns>
        public static ulong ToUInt64(this byte[] data)
        {
            var requiredSize = 8;

            if (data.Length != requiredSize)
            {
                throw new ArgumentException($"The byte-array \"{nameof(data)}\" must be exactly {requiredSize} bytes.");
            }

            var result = 0ul;

            for (var i = 0; i < requiredSize; i++)
            {
                result |= ((ulong)data[i] << ((requiredSize - (i + 1)) * 8));
            }

            return result;
        }

        /// <summary>
        /// Converts a <code>long</code> value to a <code>byte[]</code>.
        /// </summary>
        /// <param name="value">The <code>long</code> value to convert.</param>
        /// <returns>A <code>byte[]</code> representing the <code>long</code> value.</returns>
        public static byte[] ToByteArray(this long value)
        {
            var t = (ulong)value;

            return t.ToByteArray();
        }

        /// <summary>
        /// Converts a <code>byte[]</code> to a <code>long</code> value.
        /// </summary>
        /// <param name="data">The <code>byte[]</code> to convert.</param>
        /// <returns>A <code>long</code> value represented by the <code>byte[]</code>.</returns>
        public static long ToInt64(this byte[] data)
        {
            var requiredSize = 8;

            if (data.Length != requiredSize)
            {
                throw new ArgumentException($"The byte-array \"{nameof(data)}\" must be exactly {requiredSize} bytes.");
            }

            return (long)data.ToUInt64();
        }
    }
}
