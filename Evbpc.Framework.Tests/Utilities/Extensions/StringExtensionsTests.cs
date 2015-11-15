using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Evbpc.Framework.Utilities.Extensions.StringExtensions;

namespace Evbpc.Framework.Tests.Utilities.Extensions
{
    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        public void ByteArrayToBase64String_65()
        {
            var expected = "QQ==";
            var input = new byte[1] { 65 };

            var actual = ToBase64String(input, Framework.Utilities.Base64FormattingOptions.RequirePaddingCharacter);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Base64StringToByteArray_QQeqeq()
        {
            var expected = new byte[1] { 65 };
            var input = "QQ==";

            var actual = FromBase64String(input, Framework.Utilities.Base64FormattingOptions.RequirePaddingCharacter);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Base64StringToFrom()
        {
            var expected = "Man is distinguished, not only by his reason, but by this singular passion from other animals, which is a lust of the mind, that by a perseverance of delight in the continued and indefatigable generation of knowledge, exceeds the short vehemence of any carnal pleasure.";
            var input = expected;

            var actual = Encoding.ASCII.GetString(FromBase64String(ToBase64String(Encoding.ASCII.GetBytes(input))));

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PhraseToBase64String()
        {
            var expected = "TWFuIGlzIGRpc3Rpbmd1aXNoZWQsIG5vdCBvbmx5IGJ5IGhpcyByZWFzb24sIGJ1dCBieSB0aGlzIHNpbmd1bGFyIHBhc3Npb24gZnJvbSBvdGhlciBhbmltYWxzLCB3aGljaCBpcyBhIGx1c3Qgb2YgdGhlIG1pbmQsIHRoYXQgYnkgYSBwZXJzZXZlcmFuY2Ugb2YgZGVsaWdodCBpbiB0aGUgY29udGludWVkIGFuZCBpbmRlZmF0aWdhYmxlIGdlbmVyYXRpb24gb2Yga25vd2xlZGdlLCBleGNlZWRzIHRoZSBzaG9ydCB2ZWhlbWVuY2Ugb2YgYW55IGNhcm5hbCBwbGVhc3VyZS4=";
            var input = "Man is distinguished, not only by his reason, but by this singular passion from other animals, which is a lust of the mind, that by a perseverance of delight in the continued and indefatigable generation of knowledge, exceeds the short vehemence of any carnal pleasure.";

            var actual = ToBase64String(Encoding.ASCII.GetBytes(input));

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ManToBase64String()
        {
            var expected = "TWFu";
            var input = "Man";

            var actual = ToBase64String(Encoding.ASCII.GetBytes(input));

            Assert.AreEqual(expected, actual);
        }
    }
}
