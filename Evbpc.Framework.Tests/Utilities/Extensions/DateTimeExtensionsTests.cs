using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evbpc.Framework.Utilities.Extensions;

namespace Evbpc.Framework.Tests.Utilities.Extensions
{
    [TestClass]
    public class DateTimeExtensionsTests
    {
        [TestMethod, TestCategory("Date Time Extensions Tests")]
        public void EpochToDateTime_0()
        {
            var expected = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            var input = 0;

            var result = DateTimeExtensions.FromEpoch(input);

            Assert.AreEqual(expected, result);
        }

        [TestMethod, TestCategory("Date Time Extensions Tests")]
        public void DateTimeToEpoch_1970_1_1_0_0_0_0()
        {
            var expected = 0;
            var input = new DateTime(1970, 1, 1, 0, 0, 0, 0);

            var result = DateTimeExtensions.ToEpoch(input);

            Assert.AreEqual(expected, result);
        }

        [TestMethod, TestCategory("Date Time Extensions Tests")]
        public void EpochToDateTime_1()
        {
            var expected = new DateTime(1970, 1, 1, 0, 0, 1, 0);
            var input = 1;

            var result = DateTimeExtensions.FromEpoch(input);

            Assert.AreEqual(expected, result);
        }

        [TestMethod, TestCategory("Date Time Extensions Tests")]
        public void DateTimeToEpoch_1970_1_1_0_0_1_0()
        {
            var expected = 1;
            var input = new DateTime(1970, 1, 1, 0, 0, 1, 0);

            var result = DateTimeExtensions.ToEpoch(input);

            Assert.AreEqual(expected, result);
        }

        [TestMethod, TestCategory("Date Time Extensions Tests")]
        public void EpochToDateTime_61()
        {
            var expected = new DateTime(1970, 1, 1, 0, 1, 1, 0);
            var input = 61;

            var result = DateTimeExtensions.FromEpoch(input);

            Assert.AreEqual(expected, result);
        }

        [TestMethod, TestCategory("Date Time Extensions Tests")]
        public void DateTimeToEpoch_1970_1_1_0_1_1_0()
        {
            var expected = 61;
            var input = new DateTime(1970, 1, 1, 0, 1, 1, 0);

            var result = DateTimeExtensions.ToEpoch(input);

            Assert.AreEqual(expected, result);
        }

        [TestMethod, TestCategory("Date Time Extensions Tests")]
        public void EpochToDateTime_3601()
        {
            var expected = new DateTime(1970, 1, 1, 1, 0, 1, 0);
            var input = 3601;

            var result = DateTimeExtensions.FromEpoch(input);

            Assert.AreEqual(expected, result);
        }

        [TestMethod, TestCategory("Date Time Extensions Tests")]
        public void DateTimeToEpoch_1970_1_1_1_0_1_0()
        {
            var expected = 3601;
            var input = new DateTime(1970, 1, 1, 1, 0, 1, 0);

            var result = DateTimeExtensions.ToEpoch(input);

            Assert.AreEqual(expected, result);
        }

        [TestMethod, TestCategory("Date Time Extensions Tests")]
        public void EpochToDateTime_86401()
        {
            var expected = new DateTime(1970, 1, 2, 0, 0, 1, 0);
            var input = 86401;

            var result = DateTimeExtensions.FromEpoch(input);

            Assert.AreEqual(expected, result);
        }

        [TestMethod, TestCategory("Date Time Extensions Tests")]
        public void DateTimeToEpoch_1970_1_2_0_0_1_0()
        {
            var expected = 86401;
            var input = new DateTime(1970, 1, 2, 0, 0, 1, 0);

            var result = DateTimeExtensions.ToEpoch(input);

            Assert.AreEqual(expected, result);
        }

        [TestMethod, TestCategory("Date Time Extensions Tests")]
        public void EpochToDateTime_2678401()
        {
            var expected = new DateTime(1970, 2, 1, 0, 0, 1, 0);
            var input = 2678401;

            var result = DateTimeExtensions.FromEpoch(input);

            Assert.AreEqual(expected, result);
        }

        [TestMethod, TestCategory("Date Time Extensions Tests")]
        public void DateTimeToEpoch_1970_2_1_0_0_1_0()
        {
            var expected = 2678401;
            var input = new DateTime(1970, 2, 1, 0, 0, 1, 0);

            var result = DateTimeExtensions.ToEpoch(input);

            Assert.AreEqual(expected, result);
        }

        [TestMethod, TestCategory("Date Time Extensions Tests")]
        public void EpochToDateTime_31536001()
        {
            var expected = new DateTime(1971, 1, 1, 0, 0, 1, 0);
            var input = 31536001;

            var result = DateTimeExtensions.FromEpoch(input);

            Assert.AreEqual(expected, result);
        }

        [TestMethod, TestCategory("Date Time Extensions Tests")]
        public void DateTimeToEpoch_1971_1_1_0_0_1_0()
        {
            var expected = 31536001;
            var input = new DateTime(1971, 1, 1, 0, 0, 1, 0);

            var result = DateTimeExtensions.ToEpoch(input);

            Assert.AreEqual(expected, result);
        }

        [TestMethod, TestCategory("Date Time Extensions Tests")]
        public void EpochToDateTime_315532801()
        {
            var expected = new DateTime(1980, 1, 1, 0, 0, 1, 0);
            var input = 315532801;

            var result = DateTimeExtensions.FromEpoch(input);

            Assert.AreEqual(expected, result);
        }

        [TestMethod, TestCategory("Date Time Extensions Tests")]
        public void DateTimeToEpoch_1980_1_1_0_0_1_0()
        {
            var expected = 315532801;
            var input = new DateTime(1980, 1, 1, 0, 0, 1, 0);

            var result = DateTimeExtensions.ToEpoch(input);

            Assert.AreEqual(expected, result);
        }

        [TestMethod, TestCategory("Date Time Extensions Tests")]
        public void EpochToDateTime_1420070401()
        {
            var expected = new DateTime(2015, 1, 1, 0, 0, 1, 0);
            var input = 1420070401;

            var result = DateTimeExtensions.FromEpoch(input);

            Assert.AreEqual(expected, result);
        }

        [TestMethod, TestCategory("Date Time Extensions Tests")]
        public void DateTimeToEpoch_2015_1_1_0_0_1_0()
        {
            var expected = 1420070401;
            var input = new DateTime(2015, 1, 1, 0, 0, 1, 0);

            var result = DateTimeExtensions.ToEpoch(input);

            Assert.AreEqual(expected, result);
        }

        [TestMethod, TestCategory("Date Time Extensions Tests")]
        public void EpochToDateTime_Null()
        {
            var expected = (DateTime?)null;
            var input = (long?)null;

            var result = DateTimeExtensions.FromEpoch(input);

            Assert.AreEqual(expected, result);
        }

        [TestMethod, TestCategory("Date Time Extensions Tests")]
        public void DateTimeToEpoch_Null()
        {
            var expected = (long?)null;
            var input = (DateTime?)null;

            var result = DateTimeExtensions.ToEpoch(input);

            Assert.AreEqual(expected, result);
        }
    }
}
