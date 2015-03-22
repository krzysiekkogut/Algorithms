using System;
using KKogut.GraphAlgorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KKogut.Algorithms.Tests
{
    [TestClass]
    public class FordFulkersonAlgorithmTests
    {
        [TestMethod]
        public void MaximumFlowForExampleGraph()
        {
            var ff = new FordFulkersonAlgorithm(6);
            ff.AddEdge(0, 1, 16);
            ff.AddEdge(0, 2, 13);
            ff.AddEdge(1, 2, 10);
            ff.AddEdge(1, 3, 12);
            ff.AddEdge(2, 1, 4);
            ff.AddEdge(2, 4, 14);
            ff.AddEdge(3, 2, 9);
            ff.AddEdge(3, 5, 20);
            ff.AddEdge(4, 3, 7);
            ff.AddEdge(4, 5, 4);            

            var maxFlow = ff.FindMaximumFlow(0, 5);

            Assert.AreEqual(23, maxFlow);
        }
    }
}
