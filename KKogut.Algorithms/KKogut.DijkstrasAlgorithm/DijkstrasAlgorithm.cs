using System.Collections.Generic;
using System.Linq;

namespace KKogut.DijkstrasAlgorithm
{
    public class DijkstrasAlgorithm
    {
        private int n;
        private int[,] edges;
        private int[] distances;
        private SortedList<int, int> q;

        public DijkstrasAlgorithm(int numberOfVertices)
        {
            n = numberOfVertices;
            edges = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    edges[i, j] = -1;
            distances = new int[n];
            q = new SortedList<int, int>(n);
            for (int i = 0; i < n; i++)
            {
                distances[i] = int.MaxValue;
                q.Add(i, distances[i]);
            }
        }

        public void AddEdge(int u, int v, int w)
        {
            edges[u, v] = edges[v, u] = w;
        }

        public int[] FindShortestDistancesFromVertex(int v)
        {
            distances[v] = q[v] = 0;

            while (q.Any())
            {
                var u = q.First().Key;
                q.RemoveAt(0);
                for (int i = 0; i < n; i++)
                {
                    if (edges[u, i] == -1) continue;

                    if (distances[u] + edges[u, i] < distances[i])
                    {
                        distances[i] = distances[u] + edges[u, i];
                        if (q.ContainsKey(i)) q[i] = distances[i];
                        else q.Add(i, distances[i]);
                    }
                }
            }

            return distances;
        }
    }
}
