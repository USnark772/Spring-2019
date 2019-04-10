using Microsoft.VisualStudio.TestTools.UnitTesting;
using PS11_6_Spidermans_workout;

namespace WorkoutTester
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PublicTest1()
        {
            ExercisePlanner EP = new ExercisePlanner();
            int[] dists = { 4, 20, 20, 20, 20 };
            Assert.AreEqual(0, EP.SolveWorkout(dists, 1, dists[0], 0).Item1);
        }

        [TestMethod]
        public void PublicTest2()
        {
            ExercisePlanner EP = new ExercisePlanner();
            int[] dists = { 6, 3, 2, 5, 3, 1, 2 };
            Assert.AreEqual(0, EP.SolveWorkout(dists, 1, dists[0], 0).Item1);
        }

        [TestMethod]
        public void PublicTest3()
        {
            ExercisePlanner EP = new ExercisePlanner();
            int[] dists = { 7, 3, 4, 2, 1, 6, 4, 5 };
            Assert.AreNotEqual(0, EP.SolveWorkout(dists, 1, dists[0], 0).Item1);
        }

        [TestMethod]
        public void MyTest1()
        {
            ExercisePlanner EP = new ExercisePlanner();
            int[] dists = { 3, 3, 3, 6 };
            Assert.AreEqual(0, EP.SolveWorkout(dists, 1, dists[0], 0).Item1);
        }

        [TestMethod]
        public void MyTest2()
        {
            ExercisePlanner EP = new ExercisePlanner();
            int[] dists = { 9, 3, 2, 5, 3, 1, 2, 3, 3, 6 };
            Assert.AreEqual(0, EP.SolveWorkout(dists, 1, dists[0], 0).Item1);
        }

        [TestMethod]
        public void MyTest3()
        {
            ExercisePlanner EP = new ExercisePlanner();
            int[] dists = { 4, 3, 3, 6, 12 };
            Assert.AreEqual(0, EP.SolveWorkout(dists, 1, dists[0], 0).Item1);
        }

        [TestMethod]
        public void MyTestToBeat2()
        {
            ExercisePlanner EP = new ExercisePlanner();
            int[] dists = { 4, 12, 3, 3, 6 };
            Assert.AreEqual(0, EP.SolveWorkout(dists, 1, dists[0], 0).Item1);
        }

        [TestMethod]
        public void MyTestToBeat1()
        {
            ExercisePlanner EP = new ExercisePlanner();
            int[] dists = { 7, 5, 3, 3, 10, 3, 13, 5 };
            Assert.AreEqual(0, EP.SolveWorkout(dists, 1, dists[0], 0).Item1);
        }
    }
}
