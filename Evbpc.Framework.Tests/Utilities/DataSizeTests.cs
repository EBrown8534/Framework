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
        public void GetSize_1_SizeUnit_Bits()
        {
            var expected = 8.0;
            var input = 1u;

            var actual = new DataSize(input).GetSize(SizeUnit.Bits);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Data Size Tests")]
        public void GetSize_1_SizeUnit_Bytes()
        {
            var expected = 1.0;
            var input = 1u;

            var actual = new DataSize(input).GetSize(SizeUnit.Bytes);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Data Size Tests")]
        public void GetSize_1000_SizeUnit_Bytes()
        {
            var expected = 1000.0;
            var input = 1000u;

            var actual = new DataSize(input).GetSize(SizeUnit.Bytes);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Data Size Tests")]
        public void GetSize_1024_SizeUnit_Bytes()
        {
            var expected = 1024.0;
            var input = 1024u;

            var actual = new DataSize(input).GetSize(SizeUnit.Bytes);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Data Size Tests")]
        public void GetSize_1000_SizeUnit_Kilobytes()
        {
            var expected = 1.0;
            var input = 1000u;

            var actual = new DataSize(input).GetSize(SizeUnit.Kilobytes);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Data Size Tests")]
        public void GetSize_1024_SizeUnit_Kilobytes()
        {
            var expected = 1.024;
            var input = 1024u;

            var actual = new DataSize(input).GetSize(SizeUnit.Kilobytes);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Data Size Tests")]
        public void GetSize_1000_SizeUnit_Kibibytes()
        {
            var expected = 0.9765625;
            var input = 1000u;

            var actual = new DataSize(input).GetSize(SizeUnit.Kibibytes);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Data Size Tests")]
        public void GetSize_1024_SizeUnit_Kibibytes()
        {
            var expected = 1.0;
            var input = 1024u;

            var actual = new DataSize(input).GetSize(SizeUnit.Kibibytes);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Data Size Tests")]
        public void GetSize_1000000000_SizeUnit_Gigabytes()
        {
            var expected = 1.0;
            var input = 1000000000u;

            var actual = new DataSize(input).GetSize(SizeUnit.Gigabytes);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Data Size Tests")]
        public void GetSize_1073741824_SizeUnit_Gigabytes()
        {
            var expected = 1.073741824;
            var input = 1073741824ul;

            var actual = new DataSize(input).GetSize(SizeUnit.Gigabytes);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Data Size Tests")]
        public void GetSize_1000000000_SizeUnit_Gibibytes()
        {
            var expected = 0.931322574615478515625;
            var input = 1000000000u;

            var actual = new DataSize(input).GetSize(SizeUnit.Gibibytes);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Data Size Tests")]
        public void GetSize_1073741824_SizeUnit_Gibibytes()
        {
            var expected = 1.0;
            var input = 1073741824ul;

            var actual = new DataSize(input).GetSize(SizeUnit.Gibibytes);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Data Size Tests")]
        public void Construct_8_SizeUnit_Bits()
        {
            var expected = new DataSize(1u);
            var input = 8u;

            var actual = DataSize.From((double)input, SizeUnit.Bits);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Data Size Tests")]
        public void Construct_1_SizeUnit_Bytes()
        {
            var expected = new DataSize(1u);
            var input = 1u;

            var actual = new DataSize(input, SizeUnit.Bytes);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Data Size Tests")]
        public void GetLargestWholeSize_SizeUnit_Bits_1024_SizeUnit_Kibibytes()
        {
            var expected = DataSize.From(1.0, SizeUnit.Mebibytes);
            var input = 1024u;

            var actual = new DataSize(input, SizeUnit.Kibibytes).GetLargestWholeSize(SizeUnit.Bits);

            Assert.AreEqual(expected.Size, actual.Size);
        }

        [TestMethod, TestCategory("Data Size Tests")]
        public void GetLargestWholeSize_SizeUnit_Bytes_1000_SizeUnit_Kilobytes()
        {
            var expected = DataSize.From(1.0, SizeUnit.Megabytes);
            var input = 1000u;

            var actual = new DataSize(input, SizeUnit.Kilobytes).GetLargestWholeSize(SizeUnit.Bytes);

            Assert.AreEqual(expected.Size, actual.Size);
        }

        [TestMethod, TestCategory("Data Size Tests")]
        public void Subtract_2_SizeUnit_Bytes_1_SizeUnit_Bytes()
        {
            var expected = new DataSize(1u, SizeUnit.Bytes);
            var initial = new DataSize(2u, SizeUnit.Bytes);
            var subtract = new DataSize(1u, SizeUnit.Bytes);

            var actual = initial - subtract;

            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod, TestCategory("Data Size Tests")]
        public void Add_1_SizeUnit_Bytes_1_SizeUnit_Bytes()
        {
            var expected = new DataSize(2u, SizeUnit.Bytes);
            var initial = new DataSize(1u, SizeUnit.Bytes);
            var add = new DataSize(1u, SizeUnit.Bytes);

            var actual = initial + add;

            Assert.AreEqual(expected, actual);
        }
    }
}
