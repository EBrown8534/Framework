using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Utilities
{
    public static class SizeScaleExtensions
    {
        public static string Abbreviation(this SizeUnit unit)
        {
            if (unit == SizeUnit.Bytes)
            {
                return "B";
            }

            if (unit == SizeUnit.Bits)
            {
                return "b";
            }

            var firstLetter = unit.ToString()[0] + "";

            if (((int)unit & 0x00FF) == (int)SizeUnit.Bits)
            {
                return firstLetter + "iB";
            }

            return firstLetter + "B";
        }
    }

    public enum SizeUnit : int
    {
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
