using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS8_6_Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            string usr_input;
            string[] temp_usr_input;
            int N, T;
            int[] a, b;
            usr_input = Console.ReadLine();
            temp_usr_input = usr_input.Split(' ');
            int.TryParse(temp_usr_input[0], out N);
            int.TryParse(temp_usr_input[1], out T);
            a = new int[N];
            b = new int[N];
            for (int i = 0; i < N; i++)
            {
                usr_input = Console.ReadLine();
                temp_usr_input = usr_input.Split(' ');
                int.TryParse(temp_usr_input[0], out a[i]);
                int.TryParse(temp_usr_input[1], out b[i]);
            }
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine("a = " + a[i] + ", b = " + b[i]);
            }
            Console.Read();
        }
    }
}
