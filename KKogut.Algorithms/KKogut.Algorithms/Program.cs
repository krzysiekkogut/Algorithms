using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
