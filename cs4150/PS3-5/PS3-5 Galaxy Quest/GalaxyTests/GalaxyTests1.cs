using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PS3_5_Galaxy_Quest;
using System.Collections.Generic;

namespace GalaxyTests
{
    [TestClass]
    public class GalaxyTests1
    {
        private bool IsInGalaxy(long[] a, long[] b, long dSquared)
        {
            long diffx, diffy, xSquared, ySquared;
            // Calculate distance formula for the given elements using distance of dSquared.
            diffx = (a[0] - b[0]);
            diffy = (a[1] - b[1]);
            xSquared = diffx * diffx;
            ySquared = diffy * diffy;
            if (xSquared + ySquared <= dSquared)
                return true;
            return false;
        }
        private List<long[]> MakeGalaxy(int d, int k)

        {
            int divd, HalfdSquared;
            if (d % 2 == 1)
            {
                divd = (d - 1) / 2;
                HalfdSquared = divd * divd;
            }
            else
            {
                divd = d / 2;
                HalfdSquared = d * d;
            }
            Random rand = new Random();
            List<long[]> stars = new List<long[]>();
            int BigBorder = (int)Math.Pow(10, 9), temp_x, temp_y;
            HashSet<long[]> used = new HashSet<long[]>();
            long[] temp = new long[]{ 0, 0 }, first = new long[]{ 0, 0 };
            temp_x = rand.Next(d * d, BigBorder - d * d);
            temp[0] = temp_x;
            temp_y = rand.Next(d * d, BigBorder - d * d);
            temp[1] = temp_y;
            first[0] = temp[0];
            first[1] = temp[1];
            stars.Add(temp);
            used.Add(temp);
            temp = new long[] { BigBorder, BigBorder };
            // Make a galaxy with k - 1 stars around first.
            for (int i = 0; i < k - 1; i++)
            {
                // Make a new random star within bounds that is unique
                while (!IsInGalaxy(first, temp, HalfdSquared))
                {
                    while (used.Contains(temp))
                    {
                        temp_y = rand.Next((int)first[1] - d, (int)first[1] + d);
                        temp_x = rand.Next((int)first[0] - d, (int)first[0] + d);
                    }
                    temp[0] = temp_x;
                    temp[1] = temp_y;
                }
                used.Add(temp);
                stars.Add(temp);
                temp = new long[] { BigBorder, BigBorder };
            }
            return stars;
        }
        
        [TestMethod]
        public void TestIsInGalaxy()
        {
            long[] a = { 5, 8 };
            long[] b = { 9, 20 };
            int d = 13;
            GalaxyQuester GQ = new GalaxyQuester();
            PrivateObject PrivTester = new PrivateObject(GQ);
            Assert.AreEqual(PrivTester.Invoke("IsInGalaxy", a, b, d*d), true);
        }

        [TestMethod]
        public void TestIsInGalaxy2()
        {
            long[] a = { 5, 8 };
            long[] b = { 9, 20 };
            int d = 12;
            GalaxyQuester GQ = new GalaxyQuester();
            PrivateObject PrivTester = new PrivateObject(GQ);
            Assert.AreEqual(PrivTester.Invoke("IsInGalaxy", a, b, d * d), false);
        }


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
