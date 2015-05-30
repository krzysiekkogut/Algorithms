using System;
using System.Linq;
using KKogut.Algorithms.Tests.GraphAlgorithms;
using KKogut.ChangeProblem;
using KKogut.ClosestPairOfPointsProblem;
using KKogut.Euklides;
using KKogut.FibonacciSequenceUsingMatrix;
using KKogut.GraphAlgorithms;
using KKogut.LongestCommonSubsequence;
using KKogut.MultiplicationAlgorithms;
using KKogut.PriorityQueue;
using KKogut.SortAlgorithms;

namespace KKogut.Algorithms
{
    static class Runners
    {
        public static void RunRussianMultiplication()
        {
            Console.WriteLine("Enter two natural numbers (delimitted with space):");
            var @in = Console.ReadLine().Split(' ');
            Console.WriteLine(RussianMultiplication.Multiplicate(Convert.ToInt64(@in[0]), Convert.ToInt64(@in[1])));
        }

        public static void RunBubbleSort()
        {
            Console.WriteLine("Enter natural numbers to sort (delimitted with space):");
            var @in = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
            var @out = @in.BubbleSort<int>();
            foreach (var number in @out)
            {
                Console.Write("{0} ", number);
            }
            Console.WriteLine();
        }

        public static void RunInsertionSort()
        {
            Console.WriteLine("Enter natural numbers to sort (delimitted with space):");
            var @in = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
            var @out = @in.InsertionSort<int>();
            foreach (var number in @out)
            {
                Console.Write("{0} ", number);
            }
            Console.WriteLine();
        }

        public static void RunSelectionSort()
        {
            Console.WriteLine("Enter natural numbers to sort (delimitted with space):");
            var @in = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
            var @out = @in.SelectionSort<int>();
            foreach (var number in @out)
            {
                Console.Write("{0} ", number);
            }
            Console.WriteLine();
        }

        public static void RunMergeSort()
        {
            Console.WriteLine("Enter natural numbers to sort (delimitted with space):");
            var @in = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
            var @out = @in.MergeSort<int>();
            foreach (var number in @out)
            {
                Console.Write("{0} ", number);
            }
            Console.WriteLine();
        }

        public static void RunQuickSort()
        {
            Console.WriteLine("Enter natural numbers to sort (delimitted with space):");
            var @in = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
            var @out = @in.QuickSort<int>();
            foreach (var number in @out)
            {
                Console.Write("{0} ", number);
            }
            Console.WriteLine();
        }

        public static void RunEuklidesGCD()
        {
            Console.WriteLine("Enter two integers (delimitted with space):");
            var @in = Console.ReadLine().Split(' ');
            Console.WriteLine(EuklidesAlgorithm.GCD(Convert.ToInt64(@in[0]), Convert.ToInt64(@in[1])));
        }

        public static void RunFibonacciSequence()
        {
            Console.WriteLine("Enter natural number:");
            var @in = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(FibonacciSequence.GetFibonacciNumber(@in));
        }

