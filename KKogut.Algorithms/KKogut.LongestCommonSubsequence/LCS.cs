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
            var t = new int[s1.Length + 1, s2.Length + 1];

            for (int i = 1; i <= s1.Length; i++)
            {
                for (int j = 1; j <= s2.Length; j++)
                {
                    if (s1[i - 1].Equals(s2[j - 1]))
                        t[i, j] = t[i - 1, j - 1] + 1;
                    else
                        t[i, j] = Math.Max(t[i - 1, j], t[i, j - 1]);
                }
            }

            return t[s1.Length, s2.Length];
        }
    }
}
