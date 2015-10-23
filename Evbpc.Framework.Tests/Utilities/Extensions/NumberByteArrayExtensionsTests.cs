using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Evbpc.Framework.Utilities.Extensions.NumberByteArrayExtensions;

namespace Evbpc.Framework.Tests.Utilities.Extensions
{
    [TestClass]
    public class NumberByteArrayExtensionsTests
    {
        [TestMethod, TestCategory("Number Byte-Array Extensions Tests")]
        public void UIntToByteArray_0xFF007FBF()
        {
            var expected = new byte[] { 0xFF, 0x00, 0x7F, 0xBF };
            var original = 0xFF007FBFu;

            var result = original.ToByteArray();

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod, TestCategory("Number Byte-Array Extensions Tests")]
        public void ByteArrayToUInt_0xFF_0x00_0x7F_0xBF()
        {
            var expected = 0xFF007FBFu;
            var original = new byte[] { 0xFF, 0x00, 0x7F, 0xBF };

            var result = original.ToUInt32();

            Assert.AreEqual(expected, result);
        }

        [TestMethod, TestCategory("Number Byte-Array Extensions Tests")]
        public void ULongToByteArray_0xFFAF0FCF4F007FBF()
        {
            var expected = new byte[] { 0xFF, 0xAF, 0x0F, 0xCF, 0x4F, 0x00, 0x7F, 0xBF };
            var original = 0xFFAF0FCF4F007FBFu;

            var result = original.ToByteArray();

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod, TestCategory("Number Byte-Array Extensions Tests")]
        public void ByteArrayToULong_0xFF_0xAF_0x0F_0xCF_0x4F_0x00_0x7F_0xBF()
        {
            var expected = 0xFFAF0FCF4F007FBFu;
            var original = new byte[] { 0xFF, 0xAF, 0x0F, 0xCF, 0x4F, 0x00, 0x7F, 0xBF };

            var result = original.ToUInt64();

            Assert.AreEqual(expected, result);
        }

        [TestMethod, TestCategory("Number Byte-Array Extensions Tests")]
        public void IntToByteArray_0x7F00FFBF()
        {
            var expected = new byte[] { 0x7F, 0x00, 0xFF, 0xBF };
            var original = 0x7F00FFBF;

            var result = original.ToByteArray();

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod, TestCategory("Number Byte-Array Extensions Tests")]
        public void ByteArrayToInt_0x7F_0x00_0xFF_0xBF()
        {
            var expected = 0x7F00FFBF;
            var original = new byte[] { 0x7F, 0x00, 0xFF, 0xBF };

            var result = original.ToInt32();

            Assert.AreEqual(expected, result);
        }

        [TestMethod, TestCategory("Number Byte-Array Extensions Tests")]
        public void LongToByteArray_0x7FAF0FCF4F00FFBF()
        {
            var expected = new byte[] { 0x7F, 0xAF, 0x0F, 0xCF, 0x4F, 0x00, 0xFF, 0xBF };
            var original = 0x7FAF0FCF4F00FFBF;

            var result = original.ToByteArray();

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod, TestCategory("Number Byte-Array Extensions Tests")]
        public void ByteArrayToLong_0x7F_0xAF_0x0F_0xCF_0x4F_0x00_0xFF_0xBF()
        {
            var expected = 0x7FAF0FCF4F00FFBF;
            var original = new byte[] { 0x7F, 0xAF, 0x0F, 0xCF, 0x4F, 0x00, 0xFF, 0xBF };

            var result = original.ToInt64();

            Assert.AreEqual(expected, result);
        }

        [TestMethod, TestCategory("Number Byte-Array Extensions Tests")]
        public void IntToByteArray_0xFF007FBF()
        {
            unchecked
            {
                var expected = new byte[] { 0xFF, 0x00, 0x7F, 0xBF };
                var original = (int)0xFF007FBF;

                var result = original.ToByteArray();

                CollectionAssert.AreEqual(expected, result);
            }
        }

        [TestMethod, TestCategory("Number Byte-Array Extensions Tests")]
        public void ByteArrayToInt_0xFF_0x00_0x7F_0xBF()
        {
            unchecked
            {
                var expected = (int)0xFF007FBF;
                var original = new byte[] { 0xFF, 0x00, 0x7F, 0xBF };

                var result = original.ToInt32();

                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod, TestCategory("Number Byte-Array Extensions Tests")]
        public void LongToByteArray_0xFFAF0FCF4F007FBF()
        {
            unchecked
            {
                var expected = new byte[] { 0xFF, 0xAF, 0x0F, 0xCF, 0x4F, 0x00, 0x7F, 0xBF };
                var original = (long)0xFFAF0FCF4F007FBF;

                var result = original.ToByteArray();

                CollectionAssert.AreEqual(expected, result);
            }
        }

        [TestMethod, TestCategory("Number Byte-Array Extensions Tests")]
        public void ByteArrayToLong_0xFF_0xAF_0x0F_0xCF_0x4F_0x00_0x7F_0xBF()
        {
            unchecked
            {
                var expected = (long)0xFFAF0FCF4F007FBF;
                var original = new byte[] { 0xFF, 0xAF, 0x0F, 0xCF, 0x4F, 0x00, 0x7F, 0xBF };

                var result = original.ToInt64();

                Assert.AreEqual(expected, result);
            }
        }
    }
}
