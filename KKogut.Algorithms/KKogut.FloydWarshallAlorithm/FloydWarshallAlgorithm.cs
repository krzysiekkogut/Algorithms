using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKogut.FloydWarshallAlorithm
{
    public class FloydWarshallAlgorithm
    {
        const int MAX = 1000000000;

        private int n;
        private int[,] edges;
        private int[,] distances;

        public FloydWarshallAlgorithm(int numberOfVertices)
        {
            n = numberOfVertices;
            edges = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    edges[i, j] = -1;
            distances = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    distances[i, j] = i == j ? 0 : MAX;
        }

        public void AddEdge(int u, int v, int w)
        {
            edges[u, v] = w;
            distances[u, v] = w;
        }

        public int[,] FindShortestPaths()
        {
            for (int k = 0; k < n; k++)
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        if (distances[i, j] > distances[i, k] + distances[k, j])
                            distances[i, j] = distances[i, k] + distances[k, j];
            return distances;
        }
    }
}
