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
            Color color = new Color(0x00, 0x00, 0x00, 0x00);

            Assert.AreEqual(0x00000000u, color.GetPackedValue());
        }

        [TestMethod, TestCategory("Color Tests")]
        public void CreateColorStructure_Packed0x00000000()
        {
            Color color = new Color(0x00000000u);

            Assert.AreEqual(0x00, color.A);
            Assert.AreEqual(0x00, color.R);
            Assert.AreEqual(0x00, color.G);
            Assert.AreEqual(0x00, color.B);
        }

        [TestMethod, TestCategory("Color Tests")]
        public void CreateColorStructure_R0x7F_G0x00_B0xAF_A0xFF()
        {
            Color color = new Color(0x7F, 0x00, 0xAF, 0xFF);

            Assert.AreEqual(0xFF7F00AF, color.GetPackedValue());
        }

        [TestMethod, TestCategory("Color Tests")]
        public void CreateColorStructure_Packed0xFF7F00AF()
        {
            Color color = new Color(0xFF7F00AF);

            Assert.AreEqual(0xFF, color.A);
            Assert.AreEqual(0x7F, color.R);
            Assert.AreEqual(0x00, color.G);
            Assert.AreEqual(0xAF, color.B);
        }

        [TestMethod, TestCategory("Color Tests")]
        public void Equal_Packed0xFF7F00AF_Packed0xFF7F00AF()
        {
            Color color1 = new Color(0xFF7F00AF);
            Color color2 = new Color(0xFF7F00AF);

            Assert.AreEqual(color1 == color2, true);
        }

        [TestMethod, TestCategory("Color Tests")]
        public void NotEqual_Packed0xFF7F00AF_Packed0xFF7FAF00()
        {
            Color color1 = new Color(0xFF7F00AF);
            Color color2 = new Color(0xFF7FAF00);

            Assert.AreEqual(color1 != color2, true);
        }

        [TestMethod, TestCategory("Color Tests")]
        public void GetBytes_0xFF7F00AF()
        {
            Color color = new Color(0xFF7F00AF);

            CollectionAssert.AreEqual(color.GetBytes(), new byte[] { 0xFF, 0x7F, 0x00, 0xAF });
        }
    }
}
