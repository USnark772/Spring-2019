using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PS10_5_Narrow_Art_Gallery;
namespace GalleryTester
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PublicTests1()
        {
            GallerySolver GS = new GallerySolver();
            int[,] gallery = new int[7, 2];
            gallery[0, 0] = 6;
            gallery[0, 1] = 4;
            gallery[1, 0] = 3;
            gallery[1, 1] = 1;
            gallery[2, 0] = 2;
            gallery[2, 1] = 1;
            gallery[3, 0] = 1;
            gallery[3, 1] = 2;
            gallery[4, 0] = 1;
            gallery[4, 1] = 3;
            gallery[5, 0] = 3;
            gallery[5, 1] = 3;
            gallery[6, 1] = 0;
            gallery[6, 1] = 0;
            Assert.AreEqual(17, GS.SolveGallery(gallery));
        }

        [TestMethod]
        public void PublicTest2()
        {
            GallerySolver GS = new GallerySolver();
            int[,] gallery = new int[5, 2];
            gallery[0, 0] = 4;
            gallery[0, 1] = 3;
            gallery[1, 0] = 3;
            gallery[1, 1] = 4;
            gallery[2, 0] = 1;
            gallery[2, 1] = 1;
            gallery[3, 0] = 1;
            gallery[3, 1] = 1;
            gallery[4, 0] = 5;
            gallery[4, 1] = 6;
            Assert.AreEqual(17, GS.SolveGallery(gallery));
        }

        [TestMethod]
        public void PublicTest3()
        {
            GallerySolver GS = new GallerySolver();
            int[,] gallery = new int[11, 2];
            gallery[0, 0] = 10;
            gallery[0, 1] = 5;
            gallery[1, 0] = 7;
            gallery[1, 1] = 8;
            gallery[2, 0] = 4;
            gallery[2, 1] = 9;
            gallery[3, 0] = 3;
            gallery[3, 1] = 7;
            gallery[4, 0] = 5;
            gallery[4, 1] = 9;
            gallery[5, 0] = 7;
            gallery[5, 1] = 2;
            gallery[6, 0] = 10;
            gallery[6, 1] = 3;
            gallery[7, 0] = 0;
            gallery[7, 1] = 10;
            gallery[8, 0] = 3;
            gallery[8, 1] = 2;
            gallery[9, 0] = 6;
            gallery[9, 1] = 3;
            gallery[10, 0] = 7;
            gallery[10, 1] = 9;
            Assert.AreEqual(102, GS.SolveGallery(gallery));
        }

        [TestMethod]
        public void MySimpleTest1()
        {
            GallerySolver GS = new GallerySolver();
            int[,] gallery = new int[3, 2];
            int i = 0;
            gallery[i, 0] = 2;
            gallery[i++, 1] = 1;
            gallery[i, 0] = 2;
            gallery[i++, 1] = 5;
            gallery[i, 0] = 4;
            gallery[i++, 1] = 2;
            Assert.AreEqual(11, GS.SolveGallery(gallery));
        }

        [TestMethod]
        public void MyZeroTest1()
        {
            GallerySolver GS = new GallerySolver();
            int[,] gallery = new int[10, 2];
            int i = 0;
            gallery[i, 0] = 9;
            gallery[i++, 1] = 0;
            gallery[i, 0] = 0;
            gallery[i++, 1] = 0;
            gallery[i, 0] = 0;
            gallery[i++, 1] = 0;
            gallery[i, 0] = 0;
            gallery[i++, 1] = 0;
            gallery[i, 0] = 0;
            gallery[i++, 1] = 0;
            gallery[i, 0] = 0;
            gallery[i++, 1] = 0;
            gallery[i, 0] = 0;
            gallery[i++, 1] = 0;
            gallery[i, 0] = 0;
            gallery[i++, 1] = 0;
            gallery[i, 0] = 0;
            gallery[i++, 1] = 0;
            gallery[i, 0] = 0;
            gallery[i++, 1] = 0;
            Assert.AreEqual(0, GS.SolveGallery(gallery));
        }

        [TestMethod]
        public void MyZeroTest2()
        {
            GallerySolver GS = new GallerySolver();
            int[,] gallery = new int[10, 2];
            int i = 0;
            gallery[i, 0] = 9;
            gallery[i++, 1] = 3;
            gallery[i, 0] = 0;
            gallery[i++, 1] = 0;
            gallery[i, 0] = 0;
            gallery[i++, 1] = 0;
            gallery[i, 0] = 0;
            gallery[i++, 1] = 0;
            gallery[i, 0] = 0;
            gallery[i++, 1] = 0;
            gallery[i, 0] = 0;
            gallery[i++, 1] = 0;
            gallery[i, 0] = 0;
            gallery[i++, 1] = 0;
            gallery[i, 0] = 0;
            gallery[i++, 1] = 0;
            gallery[i, 0] = 0;
            gallery[i++, 1] = 0;
            gallery[i, 0] = 0;
            gallery[i++, 1] = 0;
            Assert.AreEqual(0, GS.SolveGallery(gallery));
        }

        [TestMethod]
        public void MyZeroTest3()
        {
            GallerySolver GS = new GallerySolver();
            int[,] gallery = new int[10, 2];
            int i = 0;
            gallery[i, 0] = 9;
            gallery[i++, 1] = 3;
            gallery[i, 0] = 0;
            gallery[i++, 1] = 100;
            gallery[i, 0] = 0;
            gallery[i++, 1] = 50;
            gallery[i, 0] = 0;
            gallery[i++, 1] = 0;
            gallery[i, 0] = 0;
            gallery[i++, 1] = 0;
            gallery[i, 0] = 0;
            gallery[i++, 1] = 0;
            gallery[i, 0] = 0;
            gallery[i++, 1] = 0;
            gallery[i, 0] = 0;
            gallery[i++, 1] = 0;
            gallery[i, 0] = 0;
            gallery[i++, 1] = 0;
            gallery[i, 0] = 0;
            gallery[i++, 1] = 0;
            Assert.AreEqual(150, GS.SolveGallery(gallery));
        }

        [TestMethod]
        public void MyOnesTest1()
        {
            GallerySolver GS = new GallerySolver();
            int[,] gallery = new int[10, 2];
            int i = 0;
            gallery[i, 0] = 9;
            gallery[i++, 1] = 3;
            gallery[i, 0] = 1;
            gallery[i++, 1] = 1;
            gallery[i, 0] = 1;
            gallery[i++, 1] = 1;
            gallery[i, 0] = 1;
            gallery[i++, 1] = 1;
            gallery[i, 0] = 1;
            gallery[i++, 1] = 1;
            gallery[i, 0] = 1;
            gallery[i++, 1] = 1;
            gallery[i, 0] = 1;
            gallery[i++, 1] = 1;
            gallery[i, 0] = 1;
            gallery[i++, 1] = 1;
            gallery[i, 0] = 1;
            gallery[i++, 1] = 1;
            gallery[i, 0] = 1;
            gallery[i++, 1] = 1;
            Assert.AreEqual(15, GS.SolveGallery(gallery));
        }

        [TestMethod]
        public void MyOnesTest2()
        {
            GallerySolver GS = new GallerySolver();
            int[,] gallery = new int[10, 2];
            int i = 0;
            gallery[i, 0] = 9;
            gallery[i++, 1] = 7;
            gallery[i, 0] = 1;
            gallery[i++, 1] = 1;
            gallery[i, 0] = 1;
            gallery[i++, 1] = 1;
            gallery[i, 0] = 1;
            gallery[i++, 1] = 1;
            gallery[i, 0] = 1;
            gallery[i++, 1] = 1;
            gallery[i, 0] = 1;
            gallery[i++, 1] = 1;
            gallery[i, 0] = 1;
            gallery[i++, 1] = 1;
            gallery[i, 0] = 1;
            gallery[i++, 1] = 1;
            gallery[i, 0] = 1;
            gallery[i++, 1] = 1;
            gallery[i, 0] = 1;
            gallery[i++, 1] = 1;
            Assert.AreEqual(11, GS.SolveGallery(gallery));
        }

        [TestMethod]
        public void MyBiggerTest1()
        {
            GallerySolver GS = new GallerySolver();
            int[,] gallery = new int[20, 2];
            int i = 0;
            int j = 1;
            gallery[i, 0] = 19;
            gallery[i++, 1] = 18;
            while(i < 20)
            {
                gallery[i, 0] = j++;
                gallery[i++, 1] = j++;
            }
            Assert.AreEqual(417, GS.SolveGallery(gallery));
        }

        [TestMethod]
        public void MyBiggerTest2()
        {
            GallerySolver GS = new GallerySolver();
            int[,] gallery = new int[20, 2];
            int i = 0;
            int j = 1;
            gallery[i, 0] = 19;
            gallery[i++, 1] = 19;
            while (i < 20)
            {
                gallery[i, 0] = j++;
                gallery[i++, 1] = j++;
            }
            Assert.AreEqual(380, GS.SolveGallery(gallery));
        }

        [TestMethod]
        public void MyBiggerTest3()
        {
            GallerySolver GS = new GallerySolver();
            int[,] gallery = new int[200, 2];
            int i = 0;
            int j = 1;
            int answer = 0;
            gallery[i, 0] = 199;
            gallery[i++, 1] = 0;
            while (i < 200)
            {
                answer += j;
                gallery[i, 0] = j++;
                answer += j;
                gallery[i++, 1] = j++;
            }
            Assert.AreEqual(answer, GS.SolveGallery(gallery));
        }

        [TestMethod]
        public void MyBiggerTest4()
        {
            GallerySolver GS = new GallerySolver();
            int[,] gallery = new int[200, 2];
            int i = 0;
            int j = 1;
            int answer = 0;
            gallery[i, 0] = 199;
            gallery[i++, 1] = 18;
            while (i < 19)
            {
                gallery[i, 0] = j++;
                answer += j;
                gallery[i++, 1] = j++;
            }
            while(i < 200)
            {
                answer += j;
                gallery[i, 0] = j++;
                answer += j;
                gallery[i++, 1] = j++;
            }
            Assert.AreEqual(answer, GS.SolveGallery(gallery));
        }

        [TestMethod]
        public void MyTinyTest1()
        {
            GallerySolver GS = new GallerySolver();
            int[,] gallery = new int[4, 2];
            int i = 0;
            int j = 1;
            int answer = 21;
            gallery[i, 0] = 3;
            gallery[i++, 1] = 0;
            while (i < 4)
            {
                gallery[i, 0] = j++;
                gallery[i++, 1] = j++;
            }
            Assert.AreEqual(answer, GS.SolveGallery(gallery));
        }

        [TestMethod]
        public void MyTinyTest2()
        {
            GallerySolver GS = new GallerySolver();
            int[,] gallery = new int[4, 2];
            int i = 0;
            int j = 1;
            int answer = 20;
            gallery[i, 0] = 3;
            gallery[i++, 1] = 1;
            while (i < 4)
            {
                gallery[i, 0] = j++;
                gallery[i++, 1] = j++;
            }
            Assert.AreEqual(answer, GS.SolveGallery(gallery));
        }

        [TestMethod]
        public void MyTinyTest3()
        {
            GallerySolver GS = new GallerySolver();
            int[,] gallery = new int[4, 2];
            int i = 0;
            int j = 1;
            int answer = 17;
            gallery[i, 0] = 3;
            gallery[i++, 1] = 2;
            while (i < 4)
            {
                gallery[i, 0] = j++;
                gallery[i++, 1] = j++;
            }
            Assert.AreEqual(answer, GS.SolveGallery(gallery));
        }

        [TestMethod]
        public void MyTinyTest4()
        {
            GallerySolver GS = new GallerySolver();
            int[,] gallery = new int[4, 2];
            int i = 0;
            int j = 1;
            int answer = 12;
            gallery[i, 0] = 3;
            gallery[i++, 1] = 3;
            while (i < 4)
            {
                gallery[i, 0] = j++;
                gallery[i++, 1] = j++;
            }
            Assert.AreEqual(answer, GS.SolveGallery(gallery));
        }

        [TestMethod]
        public void MyTinyTest5()
        {
            GallerySolver GS = new GallerySolver();
            int[,] gallery = new int[4, 2];
            int i = 0;
            int j = 3;
            int answer = 18;
            gallery[i, 0] = 3;
            gallery[i++, 1] = 0;
            while (i < 4)
            {
                gallery[i, 0] = j;
                gallery[i++, 1] = j;
            }
            Assert.AreEqual(answer, GS.SolveGallery(gallery));
        }

        [TestMethod]
        public void MyTinyTest6()
        {
            GallerySolver GS = new GallerySolver();
            int[,] gallery = new int[4, 2];
            int i = 0;
            int j = 3;
            int answer = 16;
            gallery[i, 0] = 3;
            gallery[i++, 1] = 1;
            while (i < 4)
            {
                gallery[i, 0] = j;
                gallery[i++, 1] = j;
            }
            gallery[2, 1] = 4;
            Assert.AreEqual(answer, GS.SolveGallery(gallery));
        }
    }
}
