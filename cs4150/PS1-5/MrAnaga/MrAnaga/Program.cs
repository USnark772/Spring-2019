using System;
using System.Collections.Generic;
using System.Diagnostics;


/* Q1) Do an experimental complexity analysis to determine the amount of time consumed by your 
 * Mr. Anaga program as a function of n, where k = 5.
 * 
 * Q2) Do an experimental complexity analysis to determine the amount of time consumed by your 
 * Mr. Anaga program as a function of k, where n = 2000.
 * 
 * Q3) When k is held constant, what runtime complexity of your program as a function of n 
 * is suggested by your data? Justify your answer with one or two sentences.
 * 
 * Q4) When n is held constant, what runtime complexity of your program as a function of 
 * k is suggested by your data? Justify your answer with one or two sentences.
 */



namespace MrAnaga
{
    class Program
    {

        /// <summary>
        /// Makes num_words number of random words of length num_letters
        /// </summary>
        /// <param name="num_words"></param>
        /// <param name="num_letters"></param>
        /// <returns></returns>
        static string[] MakeRandomWords(int num_words, int num_letters)
        {
            char[] letters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            char[] word_letters = new char[num_letters];
            string[] words = new string[num_words];
            Random rand = new Random();
            for(int i = 0; i < num_words; i++)
            {
                for(int j = 0; j < num_letters; j++)
                {
                    word_letters[j] = letters[rand.Next(0, 25)];
                }
                words[i] = new string(word_letters);
            }
            return words;
        }


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


        static void RunExperiment(int iters, int n, int k, int double_target)
        {
            Stopwatch timer = new Stopwatch();
            string[] the_words;
            int i, j, m;
            Console.WriteLine("num_words\tnum_letters\ttime taken\titeration");
            for (i = 0; i < iters; i++)
            {
                timer.Start();
                for (j = 0; j < iters; j++)
                {
                    the_words = MakeRandomWords(n, k);
                    MrAnagaMethod(n, k, the_words);
                }
                timer.Stop();
                double first_try = msecs(timer) / iters;
                timer = new Stopwatch();
                timer.Start();
                for (m = 0; m < iters; m++)
                {
                    the_words = MakeRandomWords(n, k);
                    //MrAnagaMethod(numbers[0], numbers[1], the_words);
                }
                timer.Stop();
                double second_try = msecs(timer) / iters;
                Console.WriteLine("{0}\t         {1}\t    {2}\t     {3}", n, k, first_try - second_try, i);
                if (double_target == 1)
                    n *= 2;
                else if (double_target == 2)
                    k *= 2;
            }
            Console.WriteLine("Done");
            Console.Read();
        }


        static void Main(string[] args)
        {
            Console.Write("Enter iters: ");
            int iters = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter starting num_words: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter starting num_letters: ");
            int k = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter 1 for doubling num_words or 2 for doubling num_letters: ");
            int double_target = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            RunExperiment(iters, n, k, double_target);

            /*
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
            */
            return;
        }
    }
}
