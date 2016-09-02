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
    public class SizeScaleTests
    {
        [TestMethod, TestCategory("Size Scale Tests")]
        public void Abbreviation_None()
        {
            var input = SizeScale.None;

            var actual = input.Abbreviation();

            Assert.IsNull(actual);
        }

        [TestMethod, TestCategory("Size Scale Tests")]
        public void Abbreviation_Bytes()
        {
            var expected = "B";
            var input = SizeScale.Bytes;

            var actual = input.Abbreviation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Size Scale Tests")]
        public void Abbreviation_Bits()
        {
            var expected = "b";
            var input = SizeScale.Bits;

            var actual = input.Abbreviation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Size Scale Tests")]
        public void Abbreviation_Kilobytes()
        {
            var expected = "KB";
            var input = SizeScale.Kilobytes;

            var actual = input.Abbreviation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Size Scale Tests")]
        public void Abbreviation_Kibibytes()
        {
            var expected = "KiB";
            var input = SizeScale.Kibibytes;

            var actual = input.Abbreviation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Size Scale Tests")]
        public void Abbreviation_Megabytes()
        {
            var expected = "MB";
            var input = SizeScale.Megabytes;

            var actual = input.Abbreviation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Size Scale Tests")]
        public void Abbreviation_Mebibytes()
        {
            var expected = "MiB";
            var input = SizeScale.Mebibytes;

            var actual = input.Abbreviation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Size Scale Tests")]
        public void Abbreviation_Gigabytes()
        {
            var expected = "GB";
            var input = SizeScale.Gigabytes;

            var actual = input.Abbreviation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Size Scale Tests")]
        public void Abbreviation_Gibibytes()
        {
            var expected = "GiB";
            var input = SizeScale.Gibibytes;

            var actual = input.Abbreviation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Size Scale Tests")]
        public void Abbreviation_Terabytes()
        {
            var expected = "TB";
            var input = SizeScale.Terabytes;

            var actual = input.Abbreviation();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Size Scale Tests")]
        public void Abbreviation_Tibibytes()
        {
            var expected = "TiB";
            var input = SizeScale.Tibibytes;

            var actual = input.Abbreviation();

            Assert.AreEqual(expected, actual);
        }
    }
}
