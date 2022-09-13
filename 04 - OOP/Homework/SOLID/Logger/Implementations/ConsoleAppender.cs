using LoggerApp.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerApp.Implementations
{
    public class ConsoleAppender : IAppender
    {
        private ILayout layout;

        public ConsoleAppender(ILayout layout)
        {
            this.layout = layout;
        }

        public ReportLevel ReportLevel { get; set; } = ReportLevel.Info;

        public int AppendedMessages { get; private set; }

        public void Append(string timestamp, ReportLevel reportLevel, string message)
        {
            if (reportLevel >= ReportLevel)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(string.Format(layout.Format, timestamp, reportLevel.ToString().ToUpperInvariant(), message));
                AppendedMessages++;
                Console.ResetColor();
            }
        }

        public override string ToString()
        {
            return $"Appender type: {GetType().Name}, Layout type: {layout.GetType().Name}, Report level: {ReportLevel.ToString().ToUpperInvariant()}, Messages appended: {AppendedMessages}";
        }
    }
}
