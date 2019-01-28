using System;
using System.Collections.Generic;


namespace PS3_5_Galaxy_Quest
{
    class Program
    {
        /// <summary>
        /// Finds and returns the majority element if it exists, else returns -1.
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        static long FindMajority(List<long> A)
        {
            int even_or_odd = A.Count % 2;
            long x, occurences;
            List<long> Aprime = new List<long>();
            if (A.Count == 0)
                return -1;
            else if (A.Count == 1)
                return A[0];
            else
            {
                for (int i = 0; i < A.Count - 1; i += 2)
                {
                    if (A[i] == A[i + 1])
                        Aprime.Add(A[i]);
                }
                x = FindMajority(Aprime);
                if (x < 0)
                {
                    if (even_or_odd == 1)
                    {
                        occurences = CountOccurences(A, A[A.Count - 1]);
                        if (occurences > A.Count / 2)
                            return A[A.Count - 1];
                        else return -1;
                    }
                    else
                        return -1;
                }
                else
                {
                    occurences = CountOccurences(A, x);
                    if (occurences > A.Count / 2)
                        return x;
                    else return -1;
                }
            }
        }

        /// <summary>
        /// Count occurences of element in given list.
        /// </summary>
        /// <param name="A">List</param>
        /// <param name="b">element</param>
        /// <returns></returns>
        static int CountOccurences(List<long> A, long b)
        {
            int ret = 0;
            for (int i = 0; i < A.Count; i++)
            {
                if (A[i] == b)
                    ret++;
            }
            return ret;
        }


        static int CountOccurencesStar(List<long[]> A, long[] b, long dSquared)
        {
            int ret = 0;
            long xSquared, ySquared;
            for (int i = 0; i < A.Count; i++)
            {
                xSquared = FastMult((A[i][0] - b[0]), (A[i][0] - b[0]));
                ySquared = FastMult((A[i][1] - b[1]), (A[i][1] - b[1]));
                if (xSquared + ySquared <= dSquared)
                    ret++;
            }
            return ret;
        }


        static long[] FindMajorityStar(List<long[]> A, long dSquared)
        {
            int even_or_odd = A.Count % 2, occurences;
            long[] x, false_ret = { -1, -1 };
            List<long[]> Aprime = new List<long[]>();
            if (A.Count == 0)
                return false_ret;
            else if (A.Count == 1)
                return A[0];
            else
            {
                for (int i = 0; i < A.Count - 1; i += 2)
                {
                    if (A[i] == A[i + 1])
                        Aprime.Add(A[i]);
                }
                x = FindMajorityStar(Aprime, dSquared);
                if (x[0] < 0)
                {
                    if (even_or_odd == 1)
                    {
                        occurences = CountOccurencesStar(A, A[A.Count - 1], dSquared);
                        if (occurences > A.Count / 2)
                            return A[A.Count - 1];
                        else return false_ret;
                    }
                    else
                        return false_ret;
                }
                else
                {
                    occurences = CountOccurencesStar(A, x, dSquared);
                    if (occurences > A.Count / 2)
                        return x;
                    else return false_ret;
                }
            }
        }


        static long FastMult(long a, long b)
        {
            return a * b;
        }
        

        static long CalculateGalaxies(List<long[]> stars, int d, int k)
        {
            long ret = 0;
            for (long i = 0; i < k; i += 2)
            {

            }



            if (ret > 0)
                return ret;
            else
                return -1;
        }

        static void Main(string[] args)
        {
            string usr_input;
            string[] temp_nums;
            int[] parameters;
            long[] temp_star;
            List<long[]> stars = new List<long[]>();
            long result;


            // Get galactic diameter d and star count k 
            // as parameters[0] and parameters[1] respectively.
            usr_input = Console.ReadLine();
            temp_nums = usr_input.Split(' ');
            parameters = Array.ConvertAll<string, int>(temp_nums, int.Parse);
            // Exactly k stars to read in.
            for (long i = 0; i < parameters[1] * 2; i += 2)
            {
                usr_input = Console.ReadLine();
                temp_nums = usr_input.Split(' ');
                temp_star = Array.ConvertAll<string, long>(temp_nums, long.Parse);
                stars.Add(temp_star);
            }

            result = CalculateGalaxies(stars, parameters[0], parameters[1]);
            if (result > 0)
                Console.WriteLine(result);
            else
                Console.WriteLine("NO");

            Console.Read();
        }
    }
}
