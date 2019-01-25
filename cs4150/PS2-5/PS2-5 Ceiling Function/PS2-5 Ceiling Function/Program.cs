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
        /// <summary>
        /// Compare two BSTs based on shape of tree
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static int CompareTrees(ref Node a, ref Node b)
        {
            int res1, res2;
            // If both nodes empty, shape so far is equivalent.
            if (a == null && b == null)
            {
                return 1;
            }
            // If both nodes not empty, compare left and right of both trees.
            // If both compares return true then pass that back up.
            else if (a != null && b != null)
            {
                res1 = CompareTrees(ref a.left, ref b.left);
                res2 = CompareTrees(ref a.right, ref b.right);
                if (res1 == 1 && res2 == 1)
                {
                    return 1;
                }
            }
            // Trees not equivalent so return false
            return 0;
        }

        /// <summary>
        /// Make an integer BST given an array of numbers, 
        /// an empty starting node, and a range.
        /// </summary>
        /// <param name="the_nums"> The array of integers</param>
        /// <param name="node"> The empty starting node</param>
        /// <param name="end"> The range</param>
        static void MakeTree(ref int[] the_nums, ref Node node, int end)
        {
            // Make first node from first element.
            node = new Node(the_nums[0]);
            // For each element after first, add to tree.
            for (int i = 1; i < end; i++)
            {
                AddIntToTree(the_nums[i], ref node);
            }
        }

        /// <summary>
        /// Recursively add an integer to a BST.
        /// </summary>
        /// <param name="the_num">The integer to add</param>
        /// <param name="node">BST root node</param>
        static void AddIntToTree(int the_num, ref Node node)
        {
            // If item to add greater than node being looked at and no right child,
            // add item as right child, else keep looking
            if(the_num > node.ID)
            {
                if (node.right == null)
                {
                    node.right = new Node(the_num);
                }
                else
                {
                    AddIntToTree(the_num, ref node.right);
                }
            }
            // If item to add greater than node being looked at and no left child,
            // add item as left child, else keep looking
            else if (the_num < node.ID)
            {
                if (node.left == null)
                {
                    node.left = new Node(the_num);
                }
                else
                {
                    AddIntToTree(the_num, ref node.left);
                }
            }
        }

        /// <summary>
        /// Recursively traverse the tree
        /// </summary>
        /// <param name="node"></param>
        static void TraverseTree(ref Node node)
        {
            if(node != null)
            {
                Console.WriteLine(node.ID);
                if(node.left != null)
                {
                    Console.WriteLine("Going left from: " + node.ID);
                    TraverseTree(ref node.left);
                }
                if(node.right != null)
                {
                    Console.WriteLine("Going right from: " + node.ID);
                    TraverseTree(ref node.right);
                }
            }
        }

        static void Main(string[] args)
        {
            string usr_input;
            string[] temp_nums;
            int[] parameters, the_nums;
            Node[] trees;

            // Get parameters from user
            usr_input = Console.ReadLine();
            temp_nums = usr_input.Split(' ');
            parameters = Array.ConvertAll<string, int>(temp_nums, int.Parse);
            trees = new Node[parameters[0]];

            // Get tree data from user
            for (int i = 0; i < parameters[0]; i++)
            {
                usr_input = Console.ReadLine();
                temp_nums = usr_input.Split(' ');
                the_nums = new int[parameters[1]];
                for (int j = 0; j < parameters[1]; j++)
                {
                    the_nums[j] = Int32.Parse(temp_nums[j]);
                }
                MakeTree(ref the_nums, ref trees[i], parameters[1]);
            }

            /*
            // Ensure tree looks right
            for (int b = 0; b < parameters[0]; b++)
            {
                Console.WriteLine("Traversing tree" + b);
                TraverseTree(ref trees[b]);
            }
            */


            // Find matches
            HashSet<Node> accepted = new HashSet<Node>();
            HashSet<Node> declined = new HashSet<Node>();
            for (int k = 0; k < parameters[0]; k++)
            {
                accepted.Add(trees[k]);
                for (int m = k+1; m < parameters[0]; m++)
                {
                    accepted.Add(trees[m]);
                    if(CompareTrees(ref trees[k], ref trees[m]) == 1)
                    {
                        //Console.WriteLine("Found a match between " + k + " and " + m);
                        declined.Add(trees[k]);
                        declined.Add(trees[m]);
                        accepted.Remove(trees[k]);
                        accepted.Remove(trees[m]);
                    }
                }
            }
            // Output result
            //Console.WriteLine("Num different :" + accepted.Count);
            Console.WriteLine(accepted.Count);
            Console.Read();
        }
    }
}
