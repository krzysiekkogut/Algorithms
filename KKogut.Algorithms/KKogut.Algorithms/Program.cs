using System;
using System.Linq;
using System.Xml;

namespace KKogut.Algorithms
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var xml = new XmlDocument();
            xml.Load("RunMethods.xml");
            
            while (true)
            {
                Console.WriteLine("Please type in a number of algorithm:");
                int x;
                if (Int32.TryParse(Console.ReadLine(), out x) == false) return;
                var method = xml.ChildNodes[1].ChildNodes.Item(x - 1).Attributes["name"].Value;
                typeof(Runners).GetMethod(method).Invoke(null, null);
                Console.WriteLine();
            }
        }
    }
}
