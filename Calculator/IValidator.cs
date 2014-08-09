using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public interface IValidator
    {
        bool IsIntString(string input);
        bool IsValidOperator(string input);
    }
}
