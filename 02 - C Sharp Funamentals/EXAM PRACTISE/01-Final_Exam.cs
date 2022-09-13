using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02_C_Sharp_Funamentals.EXAM_PRACTISE
{
    //https://judge.softuni.org/Contests/Practice/Index/2525#0
    public static class _01_Final_Exam
    {
        /// <summary>
        /// 01. The Imitation Game
        /// </summary>
        public static void TheImitationGame()
        {
            var message = Console.ReadLine();

            var command = Console.ReadLine();

            while (command != "Decode")
            {
                var instructions = command.Split("|").ToList();

                if (instructions.FirstOrDefault() == "Move")
                {
                    var messageList = message.ToCharArray().ToList();

                    var n = int.Parse(instructions.LastOrDefault());

                    var toAdd = message.Skip(0).Take(n).ToList();
                    messageList.RemoveRange(0, n);
                    messageList.AddRange(toAdd);

                    message = string.Join("", messageList);
                }
                else if (instructions.FirstOrDefault() == "Insert")
                {
                    var messageList = message.ToCharArray().ToList();

                    var index = int.Parse(instructions.Skip(1).FirstOrDefault());
                    var letter = instructions.LastOrDefault().ToCharArray();

                    for (int i = 0; i < letter.Length; i++)
                    {
                        messageList.Insert(index + i, letter[i]);
                    }

                    message = string.Join("", messageList);
                }
                else if (instructions.FirstOrDefault() == "ChangeAll")
                {
                    var substring = instructions.Skip(1).FirstOrDefault();
                    var replacement = instructions.LastOrDefault();

                    message = message.Replace(substring, replacement);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"The decrypted message is: {message}");
        }

        /// <summary>
        /// 02. Ad Astra
        /// </summary>
        private static void AdAstra()
        {
            var pattern = @"([#|])([a-zA-Z0-9\s]+)\1(\d{2}\/\d{2}\/\d{2})\1(\d{1,6})\1";

            var input = Console.ReadLine();

            var regex = Regex.Matches(input, pattern);

            if (regex.Count() == 0)
            {
                Console.WriteLine("You have food to last you for: 0 days!");
            }
            else
            {
                var caloriesSum = regex.Select(r => int.Parse(r.Groups[4].Value)).DefaultIfEmpty().Sum();
                Console.WriteLine($"You have food to last you for: {caloriesSum / 2000} days!");

                foreach (var group in regex.Select(r => r.Groups))
                {
                    Console.WriteLine($"Item: {group[2].Value}, Best before: {group[3].Value}, Nutrition: {group[4].Value}");
                }
            }
        }

        /// <summary>
        /// 03. The Pianist
        /// </summary>
        public static void ThePianist()
        {
            var n = int.Parse(Console.ReadLine());
            var dictionary = FillInitialDictionary(n);

            var input = Console.ReadLine();

            while (input != "Stop")
            {
                var commands = input.Split("|").ToList();
                var piece = commands.Skip(1).FirstOrDefault();
                var command = commands.FirstOrDefault();

                if (command == "Add")
                {
                    AddNewPeices(dictionary, commands, piece);
                }
                else if (command == "Remove")
                {
                    RemovePiece(dictionary, piece);
                }
                else if (command == "ChangeKey")
                {
                    ChangeKey(dictionary, commands, piece);
                }

                input = Console.ReadLine();
            }

            PrintResult(dictionary);
        }

        private static void ChangeKey(Dictionary<string, List<string>> dictionary, List<string> commands, string piece)
        {
            var key = commands.Skip(2).FirstOrDefault();

            if (dictionary.ContainsKey(piece))
            {
                var actualPiece = dictionary.FirstOrDefault(d => d.Key == piece);
                actualPiece.Value.Remove(actualPiece.Value.LastOrDefault());
                actualPiece.Value.Add(key);

                Console.WriteLine($"Changed the key of {piece} to {key}!");
            }
            else
            {
                Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
            }
        }

        private static void RemovePiece(Dictionary<string, List<string>> dictionary, string piece)
        {
            if (dictionary.ContainsKey(piece))
            {
                dictionary.Remove(piece);
                Console.WriteLine($"Successfully removed {piece}!");
            }
            else
            {
                Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
            }
        }

        private static void AddNewPeices(Dictionary<string, List<string>> dictionary, List<string> commands, string piece)
        {
            if (dictionary.ContainsKey(piece))
            {
                Console.WriteLine($"{piece} is already in the collection!");
            }
            else
            {
                var composer = commands.Skip(2).FirstOrDefault();
                var key = commands.LastOrDefault();

                dictionary.Add(piece, commands.Skip(2).ToList());
                Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
            }
        }

        private static Dictionary<string, List<string>> FillInitialDictionary(int n)
        {
            var dictionary = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                var initialInput = Console.ReadLine().Split("|").ToList();
                dictionary.Add(initialInput.FirstOrDefault(), initialInput.Skip(1).ToList());
            }

            return dictionary;
        }

        private static void PrintResult(Dictionary<string, List<string>> dictionary)
        {
            foreach (var item in dictionary.OrderBy(d => d.Key).ThenBy(d => d.Value.FirstOrDefault()))
            {
                Console.WriteLine($"{item.Key} -> Composer: {item.Value.FirstOrDefault()}, Key: {item.Value.LastOrDefault()}");
            }
        }
    }
}
