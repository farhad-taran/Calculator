using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public interface ICalculator<T>
    {
        T Add(T firstOperand, T secondOperand);
        T Subtract(T firstOperand, T secondOperand);
    }
}
