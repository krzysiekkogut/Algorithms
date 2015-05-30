using System;
using System.Collections.Generic;
using System.Linq;
using KKogut.GraphAlgorithms;

namespace KKogut.Algorithms.Tests.GraphAlgorithms
{
    public class PrimAlgorithm
    {
        private int n;
        private int[,] edges;
        private int[] distances;
        private Dictionary<int, int> q;

        public PrimAlgorithm(int numberOfVertices)
        {
            FirstVertex = -1;
            n = numberOfVertices;
            edges = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    edges[i, j] = -1;
            distances = new int[n];
            for (int i = 0; i < n; i++)
                distances[i] = int.MaxValue;
            q = new Dictionary<int, int>(n);
        }

        public void AddEdge(int u, int v, int w)
        {
            if (FirstVertex == -1)
                FirstVertex = u;

            edges[u, v] = edges[v, u] = w;
        }

        public int FindMST()
        {
            if (FirstVertex == -1)
                throw new Exception("Empty graph.");

            distances[FirstVertex] = 0;
            q.Add(FirstVertex, distances[FirstVertex]);

            while (q.Any())
            {
                var u = q.First().Key;
                q.Remove(u);
                for (int i = 0; i < n; i++)
                {
                    if (edges[u, i] != -1 && edges[u, i] < distances[i])
                    {
                        distances[i] = edges[u, i];
                        if (q.ContainsKey(i)) q[i] = distances[i];
                        else q.Add(i, distances[i]);
                    }
                }
            }

            return distances.Sum();
        }

        private int FirstVertex { get; set; }
    }
}
