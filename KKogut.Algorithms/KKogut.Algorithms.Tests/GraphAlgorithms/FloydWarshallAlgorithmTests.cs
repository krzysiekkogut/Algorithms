using KKogut.GraphAlgorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KKogut.Algorithms.Tests.GraphAlgorithms
{
    [TestClass]
    public class FloydWarshallAlgorithmTests
    {
        [TestMethod]
        public void ShortestPathsForExampleGraph()
        {
            var expected = new int[,] 
            { 
                { 0, -1, -2, 0 }, 
                { 4,  0,  2, 4 }, 
                { 5,  1,  0, 2 }, 
                { 3, -1,  1, 0 } 
            };
            var floydWarshall = new FloydWarshallAlgorithm(4);
            floydWarshall.AddEdge(0, 2, -2);
            floydWarshall.AddEdge(1, 0, 4);
            floydWarshall.AddEdge(1, 2, 3);
            floydWarshall.AddEdge(2, 3, 2);
            floydWarshall.AddEdge(3, 1, -1);

            var distances = floydWarshall.FindShortestPaths();

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    Assert.AreEqual(expected[i, j], distances[i, j]);
        }
    }
}
