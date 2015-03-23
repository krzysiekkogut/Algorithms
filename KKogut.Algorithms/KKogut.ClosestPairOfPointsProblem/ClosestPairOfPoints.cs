using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKogut.ClosestPairOfPointsProblem
{
    public class ClosestPairOfPoints
    {
        private List<Point> points;

        public ClosestPairOfPoints()
        {
            points = new List<Point>();
        }

        public void AddPoint(int x, int y)
        {
            points.Add(new Point(x, y));
        }

        public Segment FindClosestPoints()
        {
            return FindClosestPoints(points.OrderBy(p => p.X));
        }

        private Segment FindClosestPoints(IEnumerable<Point> orderedPoints)
        {
            if (orderedPoints.Count() <= 4)
                return FindClosestPointsAdHoc(orderedPoints);

            var left = orderedPoints.Take(orderedPoints.Count() / 2);
            var leftResult = FindClosestPoints(left);

            var right = orderedPoints.Skip(orderedPoints.Count() / 2);
            var rightResult = FindClosestPoints(right);

            var result = rightResult.Length < leftResult.Length ? rightResult : leftResult;

            var mid = left.Last().X;
            var width = result.Length;
            var inBand = orderedPoints.Where(p => Math.Abs(mid - p.X) <= width).OrderBy(p => p.Y);

            for (int i = 0; i < inBand.Count() - 1; i++)
            {
                var low = inBand.ElementAt(i);
                for (int j = i + 1; j < inBand.Count(); j++)
                {
                    var high = inBand.ElementAt(j);
                    if ((high.Y - low.Y) >= result.Length)
                        break;

                    if (new Segment(low, high).Length < result.Length)
                        result = new Segment(low, high);
                }
            }

            return result;

        }

        private Segment FindClosestPointsAdHoc(IEnumerable<Point> orderedPoints)
        {
            double minLength = double.MaxValue;
            Segment minSeg = null;
            for (int i = 0; i < orderedPoints.Count(); i++)
            {
                for (int j = i + 1; j < orderedPoints.Count(); j++)
                {
                    var s = new Segment(orderedPoints.ElementAt(i), orderedPoints.ElementAt(j));
                    if (s.Length < minLength)
                    {
                        minLength = s.Length;
                        minSeg = s;
                    }
                }
            }
            return minSeg;
        }
    }
}
