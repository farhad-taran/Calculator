using System;
using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTests
{
    [TestClass]
    public class IntCalculatorTests
    {
        [TestMethod]
        public void Adding_Integers_Returns_Correct_Result()
        {
            IntCalculator calculator = new IntCalculator();
            int result = calculator.Add(2, 2);
            Assert.IsTrue(result == 4);
        }

        [TestMethod]
        public void Subtracting_Integers_Returns_Correct_Result()
        {
            IntCalculator calculator = new IntCalculator();
            int result = calculator.Subtract(3, 2);
            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        public void Subtracting_Large_Int_From_Smaller_Returns_Negative_Result()
        {
            IntCalculator calculator = new IntCalculator();
            int result = calculator.Subtract(1, 2);
            Assert.IsTrue(result == -1);
        }
    }
}
