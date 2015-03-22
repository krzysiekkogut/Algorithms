using System;
using KKogut.ChangeProblem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KKogut.Algorithms.Tests
{
    [TestClass]
    public class GreedyChangeTests
    {
        [TestMethod]
        public void SimpleTest()
        {
            int changeToMake = 18;
            var expected = new int[] { 5, 5, 5, 2, 1 };
            var gc = new GreedyChange();
            gc.RegisterCoins(new[] { 1, 2, 5 });

            var actual = gc.GetChangeFor(changeToMake);

            CollectionAssert.AreEquivalent(expected, actual);
        }
    }
}
