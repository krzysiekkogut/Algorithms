using System;
namespace KKogut.ClosestPairOfPointsProblem
{
    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public override bool Equals(object obj)
        {
            Point point = obj as Point;
            if (point == null) return false;
            return X.Equals(point.X) && Y.Equals(point.Y);
        }

        public override int GetHashCode()
        {
            return ShiftAndWrap(X.GetHashCode(), 2) ^ Y.GetHashCode();
        }

        private int ShiftAndWrap(int value, int positions)
        {
            uint number = BitConverter.ToUInt32(BitConverter.GetBytes(value), 0);
            uint wrapped = number >> (32 - positions);
            return BitConverter.ToInt32(BitConverter.GetBytes((number << positions) | wrapped), 0);
        }
    }
}
