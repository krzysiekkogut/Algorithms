using System;

namespace KKogut.ClosestPairOfPointsProblem
{
    public class Segment
    {
        public Point First { get; set; }

        public Point Second { get; set; }

        public Segment(Point first, Point second)
        {
            First = first;
            Second = second;
        }

        public double Length
        {
            get
            {
                return Math.Sqrt(
                    Math.Pow(First.X - Second.X, 2)
                  + Math.Pow(First.Y - Second.Y,2));
            }
        }

        public override bool Equals(object obj)
        {
            Segment segment = obj as Segment;
            if (segment == null) return false;
            return First.Equals(segment.First) && Second.Equals(segment.Second)
                || First.Equals(segment.Second) && Second.Equals(segment.First);
        }
        
        public override int GetHashCode()
        {
            return ShiftAndWrap(First.GetHashCode(), 2) ^ Second.GetHashCode();
        }

        private int ShiftAndWrap(int value, int positions)
        {
            uint number = BitConverter.ToUInt32(BitConverter.GetBytes(value), 0);
            uint wrapped = number >> (32 - positions);
            return BitConverter.ToInt32(BitConverter.GetBytes((number << positions) | wrapped), 0);
        }
    }
}
