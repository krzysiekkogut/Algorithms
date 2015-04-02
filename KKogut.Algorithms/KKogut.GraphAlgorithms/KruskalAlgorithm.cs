using System;
using System.Collections.Generic;
using System.Linq;

namespace KKogut.GraphAlgorithms
{
    public class KruskalAlgorithm
    {
        private int n;
        private Dictionary<Tuple<int, int>, int> edges;

        public KruskalAlgorithm(int numberOfVertices)
        {
            n = numberOfVertices;
            edges = new Dictionary<Tuple<int, int>, int>();
        }

        public void AddEdge(int u, int v, int w)
        {
            edges.Add(new Tuple<int, int>(u, v), w);
        }

        public int FindMST()
        {
            var result = 0;
            var visited = new bool[n];

            var orderedEdges = edges.OrderBy(e => e.Value);
            foreach (var edge in orderedEdges)
            {
                if (visited[edge.Key.Item1] && visited[edge.Key.Item2]) continue;
                result += edge.Value;
                visited[edge.Key.Item1] = visited[edge.Key.Item2] = true;
            }
            
            return result;
        }
    }
}
