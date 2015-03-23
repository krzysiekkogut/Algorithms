using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKogut.LongestCommonSubsequence
{
    public class LCS
    {
        public static int FindLCS(string s1, string s2)
        {
            if (s1.Length > s2.Length)
            {
                var tmp = s1;
                s1 = s2;
                s2 = tmp;
            }

            var t = new int[2, s2.Length + 1];

            for (int i = 0; i < s1.Length; i++)
            {
                for (int j = 1; j <= s2.Length; j++)
                {
                    if (s1[i].Equals(s2[j - 1]))
                        t[1, j] = t[0, j - 1] + 1;
                    else
                        t[1, j] = Math.Max(t[0, j], t[1, j-1]);
                }
                for (int j = 0; j <= s2.Length; j++)
                    t[0, j] = t[1, j];
            }

            return t[0, s2.Length];
        }
    }
}
