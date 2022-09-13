namespace Formula1.IO
{
    using System;
    using Formula1.IO.Contracts;
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
