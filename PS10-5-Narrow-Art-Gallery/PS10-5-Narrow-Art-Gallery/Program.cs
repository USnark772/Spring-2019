using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS10_5_Narrow_Art_Gallery
{
    public class GallerySolver
    {
        public List<int> SolveGalleries()
        {
            List<int> ret = new List<int>();
            int[] gallery;
            string usr_input;
            string[] tmp_usr_input;
            usr_input = Console.ReadLine();
            tmp_usr_input = usr_input.Split(' ');
            int N = int.Parse(tmp_usr_input[0]);
            int k = int.Parse(tmp_usr_input[1]);
            while (N != 0 && k != 0)
            {
                gallery = new int[N*2+2];
                gallery[0] = N;
                gallery[1] = k;
                for (int i = 2; i < N+2; i+=2)
                {
                    usr_input = Console.ReadLine();
                    tmp_usr_input = usr_input.Split(' ');
                    gallery[i] = int.Parse(tmp_usr_input[0]);
                    gallery[i+1] = int.Parse(tmp_usr_input[1]);
                }
                Console.WriteLine(SolveGallery(gallery));
                usr_input = Console.ReadLine();
                tmp_usr_input = usr_input.Split(' ');
                N = int.Parse(tmp_usr_input[0]);
                k = int.Parse(tmp_usr_input[1]);
            }
            return ret;
        }

        public int SolveGallery(int[] gallery)
        {
            int ret=0;
            return ret;
        }

        static void Main(string[] args)
        {
            GallerySolver GS = new GallerySolver();
            GS.SolveGalleries();
        }
    }
}
