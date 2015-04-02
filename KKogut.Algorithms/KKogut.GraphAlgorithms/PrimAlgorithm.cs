using System;
using System.Collections.Generic;
using System.Linq;

namespace KKogut.Algorithms.Tests.GraphAlgorithms
{
    public class PrimAlgorithm
    {
        private int n;
        private int[,] edges;
        private int[] distances;
        private bool[] visited;
        private SortedList<int, int> q;
        
        public PrimAlgorithm(int numberOfVertices)
        {
            n = numberOfVertices;
            edges = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    edges[i, j] = -1;
            distances = new int[n];
            q = new SortedList<int, int>(n);
            for (int i = 0; i < n; i++)
                distances[i] = int.MaxValue;
            visited = new bool[n];
        }

        public void AddEdge(int u, int v, int w)
        {
            edges[u, v] = edges[v, u] = w;
        }

        public int FindMST()
        {
            var v = FirstVertex();
         
            distances[v] = 0;
            q.Add(v, distances[v]);

            while (q.Any())
            {
                var u = q.First().Key;
                q.RemoveAt(0);
                for (int i = 0; i < n; i++)
                {
                    if (edges[u, i] == -1 || visited[i]) continue;
                    if (edges[u,i] < distances[i])
                    {
                        distances[i] = edges[u, i];
                        if (q.ContainsKey(i)) q[i] = distances[i];
                        else q.Add(i, distances[i]);
                    }
                }
            }

            return distances.Sum();
        }

        private int FirstVertex()
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (edges[i, j] != -1)
                        return i;
            throw new Exception("Empty graph.");
        }
    }
}
