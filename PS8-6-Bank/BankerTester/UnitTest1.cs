using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using PS8_6_Bank;

namespace BankerTester
{
    [TestClass]
    public class UnitTest1
    {
        /*
        Input 1:
        4 4
        1000 1
        2000 2
        500 2
        1200 0
        Output 1:
        4200
        
        Input 2:
        3 4
        1000 0
        2000 1
        500 1
        Output 2:
        3000
        */
        [TestMethod]
        public void KattisPublicTests()
        {
            int[] money1 = new int[] { 1000, 2000, 500, 1200 };
            int[] time1 = new int[] { 1, 2, 2, 0 };
            int[] money2 = new int[] { 1000, 2000, 500 };
            int[] time2 = new int[] { 0, 1, 1 };
            int[] answers = new int[] { 4200, 3000 };
            Banker b = new Banker();

        }
    }
}
