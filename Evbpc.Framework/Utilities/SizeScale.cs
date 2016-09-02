using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Utilities
{
    public static class SizeScaleExtensions
    {
        public static string Abbreviation(this SizeScale scale)
        {
            if (scale == SizeScale.None)
            {
                return null;
            }

            if (scale == SizeScale.Bytes)
            {
                return "B";
            }

            if (scale == SizeScale.Bits)
            {
                return "b";
            }

            var firstLetter = scale.ToString()[0] + "";

            if (((int)scale & 0x00FF) == (int)SizeScale.Bits)
            {
                return firstLetter + "iB";
            }

            return firstLetter + "B";
        }
    }

    public enum SizeScale : int
    {
        None = 0x0000,
        Bytes = 0x0001,
        Bits = 0x0002,
        Kilobytes = 0x0101,
        Kibibytes = 0x0102,
        Megabytes = 0x0201,
        Mebibytes = 0x0202,
        Gigabytes = 0x0301,
        Gibibytes = 0x0302,
        Terabytes = 0x0401,
        Tibibytes = 0x0402,
        Petabytes = 0x0501,
        Pibibytes = 0x0502,
        Exabytes = 0x0601,
        Exbibytes = 0x0602,
        Zettabyts = 0x0701,
        Zebibytes = 0x0702,
        Yottabytes = 0x0801,
        Yobibytes = 0x0802,
    }
}
