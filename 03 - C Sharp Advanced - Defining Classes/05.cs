using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses1
{
    public static class _05
    {
        public static void Execute()
        {
            var firstDate = Console.ReadLine();
            var lastDate = Console.ReadLine();

            var dateModifier = new DateModifier(firstDate, lastDate);

            Console.WriteLine(dateModifier.GetDiff());
        }
    }

    public class DateModifier
    {
        public DateTime FirstDate { get; set; }
        public DateTime LastDate { get; set; }

        public DateModifier(string firstDate, string lastDate)
        {
            FirstDate = DateTime.Parse(firstDate);
            LastDate = DateTime.Parse(lastDate);
        }

        public int GetDiff()
        {
            return (int)Math.Abs((FirstDate - LastDate).TotalDays);
        }
    }
}
