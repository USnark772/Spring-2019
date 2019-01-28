using System;

namespace SelectFunction
{
    class Program
    {
        static int SelectHelper(int[] A, int loA, int hiA, int[] B, int loB, int hiB, int k)
        {
            Console.WriteLine("Scanning array A: ");
            for (int a = loA; a < hiA; a++)
            {
                Console.WriteLine(A[a]);
            }
            Console.WriteLine("Scanning array B: ");
            for (int b = loB; b < hiB; b++)
            {
                Console.WriteLine(B[b]);
            }
            if (hiA < loA)
                return B[k - loA];
            if (hiB < loB)
                return A[k - loB];
            int i = (loA + hiA) / 2;
            int j = (loB + hiB) / 2;
            if (A[i] > B[j])
            {
                if (k <= (i + j))
                    return SelectHelper(A, loA, i - 1, B, loB, j, k);
                else
                    return SelectHelper(A, i, hiA, B, j + 1, hiB, k);
            }
            else
            {
                if (k <= (i + j))
                    return SelectHelper(A, loA, i, B, loB, j - 1, k);
                else
                    return SelectHelper(A, i + 1, hiA, B, j, hiB, k);
            }

        }

        static int Select(int[] A, int[] B, int k)
        {
            return SelectHelper(A, 0, A.Length - 1, B, 0, B.Length - 1, k);
        }

        static void Main(string[] args)
        {
            int[] A = { 1, 2, 3, 4, 5 };
            int[] B = { 6, 7, 8, 9, 10 };
            int[] merged = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int k = 4;
            Console.WriteLine(merged[k] + " should be the same as " + Select(A, B, k));
            Console.Read();
        }
    }
}
