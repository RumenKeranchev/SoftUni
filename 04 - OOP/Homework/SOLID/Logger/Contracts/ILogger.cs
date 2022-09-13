using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerApp.Contracts
{
    public interface ILogger
    {
        void Info(string timestamp, string message);
        void Warning(string timestamp, string message);
        void Error(string timestamp, string message);
    }
}
