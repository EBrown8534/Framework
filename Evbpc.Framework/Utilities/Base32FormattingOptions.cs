using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Utilities
{
    [Flags]
    public enum Base32FormattingOptions
    {
        /// <summary>
        /// Do not use any special options.
        /// </summary>
        None = 0x00,
        /// <summary>
        /// Include the padding character at the end of the string, if neccessary.
        /// </summary>
        RequirePaddingCharacter = 0x01,
        /// <summary>
        /// Utilizes the Crockford Base32 alphabet.
        /// </summary>
        CrockfordAlphabet = 0x10,
        /// <summary>
        /// Utilizes an alphabet that is a direct extension of Base16 Hexadecimal.
        /// </summary>
        Hex32Alphabet = 0x20,
        /// <summary>
        /// Utilizes a proprietary alphabet that excludes vowels and other non-distinguished characters to prevent the chances of obscene words being generated. Alphabet is 0123456789bcdfhjkmnpqrtvxyDFGHJL with an equal sign (=) for optional padding.
        /// </summary>
        VowelSafeAlphabet = 0x40,
    }
}
