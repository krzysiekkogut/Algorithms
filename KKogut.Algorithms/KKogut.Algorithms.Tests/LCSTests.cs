using System;
using KKogut.LongestCommonSubsequence;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KKogut.Algorithms.Tests
{
    [TestClass]
    public class LCSTests
    {
        [TestMethod]
        public void EmptyString()
        {
            var s1 = "abcde";
            var s2 = string.Empty;

            var l = LCS.FindLCS(s1, s2);

            Assert.AreEqual(0, l);
        }

        [TestMethod]
        public void TestLCS()
        {
            var s1 = "agcat";
            var s2 = "gac";

            var l = LCS.FindLCS(s1, s2);

            Assert.AreEqual(2, l);
        }
    }
}
