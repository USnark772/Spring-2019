using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PS5_5_Rumor_Mill;

namespace RumorTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PublicKattisTest1()
        {
            RumorMill RM = new RumorMill();
            Dictionary<string, int> id_list = new Dictionary<string, int>();
            string[] students = new string[] { "Cassandra", "Alberforth", "Buttrick" };
            List<int>[] friends = new List<int>[students.Length];
            int[] reports_needed = new int[1];
            string[] answers = new string[] { "Alberforth Cassandra Buttrick" };
            string[] result;
            for (int i = 0; i < students.Length; i++)
            {
                id_list.Add(students[i], i);
            }
            for (int i = 0; i < friends.Length; i++)
            {
                friends[i] = new List<int>();
            }
            friends[0].Add(1);
            reports_needed[0] = 1;
            result = RM.GetReports(reports_needed, friends, id_list, students);
            for (int i = 0; i < reports_needed.Length; i++)
            {
                Assert.AreEqual(answers[i], result[i]);
            }
        }

        [TestMethod]
        public void PublicKattisTest2()
        {

            RumorMill RM = new RumorMill();
            Dictionary<string, int> id_list = new Dictionary<string, int>();
            string[] students = new string[] { "Cam", "Art", "Edy", "Bea", "Dan" };
            List<int>[] friends = new List<int>[students.Length];
            int[] reports_needed = new int[2];
            string[] answers = new string[] { "Dan Art Bea Edy Cam", "Cam Art Bea Dan Edy" };
            string[] result;
            for (int i = 0; i < students.Length; i++)
            {
                id_list.Add(students[i], i);
            }
            for (int i = 0; i < friends.Length; i++)
            {
                friends[i] = new List<int>();
            }
            friends[3].Add(2);
            friends[4].Add(3);
            friends[1].Add(4);
            reports_needed[0] = 4;
            reports_needed[1] = 0;
            result = RM.GetReports(reports_needed, friends, id_list, students);
            for (int i = 0; i < reports_needed.Length; i++)
            {
                Assert.AreEqual(answers[i], result[i]);
            }
        }

        [TestMethod]
        public void AugustsTest()
        {
            RumorMill RM = new RumorMill();
            Dictionary<string, int> id_list = new Dictionary<string, int>();
            string[] students = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L" };
            List<int>[] friends = new List<int>[students.Length];
            int[] reports_needed = new int[1];
            string[] answers = new string[] { "A C D E F G H B I J L K" };
            string[] result;
            for (int i = 0; i < students.Length; i++)
            {
                id_list.Add(students[i], i);
            }
            for (int i = 0; i < friends.Length; i++)
            {
                friends[i] = new List<int>();
            }
            friends[0].Add(2);
            friends[0].Add(3);
            friends[3].Add(4);
            friends[3].Add(5);
            friends[4].Add(6);
            friends[4].Add(7);
            friends[6].Add(8);
            friends[6].Add(9);
            friends[7].Add(1);
            friends[7].Add(11);
            reports_needed[0] = 0;
            result = RM.GetReports(reports_needed, friends, id_list, students);
            for (int i = 0; i < reports_needed.Length; i++)
            {
                Assert.AreEqual(answers[i], result[i]);
            }
        }
    }
}
