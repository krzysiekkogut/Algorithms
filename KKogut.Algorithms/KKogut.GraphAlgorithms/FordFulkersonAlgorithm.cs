using System;
using KKogut.PriorityQueue;

namespace KKogut.GraphAlgorithms
{
    public class FordFulkersonAlgorithm
    {
        private int n;
        private int[,] edges;
        private int[,] residual;

        public FordFulkersonAlgorithm(int numberOfVerticies)
        {
            n = numberOfVerticies;
            edges = new int[n, n];
            residual = new int[n, n];
        }

        public void AddEdge(int u, int v, int w)
        {
            edges[u, v] = w;
            residual[u, v] = w;
        }

        public int FindMaximumFlow(int source, int sink)
        {
            int[] parent = new int[n];
            int maxFlow = 0;

            while (BFS(residual, source, sink, parent))
            {
                int pathFlow = int.MaxValue;
                int v = sink;
                while (v != source)
                {
                    var u = parent[v];
                    pathFlow = Math.Min(pathFlow, residual[u, v]);
                    v = parent[v];
                }

                v = sink;
                while (v != source)
                {
                    var u = parent[v];
                    residual[u, v] -= pathFlow;
                    residual[v, u] += pathFlow;
                    v = parent[v];
                }

                maxFlow += pathFlow;
            }

            return maxFlow;
        }

        private bool BFS(int[,] graph, int source, int destination, int[] parent)
        {
            bool[] visited = new bool[n];
            var queue = new PriorityQueue<int>(n);
            queue.Enqueue(source);
            visited[source] = true;
            parent[source] = -1;

            while (queue.Count != 0)
            {
                var u = queue.Dequeue();
                for (int v = 0; v < n; v++)
                {
                    if (!visited[v] && graph[u, v] > 0)
                    {
                        queue.Enqueue(v);
                        parent[v] = u;
                        visited[v] = true;
                    }
                }
            }

            return visited[destination] == true;
        }
    }
}
