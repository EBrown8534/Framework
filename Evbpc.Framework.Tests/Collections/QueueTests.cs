using Evbpc.Framework.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Tests.Collections
{
    [TestClass]
    public class QueueTests
    {
        [TestMethod, TestCategory("Queue Tests")]
        public void Push_5_Integers()
        {
            var expected = new int[] { 0, 1, 2, 3, 4 };
            Queue<int> queue = new Queue<int>();

            for (var i = 0; i < 5; i++)
            {
                queue.Push(i);
            }

            var actual = new int[5];
            queue.CopyTo(actual, 0);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Queue Tests")]
        public void Pop_5_Integers()
        {
            var expected = new int[] { 0, 1, 2, 3, 4 };
            Queue<int> queue = new Queue<int>();

            for (var i = 0; i < 5; i++)
            {
                queue.Push(i);
            }

            var actual = new int[5];
            for (var i = 0; i < 5; i++)
            {
                actual[i] = queue.Pop();
            }

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod, TestCategory("Queue Tests")]
        public void Enumerate_5_Integers()
        {
            var expected = new int[] { 0, 1, 2, 3, 4 };
            Queue<int> queue = new Queue<int>();

            for (var i = 0; i < 5; i++)
            {
                queue.Push(i);
            }

            var actual = new System.Collections.Generic.List<int>();

            foreach (var val in queue)
            {
                actual.Add(val);
            }

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
