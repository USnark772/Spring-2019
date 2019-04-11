using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS11_6_Spidermans_workout
{
    public class ExercisePlanner
    {
        public void GetInput()
        {
            int[] dists;
            string usr_input;
            string[] tmp_usr_input;
            usr_input = Console.ReadLine();
            int N = int.Parse(usr_input);
            while (N > 0)
            {
                N--;
                usr_input = Console.ReadLine();
                int M = int.Parse(usr_input);
                dists = new int[M];
                usr_input = Console.ReadLine();
                tmp_usr_input = usr_input.Split(' ');
                for (int i = 0; i < M; i++)
                {
                    dists[i] = int.Parse(tmp_usr_input[i]);
                }
                Console.WriteLine(SolveForSpiderman(dists));
            }
        }

        public string SolveForSpiderman(int[] dists)
        {
            StringBuilder sb = new StringBuilder();
            string[] answer = new string[dists.Length];
            Dictionary<Tuple<int, int>, int> other_cache = new Dictionary<Tuple<int, int>, int>();
            int result = MinHeight(dists, new Tuple<int, int>(0, 0), other_cache);
            if (result == int.MaxValue)
                return "IMPOSSIBLE";
            int path = 0;
            for (int i = 0; i < dists.Length; i++)
            {
                if (other_cache[new Tuple<int, int>(i + 1, path + dists[i])] <= result)
                {
                    path += dists[i];
                    answer[i] = "U";
                }
                else
                {
                    path -= dists[i];
                    answer[i] = "D";
                }
            }
            return String.Join("", answer);
        }

        public int MinHeight(int[] dists, Tuple<int, int> key, Dictionary<Tuple<int, int>, int> cache)
        {
            int minus_side = int.MaxValue, plus_side;
            Tuple<int, int> min_key, plus_key;
            if (key.Item1 == dists.Length)
            {
                if (key.Item2 > 0)
                    return int.MaxValue;
                return key.Item2;
            }
            if (key.Item2 - dists[key.Item1] >= 0)
            {
                min_key = new Tuple<int, int>(key.Item1 + 1, key.Item2 - dists[key.Item1]);
                if (cache.ContainsKey(min_key))
                    minus_side = cache[min_key];
                else
                {
                    minus_side = MinHeight(dists, min_key, cache);
                    cache.Add(min_key, minus_side);
                }
            }
            plus_key = new Tuple<int, int>(key.Item1 + 1, key.Item2 + dists[key.Item1]);
            if (cache.ContainsKey(plus_key))
                plus_side = cache[plus_key];
            else
            {
                plus_side = MinHeight(dists, plus_key, cache);
                cache.Add(plus_key, plus_side);
            }
            return Math.Max(key.Item2, Math.Min(plus_side, minus_side));
        }

        static void Main(string[] args)
        {
            ExercisePlanner EP = new ExercisePlanner();
            EP.GetInput();
            //Console.Read();
        }
    }
}
