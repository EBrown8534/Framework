﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Evbpc.Framework.Drawing;

namespace Evbpc.Framework.Tests.Drawing
{
    [TestClass]
    public class PointTests
    {
        [TestMethod, TestCategory("Point Tests")]
        public void CreatePointStructure_0x00000000_0x00000000()
        {
            var expectedX = 0x00000000;
            var expectedY = 0x00000000;

            Point point = new Point(0x00000000, 0x00000000);

            Assert.AreEqual(expectedX, point.X);
            Assert.AreEqual(expectedY, point.Y);
        }

        [TestMethod, TestCategory("Point Tests")]
        public void CreatePointStructure_0x7FFF00BF_0x00BF7FFF()
        {
            var expectedX = 0x7FFF00BF;
            var expectedY = 0x00BF7FFF;

            Point point = new Point(0x7FFF00BF, 0x00BF7FFF);

            Assert.AreEqual(expectedX, point.X);
            Assert.AreEqual(expectedY, point.Y);
        }

        [TestMethod, TestCategory("Point Tests")]
        public void GetBytes_0x7FFF00BF_0x00BF7FFF()
        {
            var expected = new byte[] { 0x7F, 0xFF, 0x00, 0xBF, 0x00, 0xBF, 0x7F, 0xFF };
            Point point = new Point(0x7FFF00BF, 0x00BF7FFF);

            var result = point.GetBytes();

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod, TestCategory("Point Tests")]
        public void FromBytes_0x7F_0xFF_0x00_0xBF_0x00_0xBF_0x7F_0xFF()
        {
            var expectedX = 0x7FFF00BF;
            var expectedY = 0x00BF7FFF;

            Point point = new Point();
            point.FromBytes(new byte[] { 0x7F, 0xFF, 0x00, 0xBF, 0x00, 0xBF, 0x7F, 0xFF });

            Assert.AreEqual(expectedX, point.X);
            Assert.AreEqual(expectedY, point.Y);
        }

        [TestMethod, TestCategory("Point Tests")]
        public void EqualOperator_X0x7FFF00BF_Y0x00BF7FFF_X0x7FFF00BF_Y0x00BF7FFF()
        {
            Point point1 = new Point(0x7FFF00BF, 0x00BF7FFF);
            Point point2 = new Point(0x7FFF00BF, 0x00BF7FFF);

            var result = point1 == point2;

            Assert.IsTrue(result);
        }

        [TestMethod, TestCategory("Point Tests")]
        public void NotEqualOperator_X0x7FFF00BF_Y0x00BF7FFF_X0x7FFF00BF_Y0x00BFFF7F()
        {
            Point point1 = new Point(0x7FFF00BF, 0x00BF7FFF);
            Point point2 = new Point(0x7FFF00BF, 0x00BFFF7F);

            var result = point1 != point2;

            Assert.IsTrue(result);
        }

        [TestMethod, TestCategory("Point Tests")]
        public void Round_0_1f_1_56f()
        {
            var expectedX = 0x00;
            var expectedY = 0x02;

            PointF point = new PointF(0.1f, 1.56f);
            Point rounded = Point.Round(point);

            Assert.AreEqual(expectedX, rounded.X);
            Assert.AreEqual(expectedY, rounded.Y);
        }

        [TestMethod, TestCategory("Point Tests")]
        public void Truncate_0_1f_1_56f()
        {
            var expectedX = 0x00;
            var expectedY = 0x01;

            PointF point = new PointF(0.1f, 1.56f);
            Point rounded = Point.Truncate(point);

            Assert.AreEqual(expectedX, rounded.X);
            Assert.AreEqual(expectedY, rounded.Y);
        }

        [TestMethod, TestCategory("Point Tests")]
        public void Ceiling_0_1f_1_56f()
        {
            var expectedX = 0x01;
            var expectedY = 0x02;

            PointF point = new PointF(0.1f, 1.56f);
            Point rounded = Point.Ceiling(point);

            Assert.AreEqual(expectedX, rounded.X);
            Assert.AreEqual(expectedY, rounded.Y);
        }
    }
}
