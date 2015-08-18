using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Utilities.Extensions
{
    public static class ByteArrayExtensions
    {
        public static byte[] Append(this byte[] source, byte[] value)
        {
            byte[] result = new byte[source.Length + value.Length];

            for (int i = 0; i < source.Length; i++)
                result[i] = source[i];

            for (int i = 0; i < value.Length; i++)
                result[i + source.Length] = value[i];

            return result;
        }
    }
}
