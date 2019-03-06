using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PS7_6_algs;

namespace PS7_6
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestKey1()
        {
            Program solver = new Program();
            Assert.AreEqual(solver.Key(2, 7), "14 5 5");
            Assert.AreEqual(solver.Key(5, 3), "15 3 3");
        }

        [TestMethod]
        public void TestGCD1()
        {
            Program solver = new Program();
            Assert.AreEqual(solver.GCD(6, 15), "3");
            Assert.AreEqual(solver.GCD(2, 13), "1");
        }

        [TestMethod]
        public void TestEXP1()
        {
            Program solver = new Program();
            Assert.AreEqual(solver.EXP(6, 5, 7), "6");
            Assert.AreEqual(solver.EXP(3, 19, 330847), "326803");
            Assert.AreEqual(solver.EXP(9, 10, 3343210), "3159581");
            Assert.AreEqual(solver.EXP(4, 15, 8), "0");
            Assert.AreEqual(solver.EXP(4, 15, 19), "11");
            Assert.AreEqual(solver.EXP(4, 15, 45), "19");
            Assert.AreEqual(solver.EXP(4, 15, 1002), "628");
            Assert.AreEqual(solver.EXP(4, 15, 8), "0");
            Assert.AreEqual(solver.EXP(5, 13, 2147483647), "1220703125");
            Assert.AreEqual(solver.EXP(5, 14, 2147483642), "1808548341");
            Assert.AreEqual(solver.EXP(7438291, 897222, 232), "49");
            Assert.AreEqual(solver.EXP(1007438291, 322897222, 232), "57");
            Assert.AreEqual(solver.EXP(1007438291, 1122897222, 1214321201), "57874957");

        }

        [TestMethod]
        public void TestInverse1()
        {
            Program solver = new Program();
            Assert.AreEqual(solver.Inverse(7, 13), "2");
            Assert.AreEqual(solver.Inverse(6, 9), "none");
        }

        [TestMethod]
        public void TestIsPrime1()
        {
            Program solver = new Program();
            Assert.AreEqual(solver.IsPrime(13), "yes");
            Assert.AreEqual(solver.IsPrime(10), "no");
        }
    }
}
