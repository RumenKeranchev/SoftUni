using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02_C_Sharp_Funamentals.EXAM_PRACTISE
{
    internal class Final_Exam
    {
        /// <summary>
        /// 01. String Manipulator
        /// </summary>
        public static void StringManipulator()
        {
            var input = Console.ReadLine();

            while (true)
            {
                var commands = Console.ReadLine().Split().ToList();
                var command = commands.FirstOrDefault();

                if (command == "End")
                {
                    break;
                }

                if (command == "Translate")
                {
                    var chara = commands[1];
                    var replacement = commands[2];

                    input = input.Replace(chara, replacement);
                    Console.WriteLine(input);
                }
                else if (command == "Includes")
                {
                    var substr = commands[1];

                    Console.WriteLine(input.Contains(substr) ? "True" : "False");
                }
                else if (command == "Start")
                {
                    var substr = commands[1];

                    Console.WriteLine(input.StartsWith(substr) ? "True" : "False");
                }
                else if (command == "Lowercase")
                {
                    input = input.ToLowerInvariant();

                    Console.WriteLine(input);
                }
                else if (command == "FindIndex")
                {
                    var chara = commands[1];
                    var index = input.LastIndexOf(chara);

                    Console.WriteLine(index);
                }
                else if (command == "Remove")
                {
                    var startIndex = int.Parse(commands[1]);
                    var count = int.Parse(commands[2]);

                    if (startIndex >= 0 && startIndex < input.Length)
                    {
                        input = input.Remove(startIndex, count);
                    }

                    Console.WriteLine(input);
                }
            }
        }

        /// <summary>
        /// 02. Message Translator
        /// </summary>
        private static void MessageTranslator()
        {
            var regex = new Regex(@"!(?<command>[A-Z][a-z]{2,})!:\[(?<message>[a-zA-Z]{8,})\]");

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();

                var match = regex.Match(input);

                if (match.Success)
                {
                    var sb = new StringBuilder();

                    sb.Append(match.Groups["command"].Value);
                    sb.Append(": ");

                    var message = match.Groups["message"].Value;

                    for (int j = 0; j < message.Length; j++)
                    {
                        sb.Append((int)message[j]);
                        sb.Append(" ");
                    }

                    Console.WriteLine(sb.ToString());
                }
                else
                {
                    Console.WriteLine("The message is invalid");
                }
            }
        }

        /// <summary>
        /// 03. Hero Recruitment
        /// </summary>
        private static void HeroRecruitment()
        {
            var dict = new Dictionary<string, List<string>>();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                var input = Console.ReadLine().Split().ToList();
                var command = input.FirstOrDefault();
                if (command == "End")
                {
                    break;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                if (command == "Enroll")
                {
                    if (dict.ContainsKey(input[1]))
                    {
                        Console.WriteLine($"{input[1]} is already enrolled.", Console.ForegroundColor);
                    }
                    else
                    {
                        dict.Add(input[1], new List<string>());
                    }
                }
                else if (command == "Learn")
                {
                    var name = input[1];
                    var spell = input[2];

                    if (dict.ContainsKey(name))
                    {
                        if (dict[name].Contains(spell))
                        {
                            Console.WriteLine($"{name} has already learnt {spell}.", Console.ForegroundColor);
                        }
                        else
                        {
                            dict[name].Add(spell);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{name} doesn't exist.", Console.ForegroundColor);
                    }
                }
                else if (command == "Unlearn")
                {
                    var name = input[1];
                    var spell = input[2];

                    if (dict.ContainsKey(name))
                    {
                        if (!dict[name].Contains(spell))
                        {
                            Console.WriteLine($"{name} doesn't know {spell}.", Console.ForegroundColor);
                        }
                        else
                        {
                            dict[name].Remove(spell);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{name} doesn't exist.", Console.ForegroundColor);
                    }
                }
            }

            Console.WriteLine("Heroes:");
            foreach (var kvp in dict.OrderByDescending(d => d.Value.Count()).ThenBy(d => d.Key))
            {
                Console.WriteLine($"== {kvp.Key}: {string.Join(", ", kvp.Value)}");
            }
        }
    }
}
