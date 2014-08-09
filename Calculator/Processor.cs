using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    /// <summary>
    /// a class to interact with different types of calculator classes
    /// that are made for different prime types, ie decimal, hex, binary.
    /// we can extend the behavior of this class by injecting 
    /// an implementation of ICalculator which works on decimals, string(for hex) into the constructor
    /// and use that to operate on different types according to what has been input by the user
    /// </summary>
    public class Processor : IProcessor
    {
        private ILogger _logger;
        private ICalculator<int> _intCalculator;
        private Stack<String> _commands = new Stack<string>();

        public Stack<String> Commands
        {
            get { return _commands; }
        }

        /// <summary>
        /// can bind other types of calculator using structuremap and inject into this constructor
        /// therefor extendong the behavior of this class to be able to operate on decimal, hex, binary numbers
        /// </summary>
        /// <param name="intCalculator"></param>
        /// <param name="logger"></param>
        public Processor(ICalculator<int> intCalculator, ILogger logger)
        {
            _intCalculator = intCalculator;
            _logger = logger;
        }

        public void AddCommand(string command)
        {
            //add operator
            if (_commands.Count == 2)
            {
                _commands.Push(command.Trim());
            }

            //add firstOperand or second operand
            if (_commands.Count == 0 || _commands.Count == 1 )
            {
                _commands.Push(command.Trim());
			}
        }

        public string Calculate()
        {
            int result = 0;
            string operation = _commands.Pop();
            string secondOperand = _commands.Pop();
            string firstOerand = _commands.Pop();

            if (operation == "+")
            {
                result = _intCalculator.Add(int.Parse(firstOerand), int.Parse(secondOperand));

                _logger.Info(string.Format("Adding int {0}, to int {1}, with result {2}.", firstOerand,secondOperand,result));
            }

            if (operation == "-")
            {
                 result = _intCalculator.Subtract(int.Parse(firstOerand), int.Parse(secondOperand));

                 _logger.Info(string.Format("subtracted int {0}, from int {1}, with result {2}.", secondOperand, firstOerand, result));
            }

            _commands.Clear();

            return result.ToString(CultureInfo.InvariantCulture);
        }
    }
}
