using LoggerApp.Contracts;
using LoggerApp.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoggerApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var appenders = new List<IAppender>();

            for (int i = 0; i < n; i++)
            {
                var parameters = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                IAppender appender = null;
                ILayout layout = null;

                var appenderType = parameters[0];
                var layoutType = parameters[1];

                if (layoutType == nameof(SimpleLayout))
                {
                    layout = new SimpleLayout();
                }
                else
                {
                    layout = new XmlLayout();
                }

                if (appenderType == nameof(ConsoleAppender))
                {
                    appender = new ConsoleAppender(layout);
                }
                else
                {
                    appender = new FileAppender(layout, new LogFile());
                }

                if (parameters.Count == 3)
                {
                    if (Enum.TryParse(typeof(ReportLevel), parameters[2], true, out var reportLevel))
                    {
                        appender.ReportLevel = (ReportLevel)reportLevel;
                    }
                }

                appenders.Add(appender);
            }

            var logger = new Logger(appenders);

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                var parameters = input.Split("|", StringSplitOptions.RemoveEmptyEntries).ToList();
                var logLevel = parameters[0].ToLowerInvariant();
                var timeStamp = parameters[1];
                var message = parameters[2];

                switch (logLevel)
                {
                    case "info": logger.Info(timeStamp, message); break;
                    case "warning": logger.Warning(timeStamp, message); break;
                    case "error": logger.Error(timeStamp, message); break;
                    case "critical": logger.Critical(timeStamp, message); break;
                    case "fatal": logger.Fatal(timeStamp, message); break;
                    default: break;
                }
            }

            Console.WriteLine("Logger info");

            foreach (var appender in appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}
