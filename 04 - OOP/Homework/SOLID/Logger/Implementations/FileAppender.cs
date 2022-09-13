using LoggerApp.Contracts;
using System;
using System.IO;

namespace LoggerApp.Implementations
{
    public class FileAppender : IAppender
    {
        private ILayout layout;
        private LogFile logFile;

        private string path = "../../../log.txt";

        public FileAppender(ILayout layout, LogFile logFile)
        {
            this.layout = layout;
            this.logFile = logFile;
        }

        public ReportLevel ReportLevel { get; set; } = ReportLevel.Info;

        public int AppendedMessages { get; private set; }

        public void Append(string timestamp, ReportLevel reportLevel, string message)
        {
            if (reportLevel >= ReportLevel)
            {
                var formattedMessage = string.Format(layout.Format, timestamp, reportLevel.ToString().ToUpperInvariant(), message);
                logFile.Write(formattedMessage);
                File.AppendAllText(path, formattedMessage + Environment.NewLine);
                AppendedMessages++;
            }
        }

        public override string ToString()
        {
            return $"Appender type: {GetType().Name}, Layout type: {layout.GetType().Name}, Report level: {ReportLevel.ToString().ToUpperInvariant()}, Messages appended: {AppendedMessages}, File size {logFile.Size}";
        }
    }
}
