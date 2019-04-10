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
                dists = new int[M + 1];
                dists[0] = M;
                usr_input = Console.ReadLine();
                tmp_usr_input = usr_input.Split(' ');
                for (int i = 1; i < M + 1; i++)
                {
                    dists[i] = int.Parse(tmp_usr_input[i - 1]);
                }
                Console.WriteLine(SolveForSpiderman(dists));
                //Console.WriteLine(MinHeight(dists, 1, 0));
            }
        }


        public string SolveForSpiderman(int[] dists)
        {
            Tuple<int, List<int>> solution = SolveWorkout(dists, 1, 0, -1);
            if (solution.Item1 == int.MaxValue)
                return "IMPOSSIBLE";
            else
            {
                // interperet moves
                StringBuilder sb = new StringBuilder();
                for (int i = dists[0] - 1; i >= 0; i--)
                {
                    if (solution.Item2[i] == 1)
                        sb.Append('U');
                    else if (solution.Item2[i] == 0)
                        sb.Append('D');
                }
                return sb.ToString();
            }
        }

        // TODO: Need to figure out how to pass moves take back up the line?
        public Tuple<int, List<int>> SolveWorkout(int[] dists, int current_index, int current_height, int move_taken)
        {
            // item1 = current_height, item2 = min_height
            List<int> list_of_moves = new List<int>();
            Tuple<int, List<int>> minus_side = new Tuple<int, List<int>>(int.MaxValue, list_of_moves), plus_side, ret;
            if (current_index == dists.Length)
            {
                list_of_moves.Add(move_taken);
                if (current_height > 0)
                    return new Tuple<int, List<int>>(int.MaxValue, list_of_moves);
                else
                    return new Tuple<int, List<int>>(current_height, list_of_moves);
            }
            if (current_height - dists[current_index] >= 0)
                minus_side = SolveWorkout(dists, current_index + 1, current_height - dists[current_index], 0);
            plus_side = SolveWorkout(dists, current_index + 1, current_height + dists[current_index], 1);
            if (plus_side.Item1 < minus_side.Item1)
            {
                list_of_moves = plus_side.Item2;
                list_of_moves.Add(move_taken);
                ret = new Tuple<int, List<int>>(Math.Max(current_height, plus_side.Item1), list_of_moves);
            }
            else
            {
                list_of_moves = minus_side.Item2;
                list_of_moves.Add(move_taken);
                ret = new Tuple<int, List<int>>(Math.Max(current_height, minus_side.Item1), list_of_moves);
            }
            return ret;
        }


        // TODO: Need to figure out how to pass moves take back up the line?
        public int MinHeight(int[] dists, int current_index, int current_height)
        {
            int minus_side = int.MaxValue, plus_side;
            if (current_index == dists.Length)
            {
                if (current_height > 0)
                    return int.MaxValue;
                return current_height;
            }
            if (current_height - dists[current_index] >= 0)
                minus_side = MinHeight(dists, current_index + 1, current_height - dists[current_index]);
            plus_side = MinHeight(dists, current_index + 1, current_height + dists[current_index]);
            return Math.Max(current_height, Math.Min(plus_side, minus_side));
        }
        static void Main(string[] args)
        {
            ExercisePlanner EP = new ExercisePlanner();
            EP.GetInput();
            Console.Read();
        }
    }
}
