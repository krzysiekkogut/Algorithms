using System;
using KKogut.GraphAlgorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KKogut.Algorithms.Tests.GraphAlgorithms
{
    [TestClass]
    public class KruskalAlgorithmTests
    {
        [TestMethod]
        public void OneEdgeGraph()
        {
            var kruskal = new KruskalAlgorithm(2);
            kruskal.AddEdge(0, 1, 10);

            Assert.AreEqual(10, kruskal.FindMST());
        }

        [TestMethod]
        public void TwoEdgesGraph_NoCycle()
        {
            var kruskal = new KruskalAlgorithm(3);
            kruskal.AddEdge(0, 1, 10);
            kruskal.AddEdge(1, 2, 10);

            Assert.AreEqual(20, kruskal.FindMST());
        }

        [TestMethod]
        public void ThreeEdgesTwoVerticesGraph_Cycle()
        {
            var kruskal = new KruskalAlgorithm(3);
            kruskal.AddEdge(0, 1, 10);
            kruskal.AddEdge(1, 2, 10);
            kruskal.AddEdge(2, 0, 10);

            Assert.AreEqual(20, kruskal.FindMST());
        }

        [TestMethod]
        public void TwoCyclesDifferentWeightOfEdges()
        {
            var kruskal = new KruskalAlgorithm(6);
            kruskal.AddEdge(0, 1, 1);
            kruskal.AddEdge(0, 2, 1);
            kruskal.AddEdge(2, 3, 1);
            kruskal.AddEdge(1, 3, 1);
            kruskal.AddEdge(1, 4, 2);
            kruskal.AddEdge(3, 5, 2);
            kruskal.AddEdge(4, 5, 2);

            Assert.AreEqual(7, kruskal.FindMST());
        }
    }
}
