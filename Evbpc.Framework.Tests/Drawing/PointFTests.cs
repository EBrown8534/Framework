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
            PointF point = new PointF(0.0f, 0.0f);

            Assert.AreEqual(point.X, 0.0f);
            Assert.AreEqual(point.Y, 0.0f);
        }

        [TestMethod, TestCategory("PointF Tests")]
        public void CreatePointFStructure_0_1f_1_34f()
        {
            PointF point = new PointF(0.1f, 1.34f);

            Assert.AreEqual(point.X, 0.1f);
            Assert.AreEqual(point.Y, 1.34f);
        }
    }
}
