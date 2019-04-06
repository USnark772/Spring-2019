using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS11_6_Spidermans_workout
{
    class ExercisePlanner
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
                for (int i = 1; i < M+1; i++)
                {
                    dists[i] = int.Parse(tmp_usr_input[i-1]);
                }
                Console.WriteLine(SolveWorkout(dists));
            }
        }

        /// TODO: Implement this
        private string SolveWorkout(int[] dists)
        {
            return "temp";
        }

        static void Main(string[] args)
        {
            ExercisePlanner EP = new ExercisePlanner();
            EP.GetInput();
        }
    }
}
