using System;
using System.Collections.Generic;


namespace PS6_6_v2
{
    #region https://visualstudiomagazine.com/articles/2012/11/01/priority-queues-with-c.aspx
    public class PriorityQueue<T> where T : IComparable<T>
    {
        private List<T> data;

        public PriorityQueue()
        {
            this.data = new List<T>();
        }

        public void Enqueue(T item)
        {
            data.Add(item);
            int ci = data.Count - 1; // child index; start at end
            while (ci > 0)
            {
                int pi = (ci - 1) / 2; // parent index
                if (data[ci].CompareTo(data[pi]) >= 0) break; // child item is larger than (or equal) parent so we're done
                T tmp = data[ci]; data[ci] = data[pi]; data[pi] = tmp;
                ci = pi;
            }
        }

        public T Dequeue()
        {
            // assumes pq is not empty; up to calling code
            int li = data.Count - 1; // last index (before removal)
            T frontItem = data[0];   // fetch the front
            data[0] = data[li];
            data.RemoveAt(li);

            --li; // last index (after removal)
            int pi = 0; // parent index. start at front of pq
            while (true)
            {
                int ci = pi * 2 + 1; // left child index of parent
                if (ci > li) break;  // no children so done
                int rc = ci + 1;     // right child
                if (rc <= li && data[rc].CompareTo(data[ci]) < 0) // if there is a rc (ci + 1), and it is smaller than left child, use the rc instead
                    ci = rc;
                if (data[pi].CompareTo(data[ci]) <= 0) break; // parent is smaller than (or equal to) smallest child so done
                T tmp = data[pi]; data[pi] = data[ci]; data[ci] = tmp; // swap parent and child
                pi = ci;
            }
            return frontItem;
        }

        public T Peek()
        {
            T frontItem = data[0];
            return frontItem;
        }

        public int Count()
        {
            return data.Count;
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < data.Count; ++i)
                s += data[i].ToString() + " ";
            s += "count = " + data.Count;
            return s;
        }

        public bool IsConsistent()
        {
            // is the heap property true for all data?
            if (data.Count == 0) return true;
            int li = data.Count - 1; // last index
            for (int pi = 0; pi < data.Count; ++pi) // each parent index
            {
                int lci = 2 * pi + 1; // left child index
                int rci = 2 * pi + 2; // right child index

                if (lci <= li && data[pi].CompareTo(data[lci]) > 0) return false; // if lc exists and it's greater than parent then bad.
                if (rci <= li && data[pi].CompareTo(data[rci]) > 0) return false; // check the right child too.
            }
            return true; // passed all checks
        } // IsConsistent
    } // PriorityQueue
    #endregion
    public class MyTuple : IComparable<MyTuple>
    {
        public int vertex;
        public double priority;
        public MyTuple(int vertex, double priority)
        {
            this.vertex = vertex;
            this.priority = priority;
        }
        public int CompareTo(MyTuple other)
        {
            if (this.priority > other.priority) return -1;
            else if (this.priority < other.priority) return 1;
            else return 0;
        }
    }

    public class Program
    {
        /*
        dijkstra(G, s)

            for each u in V
                dist[u] = ∞
                prev[u] = null
            dist[s] = 0

            PQ = new PriorityQueue(|V|)
            PQ.insertOrChange(s, 0)

            while !PQ.isEmpty()
                u = PQ.deleteMin()
                for each edge(u, v, w) in E
                    if dist[v] > dist[u] + w
                        dist[v] = dist[u] + w
                        prev[v] = u
                        PQ.insertOrChange(v, dist[v])
                */
        private double[] DijkstrasAlg(Dictionary<int, List<Tuple<int, double>>> corridors, int num_corridors)
        {
            HashSet<int> visited = new HashSet<int>();
            double[] dist = new double[num_corridors];
            int[] prev = new int[num_corridors];
            MyTuple temp;
            PriorityQueue<MyTuple> PQ = new PriorityQueue<MyTuple>();
            for (int i = 0; i < num_corridors; i++)
            {
                dist[i] = -1.0;
                prev[i] = -1;
            }
            dist[0] = 1.0;
            PQ.Enqueue(new MyTuple(0, 1.0));
            while (PQ.Count() > 0)
            {
                temp = PQ.Dequeue();
                if (!visited.Contains(temp.vertex))
                {
                    visited.Add(temp.vertex);
                    for (int i = 0; i < corridors[temp.vertex].Count; i++)
                    {
                        if (dist[corridors[temp.vertex][i].Item1] < dist[temp.vertex] * corridors[temp.vertex][i].Item2)
                        {
                            dist[corridors[temp.vertex][i].Item1] = dist[temp.vertex] * corridors[temp.vertex][i].Item2;
                            prev[corridors[temp.vertex][i].Item1] = temp.vertex;
                            PQ.Enqueue(new MyTuple(corridors[temp.vertex][i].Item1, corridors[temp.vertex][i].Item2));
                        }
                    }
                }
            }
            return dist;
        }

        public double[] RunTests()
        {
            double[] ret;
            string usr_input;
            string[] temp_usr_input;
            int num_tests = 0, n = 0, m = 0, temp_1, temp_2;
            int[] n_vals = new int[20], m_vals = new int[20];
            double temp_3;
            Dictionary<int, List<Tuple<int, double>>>[] test_cases = new Dictionary<int, List<Tuple<int, double>>>[20];
            // Get input
            usr_input = Console.ReadLine();
            temp_usr_input = usr_input.Split(' ');
            int.TryParse(temp_usr_input[0], out n);
            int.TryParse(temp_usr_input[1], out m);
            while (!(m == 0 && n == 0))
            {
                test_cases[num_tests] = new Dictionary<int, List<Tuple<int, double>>>();
                n_vals[num_tests] = n;
                m_vals[num_tests] = m;
                // get the test case
                for (int i = 0; i < m; i++)
                {
                    usr_input = Console.ReadLine();
                    temp_usr_input = usr_input.Split(' ');
                    int.TryParse(temp_usr_input[0], out temp_1);
                    int.TryParse(temp_usr_input[1], out temp_2);
                    double.TryParse(temp_usr_input[2], out temp_3);
                    if (!test_cases[num_tests].ContainsKey(temp_1))
                        test_cases[num_tests].Add(temp_1, new List<Tuple<int, double>>());
                    if (!test_cases[num_tests].ContainsKey(temp_2))
                        test_cases[num_tests].Add(temp_2, new List<Tuple<int, double>>());
                    test_cases[num_tests][temp_1].Add(new Tuple<int, double>(temp_2, temp_3));
                    test_cases[num_tests][temp_2].Add(new Tuple<int, double>(temp_1, temp_3));
                }
                usr_input = Console.ReadLine();
                temp_usr_input = usr_input.Split(' ');
                int.TryParse(temp_usr_input[0], out n);
                int.TryParse(temp_usr_input[1], out m);
                num_tests++;
            }
            ret = new double[num_tests];
            // run tests on test cases.
            for (int i = 0; i < num_tests; i++)
            {
                ret[i] = RunTest(test_cases[i], n_vals[i]);
            }
            return ret;
        }

        public double RunTest(Dictionary<int, List<Tuple<int, double>>> corridors, int n)
        {
            double[] dist = DijkstrasAlg(corridors, n);
            return Math.Round(dist[dist.Length - 1], 4);
        }

        static void Main(string[] args)
        {
            Program do_it = new Program();
            double[] result = do_it.RunTests();
            foreach (var item in result)
            {
                Console.WriteLine(item.ToString("0.0000"));
            }
            Console.Read();
        }
    }
}
