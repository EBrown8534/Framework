using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Utilities.Extensions
{
    /// <summary>
    /// A collection of methods which may be used to assist in conversions from certain numeric types to others.
    /// </summary>
    public static class NumericExtensions
    {
        /// <summary>
        /// Converts a rounded <code>ushort</code> value to a <code>float</code>, with the specified number of decimals.
        /// </summary>
        /// <param name="value">The <code>ushort</code> value to convert.</param>
        /// <param name="decimalBits">The number of bits in the <code>ushort</code> value which represent decimals.</param>
        /// <returns>A <code>float</code> value constructed from the <code>ushort</code> value.</returns>
        public static float UInt16ToFloat(ushort value, byte decimalBits = 0)
        {
            float result = 0;
            ushort mask = GetUShortMask(decimalBits);

            float.Parse((value >> decimalBits).ToString() + "." + (((value & mask) / (float)(mask + 1)).ToString().Replace("0.", "")));
            return result;
        }

        /// <summary>
        /// Converts a <code>float</code> value to a rounded <code>ushort</code>, with the specified number of decimals.
        /// </summary>
        /// <param name="value">The <code>float</code> value to convert.</param>
        /// <param name="decimalBits">The number of bits in the <code>ushort</code> value which represent decimals.</param>
        /// <returns>A <code>ushort</code> value constructed from the <code>float</code> value.</returns>
        public static ushort FloatToUInt16(float value, byte decimalBits = 0)
        {
            ushort result = 0;
            ushort mask = GetUShortMask(decimalBits);

            string[] split = value.ToString().Split('.');
            result = (ushort)((ushort.Parse(split[0]) << decimalBits) | (ushort)(1000u / ushort.Parse(split[1])));

            return result;
        }

        /// <summary>
        /// Constructs a mask which can be used for <see cref="FloatToUInt16(float, byte)"/> and <see cref="UInt16ToFloat(ushort, byte)"/>.
        /// </summary>
        /// <param name="bits">The number of bits that should be set in the mask.</param>
        /// <returns>A <code>ushort</code> which represents a mask that represents the number of bits input to be set to <code>1</code>.</returns>
        public static ushort GetUShortMask(byte bits)
        {
            ushort result = 0x0000;

            while (bits > 0x00)
            {
                bits--;
                result = (ushort)(result | (0x0001u << bits));
            }

            return result;
        }
    }
}
