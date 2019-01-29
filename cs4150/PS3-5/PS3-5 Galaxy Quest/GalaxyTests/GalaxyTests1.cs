using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PS3_5_Galaxy_Quest;
using System.Collections.Generic;

namespace GalaxyTests
{
    [TestClass]
    public class GalaxyTests1
    {
        [TestMethod]
        public void TestNOd10k4()
        {
            GalaxyQuester GQ = new GalaxyQuester();
            List<long[]> stars = new List<long[]>();
            int d = 10, k = 4;
            stars.Add(new long[] { 45, 46 });
            stars.Add(new long[] { 90, 47 });
            stars.Add(new long[] { 45, 54 });
            stars.Add(new long[] { 90, 43 });
            Assert.AreEqual(GQ.CalculateGalaxies(stars, d, k), -1);
        }

        [TestMethod]
        public void TestYESd20k7()
        {
            GalaxyQuester GQ = new GalaxyQuester();
            List<long[]> stars = new List<long[]>();
            int d = 20, k = 7;
            stars.Add(new long[] { 1, 1 });
            stars.Add(new long[] { 100, 100 });
            stars.Add(new long[] { 1, 3 });
            stars.Add(new long[] { 101, 101 });
            stars.Add(new long[] { 3, 1 });
            stars.Add(new long[] { 102, 102 });
            stars.Add(new long[] { 3, 3 });
            Assert.AreEqual(GQ.CalculateGalaxies(stars, d, k), 4);
        }

        [TestMethod]
        public void TestYESd20k7number2()
        {
            GalaxyQuester GQ = new GalaxyQuester();
            List<long[]> stars = new List<long[]>();
            int d = 20, k = 7;
            stars.Add(new long[] { 1, 1 });
            stars.Add(new long[] { 100, 100 });
            stars.Add(new long[] { 101, 101 });
            stars.Add(new long[] { 102, 102 });
            stars.Add(new long[] { 3, 3 });
            stars.Add(new long[] { 3, 1 });
            stars.Add(new long[] { 1, 3 });
            Assert.AreEqual(GQ.CalculateGalaxies(stars, d, k), 4);
        }

        [TestMethod]
        public void TestYESd20k7number3()
        {
            GalaxyQuester GQ = new GalaxyQuester();
            List<long[]> stars = new List<long[]>();
            int d = 20, k = 7;
            stars.Add(new long[] { 3, 4 });
            stars.Add(new long[] { 2, 4 });
            stars.Add(new long[] { 1, 4 });
            stars.Add(new long[] { 3, 3 });
            stars.Add(new long[] { 3, 1 });
            stars.Add(new long[] { 1, 3 });
            stars.Add(new long[] { 1, 1 });
            Assert.AreEqual(GQ.CalculateGalaxies(stars, d, k), 7);
        }

        [TestMethod]
        public void TestNod20k7()
        {
            GalaxyQuester GQ = new GalaxyQuester();
            List<long[]> stars = new List<long[]>();
            int d = 20, k = 7;
            stars.Add(new long[] { 40, 41 });
            stars.Add(new long[] { 140, 4 });
            stars.Add(new long[] { 240, 4 });
            stars.Add(new long[] { 340, 3 });
            stars.Add(new long[] { 440, 1 });
            stars.Add(new long[] { 540, 3 });
            stars.Add(new long[] { 640, 1 });
            Assert.AreEqual(GQ.CalculateGalaxies(stars, d, k), -1);
        }

        [TestMethod]
        public void TestNod10k6()
        {
            GalaxyQuester GQ = new GalaxyQuester();
            List<long[]> stars = new List<long[]>();
            int d = 10, k = 6;
            stars.Add(new long[] { 1, 1 });
            stars.Add(new long[] { 1, 2 });
            stars.Add(new long[] { 100, 4 });
            stars.Add(new long[] { 1, 2 });
            stars.Add(new long[] { 300, 1 });
            stars.Add(new long[] { 400, 2 });
            Assert.AreEqual(GQ.CalculateGalaxies(stars, d, k), -1);
        }
    }
}
