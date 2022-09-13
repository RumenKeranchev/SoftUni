using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core.Implementations
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            var commandArgs = args.Split().ToArray();

            var typeName = commandArgs[0] + "Command";

            var type = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Name == typeName).First();

            var command = Activator.CreateInstance(type) as ICommand;
            return command.Execute(commandArgs.Skip(1).ToArray());
        }
    }
}
