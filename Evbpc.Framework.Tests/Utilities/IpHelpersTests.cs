using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Evbpc.Framework.Tests.Utilities
{
    [TestClass]
    public class IpHelpersTests
    {
        [TestMethod]
        public void IPv4ToHex_68_37_140_114()
        {
            var expected = "0x00000000000000000000000044258c72";
            var input = "68.37.140.114";

            var actual = Framework.Utilities.IpHelpers.IpToHex(input, true);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HexToByteArray_0x00000000000000000000000044258c72()
        {
            var expected = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x44, 0x25, 0x8c, 0x72 };
            var input = "0x00000000000000000000000044258c72";

            var actual = Framework.Utilities.IpHelpers.HexToByteArray(input);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IPv6ToHex_1()
        {
            var expected = "0x00000000000000000000000000000001";
            var input = "0000:0000:0000:0000:0000:0000:0000:0001";

            var actual = Framework.Utilities.IpHelpers.IpToHex(input, true);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExpandIPv6_CC1()
        {
            var expected = "0:0:0:0:0:0:0:1";
            var input = "::1";

            var actual = Framework.Utilities.IpHelpers.ExpandIp6(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StripLeadingZeroes_0x00000000000000000000000000000001()
        {
            var expected = "0x01";
            var input = "0x00000000000000000000000000000001";

            var actual = Framework.Utilities.IpHelpers.StripLeadingZeroes(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StripLeadingZeroes_0x00000000000000000000000044258c72()
        {
            var expected = "0x44258c72";
            var input = "0x00000000000000000000000044258c72";

            var actual = Framework.Utilities.IpHelpers.StripLeadingZeroes(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
