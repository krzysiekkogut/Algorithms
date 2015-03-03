﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKogut.RussianMultiplication
{
    public static class RussianMultiplication
    {
        public static long Multiplicate(long a, long b)
        {
            var A = new List<bool>();
            while (a >= 1)
            {
                A.Add(a % 2 == 1);
                a /= 2;
            }

            long result = 0;

            for (int i = 0; i < A.Count; i++)
            {
                if (A[i])
                {
                    result += b;
                }
                b *= 2;
            }

            return result;

        }
    }
}
