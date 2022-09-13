using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_C_Sharp_Funamentals.Exercises
{
    /// <summary>
    /// https://judge.softuni.org/Contests/Compete/Index/1213#0
    /// </summary>
    public static class AssociativeArrays
    {
        /// <summary>
        /// 01. Count Chars in a String
        /// </summary>
        public static void CountCharsInAString()
        {
            var input = Console.ReadLine().Split().SelectMany(s => s.ToCharArray()).ToArray();

            var dict = new Dictionary<char, int>();

            foreach (var chara in input)
            {
                if (dict.ContainsKey(chara))
                {
                    dict[chara]++;
                }
                else
                {
                    dict.Add(chara, 1);
                }
            }

            foreach (var kvp in dict)
            {
                Console.WriteLine(kvp.Key + " -> " + kvp.Value);
            }
        }

        /// <summary>
        /// 02. A Miner Task
        /// </summary>
        public static void AMinerTask()
        {
            int count = 1;
            var prevSourse = "";
            var dict = new Dictionary<string, int>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "stop")
                {
                    break;
                }

                if (count % 2 == 1)
                {
                    if (!dict.ContainsKey(input))
                    {
                        dict.Add(input, 0);
                    }
                    prevSourse = input;
                }
                else
                {
                    if (dict.ContainsKey(prevSourse))
                    {
                        dict[prevSourse] += int.Parse(input);
                    }
                }

                count++;
            }

            foreach (var kvp in dict)
            {
                Console.WriteLine(kvp.Key + " -> " + kvp.Value);
            }
        }

        /// <summary>
        /// 03. Legendary Farming
        /// </summary>
        public static void LegendaryFarming()
        {
            var sources = new Dictionary<string, int>
            {
                { "shards",0 },
                { "fragments", 0 },
                { "motes", 0 }
            };
            var junk = new Dictionary<string, int>();
            var items = new Dictionary<string, string>
            {
                { "shards", "Shadowmourne" },
                { "fragments", "Valanyr" },
                { "motes", "Dragonwrath" }
            };
            var winner = "";

            while (true)
            {
                var input = Console.ReadLine().Split().ToList();

                for (int i = 0; i < input.Count(); i += 2)
                {
                    var source = input[i + 1].ToLowerInvariant();
                    var quantity = input[i];

                    var isKey = items.ContainsKey(source);

                    AddToDictionaty(isKey ? sources : junk, source, quantity);

                    if (items.ContainsKey(source) && sources[source] >= 250)
                    {
                        winner = items[source];
                        sources[source] -= 250;
                        break;
                    }
                }

                if (sources.Any(s => items.ContainsKey(s.Key) && s.Value >= 250) || !string.IsNullOrEmpty(winner))
                {
                    break;
                }
            }

            Console.WriteLine(winner + " obtained!");
            foreach (var kvp in sources.OrderByDescending(s => s.Value).ThenBy(s => s.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
            foreach (var kvp in junk.OrderBy(j => j.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            static void AddToDictionaty(Dictionary<string, int> dict, string source, string quantity)
            {
                if (dict.ContainsKey(source))
                {
                    dict[source] += int.Parse(quantity);
                }
                else
                {
                    dict.Add(source, int.Parse(quantity));
                }
            }
        }


        /// <summary>
        /// 04. Orders
        /// </summary>
        public static void Orders()
        {
            var dict = new Dictionary<string, Product>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "buy")
                {
                    break;
                }

                var data = input.Split().ToArray();
                var product = new Product
                {
                    Name = data[0],
                    Price = decimal.Parse(data[1]),
                    Quantity = int.Parse(data[2])
                };

                if (dict.ContainsKey(product.Name))
                {
                    if (dict[product.Name].Price != product.Price)
                    {
                        dict[product.Name].Price = product.Price;
                    }

                    dict[product.Name].Quantity += product.Quantity;
                }
                else
                {
                    dict.Add(product.Name, product);
                }
            }

            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value.Price * kvp.Value.Quantity:f2}");
            }
        }

        class Product
        {
            public string Name { get; set; }

            public int Quantity { get; set; }

            public decimal Price { get; set; }
        }

        /// <summary>
        /// 05. SoftUni Parking
        /// </summary>
        public static void SoftUniParking()
        {
            var n = int.Parse(Console.ReadLine());

            var dict = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split().ToList();

                if (input[0] == "register")
                {
                    if (dict.ContainsKey(input[1]))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {input[2]}");
                    }
                    else
                    {
                        dict.Add(input[1], input[2]);
                        Console.WriteLine($"{input[1]} registered {input[2]} successfully");
                    }
                }
                else
                {
                    if (!dict.ContainsKey(input[1]))
                    {
                        Console.WriteLine($"ERROR: user {input[1]} not found");
                    }
                    else
                    {
                        dict.Remove(input[1]);
                        Console.WriteLine($"{input[1]} unregistered successfully");
                    }
                }
            }

            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} => {kvp.Value}");
            }
        }

        /// <summary>
        /// 06. Courses
        /// </summary>
        public static void Courses()
        {
            var dict = new Dictionary<string, List<string>>();

            while (true)
            {
                var input = Console.ReadLine().Split(':').Select(s => s.Trim()).ToList();

                if (input.FirstOrDefault() == "end")
                {
                    break;
                }

                if (dict.ContainsKey(input[0]))
                {
                    dict[input[0]].Add(input[1]);
                }
                else
                {
                    dict.Add(input[0], new List<string> { input[1] });
                }
            }

            foreach (var kvp in dict.OrderByDescending(d => d.Value.Count()))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count()}");

                foreach (var student in kvp.Value.OrderBy(s => s))
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }


        /// <summary>
        /// 07. Student Academy
        /// </summary>
        public static void StudentAcademy()
        {
            var dict = new Dictionary<string, List<decimal>>();
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var sudent = Console.ReadLine();
                var grade = decimal.Parse(Console.ReadLine());

                if (dict.ContainsKey(sudent))
                {
                    dict[sudent].Add(grade);
                }
                else
                {
                    dict.Add(sudent, new List<decimal> { grade });
                }
            }

            foreach (var kvp in dict.Where(d => d.Value.Average() >= 4.5m).OrderByDescending(d => d.Value.Average()))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value.Average():f2}");
            }
        }

        /// <summary>
        /// 08. Company Users
        /// </summary>
        public static void CompanyUsers()
        {
            var dict = new Dictionary<string, List<string>>();

            while (true)
            {
                var input = Console.ReadLine().Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToList();

                if (input.FirstOrDefault() == "End")
                {
                    break;
                }

                if (dict.ContainsKey(input[0]))
                {
                    if (!dict[input[0]].Any(u => u == input[1]))
                    {
                        dict[input[0]].Add(input[1]);
                    }
                }
                else
                {
                    dict.Add(input[0], new List<string> { input[1] });
                }
            }

            foreach (var kvp in dict.OrderBy(d => d.Key))
            {
                Console.WriteLine(kvp.Key);

                foreach (var user in kvp.Value)
                {
                    Console.WriteLine($"-- {user}");
                }
            }
        }

        /// <summary>
        /// 09. ForceBook
        /// </summary>
        public static void ForceBook()
        {
            var dict = new Dictionary<string, List<string>>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Lumpawaroo")
                {
                    break;
                }

                if (input.Contains("|"))
                {
                    var data = input.Split("|").Select(s => s.Trim()).ToList();
                    var side = data[0];
                    var user = data[1];

                    if (!dict.Any(d => d.Value.Any(v => v == user)))
                    {
                        if (dict.ContainsKey(side))
                        {
                            if (!dict[side].Any(u => u == user))
                            {
                                dict[side].Add(user);
                            }
                        }
                        else
                        {
                            dict.Add(side, new List<string> { user });
                        }
                    }
                }
                else
                {
                    var data = input.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToList();
                    var side = data[1];
                    var user = data[0];

                    var forceUser = dict.FirstOrDefault(d => d.Value.Any(v => v == user));

                    if (!forceUser.Equals(default(KeyValuePair<string, List<string>>)))
                    {
                        dict[forceUser.Key].Remove(user);
                    }

                    if (dict.ContainsKey(side))
                    {
                        dict[side].Add(user);
                    }
                    else
                    {
                        dict.Add(side, new List<string> { user });
                    }

                    Console.WriteLine($"{user} joins the {side} side!");
                }
            }

            foreach (var kvp in dict.Where(d => d.Value.Count() > 0).OrderByDescending(d => d.Value.Count()).ThenBy(d => d.Key))
            {
                Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value.Count()}");

                foreach (var user in kvp.Value.OrderBy(u => u))
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }

        /// <summary>
        /// 10. SoftUni Exam Results
        /// </summary>
        public static void SoftUniExamResults()
        {
            var users = new Dictionary<string, int>();
            var langs = new Dictionary<string, int>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "exam finished")
                {
                    break;
                }

                if (input.Contains("-banned"))
                {
                    var user = input.Split("-").FirstOrDefault();

                    if (users.ContainsKey(user))
                    {
                        users.Remove(user);
                    }
                }
                else
                {
                    var data = input.Split("-").ToList();

                    var user = data[0];
                    var lang = data[1];
                    var score = int.Parse(data[2]);

                    if (users.ContainsKey(user) && users[user] < score)
                    {
                        users[user] = score;
                    }
                    else if (!users.ContainsKey(user))
                    {
                        users.Add(user, score);
                    }

                    if (langs.ContainsKey(lang))
                    {
                        langs[lang]++;
                    }
                    else
                    {
                        langs.Add(lang, 1);
                    }
                }
            }

            Console.WriteLine("Results:");
            foreach (var kvp in users.OrderByDescending(u => u.Value).ThenBy(u => u.Key))
            {
                Console.WriteLine($"{kvp.Key} | {kvp.Value}");
            }

            Console.WriteLine("Submissions:");
            foreach (var kvp in langs.OrderByDescending(l => l.Value).ThenBy(l => l.Key))
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}
