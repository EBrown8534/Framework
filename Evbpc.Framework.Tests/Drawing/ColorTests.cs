using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Evbpc.Framework.Drawing;

namespace Evbpc.Framework.Tests.Drawing
{
    [TestClass]
    public class ColorTests
    {
        [TestMethod, TestCategory("Color Tests")]
        public void CreateColorStructure_R0x00_G0x00_B0x00_A0x00()
        {
            var expected = 0x00000000u;
            Color color = new Color(0x00, 0x00, 0x00, 0x00);

            var result = color.GetPackedValue();

            Assert.AreEqual(expected, result);
        }

        [TestMethod, TestCategory("Color Tests")]
        public void CreateColorStructure_Packed0x00000000()
        {
            var expectedA = 0x00;
            var expectedR = 0x00;
            var expectedB = 0x00;
            var expectedG = 0x00;

            Color color = new Color(0x00000000u);

            Assert.AreEqual(expectedA, color.A);
            Assert.AreEqual(expectedR, color.R);
            Assert.AreEqual(expectedB, color.G);
            Assert.AreEqual(expectedG, color.B);
        }

        [TestMethod, TestCategory("Color Tests")]
        public void CreateColorStructure_R0x7F_G0x00_B0xBF_A0xFF()
        {
            var expected = 0xFF7F00BF;
            Color color = new Color(0x7F, 0x00, 0xBF, 0xFF);

            var result = color.GetPackedValue();

            Assert.AreEqual(expected, result);
        }

        [TestMethod, TestCategory("Color Tests")]
        public void CreateColorStructure_Packed0xFF7F00BF()
        {
            var expectedA = 0xFF;
            var expectedR = 0x7F;
            var expectedB = 0x00;
            var expectedG = 0xBF;

            Color color = new Color(0xFF7F00BF);

            Assert.AreEqual(expectedA, color.A);
            Assert.AreEqual(expectedR, color.R);
            Assert.AreEqual(expectedB, color.G);
            Assert.AreEqual(expectedG, color.B);
        }

        [TestMethod, TestCategory("Color Tests")]
        public void EqualOverload_Packed0xFF7F00BF_Packed0xFF7F00BF()
        {
            Color color1 = new Color(0xFF7F00BF);
            Color color2 = new Color(0xFF7F00BF);

            var result = color1 == color2;

            Assert.IsTrue(result);
        }

        [TestMethod, TestCategory("Color Tests")]
        public void NotEqualOperator_Packed0xFF7F00BF_Packed0xFF7FBF00()
        {
            Color color1 = new Color(0xFF7F00BF);
            Color color2 = new Color(0xFF7FBF00);

            var result = color1 != color2;

            Assert.IsTrue(result);
        }

        [TestMethod, TestCategory("Color Tests")]
        public void GetBytes_0xFF7F00BF()
        {
            var expected = new byte[] { 0xFF, 0x7F, 0x00, 0xBF };
            Color color = new Color(0xFF7F00BF);

            var result = color.GetBytes();

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod, TestCategory("Color Tests")]
        public void FromBytes_0xFF_0x7F_0x00_0xBF()
        {
            var expected = 0xFF7F00BFu;

            Color color = new Color();
            color.FromBytes(new byte[] { 0xFF, 0x7F, 0x00, 0xBF });

            var result = color.GetPackedValue();

            Assert.AreEqual(expected, result);
        }
    }
}
