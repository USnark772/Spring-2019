using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS4_5_Auto_Sink
{
    class AutoSinker
    {
        static void Main(string[] args)
        {
            string usr_input;
            int parameter, result = -1;
            string[] temp_usr_input;
            Dictionary<string, int> tolls;
            Tuple<string, string>[] trips;


            AutoSinker AS = new AutoSinker();
            // Get input
            for (int j = 0; j < 3; j++)
            {
                usr_input = Console.ReadLine();
                parameter = int.Parse(usr_input);
                if (j == 0)
                {
                    tolls = new Dictionary<string, int>();
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

                    }
                }
                else
                {
                    trips = new Tuple<string, string>[j];
                    // Get trips
                    for (int t = 0; t < parameter; t++)
                    {

                    }
                }
            }
            // Print out answer.
            if (result > -1)
                Console.WriteLine(result);
            else
                Console.WriteLine("NO");
            Console.Read();
        }
    }
}
