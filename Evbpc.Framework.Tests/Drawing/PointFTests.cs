using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Evbpc.Framework.Drawing;

namespace Evbpc.Framework.Tests.Drawing
{
    [TestClass]
    public class PointFTests
    {
        [TestMethod, TestCategory("PointF Tests")]
        public void CreatePointFStructure_0_0f_0_0f()
        {
            var expectedX = 0.0f;
            var expectedY = 0.0f;

            PointF point = new PointF(0.0f, 0.0f);

            Assert.AreEqual(expectedX, point.X);
            Assert.AreEqual(expectedY, point.Y);
        }

        [TestMethod, TestCategory("PointF Tests")]
        public void CreatePointFStructure_0_1f_1_56f()
        {
            var expectedX = 0.1f;
            var expectedY = 1.56f;

            PointF point = new PointF(0.1f, 1.56f);

            Assert.AreEqual(expectedX, point.X);
            Assert.AreEqual(expectedY, point.Y);
        }
    }
}
