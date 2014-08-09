using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public interface IProcessor
    {
        Stack<String> Commands { get; }
        void AddCommand(string command);
        string Calculate();
    }

}
