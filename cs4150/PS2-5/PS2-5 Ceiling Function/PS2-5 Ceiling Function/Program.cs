using System;
using System.Collections.Generic;

namespace PS2_5_Ceiling_Function
{
    public class Node
    {
        public int ID;
        public Node left;
        public Node right;
        public Node(int id)
        {
            ID = id;
        }
    }

    class CeilingFunc
    {
        static void MakeTree(ref int[] the_nums, ref Node root, int start, int end)
        {
            if (start > end)
            {
                root = null;
            }
            else if (start == end)
            {
                root = new Node(the_nums[start]);
            }
            else
            {
                int split = (start + end) / 2;
                root = new Node(the_nums[split]);
                MakeTree(ref the_nums, ref root.left, start, split - 1);
                MakeTree(ref the_nums, ref root.right, split + 1, end);
            }
        }

        static void Main(string[] args)
        {
            string temp;
            string[] temp_nums;
            int[] numbers;
            temp = Console.ReadLine();
            temp_nums = temp.Split(' ');
            numbers = Array.ConvertAll<string, int>(temp_nums, int.Parse);
            Node[] trees = new Node[numbers[0]];

            // Get trees
            int[] the_nums;
            for (int i = 0; i < numbers[0]; i++)
            {
                temp = Console.ReadLine();
                temp_nums = temp.Split(' ');
                the_nums = new int[numbers[1]];
                for (int j = 0; j < numbers[1]; j++)
                {
                    the_nums[j] = Int32.Parse(temp_nums[j]);
                }
                trees[i] = new Node(the_nums[0]);
                MakeTree(ref the_nums, ref trees[i], 1, numbers[1]);
            }
            Console.Read();
        }
    }
}
