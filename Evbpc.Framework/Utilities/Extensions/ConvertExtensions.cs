using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Evbpc.Framework.Utilities.Extensions
{
    /// <summary>
    /// Provides extensions to convert certain objects to certain other objects.
    /// </summary>
    public static class ConvertExtensions
    {
        /// <summary>
        /// Converts a byte-array to an RFC4648 (https://tools.ietf.org/html/rfc4648) Base64 string.
        /// </summary>
        /// <param name="input">The input byte-array.</param>
        /// <param name="options">Any of <see cref="Base64FormattingOptions"/> enumeration values.</param>
        /// <returns>The input byte-array encoded into a Base64 string, following the provided options.</returns>
        public static string ToBase64String(this byte[] input, Base64FormattingOptions options = Base64FormattingOptions.RequirePaddingCharacter)
        {
            // Setup the alphabets
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";

            if ((options & Base64FormattingOptions.UrlFilenameSafeAlphabet) == Base64FormattingOptions.UrlFilenameSafeAlphabet)
                alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-_=";
            else if ((options & Base64FormattingOptions.UnixCryptAlphabet) == Base64FormattingOptions.UnixCryptAlphabet)
                alphabet = "./0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz=";

            // Create the result
            string workingResult = "";

            // Create our working set
            int os = input.Length;
            int ns = os;

            if (input.Length % 3 != 0)
                ns += 3 - (os % 3);

            byte[] workingSet = new byte[ns];

            for (int i = 0; i < os; i++)
            {
                workingSet[i] = input[i];
            }

            // Compute the Base64 string
            for (int g = 0; g < ns / 3; g++)
            {
                workingResult += alphabet[((workingSet[(g * 3)] & 0xFC) >> 2)];
                workingResult += alphabet[((workingSet[(g * 3)] & 0x03) << 4) | ((workingSet[(g * 3) + 1] & 0xF0) >> 4)];
                workingResult += alphabet[((workingSet[(g * 3) + 1] & 0x0F) << 2) | ((workingSet[(g * 3) + 2] & 0xC0) >> 6)];
                workingResult += alphabet[((workingSet[(g * 3) + 2] & 0x3F))];
            }

            // Add padding (If required)
            if ((options & Base64FormattingOptions.RequirePaddingCharacter) == Base64FormattingOptions.RequirePaddingCharacter)
                if (os != ns)
                    for (int p = 0; p < ns - os; p++)
                        workingResult += alphabet[64];

            // Break lines (If required)
            int lineBreaks = 0;

            if ((options & Base64FormattingOptions.BreakLinesAt64Characters) == Base64FormattingOptions.BreakLinesAt64Characters)
                lineBreaks = 64;
            else if ((options & Base64FormattingOptions.BreakLinesAt76Characters) == Base64FormattingOptions.BreakLinesAt76Characters)
                lineBreaks = 76;

            string result = "";
            if (lineBreaks > 0)
                for (int l = 0; l < workingResult.Length / lineBreaks; l++)
                    result += workingResult.Substring(l * lineBreaks, lineBreaks) + "\r\n";
            else
                result = workingResult;

            // Return result
            return result;
        }

        /// <summary>
        /// Converts a byte-array to an RFC4648 (https://tools.ietf.org/html/rfc4648) Base32 string.
        /// </summary>
        /// <param name="input">The input byte-array.</param>
        /// <param name="options">Any of <see cref="Base32FormattingOptions"/> enumeration values.</param>
        /// <returns>The input byte-array encoded into a Base32 string, following the provided options.</returns>
        public static string ToBase32String(this byte[] input, Base32FormattingOptions options = Base32FormattingOptions.RequirePaddingCharacter)
        {
            // Setup the alphabets
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567=";

            if ((options & Base32FormattingOptions.CrockfordAlphabet) == Base32FormattingOptions.CrockfordAlphabet)
                alphabet = "0123456789ABCDEFGHJKMNPQRSTVWXYZ=";
            else if ((options & Base32FormattingOptions.Hex32Alphabet) == Base32FormattingOptions.Hex32Alphabet)
                alphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUV=";
            else if ((options & Base32FormattingOptions.VowelSafeAlphabet) == Base32FormattingOptions.VowelSafeAlphabet)
                alphabet = "0123456789bcdfhjkmnpqrtvxyDFGHJL=";

            // Create the result
            string workingResult = "";

            // Create our working set
            int os = input.Length;
            int ns = os;

            if (input.Length % 5 != 0)
                ns += os % 5;

            byte[] workingSet = new byte[ns];

            for (int i = 0; i < os; i++)
            {
                workingSet[i] = input[i];
            }

            // Compute the Base32 string
            for (int g = 0; g < ns / 5; g++)
            {
                workingResult += alphabet[((workingSet[(g * 5)] & 0xF4) >> 3)];
                workingResult += alphabet[((workingSet[(g * 5)] & 0x03) << 2) | ((workingSet[(g * 5) + 1] & 0xC0) >> 6)];
                workingResult += alphabet[((workingSet[(g * 5) + 1] & 0x3E) >> 1)];
                workingResult += alphabet[((workingSet[(g * 5) + 1] & 0x01) << 4) | ((workingSet[(g * 5) + 2] & 0xF0) >> 4)];
                workingResult += alphabet[((workingSet[(g * 5) + 2] & 0x0F) << 1) | ((workingSet[(g * 5) + 3] & 0x80) >> 7)];
                workingResult += alphabet[((workingSet[(g * 5) + 3] & 0x7C) >> 2)];
                workingResult += alphabet[((workingSet[(g * 5) + 3] & 0x03) << 3) | ((workingSet[(g * 5) + 4] & 0xE0) >> 5)];
                workingResult += alphabet[((workingSet[(g * 5) + 4] & 0x1F))];
            }

            // Add padding (If required)
            if ((options & Base32FormattingOptions.RequirePaddingCharacter) == Base32FormattingOptions.RequirePaddingCharacter)
                if (os != ns)
                    for (int p = 0; p < ns - os; p++)
                        workingResult += alphabet[32];

            string result = "";

            result = workingResult;

            // Return result
            return result;
        }

        /// <summary>
        /// Converts an RFC4648 (https://tools.ietf.org/html/rfc4648) Base64 string to a byte-array.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="options">Any of <see cref="Base64FormattingOptions"/> enumeration values.</param>
        /// <returns>The input Base64 string decoded into a byte-array string, following the provided options.</returns>
        public static byte[] FromBase64String(this string input, Base64FormattingOptions options = Base64FormattingOptions.RequirePaddingCharacter)
        {
            // Setup the alphabets
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";

            if ((options & Base64FormattingOptions.UrlFilenameSafeAlphabet) == Base64FormattingOptions.UrlFilenameSafeAlphabet)
                alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-_=";
            else if ((options & Base64FormattingOptions.UnixCryptAlphabet) == Base64FormattingOptions.UnixCryptAlphabet)
                alphabet = "./0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz=";

            // Merge lines
            string workingSet = input.Replace("\r\n", "");

            int os = input.Length;
            int ns = os;

            if (ns % 4 != 0)
                if ((options & Base64FormattingOptions.RequirePaddingCharacter) == Base64FormattingOptions.RequirePaddingCharacter)
                    throw new ArgumentException("The input string did not contain a required padding character.");

            ns = ns / 4 * 3;

            if (input[os - 1] == alphabet[64])
                if (input[os - 2] == alphabet[64])
                    ns -= 2;
                else
                    ns -= 1;

            // Create the result
            byte[] workingResult = new byte[ns];

            // Decode the Base64 string
            for (int g = 0; g < ns / 3; g++)
            {
                workingResult[g * 3] = (byte)(((alphabet.IndexOf(workingSet[g * 4])) << 2) | ((alphabet.IndexOf(workingSet[g * 4 + 1])) >> 4));
                workingResult[g * 3 + 1] = (byte)(((alphabet.IndexOf(workingSet[g * 4 + 1])) << 4) | ((alphabet.IndexOf(workingSet[g * 4 + 2])) >> 2));
                workingResult[g * 3 + 2] = (byte)(((alphabet.IndexOf(workingSet[g * 4 + 2])) << 6) | ((alphabet.IndexOf(workingSet[g * 4 + 3]))));
            }

            byte[] result = workingResult;

            // Return result
            return result;
        }

        public static float UInt16ToFloat(ushort value, byte decimalBits = 0)
        {
            float result = 0;
            ushort mask = decimalBits.GetUShortMask();

            float.Parse((value >> decimalBits).ToString() + "." + (((value & mask) / (float)(mask + 1)).ToString().Replace("0.", "")));
            return result;
        }

        public static ushort FloatToUInt16(float value, byte decimalBits = 0)
        {
            ushort result = 0;
            ushort mask = decimalBits.GetUShortMask();

            string[] split = value.ToString().Split('.');
            result = (ushort)((ushort.Parse(split[0]) << decimalBits) | (ushort)(1000u / ushort.Parse(split[1])));

            return result;
        }

        public static ushort GetUShortMask(this byte bits)
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
