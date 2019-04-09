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
                Console.WriteLine(SolveWorkout(dists, 1, dists[0]));
            }
        }

        public int SolveWorkout(int[] dists, int start, int end)
        {
            int ret = 0, min = 0, i;
            i = start;
            while (i <= end)
            {
                if (ret == 0)
                    min = MinHeight(dists, i, end);
                if (ret - dists[i] < 0)
                {
                    ret += dists[i];
                    if (ret > min)
                        min = ret;
                }
                else
                {
                    if (ret + dists[i] <= min)
                        ret += dists[i];
                    else
                        ret -= dists[i];
                }
                i++;
            }
            return ret;
        }


        private int MinHeight(int[] dists, int start, int end)
        {
            int ret = -1;
            for (int i = start; i <= end; i++)
            {
                if (dists[i] > ret)
                    ret = dists[i];
            }
            return ret;
        }

        // This does not work.
        private string SolveWorkoutTry1(int[] dists)
        {
            int updown = 0, maxhighet;
            string[] moves = new string[dists[0]];
            updown += dists[1];
            maxhighet = updown;
            moves[0] = "U";
            for (int i = 2; i < dists[0] + 1; i++)
            {
                if (updown - dists[i] >= 0)
                {
                    updown -= dists[i];
                    moves[i - 1] = "D";
                }
                else
                {
                    updown += dists[i];
                    moves[i - 1] = "U";
                }
                if (updown > maxhighet)
                    maxhighet = updown;
            }
            maxhighet += 2;
            Console.WriteLine("maxheight = " + maxhighet);
            return string.Join("", moves);
        }

        static void Main(string[] args)
        {
            ExercisePlanner EP = new ExercisePlanner();
            EP.GetInput();
            Console.Read();
        }
    }
}
