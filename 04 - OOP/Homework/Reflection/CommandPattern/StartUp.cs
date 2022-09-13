using CommandPattern.Core.Contracts;
using CommandPattern.Core.Implementations;
using System;

namespace CommandPattern
{
    public class StartUp
    {
        // 0/100
        public static void Main(string[] args)
        {
            ICommandInterpreter command = new CommandInterpreter();
            IEngine engine = new Engine(command);
            engine.Run();
        }
    }
}
