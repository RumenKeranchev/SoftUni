namespace Gym.IO
{
    using Gym.IO.Contracts;
    using System;
    public class Writer : IWriter
    {
        public void Write(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(message);
            Console.ResetColor();
        }

        public void WriteLine(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
