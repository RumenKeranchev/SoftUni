using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02_C_Sharp_Funamentals.Exercises
{
    /// <summary>
    /// https://judge.softuni.org/Contests/Compete/Index/1668#0
    /// </summary>
    internal class RegularExpressions
    {
        /// <summary>
        /// 01. Furniture
        /// </summary>
        private static void Furniture()
        {
            var list = new List<string>();
            var total = 0m;

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Purchase")
                {
                    break;
                }

                var pattern = @">>(?<name>[A-Za-z\s]+)<<(?<price>\d+(.?\d+)?)!(?<quantity>\d+)";
                var regex = Regex.Match(input, pattern);

                if (regex.Success)
                {
                    var name = regex.Groups["name"].Value;
                    var price = decimal.Parse(regex.Groups["price"].Value);
                    var quantity = long.Parse(regex.Groups["quantity"].Value);

                    list.Add(name);
                    total += price * quantity;
                }
            }

            Console.WriteLine("Bought furniture:");
            list.ForEach(Console.WriteLine);
            Console.WriteLine($"Total money spend: {total:f2}");
        }

        /// <summary>
        /// 02. Race
        /// </summary>
        private static void Race()
        {
            var pattern = @"(?<name>[a-zA-Z]+)|(?<distance>\d)";

            var participants = Console.ReadLine().Split(",").Select(s => s.Trim()).ToDictionary(p => p, p => 0);

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "end of race")
                {
                    break;
                }

                var regex = Regex.Matches(input, pattern);
                var name = string.Join("", regex.Where(r => !string.IsNullOrEmpty(r.Groups["name"].Value)).Select(r => r.Groups["name"].Value));
                var distance = regex.Where(r => int.TryParse(r.Groups["distance"].Value, out var a)).Select(r => int.Parse(r.Groups["distance"].Value)).DefaultIfEmpty().Sum();

                if (participants.ContainsKey(name))
                {
                    participants[name] += distance;
                }
            }

            participants = participants.OrderByDescending(p => p.Value).Take(3).ToDictionary(p => p.Key, p => p.Value);
            var places = new string[] { "1st", "2nd", "3rd" };
            var index = 0;

            foreach (var participant in participants)
            {
                Console.WriteLine($"{places[index]} place: {participant.Key}");
                index++;
            }
        }

        /// <summary>
        /// 03. SoftUni Bar Income
        /// </summary>
        private static void SoftUniBarIncome()
        {
            var pattern = @"%(?<customer>[A-Z][a-z]+)%(?:[^|$%.]*)<(?<product>\w+)>(?:[^|$%.]*)\|(?<quantity>\d+)\|(?:[^|$%.]*?)(?<price>\d+\.?\d*)(?:\$)";

            var total = 0m;

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "end of shift")
                {
                    break;
                }

                var regex = Regex.Match(input, pattern);

                if (regex.Success)
                {
                    var name = regex.Groups["customer"].Value;
                    var product = regex.Groups["product"].Value;
                    var quantity = int.Parse(regex.Groups["quantity"].Value);
                    var price = decimal.Parse(regex.Groups["price"].Value);
                    var totalPrice = quantity * price;
                    total += totalPrice;

                    Console.WriteLine($"{name}: {product} - {totalPrice:f2}");
                }
            }

            Console.WriteLine($"Total income: {total:f2}");
        }

        /// <summary>
        /// 04. Star Enigma
        /// </summary>
        private static void StarEnigma()
        {
            int n = int.Parse(Console.ReadLine());

            var starPattern = @"[starSTAR]";
            var planetPattern = @"@(?<name>[A-z][a-z]+)(?:[^@\-!:>]*?):(?<population>\d+)(?:[^@\-!:>]*?)(?:[^@\-!:>]*?)!(?<type>[AD]{1})!(?:[^@\-!:>]*?)->(?<soldiers>\d+)";

            var attacked = new List<string>();
            var destroyed = new List<string>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var arr = input.ToCharArray();

                var regex = Regex.Matches(input, starPattern);
                var count = regex.Count();

                for (int j = 0; j < arr.Length; j++)
                {
                    arr[j] = (char)(arr[j] - count);
                }

                var decrypted = string.Join("", arr);

                var planetRegex = Regex.Match(decrypted, planetPattern);

                if (planetRegex.Success)
                {
                    var name = planetRegex.Groups["name"].Value;
                    var populations = planetRegex.Groups["population"].Value;
                    var type = planetRegex.Groups["type"].Value;
                    var soldiers = planetRegex.Groups["soldiers"].Value;

                    if (type == "A")
                    {
                        attacked.Add(name);
                    }
                    else
                    {
                        destroyed.Add(name);
                    }
                }
            }

            Console.WriteLine($"Attacked planets: {attacked.Count}");
            foreach (var attack in attacked.OrderBy(x => x))
            {
                Console.WriteLine($"-> {attack}");
            }

            Console.WriteLine($"Destroyed planets: {destroyed.Count}");
            foreach (var attack in destroyed.OrderBy(x => x))
            {
                Console.WriteLine($"-> {attack}");
            }
        }
    }
}
