using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabinKarp
{
    /// <summary>
    /// Implementation of Rabin Karp string matcher algorithm with d = 10
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] t = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] p = { 2, 3, 4, 5 };

            int n = t.Length;
            int m = p.Length;
            int _t=0,_p=0;
            int d = 10;
            int h = (int)Math.Pow(d, m - 1);

            //preprocessing
            for (int i = 0; i < m; i++) {
                _t = _t * d + t[i];
                _p = _p * d + p[i];
            }

            //main logic
            for (int s = 0; s < (n - m); s++) {
                if (_p == _t) {
                    int flag = 0, k = s,l = 0;
                    while (k < m) {
                        if (p[l++] != t[k++]) {
                            flag = 1;
                            break;
                        }
                    }
                    if (flag == 0) {
                        Console.WriteLine("pattern occurs with the shift:{0}",s);
                    }
                }
                
                int temp = (_t - t[s] * h) * d + t[s + m];
                _t = temp;
            }

            Console.ReadKey();
        }
    }
}
