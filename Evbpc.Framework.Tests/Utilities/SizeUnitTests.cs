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
    public class SizeUnitTests
    {
        [TestMethod, TestCategory("Size Unit Tests")]
        public void Abbreviation_Bytes()
        {
            var expected = "B";
            var input = SizeUnit.Bytes;

            var actual = input.Abbreviation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Size Unit Tests")]
        public void Abbreviation_Bits()
        {
            var expected = "b";
            var input = SizeUnit.Bits;

            var actual = input.Abbreviation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Size Unit Tests")]
        public void Abbreviation_Kilobytes()
        {
            var expected = "KB";
            var input = SizeUnit.Kilobytes;

            var actual = input.Abbreviation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Size Unit Tests")]
        public void Abbreviation_Kibibytes()
        {
            var expected = "KiB";
            var input = SizeUnit.Kibibytes;

            var actual = input.Abbreviation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Size Unit Tests")]
        public void Abbreviation_Megabytes()
        {
            var expected = "MB";
            var input = SizeUnit.Megabytes;

            var actual = input.Abbreviation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Size Unit Tests")]
        public void Abbreviation_Mebibytes()
        {
            var expected = "MiB";
            var input = SizeUnit.Mebibytes;

            var actual = input.Abbreviation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Size Unit Tests")]
        public void Abbreviation_Gigabytes()
        {
            var expected = "GB";
            var input = SizeUnit.Gigabytes;

            var actual = input.Abbreviation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Size Unit Tests")]
        public void Abbreviation_Gibibytes()
        {
            var expected = "GiB";
            var input = SizeUnit.Gibibytes;

            var actual = input.Abbreviation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Size Unit Tests")]
        public void Abbreviation_Terabytes()
        {
            var expected = "TB";
            var input = SizeUnit.Terabytes;

            var actual = input.Abbreviation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Size Unit Tests")]
        public void Abbreviation_Tibibytes()
        {
            var expected = "TiB";
            var input = SizeUnit.Tibibytes;

            var actual = input.Abbreviation();

            Assert.AreEqual(expected, actual);
        }
    }
}
