using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    /// <summary>
    /// Trivial implementation for a logging stratgy
    /// if only interfaces are used ie.(ILogger) then
    /// any changes to the implementation of the interface would not cause 
    /// any dependent classes to break.
    /// for example if this class was a wrapper for log4net and
    /// we wanted to change it to something else.
    /// because we are only using the public methods of the ILogger class in the
    /// dependent classes as long as we abide by that contract and provide
    /// implementations for the public interface methods, 
    /// Logger class should work fine and not break any code in dependent classes.
    /// </summary>
    class Logger:ILogger
    {
        public void Error(string message)
        {
            return;
        }

        public void Warn(string message)
        {
            return;
        }

        public void Debug(string message)
        {
            return;
        }

        public void Info(string message)
        {
            return;
        }
    }
}
