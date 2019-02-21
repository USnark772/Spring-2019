using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PS6_6_v2
{
    public class Program
    {
        public void RunProgram()
        {
            string usr_input;
            int n = 0, m = 0;
            string[] temp_usr_input;
            List<int[]> corridors = new List<int[]>();
            // Get input



            usr_input = Console.ReadLine();
            temp_usr_input = usr_input.Split(' ');
            while (!(temp_usr_input[0] == "0" && temp_usr_input[1] == "0"))
            {
                int.TryParse(temp_usr_input[0], out m);
                int.TryParse(temp_usr_input[1], out n);
                int[] temp = new int[m];
                // get the test case
                for (int i = 0; i < m; i++)
                {
                    usr_input = Console.ReadLine();
                    temp_usr_input = usr_input.Split(' ');
                    // Need to change this because it's not saving the data properly
                }
                corridors.Add(temp);
                temp_usr_input = usr_input.Split(' ');
                usr_input = Console.ReadLine();
            }

            /*
            for (int j = 0; j < 3; j++)
            {
                usr_input = Console.ReadLine();
                parameter = int.Parse(usr_input);
                if (j == 0)
                {
                    friends = new List<int>[parameter];
                    names = new string[parameter];
                    // Get student names (len <= 20, no repeated names)
                    for (int n = 0; n < parameter; n++)
                    {
                        usr_input = Console.ReadLine();
                        id_list.Add(usr_input, n);
                        names[n] = usr_input;
                    }
                }
                else if (j == 1)
                {
                    for (int i = 0; i < friends.Length; i++)
                    {
                        friends[i] = new List<int>();
                    }
                    // Get friend pairs (No links to self, no repeated pairs)
                    for (int f = 0; f < parameter; f++)
                    {
                        usr_input = Console.ReadLine();
                        temp_usr_input = usr_input.Split(' ');
                        friends[id_list[temp_usr_input[0]]].Add(id_list[temp_usr_input[1]]);
                        friends[id_list[temp_usr_input[1]]].Add(id_list[temp_usr_input[0]]);
                    }
                }
                else
                {
                    if (parameter > 0)
                    {
                        starters = new int[parameter];
                        // Get rumor starters. (Could be duplicates?)
                        for (int r = 0; r < parameter; r++)
                        {
                            usr_input = Console.ReadLine();
                            starters[r] = id_list[usr_input];
                        }
                    }
                }
            }
            */
        }


        static void Main(string[] args)
        {
            Program do_it = new Program();
            do_it.RunProgram();
        }
    }
}
