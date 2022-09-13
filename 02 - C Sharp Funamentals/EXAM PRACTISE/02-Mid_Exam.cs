using System;
using System.Linq;

namespace _02_C_Sharp_Funamentals.EXAM_PRACTISE
{
    /// <summary>
    /// https://judge.softuni.org/Contests/Practice/Index/2474#0
    /// </summary>
    public static class _02_Mid_Exam
    {
        /// <summary>
        /// 01. SoftUni Reception 90/100
        /// </summary>
        public static void SoftUniReception()
        {
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());
            var c = int.Parse(Console.ReadLine());
            var students = int.Parse(Console.ReadLine());

            var totalPerHour = a + b + c;
            var hours = 0;

            while (students > 0)
            {
                if (hours % 4 != 0)
                {
                    students -= totalPerHour;

                    if (students > 0)
                    {
                        hours++;
                    }
                }
                else
                {
                    hours++;
                }
            }

            Console.WriteLine($"Time needed: {hours}h.");
        }

        /// <summary>
        /// 02. Array Modifier
        /// </summary>
        public static void ArrayModifier()
        {
            var array = Console.ReadLine().Split().Select(long.Parse).ToArray();
            var command = Console.ReadLine();

            while (command != "end")
            {
                var commands = command.Split();

                if (commands[0] == "swap")
                {
                    var index1 = long.Parse(commands[1]);
                    var index2 = long.Parse(commands[2]);

                    if (index1 >= 0 && index1 <= array.Length - 1 && index2 >= 0 && index2 <= array.Length - 1)
                    {
                        var tmp = array[index1];
                        array[index1] = array[index2];
                        array[index2] = tmp;
                    }
                }
                else if (commands[0] == "multiply")
                {
                    var index1 = long.Parse(commands[1]);
                    var index2 = long.Parse(commands[2]);

                    if (index1 >= 0 && index1 <= array.Length - 1 && index2 >= 0 && index2 <= array.Length - 1)
                    {
                        array[index1] *= array[index2];
                    }
                }
                else if (commands[0] == "decrease")
                {
                    for (long i = 0; i < array.Length; i++)
                    {
                        array[i]--;
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", array));
        }

        /// <summary>
        /// 03. Numbers
        /// </summary>
        public static void Numbers()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            var avg = numbers.Average();

            numbers.RemoveAll(x => x <= avg);

            numbers = numbers.OrderByDescending(x => x).Take(5).ToList();

            if (numbers.Count() == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }
    }
}
