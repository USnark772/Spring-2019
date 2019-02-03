using System;
using System.Collections.Generic;

namespace PS4_5_Auto_Sink
{
    public class Vertex
    {
        public List<string> edges = new List<string>();
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
        private void DepthFirstSearch(Dictionary<string, Vertex> graph)
        {
            int clock = 1;
            foreach (KeyValuePair<string, Vertex> vertex in graph)
            {
                if (graph[vertex.Key].pre_value == 0)
                    Explore(graph, vertex.Key, ref clock);
            }
        }

        private void Explore(Dictionary<string, Vertex> graph, string v, ref int clock)
        {
            graph[v].pre_value = clock++;
            foreach (string vertex in graph[v].edges)
            {
                if (graph[vertex].pre_value == 0)
                    Explore(graph, vertex, ref clock);
            }
            graph[v].post_value = clock++;

        }

        /// <summary>
        /// Use DFS to set pre and post values of given graph.
        /// </summary>
        /// <param name="graph"></param>
        public void PrepGraph(Dictionary<string, Vertex> graph)
        {
            DepthFirstSearch(graph);
        }
        public int CalculatePriceOfTrip(Dictionary<string, Vertex> graph, Tuple<string, string> trip)
        {

            return -1;
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
            AS.PrepGraph(graph);
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
