using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoggerApp
{
    public class LogFile
    {
        private StringBuilder sb;

        public LogFile()
        {
            sb = new StringBuilder();
        }

        public int Size => sb.ToString().Where(c => char.IsLetter(c)).Sum(c => c);

        public void Write(string message)
        {
            sb.AppendLine(message);
        }
    }
}
