using KKogut.Euklides;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KKogut.Algorithms.Tests
{
    [TestClass]
    public class GCDTests
    {
        [TestMethod]
        public void A_is_zero_Returns_B()
        {
            long a = 0;
            long b = 9;
            Assert.AreEqual(b, EuklidesAlgorithm.GCD(a, b));
        }

        [TestMethod]
        public void B_is_zero_Returns_A()
        {
            long a = 9;
            long b = 0;
            Assert.AreEqual(a, EuklidesAlgorithm.GCD(a, b));
        }

        [TestMethod]
        public void A_is_prime_Returns_1()
        {
            long a = 13;
            long b = 8;
            Assert.AreEqual(1, EuklidesAlgorithm.GCD(a, b));
        }

        [TestMethod]
        public void A_equals_B_Returns_A()
        {
            long a = 13;
            long b = 13;
            Assert.AreEqual(a, EuklidesAlgorithm.GCD(a, b));
        }

        [TestMethod]
        public void A_and_B_not_coprime_Returns_GCD()
        {
            long a = 25;
            long b = 90;
            Assert.AreEqual(5, EuklidesAlgorithm.GCD(a, b));
        }

        [TestMethod]
        public void A_and_B_not_coprime_Returns_1()
        {
            long a = 25;
            long b = 18;
            Assert.AreEqual(1, EuklidesAlgorithm.GCD(a, b));
        }
    }
}
