using Evbpc.Framework.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Tests.Utilities
{
    [TestClass]
    public class DataSizeTests
    {
        [TestMethod, TestCategory("Data Size Tests")]
        public void GetSize_1_SizeScale_Bits()
        {
            var expected = 8.0;
            var input = 1u;

            var actual = new DataSize(input).GetSize(SizeScale.Bits);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Data Size Tests")]
        public void GetSize_1_SizeScale_Bytes()
        {
            var expected = 1.0;
            var input = 1u;

            var actual = new DataSize(input).GetSize(SizeScale.Bytes);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Data Size Tests")]
        public void GetSize_1000_SizeScale_Bytes()
        {
            var expected = 1000.0;
            var input = 1000u;

            var actual = new DataSize(input).GetSize(SizeScale.Bytes);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Data Size Tests")]
        public void GetSize_1024_SizeScale_Bytes()
        {
            var expected = 1024.0;
            var input = 1024u;

            var actual = new DataSize(input).GetSize(SizeScale.Bytes);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Data Size Tests")]
        public void GetSize_1000_SizeScale_Kilobytes()
        {
            var expected = 1.0;
            var input = 1000u;

            var actual = new DataSize(input).GetSize(SizeScale.Kilobytes);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Data Size Tests")]
        public void GetSize_1024_SizeScale_Kilobytes()
        {
            var expected = 1.024;
            var input = 1024u;

            var actual = new DataSize(input).GetSize(SizeScale.Kilobytes);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Data Size Tests")]
        public void GetSize_1000_SizeScale_Kibibytes()
        {
            var expected = 0.9765625;
            var input = 1000u;

            var actual = new DataSize(input).GetSize(SizeScale.Kibibytes);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Data Size Tests")]
        public void GetSize_1024_SizeScale_Kibibytes()
        {
            var expected = 1.0;
            var input = 1024u;

            var actual = new DataSize(input).GetSize(SizeScale.Kibibytes);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Data Size Tests")]
        public void GetSize_1000000000_SizeScale_Gigabytes()
        {
            var expected = 1.0;
            var input = 1000000000u;

            var actual = new DataSize(input).GetSize(SizeScale.Gigabytes);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Data Size Tests")]
        public void GetSize_1073741824_SizeScale_Gigabytes()
        {
            var expected = 1.073741824;
            var input = 1073741824ul;

            var actual = new DataSize(input).GetSize(SizeScale.Gigabytes);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Data Size Tests")]
        public void GetSize_1000000000_SizeScale_Gibibytes()
        {
            var expected = 0.931322574615478515625;
            var input = 1000000000u;

            var actual = new DataSize(input).GetSize(SizeScale.Gibibytes);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Data Size Tests")]
        public void GetSize_1073741824_SizeScale_Gibibytes()
        {
            var expected = 1.0;
            var input = 1073741824ul;

            var actual = new DataSize(input).GetSize(SizeScale.Gibibytes);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Data Size Tests")]
        public void Construct_8_SizeScale_Bits()
        {
            var expected = new DataSize(1u);
            var input = 8u;

            var actual = new DataSize((double)input, SizeScale.Bits);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Data Size Tests")]
        public void Construct_1_SizeScale_Bytes()
        {
            var expected = new DataSize(1u);
            var input = 1u;

            var actual = new DataSize(input, SizeScale.Bytes);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Data Size Tests")]
        public void GetLargestWholeSize_SizeScale_Bits_1024_SizeScale_Kibibytes()
        {
            var expected = new DataSize(1.0, SizeScale.Mebibytes);
            var input = 1024u;

            var actual = new DataSize(input, SizeScale.Kibibytes).GetLargestWholeSize(SizeScale.Bits);

            Assert.AreEqual(expected.Size, actual.Size);
        }

        [TestMethod, TestCategory("Data Size Tests")]
        public void GetLargestWholeSize_SizeScale_Bytes_1000_SizeScale_Kilobytes()
        {
            var expected = new DataSize(1.0, SizeScale.Megabytes);
            var input = 1000u;

            var actual = new DataSize(input, SizeScale.Kilobytes).GetLargestWholeSize(SizeScale.Bytes);

            Assert.AreEqual(expected.Size, actual.Size);
        }

        [TestMethod, TestCategory("Data Size Tests")]
        public void Subtract_2_SizeScale_Bytes_1_SizeScale_Bytes()
        {
            var expected = new DataSize(1u, SizeScale.Bytes);
            var initial = new DataSize(2u, SizeScale.Bytes);
            var subtract = new DataSize(1u, SizeScale.Bytes);

            var actual = initial - subtract;

            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod, TestCategory("Data Size Tests")]
        public void Add_1_SizeScale_Bytes_1_SizeScale_Bytes()
        {
            var expected = new DataSize(2u, SizeScale.Bytes);
            var initial = new DataSize(1u, SizeScale.Bytes);
            var add = new DataSize(1u, SizeScale.Bytes);

            var actual = initial + add;

            Assert.AreEqual(expected, actual);
        }
    }
}