        public static void RunDijkstrasAlgorithm()
        {
            Console.WriteLine("Enter the number of vertices:");
            var n = Convert.ToInt32(Console.ReadLine());
            var dijkstra = new DijkstrasAlgorithm(n);
            Console.WriteLine("Enter edges and their weights (in format: u v w).");
            Console.WriteLine("To finish type \"enough\"");
            while (true)
            {
                var @in = Console.ReadLine();
                if (@in.ToLower().Equals("enough")) break;
                var split = @in.Split(' ');
                dijkstra.AddEdge(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]), Convert.ToInt32(split[2]));
            }
            Console.WriteLine("Type in a number of source vertex:");
            var v = Convert.ToInt32(Console.ReadLine());
            var distances = dijkstra.FindShortestDistancesFromVertex(v);
            Console.WriteLine("Shortest paths to u from v is of distance:");
            Console.WriteLine("u\tdistance");
            for (int i = 0; i < distances.Length; i++)
                Console.WriteLine("{0}\t{1}", i, distances[i]);
            Console.WriteLine();
        }

        public static void RunFloydWarshallAlgorithm()
        {
            Console.WriteLine("Enter the number of vertices:");
            var n = Convert.ToInt32(Console.ReadLine());
            var fw = new FloydWarshallAlgorithm(n);
            Console.WriteLine("Enter edges and their weights (in format: u v w).");
            Console.WriteLine("To finish type \"enough\"");
            while (true)
            {
                var @in = Console.ReadLine();
                if (@in.ToLower().Equals("enough")) break;
                var split = @in.Split(' ');
                fw.AddEdge(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]), Convert.ToInt32(split[2]));
            }
            var distances = fw.FindShortestPaths();
            Console.WriteLine("Shortest paths (i -> j: distance):");
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    Console.WriteLine("{0} -> {1}: {2}", i, j, distances[i, j]);
            Console.WriteLine();
        }

        public static void RunPriorityQueue()
        {
            Console.WriteLine("Enter size of queue:");
            var size = Convert.ToInt32(Console.ReadLine());
            var queue = new PriorityQueue<int>(size);
            Console.WriteLine("Enter next operations: \"e 5\" will enqueue 5, \"d\" will dequeue next value, \"min\" would show you next value (without removal).");
            Console.WriteLine("To finish hit enter.");
            while (true)
            {
                try
                {
                    var @in = Console.ReadLine();
                    var split = @in.Split(' ');
                    switch (split[0])
                    {
                        case "e":
                            queue.Enqueue(Convert.ToInt32(split[1]));
                            break;
                        case "d":
                            Console.WriteLine(queue.Dequeue());
                            break;
                        case "min":
                            Console.WriteLine(queue.Min);
                            break;
                        default:
                            return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
        }

        public static void RunGreedyChangeMakingProblem()
        {
            var gc = new GreedyChange();
            Console.WriteLine("Enter available coins (delimitted with space):");
            var coins = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
            gc.RegisterCoins(coins);
            Console.WriteLine("Enter amount to change:");
            var change = gc.GetChangeFor(Convert.ToInt32(Console.ReadLine()));
            foreach (var c in change)
                Console.Write("{0} ", c);
            Console.WriteLine();
        }

        public static void RunKaratsubaMultiplication()
        {
            Console.WriteLine("Enter two natural numbers (delimitted with space):");
            var @in = Console.ReadLine().Split(' ');
            Console.WriteLine(KaratsubaMultiplication.Multiplicate(Convert.ToInt64(@in[0]), Convert.ToInt64(@in[1])));
        }

        public static void RunFordFulkersonAlgorithm()
        {
            Console.WriteLine("Enter the number of vertices:");
            var n = Convert.ToInt32(Console.ReadLine());
            var ff = new FordFulkersonAlgorithm(n);
            Console.WriteLine("Enter edges and their capacities (in format: u v c).");
            Console.WriteLine("To finish type \"enough\"");
            string @in;
            string[] split;
            while (true)
            {
                @in = Console.ReadLine();
                if (@in.ToLower().Equals("enough")) break;
                split = @in.Split(' ');
                ff.AddEdge(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]), Convert.ToInt32(split[2]));
            }
            Console.WriteLine("Type in a number of source and sink vertices (delimitted with space):");
            @in = Console.ReadLine();
            split = @in.Split(' ');
            var maxFlow = ff.FindMaximumFlow(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]));
            Console.WriteLine("Max flow of this graph is {0}.", maxFlow);
            Console.WriteLine();
        }

        public static void RunLCS()
        {
            Console.WriteLine("Enter first string:");
            var s1 = Console.ReadLine();
            Console.WriteLine("Enter second string:");
            var s2 = Console.ReadLine();
            Console.WriteLine("Length of longest common subsequence is {0}.", LCS.FindLCS(s1, s2));
            Console.WriteLine();
        }

        public static void RunClosestPairOfPointsProblem()
        {
            Console.WriteLine("Enter coordinates of points in format \"x y\" (only int):");
            Console.WriteLine("To finish type \"enough\"");
            var cpp = new ClosestPairOfPoints();
            while (true)
            {
                var @in = Console.ReadLine();
                if (@in.Equals("enough")) break;
                var split = @in.Split(' ');
                cpp.AddPoint(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]));
            }
            var result = cpp.FindClosestPoints();
            Console.WriteLine("Closest points are: ({0}, {1}) and ({2}, {3})", result.First.X, result.First.Y, result.Second.X, result.Second.Y);
        }

        public static void RunKruskalAlgorithm()
        {
            Console.WriteLine("Enter the number of vertices:");
            var n = Convert.ToInt32(Console.ReadLine());
            var kruskal = new KruskalAlgorithm(n);
            Console.WriteLine("Enter edges and their weights (in format: u v w).");
            Console.WriteLine("To finish type \"enough\"");
            while (true)
            {
                var @in = Console.ReadLine();
                if (@in.ToLower().Equals("enough")) break;
                var split = @in.Split(' ');
                kruskal.AddEdge(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]), Convert.ToInt32(split[2]));
            }
            Console.WriteLine("Weight if MST for given graph is {0}.", kruskal.FindMST());
        }

        public static void RunPrimAlgorithm()
        {
            Console.WriteLine("Enter the number of vertices:");
            var n = Convert.ToInt32(Console.ReadLine());
            var prim = new PrimAlgorithm(n);
            Console.WriteLine("Enter edges and their weights (in format: u v w).");
            Console.WriteLine("To finish type \"enough\"");
            while (true)
            {
                var @in = Console.ReadLine();
                if (@in.ToLower().Equals("enough")) break;
                var split = @in.Split(' ');
                prim.AddEdge(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]), Convert.ToInt32(split[2]));
            }
            Console.WriteLine("Weight if MST for given graph is {0}.", prim.FindMST());
        }
    }

}
