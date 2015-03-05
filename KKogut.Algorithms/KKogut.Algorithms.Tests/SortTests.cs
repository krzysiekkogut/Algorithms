using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KKogut.SortAlgorithms;

namespace KKogut.Algorithms.Tests
{
    [TestClass]
    public class SortTests
    {
        [TestMethod]
        public void BubbleSort_Test()
        {
            var @in = new[] { 1, 5, 12, 3, 2, 7, 6, 9, 0 };
            var expected = new[] { 0, 1, 2, 3, 5, 6, 7, 9, 12 };

            var result = @in.BubbleSort<int>();

            CollectionAssert.AreEquivalent(expected, result.ToList());
        }

        [TestMethod]
        public void InsertionSort_Test()
        {
            var @in = new[] { 1, 5, 12, 3, 2, 7, 6, 9, 0 };
            var expected = new[] { 0, 1, 2, 3, 5, 6, 7, 9, 12 };

            var result = @in.InsertionSort<int>();

            CollectionAssert.AreEquivalent(expected, result.ToList()); 
        }

        [TestMethod]
        public void SelectionSort_Test()
        {
            var @in = new[] { 1, 5, 12, 3, 2, 7, 6, 9, 0 };
            var expected = new[] { 0, 1, 2, 3, 5, 6, 7, 9, 12 };

            var result = @in.SelectionSort<int>();

            CollectionAssert.AreEquivalent(expected, result.ToList());
        }

        [TestMethod]
        public void MergeSort_Test()
        {
            var @in = new[] { 1, 5, 12, 3, 2, 7, 6, 9, 0 };
            var expected = new[] { 0, 1, 2, 3, 5, 6, 7, 9, 12 };

            var result = @in.MergeSort<int>();

            CollectionAssert.AreEquivalent(expected, result.ToList());
        }
    }
}
