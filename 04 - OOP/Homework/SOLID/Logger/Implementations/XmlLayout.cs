using LoggerApp.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerApp.Implementations
{
    public class XmlLayout : ILayout
    {
        public string Format => 
            "<log>\r\n" + 
            "  <date>{0}</date>\r\n" +
            "  <level>{1}</level>\r\n" +
            "  <message>{2}</message>\r\n" +
            "</log>";
    }
}
