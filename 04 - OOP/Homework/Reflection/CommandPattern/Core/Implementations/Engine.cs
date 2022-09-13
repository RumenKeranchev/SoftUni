using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core.Implementations
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            try
            {
                while (true)
                {
                    var input = Console.ReadLine();
                    var output = commandInterpreter.Read(input);

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(output);
                    Console.ResetColor();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
