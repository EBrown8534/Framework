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
            var sourceNumber = 0xFF007FBFu;
            var resultArray = sourceNumber.ToByteArray();
            var expectedResult = new byte[] { 0xFF, 0x00, 0x7F, 0xBF };

            CollectionAssert.AreEqual(expectedResult, resultArray);
        }

        [TestMethod, TestCategory("Number Byte-Array Extensions Tests")]
        public void ByteArrayToUInt_0xFF_0x00_0x7F_0xBF()
        {
            var sourceArray = new byte[] { 0xFF, 0x00, 0x7F, 0xBF };
            var resultNumber = sourceArray.ToUInt32();
            var expectedNumber = 0xFF007FBFu;

            Assert.AreEqual(expectedNumber, resultNumber);
        }

        [TestMethod, TestCategory("Number Byte-Array Extensions Tests")]
        public void ULongToByteArray_0xFFAF0FCF4F007FBF()
        {
            var sourceNumber = 0xFFAF0FCF4F007FBFu;
            var resultArray = sourceNumber.ToByteArray();
            var expectedResult = new byte[] { 0xFF, 0xAF, 0x0F, 0xCF, 0x4F, 0x00, 0x7F, 0xBF };

            CollectionAssert.AreEqual(expectedResult, resultArray);
        }

        [TestMethod, TestCategory("Number Byte-Array Extensions Tests")]
        public void ByteArrayToULong_0xFF_0xAF_0x0F_0xCF_0x4F_0x00_0x7F_0xBF()
        {
            var sourceArray = new byte[] { 0xFF, 0xAF, 0x0F, 0xCF, 0x4F, 0x00, 0x7F, 0xBF };
            var resultNumber = sourceArray.ToUInt64();
            var expectedNumber = 0xFFAF0FCF4F007FBFu;

            Assert.AreEqual(expectedNumber, resultNumber);
        }

        [TestMethod, TestCategory("Number Byte-Array Extensions Tests")]
        public void IntToByteArray_0x7F00FFBF()
        {
            var sourceNumber = 0x7F00FFBF;
            var resultArray = sourceNumber.ToByteArray();
            var expectedResult = new byte[] { 0x7F, 0x00, 0xFF, 0xBF };

            CollectionAssert.AreEqual(expectedResult, resultArray);
        }

        [TestMethod, TestCategory("Number Byte-Array Extensions Tests")]
        public void ByteArrayToInt_0x7F_0x00_0xFF_0xBF()
        {
            var sourceArray = new byte[] { 0x7F, 0x00, 0xFF, 0xBF };
            var resultNumber = sourceArray.ToInt32();
            var expectedNumber = 0x7F00FFBF;

            Assert.AreEqual(expectedNumber, resultNumber);
        }

        [TestMethod, TestCategory("Number Byte-Array Extensions Tests")]
        public void LongToByteArray_0x7FAF0FCF4F00FFBF()
        {
            var sourceNumber = 0x7FAF0FCF4F00FFBF;
            var resultArray = sourceNumber.ToByteArray();
            var expectedResult = new byte[] { 0x7F, 0xAF, 0x0F, 0xCF, 0x4F, 0x00, 0xFF, 0xBF };

            CollectionAssert.AreEqual(expectedResult, resultArray);
        }

        [TestMethod, TestCategory("Number Byte-Array Extensions Tests")]
        public void ByteArrayToLong_0x7F_0xAF_0x0F_0xCF_0x4F_0x00_0xFF_0xBF()
        {
            var sourceArray = new byte[] { 0x7F, 0xAF, 0x0F, 0xCF, 0x4F, 0x00, 0xFF, 0xBF };
            var resultNumber = sourceArray.ToInt64();
            var expectedNumber = 0x7FAF0FCF4F00FFBF;

            Assert.AreEqual(expectedNumber, resultNumber);
        }
    }
}
