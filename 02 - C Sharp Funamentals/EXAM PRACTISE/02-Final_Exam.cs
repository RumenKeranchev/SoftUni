using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02_C_Sharp_Funamentals.EXAM_PRACTISE
{
    public static class _02_Final_Exam
    {
        /// <summary>
        /// 01. World Tour
        /// </summary>
        public static void WorldTour()
        {
            var array = Console.ReadLine().ToList();

            var input = Console.ReadLine();

            while (input != "Travel")
            {
                var command = input.Split(":", StringSplitOptions.RemoveEmptyEntries).ToList();

                if (command[0] == "Add Stop")
                {
                    var index = int.Parse(command.Skip(1).FirstOrDefault());

                    if (index >= 0 && index <= array.Count() - 1)
                    {
                        array.InsertRange(index, command.LastOrDefault());
                    }

                    Console.WriteLine(string.Join("", array));
                }
                else if (command[0] == "Remove Stop")
                {
                    var start = int.Parse(command.Skip(1).FirstOrDefault());
                    var end = int.Parse(command.Skip(2).FirstOrDefault());

                    if (start >= 0 && start <= array.Count() - 1 && end >= 0 && end <= array.Count() - 1)
                    {
                        var arrayAsString = string.Join("", array);
                        arrayAsString = arrayAsString.Replace(arrayAsString.Substring(start, end - start + 1), "");
                        array = arrayAsString.ToList();
                    }

                    Console.WriteLine(string.Join("", array));
                }
                else if (command[0] == "Switch")
                {
                    var string1 = command.Skip(1).FirstOrDefault();
                    var string2 = command.Skip(2).FirstOrDefault();

                    var arrayAsString = string.Join("", array);
                    arrayAsString = arrayAsString.Replace(string1, string2);

                    array = arrayAsString.ToList();
                    Console.WriteLine(string.Join("", array));
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {string.Join("", array)}");
        }

        /// <summary>
        /// 02. Destination Mapper
        /// </summary>
        public static void DestinationMapper()
        {
            var input = Console.ReadLine();

            var pattern = @"([=\/])([A-Z]{1}[a-zA-Z]{2,})\1";
            var matches = Regex.Matches(input, pattern).Select(r => r.Groups.Values.LastOrDefault()).ToList();

            Console.WriteLine($"Destinations: {string.Join(", ", matches)}");
            Console.WriteLine($"Travel Points: {matches.Select(m => m.Length).Sum()}");
        }

        /// <summary>
        /// 03. Plant Discovery
        /// </summary>
        private static void PlantDiscovery()
        {
            var n = int.Parse(Console.ReadLine());
            var plants = new Dictionary<string, (int Rarity, List<decimal> Ratings)>();

            for (int i = 0; i < n; i++)
            {
                var plant = Console.ReadLine().Split("<->").ToList();
                var name = plant.FirstOrDefault();
                var rarity = int.Parse(plant.LastOrDefault());

                if (plants.ContainsKey(name))
                {
                    plants[name] = (rarity, plants[name].Ratings);
                }
                else
                {
                    plants.Add(name, (rarity, new List<decimal>()));
                }
            }

            var input = Console.ReadLine();

            while (input != "Exhibition")
            {
                var commands = input.Split(":", StringSplitOptions.RemoveEmptyEntries).ToList();

                if (commands[0] == "Rate")
                {
                    var plant = commands[1].Trim().Split(" - ", StringSplitOptions.RemoveEmptyEntries).ToList();

                    if (plants.ContainsKey(plant[0]))
                    {
                        var currentRatings = plants[plant[0]].Ratings;
                        currentRatings.Add(decimal.Parse(plant[1]));

                        plants[plant[0]] = (plants[plant[0]].Rarity, currentRatings);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (commands[0] == "Update")
                {
                    var plant = commands[1].Trim().Split(" - ", StringSplitOptions.RemoveEmptyEntries).ToList();
                    var rarity = int.Parse(plant[1]);

                    if (plants.ContainsKey(plant[0]))
                    {
                        plants[plant[0]] = (rarity, plants[plant[0]].Ratings);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (commands[0] == "Reset")
                {
                    var plant = commands[1].Trim();

                    if (plants.ContainsKey(plant))
                    {
                        plants[plant] = (plants[plant].Rarity, new List<decimal>());
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else
                {
                    Console.WriteLine("error");
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Plants for the exhibition:");
            foreach (var plant in plants.OrderByDescending(p => p.Value.Rarity).ThenByDescending(p => p.Value.Ratings.DefaultIfEmpty().Average()))
            {
                Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value.Rarity}; Rating: {plant.Value.Ratings.DefaultIfEmpty().Average():f2}");
            }
        }
    }
}
