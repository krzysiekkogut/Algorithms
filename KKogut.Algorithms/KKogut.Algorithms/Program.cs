using System;
using System.Linq;
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
                        RunInsertionSort();
                        break;
                    case "2":
                        RunSelectionSort();
                        break;
                    case "3":
                        RunMergeSort();
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
            Console.WriteLine(RussianMultiplication.RussianMultiplication.Multiplicate(Convert.ToInt64(@in[0]), Convert.ToInt64(@in[1])));
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
    }
}
