using Evbpc.Framework.Utilities.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Tests.Utilities.Cryptography
{
    [TestClass]
    public class AesCryptoTests
    {
        [TestMethod]
        public void AesCryptoToFromEncrypted()
        {
            var expected = "Man is distinguished, not only by his reason, but by this singular passion from other animals, which is a lust of the mind, that by a perseverance of delight in the continued and indefatigable generation of knowledge, exceeds the short vehemence of any carnal pleasure.";

            using (var crypto = new AesCrypto("Passphrase", new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 }))
            {
                string encrypted = crypto.AesEncrypt(expected);
                string actual = crypto.AesDecrypt(encrypted, true);

                Assert.AreEqual(expected, actual);
            }
        }
    }
}
