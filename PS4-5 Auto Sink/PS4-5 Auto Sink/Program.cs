using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS4_5_Auto_Sink
{
    public class AutoSinker
    {
        private Tuple<int, string>[] TopologicalSort(Dictionary<string, int> tolls, Dictionary<string, List<string>> highways)
        {
            Tuple<int, string>[] ret = new Tuple<int, string>[tolls.Count];

            return ret;
        }


        private void DepthFirstSearch(Dictionary<string, List<string>> graph, ref Dictionary<string, int[]> pre_post_vals)
        {
            int clock = 1;
            Dictionary<string, bool> visited = new Dictionary<string, bool>();
            foreach (var item in graph)
            {
                visited.Add(item.Key, false);
            }
            foreach (var item in graph)
            {
                if (!visited[item.Key] == true)
                    Explore(graph, item, ref pre_post_vals, clock);
            }

        }


        private void Explore(Dictionary<string, List<string>> graph, KeyValuePair<string, List<string>> node, ref Dictionary<string, int[]> pre_post_vals, int clock)
        {
            
        }


        public int CalculatePriceOfTrip(Dictionary<string, int> tolls, Dictionary<string, List<string>> highways, Tuple<string, string> trip)
        {
            Dictionary<string, int[]> pre_post_vals = new Dictionary<string, int[]>();
            DepthFirstSearch(highways, ref pre_post_vals);
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
            Dictionary<string, int> tolls = new Dictionary<string, int>();
            Tuple<string, string>[] trips = new Tuple<string, string>[0];
            Dictionary<string, List<string>> highways = new Dictionary<string, List<string>>();
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
                        tolls.Add(temp_usr_input[0], int.Parse(temp_usr_input[1]));
                    }
                }
                else if (j == 1)
                {
                    // Get highways
                    for (int h = 0; h < parameter; h++)
                    {
                        usr_input = Console.ReadLine();
                        temp_usr_input = usr_input.Split(' ');
                        highways[temp_usr_input[0]].Add(temp_usr_input[1]);
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
            foreach (var item in trips)
            {
                result = AS.CalculatePriceOfTrip(tolls, highways, item);
                if (result > -1)
                    Console.WriteLine(result);
                else
                    Console.WriteLine("NO");

            }
            Console.Read();
        }
    }
}
