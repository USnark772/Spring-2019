using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS7_6_algs
{
    public class Program
    {
        #region HelperFuncs
        /*
        For x ≥ 0,  x mod N  is remainder after dividing  by N
        For x < 0,  x mod N  is  N – (-x mod N)
        */
        private long MyMod(long a, long b)
        {
            long ret;
            if (a >= 0)
                ret = a % b;
            else
                ret = b - ((-a) % b);
            return ret;
        }

        /*
        gcd (a, b)
            while (b > 0)
                aModB = a mod b
                a = b
                b = aModB
            return a

        */
        private long GCDHelper(long a, long b)
        {
            long temp;
            while (b > 0)
            {
                temp = MyMod(a, b);
                a = b;
                b = temp;
            }
            return a;
        }

        /*
          modexp (x, y, N)
          if y == 0
              return 1
          else
              z = modexp(x, y/2, N)
              if y is even
                  return z^2 mod N
              else
                  return x∙z^2 mod N 
        */
        private long ModExp(long x, long y, long N)
        {
            long z;
            long temp;
            if (y == 0)
                return 1;
            else
            {
                z = ModExp(x, y / 2, N);
                temp = MyMod(y, 2);
                if (temp == 0)
                {
                    return MyMod((z * z), N);
                }
                else return MyMod((x * z * z), N);
            }
        }

        /*
        // Extended Euclid’s algorithm.  
        // Returns  [x, y, d] such that 
        // d = gcd(a,b)  and  ax + by = d

        ee (a, b)
            if b == 0
                return [1, 0, a]
            else
                [x’, y’, d] = ee(b, a mod b)
                return [y’,  x’ – (a/b)y’,  d]
        */
        private long[] ExtEuc(long a, long b)
        {
            long[] ret = new long[3];
            if (b == 0)
            {
                ret[0] = 1;
                ret[1] = 0;
                ret[2] = a;
            }
            else
            {
                long[] tempRet = ExtEuc(b, MyMod(a, b));
                ret[0] = tempRet[1];
                ret[1] = tempRet[0] - (a / b) * tempRet[1];
                ret[2] = tempRet[2];
            }
            return ret;
        }

        /*
        // Returns a-1 (mod N) or 
        // reports that no inverse exists

        inverse (a, N)
            [x, y, d] = ee(a, N)
            if d == 1
                return x mod N
            else
                return “No Inverse!”
        */
        private long InverseFinder(long a, long N)
        {
            long[] eucRet = ExtEuc(a, N);
            long res;
            if (eucRet[2] == 1)
            {
                res = MyMod(eucRet[0], N);
                return res;
            }
            else
            {
                res = -1;
                return res;
            }
        }
        #endregion

        #region FinishedAlgs
        /// <summary>
        /// Print the modulus N, public exponent e, and private exponent d of the RSA key pair derived from p and q.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        private void Key(long p, long q)
        {
            long N, e = 2, d;
            N = p * q;
            long thi = (p - 1) * (q - 1);
            long temp = GCDHelper(e, thi);
            while (temp != 1)
            {
                e++;
                temp = GCDHelper(e, thi);
            }
            d = InverseFinder(e, thi);
            Console.WriteLine(N + " " + e + " " + d);
        }

        /// <summary>
        /// Print yes if p (p > 5) passes the Fermat test for a = 2, 3, and 5; print no otherwise.
        /// </summary>
        /// <param name="p"></param>
        private void IsPrime(long p)
        {
            if (ModExp(1, p - 1, p) == 1 && ModExp(3, p - 1, p) == 1 && ModExp(5, p - 1, p) == 1)
                Console.WriteLine("yes");
            else
                Console.WriteLine("no");
        }

        /// <summary>
        /// Print a^(-1)modN which must be positive and less than N. If no inverse exists, print "none".
        /// </summary>
        /// <param name="a"></param>
        /// <param name="N"></param>
        private void Inverse(long a, long N)
        {
            long res = InverseFinder(a, N);
            if (res >= 0)
            {
                Console.WriteLine(res);
            }
            else
            {
                Console.WriteLine("none");
            }
        }

        /// <summary>
        /// Print x^ymodN which must be non-negative and less than N.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="N"></param>
        private void EXP(long x, long y, long N)
        {
            Console.WriteLine(ModExp(x, y, N));
        }

        /// <summary>
        /// Print the greatest common divisor of a and b.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        private void GCD(long a, long b)
        {
            Console.WriteLine(GCDHelper(a, b));
        }
        #endregion

        static void Main(string[] args)
        {
            string usr_input;
            string[] temp_usr_input;
            long a = 0, b = 0, c = 0;
            Program Solver = new Program();
            usr_input = Console.ReadLine();
            while (!usr_input.Equals(""))
            {
                temp_usr_input = usr_input.Split(' ');
                if (temp_usr_input[0].Equals("gcd"))
                {
                    long.TryParse(temp_usr_input[1], out a);
                    long.TryParse(temp_usr_input[2], out b);
                    Solver.GCD(a, b);
                }
                else if (temp_usr_input[0].Equals("exp"))
                {
                    long.TryParse(temp_usr_input[1], out a);
                    long.TryParse(temp_usr_input[2], out b);
                    long.TryParse(temp_usr_input[3], out c);
                    Solver.EXP(a, b, c);
                }
                else if (temp_usr_input[0].Equals("inverse"))
                {
                    long.TryParse(temp_usr_input[1], out a);
                    long.TryParse(temp_usr_input[2], out b);
                    Solver.Inverse(a, b);
                }
                else if (temp_usr_input[0].Equals("isprime"))
                {
                    long.TryParse(temp_usr_input[1], out a);
                    Solver.IsPrime(a);
                }
                else if (temp_usr_input[0].Equals("key"))
                {
                    long.TryParse(temp_usr_input[1], out a);
                    long.TryParse(temp_usr_input[2], out b);
                    Solver.Key(a, b);
                }
                usr_input = Console.ReadLine();
            }
        }
    }
}
