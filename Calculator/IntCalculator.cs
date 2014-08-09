using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class IntCalculator : ICalculator<int>
    {
        public int Add(int firstOperand, int secondOperand)
        {
            return firstOperand + secondOperand;
        }

        public int Subtract(int firstOperand, int secondOperand)
        {
            return firstOperand - secondOperand;
        }
    }
}
