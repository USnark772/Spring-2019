using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS8_6_Bank
{
    /*
    The first line of input contains two integers N (1≤N≤10000) and T (1≤T≤47), the number of people in the queue and the 
    time in minutes until Oliver closes the bank. Then follow N lines, each with 2 integers ci and ti, denoting the amount of 
    cash in Swedish crowns person i has and the time in minutes from now after which person i leaves if not served. Note that 
    it takes one minute to serve a person and you must begin serving a person at time ti at the latest. You can assume that 
    1≤ci≤100000 and 0≤ti<T.

    Input 1:
    4 4
    1000 1
    2000 2
    500 2
    1200 0
    Output 1:
    4200

    Input 2:
    3 4
    1000 0
    2000 1
    500 1
    Output 2:
    3000
    */
    public class Banker
    {
        public class UserInput
        {
            public Dictionary<int, List<int>> ct = new Dictionary<int, List<int>>();
            public int N, T;
            public UserInput() { }
        }

        private UserInput GetInput()
        {
            UserInput ret = new UserInput();
            string usr_input;
            int x, y;
            string[] temp_usr_input;
            usr_input = Console.ReadLine();
            temp_usr_input = usr_input.Split(' ');
            int.TryParse(temp_usr_input[0], out ret.N);
            int.TryParse(temp_usr_input[1], out ret.T);
            for (int i = 0; i < ret.T; i++)
            {
                ret.ct.Add(i, new List<int>());
            }
            for (int i = 0; i < ret.N; i++)
            {
                usr_input = Console.ReadLine();
                temp_usr_input = usr_input.Split(' ');
                int.TryParse(temp_usr_input[0], out x);
                int.TryParse(temp_usr_input[1], out y);
                ret.ct[y].Add(x);
            }
            return ret;
        }


        private int CalculateTotal(UserInput the_stuff)
        {
            int ret = 0;
            int[] best_choices = new int[the_stuff.T];
            for (int i = the_stuff.T - 1; i >= 0; i--)
            {
                if (the_stuff.ct[i].Count > 0)
                {
                    best_choices[i] = the_stuff.ct[i].Max();
                    the_stuff.ct[i].Remove(the_stuff.ct[i].Max());
                    if (i > 0)
                        the_stuff.ct[i - 1].AddRange(the_stuff.ct[i]);
                }
            }

            for (int m = 0; m < the_stuff.T; m++)
            {
                ret += best_choices[m];
            }
            return ret;
        }

        public string CalculateGreedyChoice(int N = 0, int T = 0, int[] munnies = null, int[] times = null)
        {
            UserInput the_stuff;
            if (munnies == null)
                the_stuff = GetInput();
            else
            {
                the_stuff = new UserInput();
                for (int i = 0; i < T; i++)
                {
                    the_stuff.ct.Add(i, new List<int>());
                }
                for (int i = 0; i < N; i++)
                {
                    the_stuff.ct[times[i]].Add(munnies[i]);
                }
                the_stuff.N = N;
                the_stuff.T = T;
            }

            return CalculateTotal(the_stuff).ToString();
        }

        static void Main(string[] args)
        {
            Banker b = new Banker();
            Console.WriteLine(b.CalculateGreedyChoice());
        }
    }
}
