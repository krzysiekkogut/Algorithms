using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KKogut.Algorithms.Tests.GraphAlgorithms
{
    [TestClass]
    public class PrimAlgorithmTests
    {
        [TestMethod]
        public void OneEdgeGraph()
        {
            var prim = new PrimAlgorithm(2);
            prim.AddEdge(0, 1, 10);

            Assert.AreEqual(10, prim.FindMST());
        }

        [TestMethod]
        public void TwoEdgesGraph_NoCycle()
        {
            var prim = new PrimAlgorithm(3);
            prim.AddEdge(0, 1, 10);
            prim.AddEdge(1, 2, 10);

            Assert.AreEqual(20, prim.FindMST());
        }

        [TestMethod]
        public void ThreeEdgesTwoVerticesGraph_Cycle()
        {
            var prim = new PrimAlgorithm(3);
            prim.AddEdge(0, 1, 10);
            prim.AddEdge(1, 2, 10);
            prim.AddEdge(2, 0, 10);

            Assert.AreEqual(20, prim.FindMST());
        }

        [TestMethod]
        public void TwoCyclesDifferentWeightOfEdges()
        {
            var prim = new PrimAlgorithm(6);
            prim.AddEdge(0, 1, 1);
            prim.AddEdge(0, 2, 1);
            prim.AddEdge(2, 3, 1);
            prim.AddEdge(1, 3, 1);
            prim.AddEdge(1, 4, 2);
            prim.AddEdge(3, 5, 2);
            prim.AddEdge(4, 5, 2);

            Assert.AreEqual(7, prim.FindMST());
        }
    }
}
