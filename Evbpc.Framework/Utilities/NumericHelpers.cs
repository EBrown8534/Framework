using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Utilities
{
    public class NumericHelpers
    {
        public static float UInt16ToFloat(ushort value, byte decimalBits = 0)
        {
            float result = 0;
            ushort mask = GetUShortMask(decimalBits);

            float.Parse((value >> decimalBits).ToString() + "." + (((value & mask) / (float)(mask + 1)).ToString().Replace("0.", "")));
            return result;
        }

        public static ushort FloatToUInt16(float value, byte decimalBits = 0)
        {
            ushort result = 0;
            ushort mask = GetUShortMask(decimalBits);

            string[] split = value.ToString().Split('.');
            result = (ushort)((ushort.Parse(split[0]) << decimalBits) | (ushort)(1000u / ushort.Parse(split[1])));

            return result;
        }

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
