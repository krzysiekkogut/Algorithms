using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKogut.MultiplicationAlgorithms
{
    public static class KaratsubaMultiplication
    {
        public static long Multiplicate(long a, long b)
        {
            if (a < 10 || b < 10)
                return a * b;
            var length = Math.Max(a.NumberLength(), b.NumberLength());
            var A = Split(a, length / 2);
            var B = Split(b, length / 2);

            var x = Multiplicate(A.Item2, B.Item2);
            var y = Multiplicate(A.Item1 + A.Item2, B.Item1 + B.Item2);
            var z = Multiplicate(A.Item1, B.Item1);
            return z * 10.Pow(length) + (y - z - x) * 10.Pow(length / 2) + x;
        }

        private static int NumberLength(this long number)
        {
            return number == 0 ? 1 : Convert.ToInt32(Math.Floor(Math.Log10(number))) + 1;
        }

        private static Tuple<long, long> Split(long number, int positon)
        {
            return new Tuple<long, long>
                (number / 10.Pow(positon),
                 number % 10.Pow(positon));
        }

        private static long Pow(this int @base, long pow)
        {
            return Convert.ToInt64(Math.Pow(@base, pow));
        }
    }
}
