using System;

namespace KKogut.Algorithms
{
    partial class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please type in a number of algorithm:");
                var x = Console.ReadLine();
                switch (x)
                {
                    case "1":
                        RunRussianMultiplication();
                        break;
                    case "2":
                        RunBubbleSort();
                        break;
                    case "3":
                        RunInsertionSort();
                        break;
                    case "4":
                        RunSelectionSort();
                        break;
                    case "5":
                        RunMergeSort();
                        break;
                    case "6":
                        RunFibonacciSequence();
                        break;
                    case "7":
                        RunDijkstrasAlgorithm();
                        break;
                    case "8":
                        RunFloydWarshallAlgorithm();
                        break;
                    case "9":
                        RunPriorityQueue();
                        break;
                    case "10":
                        RunGreedyChangeMakingProblem();
                        break;
                    case "11":
                        RunKaratsubaMultiplication();
                        break;
                    case "12":
                        RunFordFulkersonAlgorithm();
                        break;
                    default:
                        return;
                }
                Console.WriteLine();
            }
        }
    }
}
