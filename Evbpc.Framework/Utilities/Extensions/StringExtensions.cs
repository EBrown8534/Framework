using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Evbpc.Framework.Utilities.Extensions
{
    /// <summary>
    /// Provides extensions to convert certain objects to certain other objects.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Converts a byte-array to an RFC4648 (https://tools.ietf.org/html/rfc4648) Base64 string.
        /// </summary>
        /// <param name="input">The input byte-array.</param>
        /// <param name="options">Any of <see cref="Base64FormattingOptions"/> enumeration values.</param>
        /// <param name="charactersPerLine">If this is a non-zero uinteger, than the number of characters per line will be equivalent to this value.</param>
        /// <returns>The input byte-array encoded into a Base64 string, following the provided options.</returns>
        public static string ToBase64String(this byte[] input, Base64FormattingOptions options = Base64FormattingOptions.RequirePaddingCharacter, uint charactersPerLine = 0)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";

            if ((options & Base64FormattingOptions.UrlFilenameSafeAlphabet) == Base64FormattingOptions.UrlFilenameSafeAlphabet)
            {
                alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-_=";
            }
            else if ((options & Base64FormattingOptions.UnixCryptAlphabet) == Base64FormattingOptions.UnixCryptAlphabet)
            {
                alphabet = "./0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz=";
            }

            ExtendedStringBuilder workingResult = new ExtendedStringBuilder();

            for (int i = 0; i < input.Length; i += 3)
            {
                int temp = (input[i] & 0xFC) >> 2;

                workingResult += alphabet[temp];

                temp = (input[i] & 0x03) << 4;

                if (i + 1 < input.Length)
                {
                    temp |= (input[i + 1] & 0xF0) >> 4;
                    workingResult += alphabet[temp];

                    temp = (input[i + 1] & 0x0F) << 2;

                    if (i + 2 < input.Length)
                    {
                        temp |= (input[i + 2] & 0xC0) >> 6;
                        workingResult += alphabet[temp];
                        workingResult += alphabet[((input[i + 2] & 0x3F))];
                    }
                    else
                    {
                        workingResult += alphabet[temp];

                        if ((options & Base64FormattingOptions.RequirePaddingCharacter) == Base64FormattingOptions.RequirePaddingCharacter)
                        {
                            workingResult += alphabet[64];
                        }
                    }
                }
                else
                {
                    workingResult += alphabet[temp];

                    if ((options & Base64FormattingOptions.RequirePaddingCharacter) == Base64FormattingOptions.RequirePaddingCharacter)
                    {
                        workingResult += alphabet[64];
                        workingResult += alphabet[64];
                    }
                }
            }

            uint lineBreaks = 0;

            if (charactersPerLine > 0)
            {
                lineBreaks = charactersPerLine;
            }
            else if ((options & Base64FormattingOptions.BreakLinesAt64Characters) == Base64FormattingOptions.BreakLinesAt64Characters)
            {
                lineBreaks = 64;
            }
            else if ((options & Base64FormattingOptions.BreakLinesAt76Characters) == Base64FormattingOptions.BreakLinesAt76Characters)
            {
                lineBreaks = 76;
            }

            ExtendedStringBuilder result = new ExtendedStringBuilder();

            string workingString = workingResult;

            if (lineBreaks > 0)
            {
                for (uint line = 0; line < workingResult.Length / lineBreaks; line++)
                {
                    result += workingString.Substring((int)(line * lineBreaks), (int)lineBreaks);

                    string lineBreak = "";

                    if ((options & Base64FormattingOptions.UseCarraigeReturnNewline) == Base64FormattingOptions.UseCarraigeReturnNewline)
                    {
                        lineBreak += "\r";
                    }

                    if ((options & Base64FormattingOptions.UseLineBreakNewLine) == Base64FormattingOptions.UseLineBreakNewLine)
                    {
                        lineBreak += "\n";
                    }

                    if (lineBreak == "")
                    {
                        lineBreak = "\r\n";
                    }

                    result += lineBreak;
                }
            }
            else
            {
                result += workingResult;
            }

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
            {
                alphabet = "0123456789ABCDEFGHJKMNPQRSTVWXYZ=";
            }
            else if ((options & Base32FormattingOptions.Hex32Alphabet) == Base32FormattingOptions.Hex32Alphabet)
            {
                alphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUV=";
            }
            else if ((options & Base32FormattingOptions.VowelSafeAlphabet) == Base32FormattingOptions.VowelSafeAlphabet)
            {
                alphabet = "0123456789bcdfhjkmnpqrtvxyDFGHJL=";
            }

            ExtendedStringBuilder workingResult = new ExtendedStringBuilder();

            int originalLength = input.Length;
            int newLength = originalLength;

            if (input.Length % 5 != 0)
            {
                newLength += originalLength % 5;
            }

            byte[] workingSet = new byte[newLength];

            for (int i = 0; i < originalLength; i++)
            {
                workingSet[i] = input[i];
            }

            for (int g = 0; g < newLength / 5; g++)
            {
                int indexOffset = g * 5;
                int temp = (workingSet[indexOffset] & 0xF4) >> 3;

                workingResult += alphabet[temp];

                temp = (workingSet[indexOffset] & 0x03) << 2;

                if (indexOffset + 1 < input.Length)
                {
                    temp |= (workingSet[indexOffset + 1] & 0xC0) >> 6;
                    workingResult += alphabet[temp];

                    temp = (workingSet[indexOffset + 1] & 0x3E) >> 1;
                    workingResult += alphabet[temp];

                    temp = (workingSet[indexOffset + 1] & 0x01) << 4;

                    if (indexOffset + 2 < input.Length)
                    {
                        temp |= (workingSet[indexOffset + 2] & 0xF0) >> 4;
                        workingResult += alphabet[temp];

                        temp = (workingSet[indexOffset + 2] & 0x0F) << 1;

                        if (indexOffset + 3 < input.Length)
                        {
                            temp |= (workingSet[indexOffset + 3] & 0x80) >> 7;
                            workingResult += alphabet[temp];

                            temp = (workingSet[indexOffset + 3] & 0x7C) >> 2;
                            workingResult += alphabet[temp];

                            temp = (workingSet[indexOffset + 3] & 0x03) << 3;

                            if (indexOffset + 4 < input.Length)
                            {
                                temp |= (workingSet[indexOffset + 4] & 0xE0) >> 5;
                                workingResult += alphabet[temp];

                                temp = workingSet[indexOffset + 4] & 0x1F;
                                workingResult += alphabet[temp];
                            }
                            else
                            {
                                workingResult += alphabet[temp];

                                if ((options & Base32FormattingOptions.RequirePaddingCharacter) == Base32FormattingOptions.RequirePaddingCharacter)
                                {
                                    workingResult += alphabet[32];
                                }
                            }
                        }
                        else
                        {
                            workingResult += alphabet[temp];

                            if ((options & Base32FormattingOptions.RequirePaddingCharacter) == Base32FormattingOptions.RequirePaddingCharacter)
                            {
                                workingResult += alphabet[32];
                                workingResult += alphabet[32];
                                workingResult += alphabet[32];
                            }
                        }
                    }
                    else
                    {
                        workingResult += alphabet[temp];

                        if ((options & Base32FormattingOptions.RequirePaddingCharacter) == Base32FormattingOptions.RequirePaddingCharacter)
                        {
                            workingResult += alphabet[32];
                            workingResult += alphabet[32];
                            workingResult += alphabet[32];
                            workingResult += alphabet[32];
                        }
                    }
                }
                else
                {
                    workingResult += alphabet[temp];

                    if ((options & Base32FormattingOptions.RequirePaddingCharacter) == Base32FormattingOptions.RequirePaddingCharacter)
                    {
                        workingResult += alphabet[32];
                        workingResult += alphabet[32];
                        workingResult += alphabet[32];
                        workingResult += alphabet[32];
                        workingResult += alphabet[32];
                        workingResult += alphabet[32];
                    }
                }
            }

            if (((options & Base32FormattingOptions.RequirePaddingCharacter) == Base32FormattingOptions.RequirePaddingCharacter) && (originalLength != newLength))
            {
                for (int padCount = 0; padCount < newLength - originalLength; padCount++)
                {
                    workingResult += alphabet[32];
                }
            }

            return workingResult;
        }

        /// <summary>
        /// Converts an RFC4648 (https://tools.ietf.org/html/rfc4648) Base64 string to a byte-array.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="options">Any of <see cref="Base64FormattingOptions"/> enumeration values.</param>
        /// <returns>The input Base64 string decoded into a byte-array string, following the provided options.</returns>
        public static byte[] FromBase64String(this string input, Base64FormattingOptions options = Base64FormattingOptions.RequirePaddingCharacter)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException($"The parameter {nameof(input)} cannot be null, empty, or whitespace.");
            }

            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";

            if ((options & Base64FormattingOptions.UrlFilenameSafeAlphabet) == Base64FormattingOptions.UrlFilenameSafeAlphabet)
            {
                alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-_=";
            }
            else if ((options & Base64FormattingOptions.UnixCryptAlphabet) == Base64FormattingOptions.UnixCryptAlphabet)
            {
                alphabet = "./0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz=";
            }

            string workingSet = input.Replace("\r\n", "").Replace("\r", "").Replace("\n", "");

            int originalLength = input.Length;
            int newLength = originalLength;

            if (newLength % 4 != 0 && ((options & Base64FormattingOptions.RequirePaddingCharacter) == Base64FormattingOptions.RequirePaddingCharacter))
            {
                throw new ArgumentException("The input string did not contain a required padding character.", nameof(input));
            }

            byte[] workingResult = new byte[((workingSet.Length * 3) / 4) - (workingSet.IndexOf(alphabet[64]) > 0 ? (workingSet.Length - workingSet.IndexOf(alphabet[64])) : 0)];

            int j = 0;
            int[] temp = new int[4];
            for (int i = 0; i < originalLength; i += 4)
            {
                temp[0] = alphabet.IndexOf(workingSet[i]);
                temp[1] = alphabet.IndexOf(workingSet[i + 1]);

                if (workingSet.Length - i > 2)
                {
                    temp[2] = alphabet.IndexOf(workingSet[i + 2]);

                    if (workingSet.Length - i > 3)
                    {
                        temp[3] = alphabet.IndexOf(workingSet[i + 3]);
                    }
                    else
                    {
                        temp[3] = 64;
                    }
                }
                else
                {
                    temp[2] = 64;
                    temp[3] = 64;
                }

                workingResult[j++] = (byte)((temp[0] << 2) | (temp[1] >> 4));

                if (temp[2] < 64)
                {
                    workingResult[j++] = (byte)((temp[1] << 4) | (temp[2] >> 2));

                    if (temp[3] < 64)
                    {
                        workingResult[j++] = (byte)((temp[2] << 6) | temp[3]);
                    }
                }
            }

            byte[] result = workingResult;

            return result;
        }

        /// <summary>
        /// Converts a string of dash-separated, or underscore-separated words to a PascalCase string.
        /// </summary>
        /// <param name="s">The string to convert.</param>
        /// <returns>The resulting PascalCase string.</returns>
        public static string ToPascalCase(this string s)
        {
            var words = s.Split(new char[3] { '-', '_', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            
            var sb = new ExtendedStringBuilder(words.Sum(x => x.Length));

            foreach (string word in words)
            {
                var stringInfo = new StringInfo(word);
                sb += stringInfo.SubstringByTextElements(0, 1).ToUpper();
                sb += stringInfo.SubstringByTextElements(1).ToLower();
            }

            return sb.ToString();
        }

        /// <summary>
        /// Converts a hexadecimal string to a byte array.
        /// </summary>
        /// <param name="hex">The hexadecimal string to convert.</param>
        /// <returns>The byte array representing the hexadecimal string.</returns>
        public static byte[] HexToByteArray(this string hex)
        {
            if (hex[0] == '0' && (hex[1] == 'x' || hex[1] == 'X'))
            {
                hex = hex.Substring(2);
            }

            byte[] result = new byte[hex.Length / 2];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }

            return result;
        }

        /// <summary>
        /// Converts a string array to a hexadecimal array.
        /// </summary>
        /// <param name="input">The array to convert.</param>
        /// <returns>The hexadecimal equivalent.</returns>
        public static string[] StringArrayToHexArray(this string[] input) => input.ToList().Select(x => Convert.ToByte(x, 10).ToString("x")).ToArray();

        /// <summary>
        /// Converts a byte array to a hexadecimal string.
        /// </summary>
        /// <param name="input">The byte array to convert.</param>
        /// <returns>A hexadecimal string representing the byte array.</returns>
        public static string ToHexString(this byte[] input) => "0x" + BitConverter.ToString(input).Replace("-", string.Empty);

        public static string BuildQueryString(Dictionary<string, string> values)
        {
            var sb = new ExtendedStringBuilder();

            foreach (var kvp in values)
            {
                if (sb.Length > 0)
                {
                    sb += '&';
                }

                sb.Append(kvp.Key).Append('=').Append(kvp.Value);
            }

            return sb;
        }

        public static string InsertOnCharacter(this string source, CharacterType type, string insert)
        {
            var esb = new ExtendedStringBuilder(source.Length);

            foreach (var c in source)
            {
                var cType = c.GetCharacterType();

                if (cType == type)
                {
                    esb += insert;
                }

                esb += c;
            }

            return esb;
        }

        public static CharacterType GetCharacterType(this char c)
        {
            if (c >= 'a' && c <= 'z')
            {
                return CharacterType.LowerLetter;
            }

            if (c >= 'A' && c <= 'Z')
            {
                return CharacterType.UpperLetter;
            }

            if (c >= '0' && c <= '9')
            {
                return CharacterType.Number;
            }

            return CharacterType.Symbol;
        }

        public enum CharacterType
        {
            UpperLetter,
            LowerLetter,
            Number,
            Symbol,
        }
    }
}
