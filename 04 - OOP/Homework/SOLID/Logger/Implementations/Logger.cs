using LoggerApp.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerApp.Implementations
{
    public class Logger : ILogger
    {
        private IAppender[] appenders;

        public Logger(List<IAppender> appenders)
        {
            this.appenders = appenders.ToArray();
        }

        public Logger(params IAppender[] appender)
        {
            this.appenders = appender;
        }

        public void Info(string timestamp, string message)
        {
            Log(timestamp, ReportLevel.Info, message);
        }

        public void Warning(string timestamp, string message)
        {
            Log(timestamp, ReportLevel.Warning, message);
        }

        public void Error(string timestamp, string message)
        {
            Log(timestamp, ReportLevel.Error, message);
        }
        
        public void Critical(string timestamp, string message)
        {
            Log(timestamp, ReportLevel.Critical, message);
        }

        public void Fatal(string timestamp, string message)
        {
            Log(timestamp, ReportLevel.Fatal, message);
        }

        private void Log(string timestamp, ReportLevel level, string message)
        {
            foreach (var appender in appenders)
            {
                appender.Append(timestamp, level, message);
            }
        }
    }
}
