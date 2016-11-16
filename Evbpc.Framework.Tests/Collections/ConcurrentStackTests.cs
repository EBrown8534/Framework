using Evbpc.Framework.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Tests.Collections
{
    [TestClass]
    public class ConcurrentStackTests
    {
        [TestMethod, TestCategory("Concurrent Stack Tests")]
        public void Push_5_Integers()
        {
            var expected = new int[] { 4, 3, 2, 1, 0 };
            ConcurrentStack<int> stack = new ConcurrentStack<int>();

            for (var i = 0; i < 5; i++)
            {
                stack.Push(i);
            }

            var actual = new int[5];
            stack.CopyTo(actual, 0);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Concurrent Stack Tests")]
        public void Pop_5_Integers()
        {
            var expected = new int[] { 4, 3, 2, 1, 0 };
            ConcurrentStack<int> stack = new ConcurrentStack<int>();

            for (var i = 0; i < 5; i++)
            {
                stack.Push(i);
            }

            var actual = new int[5];
            for (var i = 0; i < 5; i++)
            {
                actual[i] = stack.Pop();
            }

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Concurrent Stack Tests")]
        public void Enumerate_5_Integers()
        {
            var expected = new int[] { 4, 3, 2, 1, 0 };
            ConcurrentStack<int> stack = new ConcurrentStack<int>();

            for (var i = 0; i < 5; i++)
            {
                stack.Push(i);
            }

            var actual = new List<int>();

            foreach (var val in stack)
            {
                actual.Add(val);
            }

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
