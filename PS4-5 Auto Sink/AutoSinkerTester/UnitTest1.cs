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
            string[] cities = new string[] { "Sourceville", "SinkCity", "Easton", "Weston" };
            int[] prices = new int[] { 5, 10, 20, 15 };
            Dictionary<string, Vertex> graph = new Dictionary<string, Vertex>();
            Tuple<string, string>[] trips = new Tuple<string, string>[6];
            int[] answers = new int[] { 25, 10, 0, 0, -1, -1 };
            for (int i = 0; i < cities.Length; i++)
            {
                graph.Add(cities[i], new Vertex());
                graph[cities[i]].price = prices[i];
            }

            graph[cities[0]].edges.Add(cities[2]);
            graph[cities[0]].edges.Add(cities[3]);
            graph[cities[3]].edges.Add(cities[1]);
            graph[cities[2]].edges.Add(cities[1]);
            trips[0] = new Tuple<string, string>(cities[0], cities[1]);
            trips[1] = new Tuple<string, string>(cities[2], cities[1]);
            trips[2] = new Tuple<string, string>(cities[1], cities[1]);
            trips[3] = new Tuple<string, string>(cities[3], cities[3]);
            trips[4] = new Tuple<string, string>(cities[3], cities[0]);
            trips[5] = new Tuple<string, string>(cities[1], cities[0]);
            AutoSinker AS = new AutoSinker();
            AS.PrepGraph(graph);
            /*
            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(answers[i], AS.CalculatePriceOfTrip(graph, trips[i]));
            }
            */
            for (int j = 4; j < 6; j++)
            {
                Assert.AreEqual(answers[j], AS.CalculatePriceOfTrip(graph, trips[j]));
            }
        }

        [TestMethod]
        public void KattisPublicTest2()
        {
            string[] cities = new string[] { "Here", "There" };
            int[] prices = new int[] { 10, 20 };
            Dictionary<string, Vertex> graph = new Dictionary<string, Vertex>();
            Tuple<string, string>[] trips = new Tuple<string, string>[6];
            int[] answers = new int[] { 25, 10, 0, 0 };
            for (int i = 0; i < cities.Length; i++)
            {
                graph.Add(cities[i], new Vertex());
                graph[cities[i]].price = prices[i];
            }
            trips[0] = new Tuple<string, string>(cities[0], cities[1]);
            trips[1] = new Tuple<string, string>(cities[1], cities[1]);
            AutoSinker AS = new AutoSinker();
            AS.PrepGraph(graph);
            Assert.AreEqual("NO", AS.CalculatePriceOfTrip(graph, trips[0]));
            Assert.AreEqual(0, AS.CalculatePriceOfTrip(graph, trips[1]));
        }
    }
}
