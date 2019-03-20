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
            public int[] munnies, times;
            public int N, T;
            public UserInput() {}
        }
        private UserInput GetInput()
        {
            UserInput ret = new UserInput();
            string usr_input;
            string[] temp_usr_input;
            usr_input = Console.ReadLine();
            temp_usr_input = usr_input.Split(' ');
            int.TryParse(temp_usr_input[0], out ret.N);
            int.TryParse(temp_usr_input[1], out ret.T);
            ret.munnies = new int[ret.N];
            ret.times = new int[ret.N];
            for (int i = 0; i < ret.N; i++)
            {
                usr_input = Console.ReadLine();
                temp_usr_input = usr_input.Split(' ');
                int.TryParse(temp_usr_input[0], out ret.munnies[i]);
                int.TryParse(temp_usr_input[1], out ret.times[i]);
            }
            return ret;
        }


        private int CalculateTotal(UserInput the_stuff)
        {
            int ret = 0;
            int[] best_choices = new int[the_stuff.T];

            for (int j = 0; j < the_stuff.T; j++)
            {
                best_choices[j] = 0;
            }

            for (int b = 0; b < the_stuff.N; b++)
            {
                if (best_choices[the_stuff.times[b]] < the_stuff.munnies[b])
                    best_choices[the_stuff.times[b]] = the_stuff.munnies[b];
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
                the_stuff.munnies = munnies;
                the_stuff.times = times;
                the_stuff.N = N;
                the_stuff.T = T;
            }

            string ret = CalculateTotal(the_stuff).ToString();
            return ret;
        }

        static void Main(string[] args)
        {
            Banker b = new Banker();
            Console.WriteLine(b.CalculateGreedyChoice());
            Console.Read();
        }
    }
}
