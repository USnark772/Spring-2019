using System;
using System.Collections.Generic;

namespace PS4_5_Auto_Sink
{
    public class Vertex
    {
        public List<string> edges = new List<string>();
        public int price = 0;
        public int stage_price = int.MaxValue - 1;
        public int pre_value = 0;
        public int post_value = 0;
        // Maybe an int array instead of these other things.
        public Vertex() { }
    }


    /// <summary>
    /// Manipulates a DAG for the purpose of calculating best routes between two places.
    /// </summary>
    public class AutoSinker
    {
        #region GivenAlgs
        private string[] TopoSort(Dictionary<string, Vertex> graph)
        {
            string[] ret = new string[graph.Count];
            DepthFirstSearch(graph);
            foreach (string vert in graph.Keys)
            {
                ret[graph[vert].post_value] = vert;
            }
            return ret;
        }

        private void DepthFirstSearch(Dictionary<string, Vertex> graph)
        {
            int clock = 0;
            foreach (string vertex in graph.Keys)
            {
                if (graph[vertex].pre_value == 0)
                    Explore(graph, vertex, ref clock);
            }
        }


        private void Explore(Dictionary<string, Vertex> graph, string v, ref int clock)
        {
            graph[v].pre_value = 1;
            foreach (string vertex in graph[v].edges)
            {
                if (graph[vertex].pre_value == 0)
                    Explore(graph, vertex, ref clock);
            }
            graph[v].post_value = clock++;
        }
        #endregion

        #region MyAlgs

        private int GetPrice(Dictionary<string, Vertex> graph, int start, int end, string[] sorted)
        {
            int current = end, temp_price, ret;
            foreach (string vert in graph.Keys)
            {
                graph[vert].stage_price = int.MaxValue;
            }
            graph[sorted[end]].stage_price = 0;
            while (current != start)
            {
                current++;
                if (graph[sorted[current]].edges.Count > 0)
                {
                    for (int i = 0; i < graph[sorted[current]].edges.Count; i++)
                    {
                        temp_price = graph[graph[sorted[current]].edges[i]].stage_price + graph[graph[sorted[current]].edges[i]].price;
                        if (temp_price < 0)
                            temp_price = int.MaxValue;
                        if (graph[graph[sorted[current]].edges[i]].stage_price == int.MaxValue)
                            continue;
                        if (graph[sorted[current]].stage_price > temp_price)
                            graph[sorted[current]].stage_price = temp_price;
                    }
                }
                else
                {
                    graph[sorted[current]].stage_price = int.MaxValue;
                }
            }
            ret = graph[sorted[current]].stage_price;
            if (ret == int.MaxValue)
                return -1;
            return ret;
        }

        private int CalculatePriceOfTrip(Dictionary<string, Vertex> graph, Tuple<string, string> trip, string[] sorted)
        {
            // Know we cannot make trip, don't even try to calculate.
            if (graph[trip.Item1].post_value < graph[trip.Item2].post_value)
            {
                return -1;
            }
            else
            {
                return GetPrice(graph, graph[trip.Item1].post_value, graph[trip.Item2].post_value, sorted);
            }
        }

        public int[] CalculateTrips(Dictionary<string, Vertex> graph, Tuple<string, string>[] trips)
        {
            string[] sorted = TopoSort(graph);
            int[] results = new int[trips.Length];
            for (int i = 0; i < trips.Length; i++)
            {
                results[i] = CalculatePriceOfTrip(graph, trips[i], sorted);
            }
            return results;
        }

        public int[] RunAlgorithm()
        {
            string usr_input;
            int parameter;
            string[] temp_usr_input;
            Dictionary<string, Vertex> graph = new Dictionary<string, Vertex>();
            Tuple<string, string>[] trips = new Tuple<string, string>[0];
            // Get input
            for (int j = 0; j < 3; j++)
            {
                usr_input = Console.ReadLine();
                parameter = int.Parse(usr_input);
                if (j == 0)
                {
                    // Get cities
                    for (int n = 0; n < parameter; n++)
                    {
                        usr_input = Console.ReadLine();
                        temp_usr_input = usr_input.Split(' ');
                        graph.Add(temp_usr_input[0], new Vertex());
                        graph[temp_usr_input[0]].price = int.Parse(temp_usr_input[1]);
                    }
                }
                else if (j == 1)
                {
                    // Get highways
                    for (int h = 0; h < parameter; h++)
                    {
                        usr_input = Console.ReadLine();
                        temp_usr_input = usr_input.Split(' ');
                        graph[temp_usr_input[0]].edges.Add(temp_usr_input[1]);
                    }
                }
                else
                {
                    if (parameter > 0)
                        trips = new Tuple<string, string>[parameter];
                    // Get trips
                    for (int t = 0; t < parameter; t++)
                    {
                        usr_input = Console.ReadLine();
                        temp_usr_input = usr_input.Split(' ');
                        trips[t] = new Tuple<string, string>(temp_usr_input[0], temp_usr_input[1]);
                    }
                }
            }
            return CalculateTrips(graph, trips);
        }

        #endregion
    }


    class Program
    {
        static void Main(string[] args)
        {
            AutoSinker AS = new AutoSinker();
            foreach (int res in AS.RunAlgorithm())
            {
                if (res > -1)
                    Console.WriteLine(res);
                else
                    Console.WriteLine("NO");

            }
        }
    }
}
