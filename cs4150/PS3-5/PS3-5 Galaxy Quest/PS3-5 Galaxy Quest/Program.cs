using System;
using System.Collections.Generic;

namespace PS3_5_Galaxy_Quest
{
    public class GalaxyQuester
    {
        private bool IsInGalaxy(long[] a, long[] b, long dSquared)
        {
            long diffx, diffy, xSquared, ySquared;
            // Calculate distance formula for the given elements using distance of dSquared.
            diffx = (a[0] - b[0]);
            diffy = (a[1] - b[1]);
            xSquared = FastMult(diffx, diffx);
            ySquared = FastMult(diffy, diffy);
            if (xSquared + ySquared <= dSquared)
                return true;
            return false;
        }

        private int CountOccurencesStar(List<long[]> A, long[] b, long dSquared)
        {
            int ret = 0;
            // for each element of list A, compare to element b and count true.
            for (int i = 0; i < A.Count; i++)
            {
                if (IsInGalaxy(A[i], b, dSquared))
                    ret++;
            }
            return ret;
        }

        private long[] FindMajorityStar(List<long[]> A, long dSquared)
        {
            // Calculate if even or odd length list.
            int even_or_odd = A.Count % 2, occurences, half_len;
            // Prepare to return false.
            long[] x, false_ret = { -1, -1 };
            List<long[]> Aprime = new List<long[]>();
            // If list is empty, no majority element.
            if (A.Count == 0)
                return false_ret;
            // If list contains one element, that is the majority element.
            else if (A.Count == 1)
                return A[0];
            else
            {
                if (even_or_odd == 1)
                    half_len = (A.Count - 1) / 2;
                else
                    half_len = A.Count / 2;
                // Split into pairs and find elements that are in the same galaxy
                // or in other words, find "same" elements.
                for (int i = 0; i < A.Count - 1; i += 2)
                {
                    if (IsInGalaxy(A[i], A[i + 1], dSquared))
                        Aprime.Add(A[i]);
                }
                // Find majority element of candidates.
                x = FindMajorityStar(Aprime, dSquared);
                if (x[0] < 0)
                {
                    // Didn't find a majority element.
                    if (even_or_odd == 1)
                    {
                        // See if last element in list is majority element.
                        occurences = CountOccurencesStar(A, A[A.Count - 1], dSquared);
                        if (occurences > half_len)
                            return A[A.Count - 1];
                        else return false_ret;
                    }
                    // No majority element found.
                    else
                        return false_ret;
                }
                else
                {
                    // x was a majority element, see if still a majority element.
                    occurences = CountOccurencesStar(A, x, dSquared);
                    if (occurences > half_len)
                        return x;
                    else return false_ret;
                }
            }
        }

        private long FastMult(long a, long b)
        {
            // Not yet optimized for large numbers.
            return a * b;
        }

        public long CalculateGalaxies(List<long[]> stars, int d, int k)
        {
            // Set ret for false.
            int ret = -1;
            long[] the_star;
            // Square d for use in distance formula.
            long dSquared = d * d;
            // Find the majority element. Returns a { -1, -1 } star 
            // for no majority element.
            the_star = FindMajorityStar(stars, dSquared);
            if (the_star[0] > -1)
            {
                ret = 0;
                // Count all stars near given star. This will count the given star as well.
                for (int i = 0; i < stars.Count; i++)
                {
                    if (IsInGalaxy(the_star, stars[i], dSquared))
                        ret++;
                }
            }
            // return result.
            if (ret > 0)
                return ret;
            else
                return -1;
        }

        public GalaxyQuester() { }

        public static void Main(string[] args)
        {
            string usr_input;
            string[] temp_nums;
            int[] parameters;
            long[] temp_star = { 3, 8 };
            List<long[]> stars = new List<long[]>();
            long result = -1;
            GalaxyQuester GQ = new GalaxyQuester();
            // Get galactic diameter d and star count k 
            // as parameters[0] and parameters[1] respectively.
            usr_input = Console.ReadLine();
            temp_nums = usr_input.Split(' ');
            parameters = Array.ConvertAll<string, int>(temp_nums, int.Parse);
            // Exactly k stars to read in.
            if (parameters[1] > 0)
            {
                for (long i = 0; i < parameters[1] * 2; i += 2)
                {
                    usr_input = Console.ReadLine();
                    temp_nums = usr_input.Split(' ');
                    temp_star = Array.ConvertAll<string, long>(temp_nums, long.Parse);
                    stars.Add(temp_star);
                }
                // Calculate result.
                result = GQ.CalculateGalaxies(stars, parameters[0], parameters[1]);
            }
            // Print out answer.
            if (result > 0)
                Console.WriteLine(result);
            else
                Console.WriteLine("NO");
            Console.Read();
        }
    }
}
