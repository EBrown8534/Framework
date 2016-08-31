using Evbpc.Framework.Utilities.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Tests.Utilities.Extensions
{
    [TestClass]
    public class IEnumerableExtensionsTests
    {
        [TestMethod, TestCategory("IEnumerable int Extension Tests")]
        public void GetMissingNumbers_IntMinValue_IntMaxValue()
        {
            var expected = new int[] { int.MinValue + 1, int.MinValue + 2, int.MinValue + 3, int.MinValue + 4, int.MinValue + 5 };
            var input = new int[] { int.MinValue, int.MaxValue };

            var actual = input.GetMissingNumbers().Take(5).ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }
        
        [TestMethod, TestCategory("IEnumerable int Extension Tests")]
        public void GetMissingNumbers_1_2_3_6_7_10()
        {
            var expected = new int[] { 4, 5, 8, 9 };
            var input = new int[] { 1, 2, 3, 6, 7, 10 };

            var actual = input.GetMissingNumbers().ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("IEnumerable int Extension Tests")]
        public void GetMissingNumbers_n10_n7_n6_n3_n2_n1()
        {
            var expected = new int[] { -9, -8, -5, -4 };
            var input = new int[] { -10, -7, -6, -3, -2, -1 };

            var actual = input.GetMissingNumbers().ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("IEnumerable int Extension Tests")]
        public void GetMissingNumbers_n100_n97_n96_n93_n92_n91()
        {
            var expected = new int[] { -99, -98, -95, -94 };
            var input = new int[] { -100, -97, -96, -93, -92, -91 };

            var actual = input.GetMissingNumbers().ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("IEnumerable int Extension Tests")]
        public void GetMissingNumbers_91_92_93_96_97_100()
        {
            var expected = new int[] { 94, 95, 98, 99 };
            var input = new int[] { 91, 92, 93, 96, 97, 100 };

            var actual = input.GetMissingNumbers().ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("IEnumerable int Extension Tests")]
        public void GetMissingNumbers_1_2_3_4_5_6_7_8_9_10()
        {
            var expected = new int[] { };
            var input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var actual = input.GetMissingNumbers().ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("IEnumerable int Extension Tests")]
        [ExpectedException(typeof(ArgumentException))]
        public void GetMissingNumbers_ThrowExceptionOnUnordered()
        {
            var input = new int[] { 2, 1, 3, 6, 7, 10 };

            var actual = input.GetMissingNumbers().ToArray();

            Assert.Fail("Exception was not thrown.");
        }

        [TestMethod, TestCategory("IEnumerable int Extension Tests")]
        [ExpectedException(typeof(ArgumentException))]
        public void GetMissingNumbers_ThrowExceptionOnDuplicate()
        {
            var input = new int[] { 1, 2, 2, 3, 6, 7, 10 };

            var actual = input.GetMissingNumbers().ToArray();

            Assert.Fail("Exception was not thrown.");
        }
    }
}
