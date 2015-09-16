using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Evbpc.Framework.Utilities
{
    /// <summary>
    /// Provides extensions to convert certain objects to certain other objects.
    /// </summary>
    public static class StringHelpers
    {
        /// <summary>
        /// Converts a byte-array to an RFC4648 (https://tools.ietf.org/html/rfc4648) Base64 string.
        /// </summary>
        /// <param name="input">The input byte-array.</param>
        /// <param name="options">Any of <see cref="Base64FormattingOptions"/> enumeration values.</param>
        /// <returns>The input byte-array encoded into a Base64 string, following the provided options.</returns>
        public static string ToBase64String(byte[] input, Base64FormattingOptions options = Base64FormattingOptions.RequirePaddingCharacter)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";

            if ((options & Base64FormattingOptions.UrlFilenameSafeAlphabet) == Base64FormattingOptions.UrlFilenameSafeAlphabet)
                alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-_=";
            else if ((options & Base64FormattingOptions.UnixCryptAlphabet) == Base64FormattingOptions.UnixCryptAlphabet)
                alphabet = "./0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz=";

            StringBuilder workingResult = new StringBuilder();

            int originalLength = input.Length;
            int newLength = originalLength;

            if (input.Length % 3 != 0)
                newLength += 3 - (originalLength % 3);

            byte[] workingSet = new byte[newLength];

            for (int i = 0; i < originalLength; i++)
            {
                workingSet[i] = input[i];
            }

            for (int g = 0; g < newLength / 3; g++)
            {
                workingResult.Append(alphabet[((workingSet[(g * 3)] & 0xFC) >> 2)]);
                workingResult.Append(alphabet[((workingSet[(g * 3)] & 0x03) << 4) | ((workingSet[(g * 3) + 1] & 0xF0) >> 4)]);
                workingResult.Append(alphabet[((workingSet[(g * 3) + 1] & 0x0F) << 2) | ((workingSet[(g * 3) + 2] & 0xC0) >> 6)]);
                workingResult.Append(alphabet[((workingSet[(g * 3) + 2] & 0x3F))]);
            }

            if ((options & Base64FormattingOptions.RequirePaddingCharacter) == Base64FormattingOptions.RequirePaddingCharacter)
            {
                if (originalLength != newLength)
                {
                    for (int p = 0; p < newLength - originalLength; p++)
                        workingResult.Append(alphabet[64]);
                }
            }

            int lineBreaks = 0;

            if ((options & Base64FormattingOptions.BreakLinesAt64Characters) == Base64FormattingOptions.BreakLinesAt64Characters)
                lineBreaks = 64;
            else if ((options & Base64FormattingOptions.BreakLinesAt76Characters) == Base64FormattingOptions.BreakLinesAt76Characters)
                lineBreaks = 76;

            StringBuilder result = new StringBuilder();

            string workingString = workingResult.ToString();

            if (lineBreaks > 0)
            {
                for (int l = 0; l < workingResult.Length / lineBreaks; l++)
                {
                    result.Append(workingString.Substring(l * lineBreaks, lineBreaks));
                    result.Append("\r\n");
                }
            }
            else
                result.Append(workingResult);

            return result.ToString();
        }

        /// <summary>
        /// Converts a byte-array to an RFC4648 (https://tools.ietf.org/html/rfc4648) Base32 string.
        /// </summary>
        /// <param name="input">The input byte-array.</param>
        /// <param name="options">Any of <see cref="Base32FormattingOptions"/> enumeration values.</param>
        /// <returns>The input byte-array encoded into a Base32 string, following the provided options.</returns>
        public static string ToBase32String(this byte[] input, Base32FormattingOptions options = Base32FormattingOptions.RequirePaddingCharacter)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567=";

            if ((options & Base32FormattingOptions.CrockfordAlphabet) == Base32FormattingOptions.CrockfordAlphabet)
                alphabet = "0123456789ABCDEFGHJKMNPQRSTVWXYZ=";
            else if ((options & Base32FormattingOptions.Hex32Alphabet) == Base32FormattingOptions.Hex32Alphabet)
                alphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUV=";
            else if ((options & Base32FormattingOptions.VowelSafeAlphabet) == Base32FormattingOptions.VowelSafeAlphabet)
                alphabet = "0123456789bcdfhjkmnpqrtvxyDFGHJL=";

            StringBuilder workingResult = new StringBuilder();

            int originalLength = input.Length;
            int newLength = originalLength;

            if (input.Length % 5 != 0)
                newLength += originalLength % 5;

            byte[] workingSet = new byte[newLength];

            for (int i = 0; i < originalLength; i++)
            {
                workingSet[i] = input[i];
            }

            for (int g = 0; g < newLength / 5; g++)
            {
                workingResult.Append(alphabet[((workingSet[(g * 5)] & 0xF4) >> 3)]);
                workingResult.Append(alphabet[((workingSet[(g * 5)] & 0x03) << 2) | ((workingSet[(g * 5) + 1] & 0xC0) >> 6)]);
                workingResult.Append(alphabet[((workingSet[(g * 5) + 1] & 0x3E) >> 1)]);
                workingResult.Append(alphabet[((workingSet[(g * 5) + 1] & 0x01) << 4) | ((workingSet[(g * 5) + 2] & 0xF0) >> 4)]);
                workingResult.Append(alphabet[((workingSet[(g * 5) + 2] & 0x0F) << 1) | ((workingSet[(g * 5) + 3] & 0x80) >> 7)]);
                workingResult.Append(alphabet[((workingSet[(g * 5) + 3] & 0x7C) >> 2)]);
                workingResult.Append(alphabet[((workingSet[(g * 5) + 3] & 0x03) << 3) | ((workingSet[(g * 5) + 4] & 0xE0) >> 5)]);
                workingResult.Append(alphabet[((workingSet[(g * 5) + 4] & 0x1F))]);
            }

            if ((options & Base32FormattingOptions.RequirePaddingCharacter) == Base32FormattingOptions.RequirePaddingCharacter)
            {
                if (originalLength != newLength)
                {
                    for (int p = 0; p < newLength - originalLength; p++)
                        workingResult.Append(alphabet[32]);
                }
            }

            string result = "";

            result = workingResult.ToString();

            return result;
        }

        /// <summary>
        /// Converts an RFC4648 (https://tools.ietf.org/html/rfc4648) Base64 string to a byte-array.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="options">Any of <see cref="Base64FormattingOptions"/> enumeration values.</param>
        /// <returns>The input Base64 string decoded into a byte-array string, following the provided options.</returns>
        public static byte[] FromBase64String(string input, Base64FormattingOptions options = Base64FormattingOptions.RequirePaddingCharacter)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";

            if ((options & Base64FormattingOptions.UrlFilenameSafeAlphabet) == Base64FormattingOptions.UrlFilenameSafeAlphabet)
                alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-_=";
            else if ((options & Base64FormattingOptions.UnixCryptAlphabet) == Base64FormattingOptions.UnixCryptAlphabet)
                alphabet = "./0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz=";

            string workingSet = input.Replace("\r\n", "");

            int originalLength = input.Length;
            int newLength = originalLength;

            if (newLength % 4 != 0)
                if ((options & Base64FormattingOptions.RequirePaddingCharacter) == Base64FormattingOptions.RequirePaddingCharacter)
                    throw new ArgumentException("The input string did not contain a required padding character.");

            newLength = newLength / 4 * 3;

            if (input[originalLength - 1] == alphabet[64])
            {
                if (input[originalLength - 2] == alphabet[64])
                    newLength -= 2;
                else
                    newLength -= 1;
            }

            byte[] workingResult = new byte[newLength];

            for (int g = 0; g < newLength / 3; g++)
            {
                workingResult[g * 3] = (byte)(((alphabet.IndexOf(workingSet[g * 4])) << 2) | ((alphabet.IndexOf(workingSet[g * 4 + 1])) >> 4));
                workingResult[g * 3 + 1] = (byte)(((alphabet.IndexOf(workingSet[g * 4 + 1])) << 4) | ((alphabet.IndexOf(workingSet[g * 4 + 2])) >> 2));
                workingResult[g * 3 + 2] = (byte)(((alphabet.IndexOf(workingSet[g * 4 + 2])) << 6) | ((alphabet.IndexOf(workingSet[g * 4 + 3]))));
            }

            byte[] result = workingResult;

            return result;
        }
    }
}
