using System;
using System.Linq;
using KKogut.ChangeProblem;
using KKogut.FibonacciSequenceUsingMatrix;
using KKogut.FloydWarshallAlorithm;
using KKogut.MultiplicationAlgorithms;
using KKogut.PriorityQueue;
using KKogut.SortAlgorithms;

namespace KKogut.Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please type in a number of algorithm:");
                var x = Console.ReadLine();
                switch (x)
                {
                    case "0":
                        RunRussianMultiplication();
                        break;
                    case "1":
                        RunBubbleSort();
                        break;
                    case "2":
                        RunInsertionSort();
                        break;
                    case "3":
                        RunSelectionSort();
                        break;
                    case "4":
                        RunMergeSort();
                        break;
                    case "5":
                        RunFibonacciSequence();
                        break;
                    case "6":
                        RunDijkstrasAlgorithm();
                        break;
                    case "7":
                        RunFloydWarshallAlgorithm();
                        break;
                    case "8":
                        RunPriorityQueue();
                        break;
                    case "9":
                        RunGreedyChangeMakingProblem();
                        break;
                    default:
                        return;
                }
                Console.WriteLine();
            }
        }

        private static void RunRussianMultiplication()
        {
            Console.WriteLine("Enter two natural numbers (delimitted with space):");
            var @in = Console.ReadLine().Split(' ');
            Console.WriteLine(RussianMultiplication.Multiplicate(Convert.ToInt64(@in[0]), Convert.ToInt64(@in[1])));
        }

        private static void RunBubbleSort()
        {
            Console.WriteLine("Enter natural numbers to sort (delimitted with space):");
            var @in = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x));
            var @out = @in.BubbleSort<int>();
            foreach (var number in @out)
            {
                Console.Write("{0} ", number);
            }
            Console.WriteLine();
        }

        private static void RunInsertionSort()
        {
            Console.WriteLine("Enter natural numbers to sort (delimitted with space):");
            var @in = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x));
            var @out = @in.InsertionSort<int>();
            foreach (var number in @out)
            {
                Console.Write("{0} ", number);
            }
            Console.WriteLine();
        }

        private static void RunSelectionSort()
        {
            Console.WriteLine("Enter natural numbers to sort (delimitted with space):");
            var @in = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x));
            var @out = @in.SelectionSort<int>();
            foreach (var number in @out)
            {
                Console.Write("{0} ", number);
            }
            Console.WriteLine();
        }

        private static void RunMergeSort()
        {
            Console.WriteLine("Enter natural numbers to sort (delimitted with space):");
            var @in = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x));
            var @out = @in.MergeSort<int>();
            foreach (var number in @out)
            {
                Console.Write("{0} ", number);
            }
            Console.WriteLine();
        }

        private static void RunFibonacciSequence()
        {
            Console.WriteLine("Enter natural number:");
            var @in = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(FibonacciSequence.GetFibonacciNumber(@in));
        }

        private static void RunDijkstrasAlgorithm()
        {
            Console.WriteLine("Enter the number of vertices:");
            var n = Convert.ToInt32(Console.ReadLine());
            var dijkstra = new DijkstrasAlgorithm.DijkstrasAlgorithm(n);
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

        private static void RunFloydWarshallAlgorithm()
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

        private static void RunPriorityQueue()
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

        private static void RunGreedyChangeMakingProblem()
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
    }
}
