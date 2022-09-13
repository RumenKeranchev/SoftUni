using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerApp.Contracts
{
    public interface ILayout
    {
        string Format { get; }
    }
}
