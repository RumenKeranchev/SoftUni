using System;
using WarCroft.Core.IO.Contracts;

namespace WarCroft.Core.IO
{
	public class ConsoleWriter : IWriter
	{
		public void WriteLine(string message)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(message);
			Console.ResetColor();
		}
	}
}