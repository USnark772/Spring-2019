using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessTools;

namespace BrowserTester
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string filepath = @"C:\Users\Snark\Downloads\kb1.pgn";
            List<ChessGame> result = PGNReader.ParseFile(filepath);
            foreach (var item in result)
            {
                Console.WriteLine(item.EventName);
            }
        }
    }
}
