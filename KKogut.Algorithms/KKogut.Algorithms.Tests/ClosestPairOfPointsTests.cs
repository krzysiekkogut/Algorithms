using System;
using KKogut.ClosestPairOfPointsProblem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KKogut.Algorithms.Tests
{
    [TestClass]
    public class ClosestPairOfPointsTests
    {
        [TestMethod]
        public void ExampleClosestPairOfPoints()
        {
            var cpp = new ClosestPairOfPoints();
            cpp.AddPoint(0, 0);
            cpp.AddPoint(-4, 1);
            cpp.AddPoint(-7, -2);
            cpp.AddPoint(4, 5);
            cpp.AddPoint(1, 1);
            var expected = new Segment(new Point(0, 0), new Point(1, 1));

            var result = cpp.FindClosestPoints();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BiggerTest()
        {
            var cpp = new ClosestPairOfPoints();
            cpp.AddPoint(12486, 11863);
            cpp.AddPoint(-1845, 11079);
            cpp.AddPoint(-10302, -11812);
            cpp.AddPoint(-13778, -12047);
            cpp.AddPoint(-13353, -8242);
            cpp.AddPoint(-13252, 11824);
            cpp.AddPoint(5966, 14725);
            cpp.AddPoint(-8914, -9931);
            cpp.AddPoint(6354, 8675);
            cpp.AddPoint(-11093, 16);
            cpp.AddPoint(1492, 11400);
            cpp.AddPoint(14663, -3715);
            cpp.AddPoint(-5075, 11588);
            cpp.AddPoint(-4278, 10241);
            cpp.AddPoint(-2299, 15314);
            cpp.AddPoint(-15182, 2870);
            cpp.AddPoint(-1292, 8131);
            cpp.AddPoint(-389, -9373);
            cpp.AddPoint(3432, 14520);
            cpp.AddPoint(-13539, -1200);
            cpp.AddPoint(11079, 14036);
            cpp.AddPoint(15959, 3161);
            var expected = new Segment(new Point(-5075, 11588), new Point(-4278, 10241));

            var result = cpp.FindClosestPoints();

            Assert.AreEqual(expected, result);
        }
    }
}
