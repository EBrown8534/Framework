using Evbpc.Framework.Drawing;
using Evbpc.Framework.Physics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Tests.Physics
{
    [TestClass]
    public class LineTests
    {
        [TestMethod]
        public void Intersect_OnePositive_OneNegative_Line_0_0_2_2_Line_2_0_0_2()
        {
            // \  /
            //  \/
            //  /\
            // /  \
            var expected = new PointF(1f, 1f);
            var l1 = new Line(new Point(0, 0), new Point(2, 2));
            var l2 = new Line(new Point(2, 0), new Point(0, 2));

            var actual = Line.Intersect(l1, l2).Value;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Intersect_Coincident_Line_0_0_2_2_Line_0_0_2_2()
        {
            //    /
            //   /
            //  /
            // /
            var l1 = new Line(new Point(0, 0), new Point(2, 2));
            var l2 = new Line(new Point(0, 0), new Point(2, 2));

            var result = Line.Intersect(l1, l2);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Intersect_Coincident_Line_0_0_2_2_Line_1_1_3_3()
        {
            //      /
            //     /
            //    /
            //   /
            //  /
            // /
            var l1 = new Line(new Point(0, 0), new Point(2, 2));
            var l2 = new Line(new Point(1, 1), new Point(3, 3));

            var result = Line.Intersect(l1, l2);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Intersect_OneHorizontal_OnePositive_Line_0_0_2_2_Line_0_1_2_1()
        {
            //    /
            // __/_
            //  /
            // /
            var expected = new PointF(1f, 1f);
            var l1 = new Line(new Point(0, 0), new Point(2, 2));
            var l2 = new Line(new Point(0, 1), new Point(2, 1));

            var actual = Line.Intersect(l1, l2).Value;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Intersect_OneVertical_OnePositive_Line_0_0_2_2_Line_1_0_1_2()
        {
            //   |/
            //   |
            //  /|
            // / |
            var expected = new PointF(1f, 1f);
            var l1 = new Line(new Point(0, 0), new Point(2, 2));
            var l2 = new Line(new Point(1, 0), new Point(1, 2));

            var actual = Line.Intersect(l1, l2).Value;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Intersect_BothVertical_Line_0_0_0_2_Line_1_0_1_2()
        {
            // | |
            // | |
            // | |
            // | |
            var l1 = new Line(new Point(0, 0), new Point(0, 2));
            var l2 = new Line(new Point(1, 0), new Point(1, 2));

            var result = Line.Intersect(l1, l2);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Intersect_OneVertical_OneHorizontal_Line_1_0_1_2_Line_0_1_2_1()
        {
            //   |
            // __|_
            //   |
            //   |
            var expected = new PointF(1f, 1f);
            var l1 = new Line(new Point(1, 0), new Point(1, 2));
            var l2 = new Line(new Point(0, 1), new Point(2, 1));

            var actual = Line.Intersect(l1, l2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Intersect_BothPositive_Line_0_0_2_2_Line_1_0_2_2()
        {
            //   _/
            // _//
            //  /
            // /
            var expected = new PointF(2f, 2f);
            var l1 = new Line(new Point(0, 0), new Point(2, 2));
            var l2 = new Line(new Point(1, 0), new Point(2, 2));

            var actual = Line.Intersect(l1, l2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Intersect_BothHorizontal_Line_0_0_2_0_Line_0_1_2_1()
        {
            // 
            // ____
            // 
            // ____
            var l1 = new Line(new Point(0, 0), new Point(2, 0));
            var l2 = new Line(new Point(0, 1), new Point(2, 1));

            var result = Line.Intersect(l1, l2);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Intersect_OneVertical_OnePositive_Line_0_0_2_2_Line_1_3_1_4()
        {
            //   |
            //   |
            //    /
            //   /
            //  /
            // /
            var l1 = new Line(new Point(0, 0), new Point(2, 2));
            var l2 = new Line(new Point(1, 3), new Point(1, 4));

            var result = Line.Intersect(l1, l2);

            Assert.IsNull(result);
        }
    }
}
