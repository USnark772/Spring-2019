using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PS10_5_Narrow_Art_Gallery
{
    public class GallerySolver
    {
        public void SolveGalleries()
        {
            int[,] gallery;
            string usr_input;
            string[] tmp_usr_input;
            usr_input = Console.ReadLine();
            tmp_usr_input = usr_input.Split(' ');
            int N = int.Parse(tmp_usr_input[0]);
            int k = int.Parse(tmp_usr_input[1]);
            while (N != 0)
            {
                gallery = new int[N + 1, 2];
                gallery[0, 0] = N;
                gallery[0, 1] = k;
                for (int i = 1; i < N + 1; i++)
                {
                    usr_input = Console.ReadLine();
                    tmp_usr_input = usr_input.Split(' ');
                    gallery[i, 0] = int.Parse(tmp_usr_input[0]);
                    gallery[i, 1] = int.Parse(tmp_usr_input[1]);
                }
                Console.WriteLine(SolveGallery(gallery));
                usr_input = Console.ReadLine();
                tmp_usr_input = usr_input.Split(' ');
                N = int.Parse(tmp_usr_input[0]);
                k = int.Parse(tmp_usr_input[1]);
            }
        }

        private int MaxVal(int r, int unclosable, int k, int[,] values, Dictionary<Tuple<int, int, int>, int> calculated)
        {
            Tuple<int, int, int> temp = new Tuple<int, int, int>(r, unclosable, k);
            if (calculated.ContainsKey(temp))
                return calculated[temp];
            int ret = 0;
            int NminR = values[0, 0] + 1 - r;
            if (NminR == 0)
                ret = 0;
            else if (k == NminR)
            {
                if (unclosable == 0)
                    ret = values[r, 0] + MaxVal(r + 1, 0, k - 1, values, calculated);
                else if (unclosable == 1)
                    ret = values[r, 1] + MaxVal(r + 1, 1, k - 1, values, calculated);
                else if (unclosable == -1)
                    ret = Math.Max(
                        values[r, 0] + MaxVal(r + 1, 0, k - 1, values, calculated),
                        values[r, 1] + MaxVal(r + 1, 1, k - 1, values, calculated));
            }
            else if (k < NminR && k > 0)
            {
                if (unclosable == 0)

                    ret = Math.Max(
                        values[r, 0] + MaxVal(r + 1, 0, k - 1, values, calculated),
                        values[r, 0] + values[r, 1] + MaxVal(r + 1, -1, k, values, calculated));
                else if (unclosable == 1)
                    ret = Math.Max(
                        values[r, 1] + MaxVal(r + 1, 1, k - 1, values, calculated),
                        values[r, 0] + values[r, 1] + MaxVal(r + 1, -1, k, values, calculated));
                else if (unclosable == -1)
                    ret = Math.Max(
                        values[r, 0] + MaxVal(r + 1, 0, k - 1, values, calculated),
                        Math.Max(
                        values[r, 1] + MaxVal(r + 1, 1, k - 1, values, calculated),
                        values[r, 0] + values[r, 1] + MaxVal(r + 1, -1, k, values, calculated)));
            }
            else if (k == 0)
                ret = values[r, 0] + values[r, 1] + MaxVal(r + 1, -1, k, values, calculated);
            calculated.Add(temp, ret);
            return ret;
        }

        public int SolveGallery(int[,] gallery)
        {
            Dictionary<Tuple<int, int, int>, int> calculated = new Dictionary<Tuple<int, int, int>, int>();
            return MaxVal(1, -1, gallery[0, 1], gallery, calculated);
        }

        static void Main(string[] args)
        {
            GallerySolver GS = new GallerySolver();
            GS.SolveGalleries();
        }
    }
}
