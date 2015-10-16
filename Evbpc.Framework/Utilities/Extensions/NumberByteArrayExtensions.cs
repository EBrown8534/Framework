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
            byte[] result = new byte[4];

            uint t = value;

            result[0] = (byte)((t & 0xFF000000u) >> 24);
            result[1] = (byte)((t & 0x00FF0000u) >> 16);
            result[2] = (byte)((t & 0x0000FF00u) >> 8);
            result[3] = (byte)((t & 0x000000FFu) >> 0);

            return result;
        }

        /// <summary>
        /// Converts a <code>byte[]</code> to a <code>uint</code> value.
        /// </summary>
        /// <param name="data">The <code>byte[]</code> to convert.</param>
        /// <returns>A <code>uint</code> that represents the converted <code>byte[]</code>.</returns>
        public static uint ToUInt32(this byte[] data)
        {
            if (data.Length != 4)
            {
                throw new ArgumentException($"The byte-array \"{nameof(data)}\" must be exactly four bytes.");
            }

            uint result = 0;

            result = ((uint)data[0] << 24) | ((uint)data[1] << 16) | ((uint)data[2] << 8) | ((uint)data[3] << 0);

            return result;
        }

        /// <summary>
        /// Converts an <code>int</code> value to a <code>byte[]</code>.
        /// </summary>
        /// <param name="value">The <code>int</code> to convert.</param>
        /// <returns>A <code>byte[]</code> representing the <code>int</code> value.</returns>
        public static byte[] ToByteArray(this int value)
        {
            byte[] result = new byte[4];

            uint t = (uint)value;

            result[0] = (byte)((t & 0xFF000000u) >> 24);
            result[1] = (byte)((t & 0x00FF0000u) >> 16);
            result[2] = (byte)((t & 0x0000FF00u) >> 8);
            result[3] = (byte)((t & 0x000000FFu) >> 0);

            return result;
        }

        /// <summary>
        /// Converts a <code>byte[]</code> to an <code>int</code> value.
        /// </summary>
        /// <param name="data">The <code>byte[]</code> to convert.</param>
        /// <returns>An <code>int</code> value representing the <code>byte[]</code>.</returns>
        public static int ToInt32(this byte[] data)
        {
            if (data.Length != 4)
            {
                throw new ArgumentException($"The byte-array \"{nameof(data)}\" must be exactly four bytes.");
            }

            int result = 0;

            result = ((int)data[0] << 24) | ((int)data[1] << 16) | ((int)data[2] << 8) | ((int)data[3] << 0);

            return result;
        }

        /// <summary>
        /// Converts a <code>ulong</code> to a <code>byte[]</code>.
        /// </summary>
        /// <param name="value">The <code>ulong</code> to convert.</param>
        /// <returns>A <code>byte[]</code> representing the <code>ulong</code>.</returns>
        public static byte[] ToByteArray(this ulong value)
        {
            byte[] result = new byte[8];

            ulong t = value;

            result[0] = (byte)((t & 0xFF00000000000000u) >> 56);
            result[1] = (byte)((t & 0x00FF000000000000u) >> 48);
            result[2] = (byte)((t & 0x0000FF0000000000u) >> 40);
            result[3] = (byte)((t & 0x000000FF00000000u) >> 32);
            result[4] = (byte)((t & 0x00000000FF000000u) >> 24);
            result[5] = (byte)((t & 0x0000000000FF0000u) >> 16);
            result[6] = (byte)((t & 0x000000000000FF00u) >> 8);
            result[7] = (byte)((t & 0x00000000000000FFu) >> 0);

            return result;
        }

        /// <summary>
        /// Converts a <code>byte[]</code> to a <code>ulong</code>.
        /// </summary>
        /// <param name="data">The <code>byte[]</code> to convert.</param>
        /// <returns>A <code>ulong</code> reprented by the <code>byte[]</code>.</returns>
        public static ulong ToUInt64(this byte[] data)
        {
            if (data.Length != 8)
            {
                throw new ArgumentException($"The byte-array \"{nameof(data)}\" must be exactly eight bytes.");
            }

            ulong result = 0;

            result = ((ulong)data[0] << 56) | ((ulong)data[1] << 48) | ((ulong)data[2] << 40) | ((ulong)data[3] << 32) | ((ulong)data[4] << 24) | ((ulong)data[5] << 16) | ((ulong)data[6] << 8) | ((ulong)data[7] << 0);

            return result;
        }

        /// <summary>
        /// Converts a <code>long</code> value to a <code>byte[]</code>.
        /// </summary>
        /// <param name="value">The <code>long</code> value to convert.</param>
        /// <returns>A <code>byte[]</code> representing the <code>long</code> value.</returns>
        public static byte[] ToByteArray(this long value)
        {
            byte[] result = new byte[8];

            ulong t = (ulong)value;

            result[0] = (byte)((t & 0xFF00000000000000u) >> 56);
            result[1] = (byte)((t & 0x00FF000000000000u) >> 48);
            result[2] = (byte)((t & 0x0000FF0000000000u) >> 40);
            result[3] = (byte)((t & 0x000000FF00000000u) >> 32);
            result[4] = (byte)((t & 0x00000000FF000000u) >> 24);
            result[5] = (byte)((t & 0x0000000000FF0000u) >> 16);
            result[6] = (byte)((t & 0x000000000000FF00u) >> 8);
            result[7] = (byte)((t & 0x00000000000000FFu) >> 0);

            return result;
        }

        /// <summary>
        /// Converts a <code>byte[]</code> to a <code>long</code> value.
        /// </summary>
        /// <param name="data">The <code>byte[]</code> to convert.</param>
        /// <returns>A <code>long</code> value represented by the <code>byte[]</code>.</returns>
        public static long ToInt64(this byte[] data)
        {
            if (data.Length != 8)
            {
                throw new ArgumentException($"The byte-array \"{nameof(data)}\" must be exactly eight bytes.");
            }

            long result = 0;

            result = ((long)data[0] << 56) | ((long)data[1] << 48) | ((long)data[2] << 40) | ((long)data[3] << 32) | ((long)data[4] << 24) | ((long)data[5] << 16) | ((long)data[6] << 8) | ((long)data[7] << 0);

            return result;
        }
    }
}
