using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Utilities
{
    /// <summary>
    /// This class provides helper methods to assist in language-specific situations. (Number conversions from Roman to Decimal, etc.)
    /// </summary>
    public static class LanguageHelpers
    {
        /// <summary>
        /// Converts a roman number string to it's integer equivalent. When used after a conversion of <see cref="NumberToRoman(int, bool)" /> this method should return the original number that was presented.
        /// </summary>
        /// <param name="roman">The roman number to convert to an integer.</param>
        /// <param name="allowShorthand">Optional: if true use shorthand/subtraction rules, certain sequences of small value characters preceeding large value characters are allowed. If false throws an exception (if specified) when a shorthand situation is encountered.</param>
        /// <param name="throwExceptions">Optional: if true throws exceptions as normal. If false does not throw exceptions and instead returns -1 immediately when an exception would be thrown. (Note: Setting false here is faster than wrapping the call in a Try-Catch block.)</param>
        /// <returns>An integer that represents the roman number. May also be -1 when an exception occurs and throwException is false.</returns>
        public static int RomanToNumber(string roman, bool allowShorthand = true, bool throwExceptions = true)
        {
            // I = 1
            // V = 5
            // X = 10
            // L = 50
            // C = 100
            // D = 500
            // M = 1000

#if DEBUG
#warning In DEBUG mode RomanToNumber Exceptions will be thrown regardless of throwExceptions parameter.
            throwErrors = true;
#endif

            int result = 0;

            for (int i = 0; i < roman.Length; i++)
            {
                switch (roman[i])
                {
                    case 'I':
                        if (roman.Length > i + 1)
                        {
                            switch (roman[i + 1])
                            {
                                case 'V':
                                    if (allowShorthand)
                                    {
                                        result += 4;
                                        i++;
                                    }
                                    else
                                    {
                                        if (throwExceptions)
                                        {
                                            throw new ArgumentException("Shorthand rules are off and a shorthand situation was encountered: an I was directly followed by a V.");
                                        }
                                        else
                                        {
                                            return -1;
                                        }
                                    }
                                    break;
                                case 'X':
                                    if (allowShorthand)
                                    {
                                        result += 9;
                                        i++;
                                    }
                                    else
                                    {
                                        if (throwExceptions)
                                        {
                                            throw new ArgumentException("Shorthand rules are off and a shorthand situation was encountered: an I was directly followed by an X.");
                                        }
                                        else
                                        {
                                            return -1;
                                        }
                                    }
                                    break;
                                case 'I':
                                    result += 1;
                                    break;
                                default:
                                    throw new ArgumentException("An invalid sequence of characters was discovered: an I was succeeded by a character which was not an I, V or X.");
                            }
                        }
                        else
                        {
                            result += 1;
                        }
                        break;
                    case 'V':
                        if (roman.Length > i + 1)
                        {
                            switch (roman[i + 1])
                            {
                                case 'V':
                                case 'I':
                                    result += 5;
                                    break;
                                default:
                                    throw new ArgumentException("An invalid sequence of characters was discovered: a V was succeeded by a character which was not an I or a V.");
                            }
                        }
                        else
                        {
                            result += 5;
                        }
                        break;
                    case 'X':
                        if (roman.Length > i + 1)
                        {
                            switch (roman[i + 1])
                            {
                                case 'L':
                                    if (allowShorthand)
                                    {
                                        result += 40;
                                        i++;
                                    }
                                    else
                                    {
                                        if (throwExceptions)
                                        {
                                            throw new ArgumentException("Shorthand rules are off and a shorthand situation was encountered: an X was directly followed by an L.");
                                        }
                                        else
                                        {
                                            return -1;
                                        }
                                    }
                                    break;
                                case 'C':
                                    if (allowShorthand)
                                    {
                                        result += 90;
                                        i++;
                                    }
                                    else
                                    {
                                        if (throwExceptions)
                                        {
                                            throw new ArgumentException("Shorthand rules are off and a shorthand situation was encountered: an X was directly followed by a C.");
                                        }
                                        else
                                        {
                                            return -1;
                                        }
                                    }
                                    break;
                                case 'X':
                                case 'V':
                                case 'I':
                                    result += 10;
                                    break;
                                default:
                                    throw new ArgumentException("An invalid sequence of characters was discovered: an X was succeeded by a character which was not an I, V, X, C or L.");
                            }
                        }
                        else
                        {
                            result += 10;
                        }
                        break;
                    case 'L':
                        if (roman.Length > i + 1)
                        {
                            switch (roman[i + 1])
                            {
                                case 'L':
                                case 'X':
                                case 'V':
                                case 'I':
                                    result += 50;
                                    break;
                                default:
                                    throw new ArgumentException("An invalid sequence of characters was discovered: an L was succeeded by a character which was not an I, V, X, or L.");
                            }
                        }
                        else
                        {
                            result += 50;
                        }
                        break;
                    case 'C':
                        if (roman.Length > i + 1)
                        {
                            switch (roman[i + 1])
                            {
                                case 'D':
                                    if (allowShorthand)
                                    {
                                        result += 400;
                                        i++;
                                    }
                                    else
                                    {
                                        if (throwExceptions)
                                        {
                                            throw new ArgumentException("Shorthand rules are off and a shorthand situation was encountered: a C was directly followed by a D.");
                                        }
                                        else
                                        {
                                            return -1;
                                        }
                                    }
                                    break;
                                case 'M':
                                    if (allowShorthand)
                                    {
                                        result += 900;
                                        i++;
                                    }
                                    else
                                    {
                                        if (throwExceptions)
                                        {
                                            throw new ArgumentException("Shorthand rules are off and a shorthand situation was encountered: a C was directly followed by an M.");
                                        }
                                        else
                                        {
                                            return -1;
                                        }
                                    }
                                    break;
                                case 'C':
                                case 'L':
                                case 'X':
                                case 'V':
                                case 'I':
                                    result += 100;
                                    break;
                                default:
                                    throw new ArgumentException("An invalid sequence of characters was discovered: a C was succeeded by a character which was not an I, V, X, L, C, D or M.");
                            }
                        }
                        else
                        {
                            result += 100;
                        }
                        break;
                    case 'D':
                        if (roman.Length > i + 1)
                        {
                            switch (roman[i + 1])
                            {
                                case 'D':
                                case 'C':
                                case 'L':
                                case 'X':
                                case 'V':
                                case 'I':
                                    result += 500;
                                    break;
                                default:
                                    throw new ArgumentException("An invalid sequence of characters was discovered: a D was succeeded by a character which was not an I, V, X, L, C, or D.");
                            }
                        }
                        else
                        {
                            result += 500;
                        }
                        break;
                    case 'M':
                        if (roman.Length > i + 1)
                        {
                            switch (roman[i + 1])
                            {
                                case 'M':
                                case 'D':
                                case 'C':
                                case 'L':
                                case 'X':
                                case 'V':
                                case 'I':
                                    result += 1000;
                                    break;
                                default:
                                    throw new ArgumentException("An invalid sequence of characters was discovered: an M was succeeded by a character which was not an I, V, X, L, C, D or M.");
                            }
                        }
                        else
                        {
                            result += 1000;
                        }
                        break;
                    default:
                        if (throwExceptions)
                        {
                            throw new ArgumentException("An invalid character was found in the input string. Valid characters are capital letters from the following list: I, V, X, L, C, D, M.");
                        }
                        else
                        {
                            return -1;
                        }
                }
            }

            return result;
        }

        /// <summary>
        /// Converts an integer to it's roman number equivalent. When used after a conversion of <see cref="RomanToNumber(string, bool, bool)"/> this method should return the original roman that was presented.
        /// </summary>
        /// <param name="number">The integer to convert.</param>
        /// <param name="allowShorthand">Optional: use shorthand/subtraction rules. Certain sequences of small value characters preceeding large value characters are allowed.</param>
        /// <returns>A string that represents the roman number for this integer.</returns>
        public static string NumberToRoman(int number, bool allowShorthand = true)
        {
            // I = 1
            // V = 5
            // X = 10
            // L = 50
            // C = 100
            // D = 500
            // M = 1000

            string result = "";

            while (number >= 1000)
            {
                result += "M";
                number -= 1000;
            }
            while (number >= 500)
            {
                result += "D";
                number -= 500;
            }
            while (number >= 100)
            {
                result += "C";
                number -= 100;
            }
            while (number >= 50)
            {
                result += "L";
                number -= 50;
            }
            while (number >= 10)
            {
                result += "X";
                number -= 10;
            }
            while (number >= 5)
            {
                result += "V";
                number -= 5;
            }
            while (number > 0)
            {
                result += "I";
                number -= 1;
            }

            if (allowShorthand)
            {
                result = result.Replace("IIII", "IV");
                result = result.Replace("VIV", "IX");
                result = result.Replace("XXXX", "XL");
                result = result.Replace("LXL", "XC");
                result = result.Replace("CCCC", "CD");
                result = result.Replace("DCD", "CM");
            }

            return result;
        }
    }
}
