using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 ****************************** Explanation ******************************
At the Benjamin Franklin School in Broken Fork Saskatchewan, 
the spreading of rumors is strictly regulated.

On Day 0, a student wishing to spread a rumor must notify the school office.
No spreading of the rumor may occur that day.

On Day 1, the student must tell all of his or her friends the rumor before the
end of the day. (Leaving out any friends causes hurt feelings, so this rule is
strictly enforced.) No further spreading of the rumor is allowed that day.

On Day 2, each student who learned of the rumor the previous day must pass the 
rumor along to every friend who has not yet heard the rumor. No further spreading 
of the rumor is allowed that day.

The rumor must continue spreading in this fashion until the day comes that no 
more spreading of the rumor is possible under the rules. On that day, the school 
principal reads the rumor over the intercom, which guarantees that all students 
have heard the rumor.

Following the intercom announcement, the principal must file a report with the 
school board. In the report, the principal must list the student who started the 
rumor, followed by the students (in lexicographic order) who first learned of the 
rumor on Day 1, and so on, ending with the students (in lexicographic order) who 
first learned of the rumor over the intercom.

For example, suppose the student body consists of Cam, Art, Edy, Bea, and Dan, 
where Bea and Edy are friends, Dan and Bea are friends, and Art and Dan are friends.

On Day 0, Dan notifies the office of his plan to start a rumor about the school lunches.

On Day 1, Dan spreads the rumor to his two friends, Bea and Art.

On Day 2, Bea tells her friend Edy. Bea’s other friend (Dan) already knows the rumor, 
as does Art’s only friend (also Dan).

On Day 3, the rules don’t permit anyone else to be told the rumor, since Edy’s only 
friend (Bea) already knows. The principal reads the rumor over the intercom and 
invites everyone to lunch at McDonalds. Cam, who is new to the school and has no 
friends, finally learns what everyone else has been whispering about.

After lunch, the principal fires the lunchroom staff and files the rumor report, 
listing the students in this order: Dan, Art, Bea, Edy, Cam.

Your job is to help the principal prepare rumor reports.

********************************* Input *********************************
The first line contains the number n of students at the school (1≤n≤2000).

The next n lines are student names. Each line contains a single unique name 
(maximum length 20, no embedded white space).

The next line contains the number f of friend pairs at the school (0≤f≤10000).

The next f lines identify friends. Each line contains the names of two students 
who are friends. No one is his or her own friend. A single friend pair never appears 
more than once.

The next line contains the number r of reports that the principal needs to generate 
(1≤r≤2000).

Each of the next r lines is the name of a student who has started a rumor.

********************************* Output *********************************
For each student named in the final section of the input, print the list of students 
that the principal would need to put into a report concerning a rumor started by that 
student. The list should be a single line that contains, in the proper order, the names 
of all the students in the school. The names should be separated by spaces.
*/


namespace PS5_5_Rumor_Mill
{
    public class RumorMill
    {
        /*bfs (G, s) 
            for each u in V
                dist[u] = ∞
                prev[u] = NULL
            dist[s] = 0

            Q = new Queue()
            Q.enq(s)

            while !Q.isEmpty()
                u = Q.deq()
                for each (u,v) in E
                    if dist[v] = ∞
                        Q.enq(v)
                        dist[v] = dist[u] + 1
                        prev[v] = u
        */
        private int[] BFS(int starter, List<int>[] friends, int num_students)
        {
            int[] dist = new int[num_students], prev = new int[num_students];
            int temp;
            Queue<int> Q = new Queue<int>();
            for (int i = 0; i < num_students; i++)
            {
                dist[i] = int.MaxValue;
                prev[i] = -1;
            }
            dist[starter] = 0;
            Q.Enqueue(starter);
            while (Q.Count > 0)
            {
                temp = Q.Dequeue();
                for (int i = 0; i < friends[temp].Count; i++)
                {
                    if (dist[friends[temp][i]] == int.MaxValue)
                    {
                        Q.Enqueue(friends[temp][i]);
                        dist[friends[temp][i]] = dist[temp] + 1;
                        prev[friends[temp][i]] = temp;
                    }
                }
            }
            return dist;
        }

        // For some reason, List<string>.sort is not sorting the way the Kattis problem wants it sorted.
        private string GetReport(int starter, List<int>[] friends, Dictionary<string, int> id_list, string[] names)
        {
            string[] to_cat = new string[id_list.Count];
            int[] dist = BFS(starter, friends, id_list.Count);
            List<string>[] temp = new List<string>[id_list.Count];
            for (int b = 0; b < temp.Length; b++)
            {
                temp[b] = new List<string>();
            }
            int i, j;
            for (i = 0; i < dist.Length; i++)
            {
                if (dist[i] == int.MaxValue)
                    temp[dist.Length - 1].Add(names[i] + " ");
                else
                    temp[dist[i]].Add(names[i] + " ");
            }
            for (j = 0; j < dist.Length; j++)
            {
                temp[j].Sort();
                to_cat[j] = string.Concat(temp[j]);
            }
            return string.Concat(to_cat).Trim();
        }


        /// <summary>
        /// Takes already prepared input and returns results
        /// </summary>
        /// <param name="starters"></param>
        /// <param name="friends"></param>
        /// <param name="id_list"></param>
        /// <returns></returns>
        public string[] GetReports(int[] starters, List<int>[] friends, Dictionary<string, int> id_list, string[] names)
        {
            string[] ret = new string[starters.Length];
            for (int i = 0; i < starters.Length; i++)
            {
                ret[i] = GetReport(starters[i], friends, id_list, names);
            }
            return ret;
        }


        /// <summary>
        /// Gets user input line by line and runs GetReport
        /// </summary>
        /// <returns></returns>
        public string[] RunRumorMill()
        {
            string usr_input;
            int parameter;
            string[] temp_usr_input, names = new string[0];
            int[] starters = new int[0];
            Dictionary<string, int> id_list = new Dictionary<string, int>();
            List<int>[] friends = new List<int>[0];
            // Get input
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
            return GetReports(starters, friends, id_list, names);
        }


        static void Main(string[] args)
        {
            RumorMill RM = new RumorMill();
            string[] results;
            results = RM.RunRumorMill();
            foreach (string res in results)
            {
                Console.WriteLine(res);
            }
        }
    }
}
