using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Evbpc.Framework.Tests.Utilities
{
    [TestClass]
    public class IpHelpersTests
    {
        [TestMethod]
        public void IPv4ToHex_192_168_0_1()
        {
            var expected = "0x000000000000000000000000c0a80001";
            var input = "192.168.0.1";

            var actual = Framework.Utilities.IpHelpers.IpToHex(input, true);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HexToByteArray_0x000000000000000000000000c0a80001()
        {
            var expected = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xC0, 0xA8, 0x00, 0x01 };
            var input = "0x000000000000000000000000c0a80001";

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
        public void StripLeadingZeroes_0x000000000000000000000000c0a80001()
        {
            var expected = "0xc0a80001";
            var input = "0x000000000000000000000000c0a80001";

            var actual = Framework.Utilities.IpHelpers.StripLeadingZeroes(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
