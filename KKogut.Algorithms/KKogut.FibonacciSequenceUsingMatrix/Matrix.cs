using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KKogut.FibonacciSequenceUsingMatrix
{
    class Matrix
    {
        private int rows;
        private int columns;
        private static int mod = 100000000;

        private long[,] matrixData;

        public Matrix()
            : this(1, 1)
        { }

        public Matrix(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            matrixData = new long[rows, columns];
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < columns; c++)
                    matrixData[r, c] = 0;
        }

        public long this[int row, int column]
        {
            get { return matrixData[row, column]; }
            set { matrixData[row, column] = value % mod; }
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.columns != b.rows)
            {
                throw new ArgumentException("Number of columns in the first A has to equal number of rows in the second A.");
            }

            var result = new Matrix(a.rows, b.columns);

            for (int r = 0; r < a.rows; r++)
                for (int c = 0; c < b.columns; c++)
                    for (int i = 0; i < a.columns; i++)
                        result[r, c] += (a[r, i] * b[i, c]) % mod;

            return result;
        }

        public static Matrix operator ^(Matrix matrix, int power)
        {
            if (power == 1)
                return matrix;

            var m = (matrix ^ (power / 2));
            return power % 2 == 0 ? m * m : m * m * matrix;
        }
    }
}

