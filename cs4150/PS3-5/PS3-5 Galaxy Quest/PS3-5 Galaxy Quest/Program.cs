using System;
using System.Collections.Generic;



/*
 * Each PU is a 2D square 10^9 by 10^9
 * Each PU has Galactic Diameter d where d is an integer
 * Each star is ecatly x light years from its universe's left edge and y light years from its universe's bottom edge,
 *      where x and y are non-negative integers
 * Stars are clustered into galaxies. Each galaxy consist of one or more stars. each star is at most
 *      d light years from every other star in its galaxy. Any two stars from different galaxies are
 *      more than d light years apart
 * 
 * Input:
 *      Each input describes a single PU. All numbers in the input are integers.
 *      
 *      The first line is Galactic diameter 1 <= d <= 10^6 and star count 1 <= k <= 10^6
 *      
 *      There are exactly k more lines. Each line contains 0<=x<=10^9 and 0<=y<=10^9. no two lines are identical
 *      
 *      The input is guaranteed to obey the clustering constraint described above
 *      
 * Output:
 *      If the PU described by the input has a galaxy containing more than half of the stars, display the number of stars
 *      in the galaxy. Otherwise display NO
 *      
 *      
 * Majority element algorithm will be best here.
 * Use long instead of int for x and y
*/

/* GetInput()
 * Calculate(stars)
 * {
 *      FindMajority(stars)
 *      if(have majority)
 *          return number of majority
 *      else return false
 * }
 * ReturnOutput()
*/




namespace PS3_5_Galaxy_Quest
{
    class Program
    {
        #region Majority ALgorithm
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
        #endregion

        static bool IsInGalaxy(long[] a, long[] b, long dSquared)
        {
            long xSquared, ySquared;
            xSquared = FastMult((a[0] - b[0]), (a[0] - b[0]));
            ySquared = FastMult((a[1] - b[1]), (a[1] - b[1]));
            if (xSquared + ySquared <= dSquared)
                return true;
            return false;
        }

        static int CountOccurencesStar(List<long[]> A, long[] b, long dSquared)
        {
            int ret = 0;
            for (int i = 0; i < A.Count; i++)
            {
                if (IsInGalaxy(A[i], b, dSquared))
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
                    if (IsInGalaxy(A[i], A[i + 1], dSquared))
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
            int ret = 0;
            long[] the_star;
            long dSquared = d * d;
            the_star = FindMajorityStar(stars, dSquared);
            for (int i = 0; i < stars.Count; i++)
            {
                if (IsInGalaxy(the_star, stars[i], dSquared))
                    ret++;
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
