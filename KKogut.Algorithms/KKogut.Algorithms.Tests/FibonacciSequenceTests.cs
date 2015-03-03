using System;
using KKogut.FibonacciSequenceUsingMatrix;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KKogut.Algorithms.Tests
{
    [TestClass]
    public class FibonacciSequenceTests
    {
        [TestMethod]
        public void Fib_5_Returns_5()
        {
            var n = 5;
            var expected = 5;

            Assert.AreEqual(expected, FibonacciSequence.GetFibonacciNumber(n));
        }

        [TestMethod]
        public void Fib_20_Returns_5()
        {
            var n = 20;
            var expected = 6765;

            Assert.AreEqual(expected, FibonacciSequence.GetFibonacciNumber(n));
        }

        [TestMethod]
        public void Fib_45_Returns_34903170()
        {
            var n = 45;
            var expected = 34903170;

            Assert.AreEqual(expected, FibonacciSequence.GetFibonacciNumber(n));
        }
    }
}
