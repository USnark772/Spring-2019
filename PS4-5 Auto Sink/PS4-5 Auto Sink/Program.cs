using System;
using System.Collections.Generic;

namespace PS4_5_Auto_Sink
{
    public class Vertex
    {
        public List<string> edges_forward = new List<string>();
        public List<string> edges_back = new List<string>();
        public int price = 0;
        public int pre_value = 0;
        public int post_value = 0;
        public int top_sort_value = 0;
        public Vertex() { }
    }


    /// <summary>
    /// Manipulates a DAG for the purpose of calculating best routes between two places.
    /// </summary>
    public class AutoSinker
    {
        /// <summary>
        /// Sort each vertex's list of edges by price
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="vertex"></param>
        private void MySort(Dictionary<string, Vertex> graph, string vertex)
        {
            string temp;
            for (int i = 0; i < graph[vertex].edges_forward.Count - 1; i++)
            {
                for (int j = 0; j < graph[vertex].edges_forward.Count - i - 1; j++)
                {
                    if (graph[graph[vertex].edges_forward[j]].price > graph[graph[vertex].edges_forward[j + 1]].price)
                    {
                        temp = graph[vertex].edges_forward[j];
                        graph[vertex].edges_forward[j] = graph[vertex].edges_forward[j + 1];
                        graph[vertex].edges_forward[j + 1] = temp;
                    }
                }
            }
        }

        // Need to figure out how to guarantee we start from source verticies.
        private void DepthFirstSearch(Dictionary<string, Vertex> graph)
        {
            int clock = 1;
            foreach (string vertex in graph.Keys)
            {
                if (graph[vertex].pre_value == 0)
                    Explore(graph, vertex, ref clock);
            }
        }
        

        private void Explore(Dictionary<string, Vertex> graph, string v, ref int clock)
        {
            graph[v].pre_value = clock++;
            foreach (string vertex in graph[v].edges_forward)
            {
                if (graph[vertex].pre_value == 0)
                    Explore(graph, vertex, ref clock);
            }
            graph[v].post_value = clock++;
        }

        private int GetPrice(Dictionary<string, Vertex> graph, string start, string end)
        {
            int price = 0;
            string current = start;
            // This not working properly
            while (current != end)
            {
                current = graph[current].edges_forward[0];
                price += graph[current].price;
            }
            return price;
        }

        /// <summary>
        /// Use DFS to set pre and post values of given graph.
        /// </summary>
        /// <param name="graph"></param>
        private void PrepGraph(Dictionary<string, Vertex> graph)
        {
            foreach (string vertex in graph.Keys)
            {
                MySort(graph, vertex);
            }
            DepthFirstSearch(graph);
        }

        private int CalculatePriceOfTrip(Dictionary<string, Vertex> graph, Tuple<string, string> trip)
        {
            // Not able to make trip, return false.
            if (!(graph[trip.Item1].pre_value < graph[trip.Item2].pre_value) &&
                (graph[trip.Item1].post_value > graph[trip.Item2].post_value))
            {
                return -1;
            }
            else
            {
                return GetPrice(graph, trip.Item1, trip.Item2);
            }
        }

        public int[] CalculateTrips(Dictionary<string, Vertex> graph, Tuple<string, string>[] trips)
        {
            PrepGraph(graph);
            int[] results = new int[trips.Length];
            for (int i = 0; i < trips.Length; i++)
            {
                results[i] = CalculatePriceOfTrip(graph, trips[i]);
            }
            return results;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            string usr_input;
            int parameter, result = -1;
            string[] temp_usr_input;
            Dictionary<string, Vertex> graph = new Dictionary<string, Vertex>();
            Tuple<string, string>[] trips = new Tuple<string, string>[0];
            AutoSinker AS = new AutoSinker();
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
                        graph[temp_usr_input[0]].edges_forward.Add(temp_usr_input[1]);
                        graph[temp_usr_input[1]].edges_back.Add(temp_usr_input[0]);
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
            foreach (Tuple<string, string> trip in trips)
            {
                result = AS.CalculatePriceOfTrip(graph, trip);
                if (result > -1)
                    Console.WriteLine(result);
                else
                    Console.WriteLine("NO");

            }
            Console.Read();
        }
    }
}
