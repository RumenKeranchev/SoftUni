using LoggerApp.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerApp.Implementations
{
    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
