using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KKogut.Algorithms.Tests
{
    [TestClass]
    public class RussianMultiplicationTests
    {
        [TestMethod]
        public void Multiplicate_By_0_Returns_0()
        {
            long a = 0;
            long b = 253;

            var result = RussianMultiplication.RussianMultiplication.Multiplicate(a, b);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Multiplicate_12341234_and_897123()
        {
            long a = 12341234;
            long b = 897123;

            var result = RussianMultiplication.RussianMultiplication.Multiplicate(a, b);

            Assert.AreEqual(a * b, result);
        }

    }
}
