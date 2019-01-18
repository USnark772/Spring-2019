using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MrAnaga
{
    class Program
    {

        public static double msecs(Stopwatch sw)
        {
            return (((double)sw.ElapsedTicks) / Stopwatch.Frequency) * 1000;
        }
        /// <summary>
        /// Sort a string alphabetically
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        static string AlphaSortString(string word)
        {
            char[] chars = word.ToCharArray();
            Array.Sort(chars);
            return new string(chars);
        }


        // Iterate through given words, sort the letters in each word and then compare
        // words looking for matches, reduce count of unique words by 1 for each set 
        // of letters that appears more than once
        static int CountUnique(int num_words, int word_len, string[] the_words)
        {
            int num_unique = num_words, i, j;
            int[] indices = new int[num_words];
            HashSet<string> accepted = new HashSet<string>();
            HashSet<string> declined = new HashSet<string>();
            // Sort letters in each word, if words are anagrams they should have the same letters.
            for (i = 0; i < num_words; i++)
            {
                the_words[i] = AlphaSortString(the_words[i]);
            }

            // Maybe optimize this?
            // Compare the results to find matches
            for (i = 0; i < num_words; i++)
            {
                if (accepted.Contains(the_words[i]))
                {
                    accepted.Remove(the_words[i]);
                    declined.Add(the_words[i]);
                }
                else if (!declined.Contains(the_words[i]))
                {
                    accepted.Add(the_words[i]);
                }
            }

            // Return count
            return accepted.Count;
        }


        static int MrAnagaMethod(int n, int k, string[] the_words)
        {
            return CountUnique(n, k, the_words);
        }


        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            string temp;
            int[] numbers = new int[2];
            string[] the_words, temp_nums;
            int i, iterations = 100;

            // Get parameters
            temp = Console.ReadLine();
            temp_nums = temp.Split(' ');
            numbers = Array.ConvertAll<string, int>(temp_nums, int.Parse);

            // Get words
            the_words = new string[numbers[0]];
            for (i = 0; i < numbers[0]; i++)
            {
                the_words[i] = Console.ReadLine();
            }

            // Calculate and print the result

            timer.Start();
            for (i = 0; i < iterations; i++)
            {
                Console.WriteLine(MrAnagaMethod(numbers[0], numbers[1], the_words));
            }
            timer.Stop();
            Console.WriteLine("Runtime = " + msecs(timer));
            Console.Read();
            return;
        }
    }
}
