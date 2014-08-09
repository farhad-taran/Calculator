using System;
using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace CalculatorTests
{
    [TestClass]
    public class ProcessorTests
    {
        [TestMethod]
        public void Should_Store_Integers_In_Commands()
        {
            var mockCalculator = MockRepository.GenerateMock<ICalculator<int>>();
            var mockLogger = MockRepository.GenerateMock<ILogger>();
            Processor processor = new Processor(mockCalculator,mockLogger);

            processor.AddCommand("1");
            processor.AddCommand("2");

            Assert.IsTrue(processor.Commands.Count == 2);
        }

        [TestMethod]
        public void Should_Store_Operator_In_Commands_If_Two_Integers_Already_Exist()
        {
            var mockCalculator = MockRepository.GenerateMock<ICalculator<int>>();
            var mockLogger = MockRepository.GenerateMock<ILogger>();
            Processor processor = new Processor(mockCalculator, mockLogger);

            processor.AddCommand("1");
            processor.AddCommand("2");
            processor.AddCommand("+");
            
            Assert.IsTrue(processor.Commands.Count == 3);
        }

        [TestMethod]
        public void Should_Not_Store_In_Commands_If_Three_Commands_Already_Exist()
        {
            var mockCalculator = MockRepository.GenerateMock<ICalculator<int>>();
            var mockLogger = MockRepository.GenerateMock<ILogger>();
            Processor processor = new Processor(mockCalculator, mockLogger);

            processor.AddCommand("1");
            processor.AddCommand("2");
            processor.AddCommand("+");
            processor.AddCommand("1");

            Assert.IsTrue(processor.Commands.Count == 3);
        }

        [TestMethod]
        public void Should_Call_IntCalculator_Add_To_Calculate()
        {
            var mockCalculator = MockRepository.GenerateMock<ICalculator<int>>();
            var mockLogger = MockRepository.GenerateMock<ILogger>();
            Processor processor = new Processor(mockCalculator, mockLogger);

            processor.AddCommand("1");
            processor.AddCommand("2");
            processor.AddCommand("+");

            processor.Calculate();

            mockCalculator.AssertWasCalled(x => x.Add(1, 2));
        }

        [TestMethod]
        public void Should_Call_IntCalculator_Subtract_To_Calculate()
        {
            var mockCalculator = MockRepository.GenerateMock<ICalculator<int>>();
            var mockLogger = MockRepository.GenerateMock<ILogger>();
            Processor processor = new Processor(mockCalculator, mockLogger);

            processor.AddCommand("1");
            processor.AddCommand("2");
            processor.AddCommand("-");

            processor.Calculate();

            mockCalculator.AssertWasCalled(x => x.Subtract(1, 2));
        }
    }
}
