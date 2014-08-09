using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    /// <summary>
    /// Trivial interface decleration for a logging strategy
    /// </summary>
    public interface ILogger
    {
        void Error(String message);
        void Warn(String message);
        void Debug(String message);
        void Info(String message);
    }
}
