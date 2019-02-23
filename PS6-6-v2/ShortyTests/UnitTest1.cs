using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PS6_6_v2;

namespace ShortyTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Program do_it = new Program();
            Dictionary<int, List<Tuple<int, double>>>[] corridors = new Dictionary<int, List<Tuple<int, double>>>[2];
            Tuple<int, int>[] edges = new Tuple<int, int>[] {
                new Tuple<int, int>(0, 1),
                new Tuple<int, int>(1, 2),
                new Tuple<int, int>(0, 2),
                new Tuple<int, int>(1, 0) };
            int[] num_per_test = new int[] { 3, 1, 1 };
            double[] weights = new double[] { 0.9, 0.9, 0.8, 1.0 };
            double[] answers = new double[] { 0.8100, 1.0000 };
            int j = 0, next_set_cap = 0;
            for (int i = 0; i < corridors.Length; i++)
            {
                next_set_cap += num_per_test[i];
                corridors[i] = new Dictionary<int, List<Tuple<int, double>>>();
                for (; j < next_set_cap; j++)
                {
                    if (!corridors[i].ContainsKey(edges[j].Item1))
                        corridors[i].Add(edges[j].Item1, new List<Tuple<int, double>>());
                    if (!corridors[i].ContainsKey(edges[j].Item2))
                        corridors[i].Add(edges[j].Item2, new List<Tuple<int, double>>());
                    corridors[i][edges[j].Item1].Add(new Tuple<int, double>(edges[j].Item2, weights[j]));
                    corridors[i][edges[j].Item2].Add(new Tuple<int, double>(edges[j].Item1, weights[j]));
                }
            }

            for (int i = 0; i < corridors.Length; i++)
            {
                Assert.AreEqual(answers[i], do_it.RunTest(corridors[i], corridors[i].Count));
            }
        }

        /*
         * 4 5
         * 0 1 0.9
         * 1 2 0.9
         * 0 2 0.8
         * 0 3 0
         * 2 3 0.0001
         * 
         * 0.0001
         */
        [TestMethod]
        public void GarinTest1()
        {
            Program do_it = new Program();
            Dictionary<int, List<Tuple<int, double>>>[] corridors = new Dictionary<int, List<Tuple<int, double>>>[1];
            Tuple<int, int>[] edges = new Tuple<int, int>[] {
                new Tuple<int, int>(0, 1),
                new Tuple<int, int>(1, 2),
                new Tuple<int, int>(0, 2),
                new Tuple<int, int>(0, 3),
                new Tuple<int, int>(2, 3) };
            int[] num_per_test = new int[] { 5 };
            double[] weights = new double[] { 0.9, 0.9, 0.8, 0.0, 0.0001 };
            double[] answers = new double[] { 0.0001 };
            int j = 0, next_set_cap = 0;
            for (int i = 0; i < corridors.Length; i++)
            {
                next_set_cap += num_per_test[i];
                corridors[i] = new Dictionary<int, List<Tuple<int, double>>>();
                for (; j < next_set_cap; j++)
                {
                    if (!corridors[i].ContainsKey(edges[j].Item1))
                        corridors[i].Add(edges[j].Item1, new List<Tuple<int, double>>());
                    if (!corridors[i].ContainsKey(edges[j].Item2))
                        corridors[i].Add(edges[j].Item2, new List<Tuple<int, double>>());
                    corridors[i][edges[j].Item1].Add(new Tuple<int, double>(edges[j].Item2, weights[j]));
                    corridors[i][edges[j].Item2].Add(new Tuple<int, double>(edges[j].Item1, weights[j]));
                }
            }

            for (int i = 0; i < corridors.Length; i++)
            {
                Assert.AreEqual(answers[i], do_it.RunTest(corridors[i], corridors[i].Count));
            }
        }

        /*
         * 2 1
         * 1 0 1
         * 
         * 1.0000
         */
        [TestMethod]
        public void GarinTest2()
        {
            Program do_it = new Program();
            Dictionary<int, List<Tuple<int, double>>>[] corridors = new Dictionary<int, List<Tuple<int, double>>>[1];
            Tuple<int, int>[] edges = new Tuple<int, int>[] {
                new Tuple<int, int>(1, 0) };
            int[] num_per_test = new int[] { 1 };
            double[] weights = new double[] { 1 };
            double[] answers = new double[] { 1.0000 };
            int j = 0, next_set_cap = 0;
            for (int i = 0; i < corridors.Length; i++)
            {
                next_set_cap += num_per_test[i];
                corridors[i] = new Dictionary<int, List<Tuple<int, double>>>();
                for (; j < next_set_cap; j++)
                {
                    if (!corridors[i].ContainsKey(edges[j].Item1))
                        corridors[i].Add(edges[j].Item1, new List<Tuple<int, double>>());
                    if (!corridors[i].ContainsKey(edges[j].Item2))
                        corridors[i].Add(edges[j].Item2, new List<Tuple<int, double>>());
                    corridors[i][edges[j].Item1].Add(new Tuple<int, double>(edges[j].Item2, weights[j]));
                    corridors[i][edges[j].Item2].Add(new Tuple<int, double>(edges[j].Item1, weights[j]));
                }
            }

            for (int i = 0; i < corridors.Length; i++)
            {
                Assert.AreEqual(answers[i], do_it.RunTest(corridors[i], corridors[i].Count));
            }
        }

        /*
         * 8 10
         * 0 1 0.5
         * 1 3 0.75
         * 3 4 1
         * 4 6 0.355
         * 5 6 1
         * 5 7 0.9999
         * 1 4 0.8
         * 4 7 0.333
         * 4 0 0.11
         * 7 3 0.8933
         * 
         * 0.3573
         */
        [TestMethod]
        public void GarinTest3()
        {
            int n_val = 8;
            Program do_it = new Program();
            Dictionary<int, List<Tuple<int, double>>>[] corridors = new Dictionary<int, List<Tuple<int, double>>>[1];
            Tuple<int, int>[] edges = new Tuple<int, int>[] {
                new Tuple<int, int>(0, 1),
                new Tuple<int, int>(1, 3),
                new Tuple<int, int>(3, 4),
                new Tuple<int, int>(4, 6),
                new Tuple<int, int>(5, 6),
                new Tuple<int, int>(5, 7),
                new Tuple<int, int>(1, 4),
                new Tuple<int, int>(4, 7),
                new Tuple<int, int>(4, 0),
                new Tuple<int, int>(7, 3), };
            int[] num_per_test = new int[] { 10 };
            double[] weights = new double[] { 0.5, 0.75, 1, 0.355, 1, 0.9999, 0.8, 0.333, 0.11, 0.8933 };
            double[] answers = new double[] { 0.3573 };
            int j = 0, next_set_cap = 0;
            for (int i = 0; i < corridors.Length; i++)
            {
                next_set_cap += num_per_test[i];
                corridors[i] = new Dictionary<int, List<Tuple<int, double>>>();
                for (; j < next_set_cap; j++)
                {
                    if (!corridors[i].ContainsKey(edges[j].Item1))
                        corridors[i].Add(edges[j].Item1, new List<Tuple<int, double>>());
                    if (!corridors[i].ContainsKey(edges[j].Item2))
                        corridors[i].Add(edges[j].Item2, new List<Tuple<int, double>>());
                    corridors[i][edges[j].Item1].Add(new Tuple<int, double>(edges[j].Item2, weights[j]));
                    corridors[i][edges[j].Item2].Add(new Tuple<int, double>(edges[j].Item1, weights[j]));
                }
            }

            for (int b = 0; b < corridors.Length; b++)
            {
                Assert.AreEqual(answers[b], do_it.RunTest(corridors[b], n_val));
            }
        }

        /*
         * 19 23
         * 0 1 1
         * 1 5 0.89
         * 1 6 0.99
         * 6 2 0.93
         * 2 3 0.99
         * 3 4 0.8214
         * 4 7 0.314
         * 4 8 0.5618
         * 4 9 0.5618
         * 6 10 0.0201
         * 10 110 1
         * 12 13 0.0501
         * 8 11 0.435
         * 9 12 0.9999
         * 13 18 0.721
         * 10 140 1
         * 14 15 0.3246
         * 15 16 0.789
         * 5 7 0.9706
         * 11 15 0.5678
         * 11 17 0.5
         * 16 17 0.9902
         * 17 18 0.9001
         * 
         * 0.0823
         */
        [TestMethod]
        public void GarinTest4()
        {
            int n_val = 19;
            Program do_it = new Program();
            Dictionary<int, List<Tuple<int, double>>>[] corridors = new Dictionary<int, List<Tuple<int, double>>>[1];
            Tuple<int, int>[] edges = new Tuple<int, int>[] {
                new Tuple<int, int>(0, 1),
                new Tuple<int, int>(1, 5),
                new Tuple<int, int>(1, 6),
                new Tuple<int, int>(6, 2),
                new Tuple<int, int>(2, 3),
                new Tuple<int, int>(3, 4),
                new Tuple<int, int>(4, 7),
                new Tuple<int, int>(4, 8),
                new Tuple<int, int>(4, 9),
                new Tuple<int, int>(6, 10),
                new Tuple<int, int>(10, 11),
                new Tuple<int, int>(12, 13),
                new Tuple<int, int>(8, 11),
                new Tuple<int, int>(9, 12),
                new Tuple<int, int>(13, 18),
                new Tuple<int, int>(10, 14),
                new Tuple<int, int>(14, 15),
                new Tuple<int, int>(15, 16),
                new Tuple<int, int>(5, 7),
                new Tuple<int, int>(11, 15),
                new Tuple<int, int>(11, 17),
                new Tuple<int, int>(16, 17),
                new Tuple<int, int>(17, 18), };
            double[] weights = new double[]
            { 1, 0.89, 0.99, 0.93, 0.99, 0.8214, 0.314, 0.5618, 0.5618, 0.0201,
            1, 0.0501, 0.435, 0.9999, 0.721, 1, 0.3246, 0.789, 0.9706, 0.5678,
            0.5, 0.9902, 0.9001 };
            int[] num_per_test = new int[] { 23 };
            double[] answers = new double[] { 0.0823 };
            int j = 0, next_set_cap = 0;
            for (int i = 0; i < corridors.Length; i++)
            {
                next_set_cap += num_per_test[i];
                corridors[i] = new Dictionary<int, List<Tuple<int, double>>>();
                for (; j < next_set_cap; j++)
                {
                    if (!corridors[i].ContainsKey(edges[j].Item1))
                        corridors[i].Add(edges[j].Item1, new List<Tuple<int, double>>());
                    if (!corridors[i].ContainsKey(edges[j].Item2))
                        corridors[i].Add(edges[j].Item2, new List<Tuple<int, double>>());
                    corridors[i][edges[j].Item1].Add(new Tuple<int, double>(edges[j].Item2, weights[j]));
                    corridors[i][edges[j].Item2].Add(new Tuple<int, double>(edges[j].Item1, weights[j]));
                }
            }

            for (int b = 0; b < corridors.Length; b++)
            {
                Assert.AreEqual(answers[b], do_it.RunTest(corridors[b], n_val));
            }
        }

        /*
         * 26 25
         * 0 1 1
         * 1 2 1
         * 2 3 1
         * 3 4 1
         * 4 5 1
         * 5 6 1
         * 6 7 1
         * 7 8 1
         * 8 9 1
         * 9 10 1
         * 10 11 1
         * 11 12 1
         * 12 13 1
         * 13 14 1
         * 14 15 1
         * 15 16 1
         * 16 17 1
         * 17 18 1
         * 18 19 1
         * 19 20 1
         * 20 21 1
         * 21 22 1
         * 22 23 1
         * 23 24 1
         * 24 25 1
         * 
         * 1.0000
        */
        [TestMethod]
        public void GarinTest5()
        {
            int n_val = 26;
            Program do_it = new Program();
            Dictionary<int, List<Tuple<int, double>>>[] corridors = new Dictionary<int, List<Tuple<int, double>>>[1];
            Tuple<int, int>[] edges = new Tuple<int, int>[] {
                new Tuple<int, int>(0, 1),
                new Tuple<int, int>(1, 2),
                new Tuple<int, int>(2, 3),
                new Tuple<int, int>(3, 4),
                new Tuple<int, int>(4, 5),
                new Tuple<int, int>(5, 6),
                new Tuple<int, int>(6, 7),
                new Tuple<int, int>(7, 8),
                new Tuple<int, int>(8, 9),
                new Tuple<int, int>(9, 10),
                new Tuple<int, int>(10, 11),
                new Tuple<int, int>(11, 12),
                new Tuple<int, int>(12, 13),
                new Tuple<int, int>(13, 14),
                new Tuple<int, int>(14, 15),
                new Tuple<int, int>(15, 16),
                new Tuple<int, int>(16, 17),
                new Tuple<int, int>(17, 18),
                new Tuple<int, int>(18, 19),
                new Tuple<int, int>(19, 20),
                new Tuple<int, int>(20, 21),
                new Tuple<int, int>(21, 22),
                new Tuple<int, int>(22, 23),
                new Tuple<int, int>(23, 24),
                new Tuple<int, int>(24, 25) };
            int[] num_per_test = new int[] { 25 };
            double[] weights = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            double[] answers = new double[] { 1.0000 };
            int j = 0, next_set_cap = 0;
            for (int i = 0; i < corridors.Length; i++)
            {
                next_set_cap += num_per_test[i];
                corridors[i] = new Dictionary<int, List<Tuple<int, double>>>();
                for (; j < next_set_cap; j++)
                {
                    if (!corridors[i].ContainsKey(edges[j].Item1))
                        corridors[i].Add(edges[j].Item1, new List<Tuple<int, double>>());
                    if (!corridors[i].ContainsKey(edges[j].Item2))
                        corridors[i].Add(edges[j].Item2, new List<Tuple<int, double>>());
                    corridors[i][edges[j].Item1].Add(new Tuple<int, double>(edges[j].Item2, weights[j]));
                    corridors[i][edges[j].Item2].Add(new Tuple<int, double>(edges[j].Item1, weights[j]));
                }
            }

            for (int b = 0; b < corridors.Length; b++)
            {
                Assert.AreEqual(answers[b], do_it.RunTest(corridors[b], n_val));
            }
        }

        /*
         *8 11
         * 0 1 0.8
         * 1 2 0.9
         * 2 3 0.9
         * 0 4 0.4
         * 0 5 0.6
         * 5 4 0.9
         * 5 2 0.6
         * 6 5 0.9
         * 6 7 0.8
         * 2 6 0.8
         * 3 7 0.9
         * 
         * 0.5832
         */
        [TestMethod]
        public void GarinTest6()
        {
            double[] weights = new double[] { 0.8, 0.9, 0.9, 0.4, 0.6, 0.9, 0.6, 0.9, 0.8, 0.8, 0.9 };
            int n_val = 8;
            Program do_it = new Program();
            Dictionary<int, List<Tuple<int, double>>>[] corridors = new Dictionary<int, List<Tuple<int, double>>>[1];
            Tuple<int, int>[] edges = new Tuple<int, int>[] {
                new Tuple<int, int>(0, 1),
                new Tuple<int, int>(1, 2),
                new Tuple<int, int>(2, 3),
                new Tuple<int, int>(0, 4),
                new Tuple<int, int>(0, 5),
                new Tuple<int, int>(5, 4),
                new Tuple<int, int>(5, 2),
                new Tuple<int, int>(6, 5),
                new Tuple<int, int>(6, 7),
                new Tuple<int, int>(2, 6),
                new Tuple<int, int>(3, 7), };
            int[] num_per_test = new int[] { 11 };
            double[] answers = new double[] { 0.5832 };
            int j = 0, next_set_cap = 0;
            for (int i = 0; i < corridors.Length; i++)
            {
                next_set_cap += num_per_test[i];
                corridors[i] = new Dictionary<int, List<Tuple<int, double>>>();
                for (; j < next_set_cap; j++)
                {
                    if (!corridors[i].ContainsKey(edges[j].Item1))
                        corridors[i].Add(edges[j].Item1, new List<Tuple<int, double>>());
                    if (!corridors[i].ContainsKey(edges[j].Item2))
                        corridors[i].Add(edges[j].Item2, new List<Tuple<int, double>>());
                    corridors[i][edges[j].Item1].Add(new Tuple<int, double>(edges[j].Item2, weights[j]));
                    corridors[i][edges[j].Item2].Add(new Tuple<int, double>(edges[j].Item1, weights[j]));
                }
            }

            for (int b = 0; b < corridors.Length; b++)
            {
                Assert.AreEqual(answers[b], do_it.RunTest(corridors[b], n_val));
            }
        }

        /*
         * 7 8
        0 1 0.9
        0 3 0.9
        1 2 0.87
        3 2 0.85
        2 4 0.9
        4 5 0.99
        2 5 0.8
        5 6 0.9

        0.6279
        */
        [TestMethod]
        public void AugustTest1()
        {
            double[] weights = new double[] { 0.9, 0.9, 0.87, 0.85, 0.9, 0.99, 0.8, 0.9 };
            int n_val = 7;
            Program do_it = new Program();
            Dictionary<int, List<Tuple<int, double>>>[] corridors = new Dictionary<int, List<Tuple<int, double>>>[1];
            Tuple<int, int>[] edges = new Tuple<int, int>[] {
                new Tuple<int, int>(0, 1),
                new Tuple<int, int>(0, 3),
                new Tuple<int, int>(1, 2),
                new Tuple<int, int>(3, 2),
                new Tuple<int, int>(2, 4),
                new Tuple<int, int>(4, 5),
                new Tuple<int, int>(2, 2),
                new Tuple<int, int>(5, 6), };
            int[] num_per_test = new int[] { 8 };
            double[] answers = new double[] { 0.6279 };
            int j = 0, next_set_cap = 0;
            for (int i = 0; i < corridors.Length; i++)
            {
                next_set_cap += num_per_test[i];
                corridors[i] = new Dictionary<int, List<Tuple<int, double>>>();
                for (; j < next_set_cap; j++)
                {
                    if (!corridors[i].ContainsKey(edges[j].Item1))
                        corridors[i].Add(edges[j].Item1, new List<Tuple<int, double>>());
                    if (!corridors[i].ContainsKey(edges[j].Item2))
                        corridors[i].Add(edges[j].Item2, new List<Tuple<int, double>>());
                    corridors[i][edges[j].Item1].Add(new Tuple<int, double>(edges[j].Item2, weights[j]));
                    corridors[i][edges[j].Item2].Add(new Tuple<int, double>(edges[j].Item1, weights[j]));
                }
            }

            for (int b = 0; b < corridors.Length; b++)
            {
                Assert.AreEqual(answers[b], do_it.RunTest(corridors[b], n_val));
            }
        }

        /*
        * 6 15
        * 0 1 1
        * 0 2 0.5
        * 0 3 0.6
        * 0 4 0.8
        * 0 5 0.7
        * 
        * 1 2 1
        * 1 3 0.8
        * 1 4 0.9
        * 1 5 0.5
        * 
        * 2 3 1
        * 2 4 0.5
        * 2 5 0.6
        * 
        * 3 4 1
        * 3 5 0.8
        * 
        * 4 5 1
        * 
        * 1.0000
        */
        [TestMethod]
        public void MyTest1()
        {
            double[] weights = new double[] 
            { 1, 0.5, 0.6, 0.8, 0.7,
                1, 0.8, 0.9, 0.5,
                1, 0.5, 0.6,
            1, 0.8, 1};
            int n_val = 6;
            Program do_it = new Program();
            Dictionary<int, List<Tuple<int, double>>>[] corridors = new Dictionary<int, List<Tuple<int, double>>>[1];
            Tuple<int, int>[] edges = new Tuple<int, int>[] {
                new Tuple<int, int>(0, 1),
                new Tuple<int, int>(0, 2),
                new Tuple<int, int>(0, 3),
                new Tuple<int, int>(0, 4),
                new Tuple<int, int>(0, 5),
                new Tuple<int, int>(1, 2),
                new Tuple<int, int>(1, 3),
                new Tuple<int, int>(1, 4),
                new Tuple<int, int>(1, 5),
                new Tuple<int, int>(2, 3),
                new Tuple<int, int>(2, 4),
                new Tuple<int, int>(2, 5),
                new Tuple<int, int>(3, 4),
                new Tuple<int, int>(3, 5),
                new Tuple<int, int>(4, 5), };
            int[] num_per_test = new int[] { 15 };
            double[] answers = new double[] { 1.0000 };
            int j = 0, next_set_cap = 0;
            for (int i = 0; i < corridors.Length; i++)
            {
                next_set_cap += num_per_test[i];
                corridors[i] = new Dictionary<int, List<Tuple<int, double>>>();
                for (; j < next_set_cap; j++)
                {
                    if (!corridors[i].ContainsKey(edges[j].Item1))
                        corridors[i].Add(edges[j].Item1, new List<Tuple<int, double>>());
                    if (!corridors[i].ContainsKey(edges[j].Item2))
                        corridors[i].Add(edges[j].Item2, new List<Tuple<int, double>>());
                    corridors[i][edges[j].Item1].Add(new Tuple<int, double>(edges[j].Item2, weights[j]));
                    corridors[i][edges[j].Item2].Add(new Tuple<int, double>(edges[j].Item1, weights[j]));
                }
            }

            for (int b = 0; b < corridors.Length; b++)
            {
                Assert.AreEqual(answers[b], do_it.RunTest(corridors[b], n_val));
            }
        }

        /*
        26 325
        0 1 1
        0 2 1
        0 3 1
        0 4 1
        0 5 1
        0 6 1
        0 7 1
        0 8 1
        0 9 1
        0 10 1
        0 11 1
        0 12 1
        0 13 1
        0 14 1
        0 15 1
        0 16 1
        0 17 1
        0 18 1
        0 19 1
        0 20 1
        0 21 1
        0 22 1
        0 23 1
        0 24 1
        0 25 1
        */
        /*
        1 2 1
        1 3 1
        1 4 1
        1 5 1
        1 6 1
        1 7 1
        1 8 1
        1 9 1
        1 10 1
        1 11 1
        1 12 1
        1 13 1
        1 14 1
        1 15 1
        1 16 1
        1 17 1
        1 18 1
        1 19 1
        1 20 1
        1 21 0.9978
        1 22 1
        1 23 1
        1 24 1
        1 25 1
        */
        /*
        2 3 1
        2 4 0.9978
        2 5 1
        2 6 1
        2 7 0.9978
        2 8 1
        2 9 0.0125
        2 10 1
        2 11 1
        2 12 1
        2 13 1
        2 14 0.0125
        2 15 0.0125
        2 16 1
        2 17 0.0125
        2 18 1
        2 19 0.0125
        2 20 0.0125
        2 21 1
        2 22 1
        2 23 1
        2 24 1
        2 25 1
        */
        /*
        3 4 1
        3 5 1
        3 6 1
        3 7 1
        3 8 1
        3 9 1
        3 10 1
        3 11 1
        3 12 0.9978
        3 13 1
        3 14 1
        3 15 1
        3 16 1
        3 17 1
        3 18 1
        3 19 0.9978
        3 20 0.9978
        3 21 1
        3 22 0.9978
        3 23 1
        3 24 1
        3 25 1
        */
        /*
        4 5 0.9978
        4 6 1
        4 7 1
        4 8 1
        4 9 1
        4 10 1
        4 11 1
        4 12 1
        4 13 1
        4 14 0.0125
        4 15 0.0125
        4 16 0.0125
        4 17 1
        4 18 1
        4 19 1
        4 20 1
        4 21 1
        4 22 1
        4 23 0.0125
        4 24 1
        4 25 1
        */
        /*
        5 6 1
        5 7 1
        5 8 1
        5 9 1
        5 10 1
        5 11 0.0125
        5 12 0.0125
        5 13 0.0125
        5 14 1
        5 15 1
        5 16 1
        5 17 1
        5 18 1
        5 19 1
        5 20 1
        5 21 0.0125
        5 22 1
        5 23 1
        5 24 1
        5 25 1
        */
        /*
        6 7 1
        6 8 1
        6 9 1
        6 10 1
        6 11 1
        6 12 1
        6 13 1
        6 14 0.0025
        6 15 0.0125
        6 16 0.0125
        6 17 1
        6 18 1
        6 19 1
        6 20 1
        6 21 1
        6 22 1
        6 23 1
        6 24 0.0125
        6 25 1
        */
        /*
        7 8 1
        7 9 1
        7 10 1
        7 11 0.0025
        7 12 1
        7 13 1
        7 14 1
        7 15 1
        7 16 1
        7 17 1
        7 18 1
        7 19 1
        7 20 1
        7 21 1
        7 22 1
        7 23 1
        7 24 1
        7 25 1
        */
        /*
        8 9 1
        8 10 1
        8 11 0.0025
        8 12 1
        8 13 0.0025
        8 14 1
        8 15 0.0025
        8 16 1
        8 17 0.0025
        8 18 1
        8 19 0.0025
        8 20 0.0025
        8 21 1
        8 22 1
        8 23 0.9978
        8 24 1
        8 25 0.9978
        */
        /*
        9 10 1
        9 11 0.0025
        9 12 0.0025
        9 13 1
        9 14 0.056
        9 15 1
        9 16 1
        9 17 1
        9 18 1
        9 19 0.0025
        9 20 1
        9 21 1
        9 22 1
        9 23 1
        9 24 1
        9 25 0.9978
        */
        /*
        10 11 1
        10 12 1
        10 13 0.9978
        10 14 1
        10 15 1
        10 16 1
        10 17 0.9978
        10 18 1
        10 19 1
        10 20 1
        10 21 0.9978
        10 22 0.0025
        10 23 0.0025
        10 24 0.9321
        10 25 1
        */
        /*
        11 12 0.9321
        11 13 1
        11 14 1
        11 15 1
        11 16 1
        11 17 1
        11 18 1
        11 19 1
        11 20 1
        11 21 1
        11 22 1
        11 23 1
        11 24 0.9321
        11 25 1
        */
        /*
        12 13 1
        12 14 0.9321
        12 15 0.9321
        12 16 1
        12 17 1
        12 18 0.056
        12 19 1
        12 20 1
        12 21 0.056
        12 22 1
        12 23 0.9321
        12 24 1
        12 25 0.056
        */
        /*
        13 14 1
        13 15 1
        13 16 1
        13 17 1
        13 18 1
        13 19 1
        13 20 1
        13 21 1
        13 22 0.056
        13 23 1
        13 24 1
        13 25 1
        */
        /*
        14 15 1
        14 16 0.9321
        14 17 0.9321
        14 18 0.9321
        14 19 0.9321
        14 20 0.9321
        14 21 1
        14 22 1
        14 23 1
        14 24 0.056
        14 25 1
        */
        /*
        15 16 0.056
        15 17 1
        15 18 0.056
        15 19 0.9321
        15 20 1
        15 21 1
        15 22 1
        15 23 0.056
        15 24 1
        15 25 1
        */
        /*
        16 17 1
        16 18 1
        16 19 1
        16 20 1
        16 21 1
        16 22 1
        16 23 0.056
        16 24 1
        16 25 1
        */
        /*
        17 18 1
        17 19 1
        17 20 1
        17 21 0.9321
        17 22 1
        17 23 1
        17 24 0.056
        17 25 1
        */
        /*
        18 19 1
        18 20 1
        18 21 0.9321
        18 22 1
        18 23 1
        18 24 0.9321
        18 25 0.9321
        */
        /*
        19 20 1
        19 21 0.056
        19 22 1
        19 23 1
        19 24 1
        19 25 1
        */
        /*
        20 21 1
        20 22 1
        20 23 0.056
        20 24 1
        20 25 1
        */
        /*
        21 22 1
        21 23 0.056
        21 24 1
        21 25 0.9321
        */
        /*
        22 23 1
        22 24 0.056
        22 25 1
        23 24 0.9321
        23 25 0.9321
        24 25 0.056
        */
        [TestMethod]
        public void GarinTest7()
        {
            double[] weights = new double[325];
            int n_val = 26;
            Program do_it = new Program();
            Dictionary<int, List<Tuple<int, double>>>[] corridors = new Dictionary<int, List<Tuple<int, double>>>[1];
            Tuple<int, int>[] edges = new Tuple<int, int>[325];
            int k = 0;
            for (int a = 0; a < 26; a++)
            {
                for (int c = 1 + a; c < 26; c++)
                {
                    edges[k] = new Tuple<int, int>(a, c);
                    weights[k] = 1;
                    k++;
                }
            }
            weights[46] = 0.9978;
            weights[80] = 0.7087;
            weights[94] = 0.7487;
            weights[104] = 0.531;
            int[] num_per_test = new int[] { 325 };
            double[] answers = new double[] { 1.0000 };
            int j = 0, next_set_cap = 0;
            for (int i = 0; i < corridors.Length; i++)
            {
                next_set_cap += num_per_test[i];
                corridors[i] = new Dictionary<int, List<Tuple<int, double>>>();
                for (; j < next_set_cap; j++)
                {
                    if (!corridors[i].ContainsKey(edges[j].Item1))
                        corridors[i].Add(edges[j].Item1, new List<Tuple<int, double>>());
                    if (!corridors[i].ContainsKey(edges[j].Item2))
                        corridors[i].Add(edges[j].Item2, new List<Tuple<int, double>>());
                    corridors[i][edges[j].Item1].Add(new Tuple<int, double>(edges[j].Item2, weights[j]));
                    corridors[i][edges[j].Item2].Add(new Tuple<int, double>(edges[j].Item1, weights[j]));
                }
            }

            for (int b = 0; b < corridors.Length; b++)
            {
                Assert.AreEqual(answers[b], do_it.RunTest(corridors[b], n_val));
            }
        }
    }
}
 
 
