using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KKogut.Algorithms.Tests
{
    [TestClass]
    public class DijkstrasAlgorithmTest
    {
        [TestMethod]
        public void ShortestPathForExampleGraph()
        {
            var dijkstra = new DijkstrasAlgorithm.DijkstrasAlgorithm(6);
            dijkstra.AddEdge(0, 1, 7);
            dijkstra.AddEdge(0, 2, 9);
            dijkstra.AddEdge(0, 5, 14);
            dijkstra.AddEdge(1, 2, 10);
            dijkstra.AddEdge(1, 3, 15);
            dijkstra.AddEdge(2, 3, 11);
            dijkstra.AddEdge(2, 5, 2);
            dijkstra.AddEdge(3, 4, 6);
            dijkstra.AddEdge(4, 5, 9);

            var distances = dijkstra.FindShortestDistancesFromVertex(0);

            var expected = new[] { 0, 7, 9, 20, 20, 11 };
            CollectionAssert.AreEquivalent(expected, distances);
        }
    }
}
