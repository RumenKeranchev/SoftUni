using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerApp.Contracts
{
    public interface IAppender
    {
        int AppendedMessages { get; }

        void Append(string timestamp, ReportLevel reportLevel, string message);

        ReportLevel ReportLevel { get; set; }
    }
}
