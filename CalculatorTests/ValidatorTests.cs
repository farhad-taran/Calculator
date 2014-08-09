using System;
using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTests
{
    [TestClass]
    public class ValidatorTests
    {
        [TestMethod]
        public void Should_Return_False_If_Given_nonInteger()
        {
            Validator validator = new Validator();
            bool isInt = validator.IsIntString("a");
            Assert.IsFalse(isInt);
        }

        [TestMethod]
        public void Should_Return_False_If_Given_Decimal()
        {
            Validator validator = new Validator();
            bool isInt = validator.IsIntString("9.9");
            Assert.IsFalse(isInt);
        }

        [TestMethod]
        public void Should_Return_True_If_Given_Integer()
        {
            Validator validator = new Validator();
            bool isInt = validator.IsIntString("0");
            Assert.IsTrue(isInt);
        }

        [TestMethod]
        public void Should_Return_True_If_Given_Minus()
        {
            Validator validator = new Validator();
            bool isOperator = validator.IsValidOperator("-");
            Assert.IsTrue(isOperator);
        }

        [TestMethod]
        public void Should_Return_True_If_Given_Plus()
        {
            Validator validator = new Validator();
            bool isOperator = validator.IsValidOperator("+");
            Assert.IsTrue(isOperator);
        }

        [TestMethod]
        public void Should_Return_False_If_Given_Wrong_String()
        {
            Validator validator = new Validator();
            bool isOperator = validator.IsValidOperator("*");
            Assert.IsFalse(isOperator);
        }
    }
}
