using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PS4_5_Auto_Sink;


namespace AutoSinkerTester
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void KattisPublicTest1()
        {
            Dictionary<string, int> tolls = new Dictionary<string, int>();
            Tuple<string, string>[] trips = new Tuple<string, string>[6];
            Dictionary<string, List<string>> highways = new Dictionary<string, List<string>>();
            int[] answers = new int[] { 25, 10, 0, 0};
            tolls.Add("Sourceville", 5);
            tolls.Add("SinkCity", 10);
            tolls.Add("Easton", 20);
            tolls.Add("Weston", 15);
            highways.Add("Sourceville", new List<string>() { "Easton" });
            highways["Sourceville"].Add("Weston");
            highways.Add("Weston", new List<string>() { "SinkCity" });
            highways.Add("Easton", new List<string>() { "SinkCity" });
            trips[0] = new Tuple<string, string>("Sourceville", "SinkCity");
            trips[1] = new Tuple<string, string>("Easton", "SinkCity");
            trips[2] = new Tuple<string, string>("SinkCity", "SinkCity");
            trips[3] = new Tuple<string, string>("Weston", "Weston");
            trips[4] = new Tuple<string, string>("Weston", "Sourceville");
            trips[5] = new Tuple<string, string>("SinkCity", "Sourceville");
            AutoSinker AS = new AutoSinker();
            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(answers[i], AS.CalculatePriceOfTrip(tolls, highways, trips[i]));
            }
            for(int j = 4; j < 6; j++)
            {
                Assert.AreEqual("NO", AS.CalculatePriceOfTrip(tolls, highways, trips[j]));
            }
        }

        [TestMethod]
        public void KattisPublicTest2()
        {
            Dictionary<string, int> tolls = new Dictionary<string, int>();
            Tuple<string, string>[] trips = new Tuple<string, string>[6];
            Dictionary<string, List<string>> highways = new Dictionary<string, List<string>>();
            int[] answers = new int[] { 25, 10, 0, 0 };
            tolls.Add("Here", 10);
            tolls.Add("There", 20);
            trips[0] = new Tuple<string, string>("Here", "There");
            trips[1] = new Tuple<string, string>("There", "There");
            AutoSinker AS = new AutoSinker();
            Assert.AreEqual("NO", AS.CalculatePriceOfTrip(tolls, highways, trips[0]));
            Assert.AreEqual(0, AS.CalculatePriceOfTrip(tolls, highways, trips[1]));
        }
    }
}
