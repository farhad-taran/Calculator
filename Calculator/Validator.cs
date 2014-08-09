using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Validator:IValidator
    {
        public bool IsIntString(string input)
        {
            int value;
            return int.TryParse(input, out value);
        }
        
        public bool IsValidOperator(string input)
        {
            input = input.Trim();
            return input == "+" || input == "-";
        }
    }
}
