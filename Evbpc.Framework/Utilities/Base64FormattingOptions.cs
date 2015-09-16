using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Utilities
{
    /// <summary>
    /// A series of values that may be used in any combination to determine how a Base64 string will be formatted.
    /// </summary>
    [Flags]
    public enum Base64FormattingOptions
    {
        /// <summary>
        /// Do not use any special options.
        /// </summary>
        None = 0 << 0,
        /// <summary>
        /// Include the padding character at the end of the string, if neccessary.
        /// </summary>
        RequirePaddingCharacter = 0 << 1,
        /// <summary>
        /// Insert line breaks after every 64 characters in the string representation. Superceeds 76-character breaks.
        /// </summary>
        BreakLinesAt64Characters = 0 << 2,
        /// <summary>
        /// Insert line breaks after every 76 characters in the string representation.
        /// </summary>
        BreakLinesAt76Characters = 0 << 3,
        /// <summary>
        /// Utilize an alphabet with safe characters allowed in filenames and URLs. Superceeds all other alphabets.
        /// </summary>
        UrlFilenameSafeAlphabet = 0 << 4,
        /// <summary>
        /// Utilizes an alphabet compatible with Unix Crypt PASSWD stores.
        /// </summary>
        UnixCryptAlphabet = 0 << 5,
        /// <summary>
        /// Will add a \r to each newline.
        /// </summary>
        UseCarraigeReturnNewline = 0 << 6,
        /// <summary>
        /// Will add a \n to each newline.
        /// </summary>
        UseLineBreakNewLine = 0 << 7,

        // Composite options
        /// <summary>
        /// Composite flag for use encoding to original Privacy-Enhanced Mail (RFC 1421) Base64.
        /// </summary>
        Rfc1421PemEncoding = RequirePaddingCharacter | BreakLinesAt64Characters,
        /// <summary>
        /// Composite flag for use encoding to MIME (RFC 2045) Base64.
        /// </summary>
        Rfc2045MimeEncoding = RequirePaddingCharacter | BreakLinesAt76Characters,
        /// <summary>
        /// Encodes to RFC 3548 (obsoleted by RFC 4648) standard encoding, with 64-character lines.
        /// </summary>
        Rfc3548Standard64Encoding = RequirePaddingCharacter | BreakLinesAt64Characters,
        /// <summary>
        /// Encodes to RFC 3548 (obsoleted by RFC 4648) standard encoding, with 76-character lines.
        /// </summary>
        Rfc3548Standard76Encoding = RequirePaddingCharacter | BreakLinesAt76Characters,
        /// <summary>
        /// Encodes to RFC 4648 URL/Filename Safe encoding, with no line breaks.
        /// </summary>
        Rfc4648UrlFilenameEncoding = RequirePaddingCharacter | UrlFilenameSafeAlphabet,
        /// <summary>
        /// Encodes to RFC 4648 URL/Filename Safe encoding, with 64-character lines.
        /// </summary>
        Rfc4648UrlFilename64Encoding = RequirePaddingCharacter | UrlFilenameSafeAlphabet | BreakLinesAt64Characters,
        /// <summary>
        /// Encodes to RFC 4648 URL/Filename Safe encoding, with 76-character lines.
        /// </summary>
        Rfc4648UrlFilename76Encoding = RequirePaddingCharacter | UrlFilenameSafeAlphabet | BreakLinesAt76Characters,
    }
}
