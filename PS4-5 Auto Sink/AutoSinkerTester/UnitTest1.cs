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
            int[] result;
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
            result = AS.CalculateTrips(graph, trips);
            for (int i = 0; i < 6; i++)
            {
                Assert.AreEqual(answers[i], result[i]);
            }
        }

        
        [TestMethod]
        public void KattisPublicTest2()
        {
            string[] cities = new string[] { "Here", "There" };
            int[] prices = new int[] { 10, 20 };
            Dictionary<string, Vertex> graph = new Dictionary<string, Vertex>();
            Tuple<string, string>[] trips = new Tuple<string, string>[2];
            int[] answers = new int[] { -1, 0 };
            for (int i = 0; i < cities.Length; i++)
            {
                graph.Add(cities[i], new Vertex());
                graph[cities[i]].price = prices[i];
            }
            trips[0] = new Tuple<string, string>(cities[0], cities[1]);
            trips[1] = new Tuple<string, string>(cities[1], cities[1]);
            AutoSinker AS = new AutoSinker();
            int[] result = AS.CalculateTrips(graph, trips);
            for (int i = 0; i < trips.Length; i++)
            {
                Assert.AreEqual(answers[i], result[i]);
            }
        }

        [TestMethod]
        public void PrivateTest1()
        {
            //                                0    1    2    3    4    5    6    7
            string[] cities = new string[] { "A", "B", "C", "D", "E", "F", "G", "H" };
            int[] prices = new int[] { 100, 6, 1, 2, 1, 5, 2, 5 };
            Dictionary<string, Vertex> graph = new Dictionary<string, Vertex>();
            Tuple<string, string>[] trips = new Tuple<string, string>[7];
            int[] answers = new int[] { 6, 2, 5, -1, -1, -1, 0 };
            for (int i = 0; i < cities.Length; i++)
            {
                graph.Add(cities[i], new Vertex());
                graph[cities[i]].price = prices[i];
            }
            graph[cities[0]].edges.Add(cities[1]);
            graph[cities[0]].edges.Add(cities[2]);
            graph[cities[1]].edges.Add(cities[4]);
            graph[cities[1]].edges.Add(cities[3]);
            graph[cities[2]].edges.Add(cities[3]);
            graph[cities[2]].edges.Add(cities[5]);
            graph[cities[3]].edges.Add(cities[4]);
            graph[cities[4]].edges.Add(cities[6]);
            graph[cities[5]].edges.Add(cities[6]);
            graph[cities[5]].edges.Add(cities[7]);
            trips[0] = new Tuple<string, string>(cities[0], cities[6]); // ans 6
            trips[1] = new Tuple<string, string>(cities[2], cities[3]); // ans 2
            trips[2] = new Tuple<string, string>(cities[2], cities[5]); // ans 5
            trips[3] = new Tuple<string, string>(cities[7], cities[1]); // ans -1
            trips[4] = new Tuple<string, string>(cities[7], cities[3]); // ans -1
            trips[5] = new Tuple<string, string>(cities[7], cities[6]); // ans -1
            trips[6] = new Tuple<string, string>(cities[7], cities[7]); // ans 0
            AutoSinker AS = new AutoSinker();
            int[] result = AS.CalculateTrips(graph, trips);
            for (int i = 1; i < trips.Length; i++)
            {
                Assert.AreEqual(answers[i], result[i]);
            }
        }

        [TestMethod]
        public void PrivateTest2()
        {
            //                                0    1    2    3    4    5    6    7
            string[] cities = new string[] { "A", "B", "C", "D", "E", "F", "G", "H" };
            int[] prices = new int[] { 100, 6, 1, 2, 1, 5, 2, 5 };
            Dictionary<string, Vertex> graph = new Dictionary<string, Vertex>();
            Tuple<string, string>[] trips = new Tuple<string, string>[5];
            int[] answers = new int[] { 0, -1, -1, -1, -1 };
            for (int i = 0; i < cities.Length; i++)
            {
                graph.Add(cities[i], new Vertex());
                graph[cities[i]].price = prices[i];
            }
            graph[cities[0]].edges.Add(cities[1]);
            graph[cities[0]].edges.Add(cities[2]);
            graph[cities[1]].edges.Add(cities[4]);
            graph[cities[1]].edges.Add(cities[3]);
            graph[cities[2]].edges.Add(cities[3]);
            graph[cities[2]].edges.Add(cities[5]);
            graph[cities[3]].edges.Add(cities[4]);
            graph[cities[4]].edges.Add(cities[6]);
            graph[cities[5]].edges.Add(cities[6]);
            graph[cities[5]].edges.Add(cities[7]);
            trips[0] = new Tuple<string, string>(cities[5], cities[5]); // ans 0
            trips[1] = new Tuple<string, string>(cities[5], cities[2]); // ans -1
            trips[2] = new Tuple<string, string>(cities[5], cities[4]); // ans -1
            trips[3] = new Tuple<string, string>(cities[7], cities[6]); // ans -1
            trips[4] = new Tuple<string, string>(cities[6], cities[7]); // ans -1
            AutoSinker AS = new AutoSinker();
            int[] result = AS.CalculateTrips(graph, trips);
            for (int i = 1; i < trips.Length; i++)
            {
                Assert.AreEqual(answers[i], result[i]);
            }
        }
    }
}
