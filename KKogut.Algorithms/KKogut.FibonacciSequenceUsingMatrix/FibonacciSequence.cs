using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKogut.FibonacciSequenceUsingMatrix
{
    public static class FibonacciSequence
    {
        public static long GetFibonacciNumber(int n)
        {
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;

            var A = new Matrix(2, 2);
            A[0, 0] = A[0, 1] = A[1, 0] = 1;
            A[1, 1] = 0;

            var F = new Matrix(2, 1);
            F[0, 0] = 1;
            F[1, 0] = 0;

            return ((A ^ (n - 1)) * F)[0, 0];
        }
    }
}
