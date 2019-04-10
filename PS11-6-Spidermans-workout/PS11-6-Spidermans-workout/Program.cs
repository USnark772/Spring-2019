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
                Tuple<int, int, int> solution = SolveWorkout(dists, 1, dists[0], 0, -1);
                if(solution.Item1 != 0)
                    Console.WriteLine("IMPOSSIBLE");
                Console.WriteLine(solution.Item1);
                /*
                if (solution.Item1 == 0)
                    Console.WriteLine("Made it back down with min height: " + solution.Item2);
                else
                    Console.WriteLine("Didn't make it back down, min height = " + solution.Item2);
                */
            }
        }

        // TODO: Need to figure out how to pass moves take back up the line?
        public Tuple<int, int, int> SolveWorkout(int[] dists, int current_index, int end, int current_height, int move_taken)
        {
            // item1 = current_height, item2 = min_height
            Tuple<int, int, int> minus_side = new Tuple<int, int, int>(int.MaxValue, -1, -1), plus_side, ret;
            if (current_index == end + 1)
            {
                if (current_height > 0)
                    return new Tuple<int, int, int>(current_height, int.MaxValue, move_taken);
                else
                    return new Tuple<int, int, int>(current_height, current_height, move_taken);
            }
            if (current_height - dists[current_index] >= 0)
                minus_side = SolveWorkout(dists, current_index + 1, end, current_height - dists[current_index], 0);
            plus_side = SolveWorkout(dists, current_index + 1, end, current_height + dists[current_index], 1);
            if (plus_side.Item1 < minus_side.Item1)
                ret = new Tuple<int, int, int>(plus_side.Item1, Math.Max(current_height, plus_side.Item2), move_taken);
            else
                ret = new Tuple<int, int, int>(minus_side.Item1, Math.Max(current_height, minus_side.Item2), move_taken);
            Console.WriteLine("Results are in at: " + ret.Item1 + " " + ret.Item2);
            return ret;
        }

        static void Main(string[] args)
        {
            ExercisePlanner EP = new ExercisePlanner();
            EP.GetInput();
            Console.Read();
        }
    }
}
