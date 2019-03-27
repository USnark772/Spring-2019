using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS9_5_Under_The_Rainbow
{

    /*
    You are planning a drive along the Yellow Brick Road from Munchkinland to Emerald City. There are n+1 hotels along the route, 
    numbered 0 through n. Hotel 0 is in Munchkinland and hotel n is in Emerald City.

    The distance in miles from Munchkinland to hotel i is distance[i], where 0=distance[0]<distance[1]<….<distance[n]. The first 
    hotel is in Munchkinland and is (of course) zero miles from Munchkinland, and the final hotel is in Emerald City.

    You start in Munchkinland on the morning of day 1, having stayed in the Munchkinland hotel the night before. At the end of 
    each day you must stay in one of the hotels; at the end of the last day you must stay in the Emerald City hotel; you may never 
    turn around and drive back toward Munchkinland.

    The Good Witch of the North is paying for your trip. She doesn’t want you to drive too far each day (that isn’t safe) or too
    little each day (that’s too expensive). She wants you to drive approximately 400 miles each day, so she makes the following deal.
    Each day you will drive some distance x to reach a hotel. You will owe her a penalty of (400−x)2 cents for that day. At the end 
    of the trip you will owe her the sum of all the penalties you have amassed.

    You, of course, want to minimize the total penalty. For example, suppose

    distance = [0, 350, 450, 825].
    The optimal strategy is to drive to hotel 2 on the first day (penalty 2500) and then to hotel 3 the second day (penalty 625), 
    for a total penalty of 3125 cents.

    On the other hand, suppose

    distance = [0, 350, 450, 700].
    The optimal strategy is to drive to hotel 1 on the first day (penalty 2500) and then hotel 3 the second day (penalty 2500), 
    for a total penalty of 5000 cents.

    Given an array of distances, you are to determine the minimum possible penalty that can accumulate when driving from
    Munchkinland to Emerald City.

    Input
    The first line contains n, where 1≤n≤1000. The next n+1 lines give the elements of the hotel distance array described above. 
    The first element is 0; each successive element is larger than its predecessor; the last element is less than 30000.

    Output
    Produce a single line of input that contains the minimum penalty for the trip.


    Sample input 1
    3
    0
    350
    450
    825
    Sample output 1
    3125

    Sample input 2
    3
    0
    350
    450
    700
    Sample output 2
    5000
    */
    class RouteMaker
    {
        /// <summary>
        /// Get well formed input line by line from console
        /// </summary>
        /// <returns></returns>
        private int[] GetInput()
        {
            int[] ret;
            string usr_input;
            usr_input = Console.ReadLine();
            int n = int.Parse(usr_input);
            ret = new int[n + 1];
            for (int i = 0; i < n + 1; i++)
            {
                ret[i] = int.Parse(Console.ReadLine());
            }
            return ret;
        }


        private long Penalty(int k, int[] distance)
        {
            long ret, temp;
            if (k == distance.Length - 1) // At Emerald City, no further trips to make
                ret = 0;
            else
            {
                temp = 400 - (distance[k + 1] - distance[k]);
                ret = (temp * temp) + Penalty(k + 1, distance);
                for (int j = k + 2; j < distance.Length - 1; j++)
                {
                    temp = 400 - (distance[j] - distance[k]);
                    ret = Math.Min(ret, (temp * temp) + Penalty(j, distance));
                }
            }
            return ret;
        }

        /// <summary>
        /// Calculate the minimum penalty
        /// </summary>
        private long CalculateTotalMinPenalty(int[] distance)
        {
            return Penalty(0, distance);
        }

        private void GiveOutput(long result)
        {
            Console.WriteLine(result);
        }

        static void Main(string[] args)
        {
            RouteMaker RM = new RouteMaker();
            int[] input = RM.GetInput();
            RM.GiveOutput(RM.CalculateTotalMinPenalty(input));
            Console.Read();
        }
    }
}
