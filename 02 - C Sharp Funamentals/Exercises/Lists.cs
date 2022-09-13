using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_C_Sharp_Funamentals.Exercises
{
    /// <summary>
    /// https://judge.softuni.org/Contests/Compete/Index/1211#0
    /// </summary>
    public static class Lists
    {

        /// <summary>
        /// 01. Train
        /// </summary>
        public static void Train()
        {
            var wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            var capacity = int.Parse(Console.ReadLine());
            var command = Console.ReadLine();

            while (command != "end")
            {
                if (command.StartsWith("Add"))
                {
                    var passengers = command.Split().Skip(1).Select(int.Parse).FirstOrDefault();
                    wagons.Add(passengers);
                }
                else
                {
                    var passangers = int.Parse(command);

                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (wagons[i] + passangers <= capacity)
                        {
                            wagons[i] += passangers;
                            passangers = 0;
                        }

                        if (passangers == 0)
                        {
                            break;
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", wagons));
        }

        /// <summary>
        /// 02. Change List
        /// </summary>
        public static void ChangeList()
        {
            var list = Console.ReadLine().Split().Select(int.Parse).ToList();
            var command = Console.ReadLine();

            while (command != "end")
            {
                if (command.StartsWith("Delete"))
                {
                    var toRemove = command.Split().Skip(1).Select(int.Parse).FirstOrDefault();
                    list.RemoveAll(l => l == toRemove);
                }
                else
                {
                    var toAdd = command.Split().Skip(1).Select(int.Parse).ToList();
                    list.Insert(toAdd.LastOrDefault(), toAdd.FirstOrDefault());
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", list));
        }

        /// <summary>
        /// 03. House Party
        /// </summary>
        public static void HouseParty()
        {
            var n = int.Parse(Console.ReadLine());
            var list = new List<string>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();

                if (input.EndsWith("is going!"))
                {
                    var name = input.Split().FirstOrDefault();

                    if (list.Contains(name))
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                    else
                    {
                        list.Add(name);
                    }
                }
                else
                {
                    var name = input.Split().FirstOrDefault();

                    if (!list.Contains(name))
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                    else
                    {
                        list.Remove(name);
                    }
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, list));
        }

        /// <summary>
        /// 04. List Operations
        /// </summary>
        public static void ListOperations()
        {
            var list = Console.ReadLine().Split().Select(int.Parse).ToList();
            var command = Console.ReadLine().Trim();

            while (command != "End")
            {
                if (command.StartsWith("Remove"))
                {
                    var toRemove = command.Split().Skip(1).Select(int.Parse).FirstOrDefault();

                    if (toRemove >= list.Count || toRemove < 0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        list.RemoveAt(toRemove);
                    }
                }
                else if (command.StartsWith("Insert"))
                {
                    var toAdd = command.Split().Skip(1).Select(int.Parse).ToList();

                    if (toAdd.LastOrDefault() >= list.Count || toAdd.LastOrDefault() < 0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        list.Insert(toAdd.LastOrDefault(), toAdd.FirstOrDefault());
                    }
                }
                else if (command.StartsWith("Add"))
                {
                    var toAdd = command.Split().Skip(1).Select(int.Parse).FirstOrDefault();
                    list.Add(toAdd);
                }
                else if (command.StartsWith("Shift left"))
                {
                    var count = command.Split().Skip(2).Select(int.Parse).FirstOrDefault();

                    for (int i = 0; i < count; i++)
                    {
                        var tmp = list.FirstOrDefault();
                        list.Remove(tmp);
                        list.Add(tmp);
                    }
                }
                else if (command.StartsWith("Shift right"))
                {
                    var count = command.Split().Skip(2).Select(int.Parse).FirstOrDefault();

                    for (int i = 0; i < count; i++)
                    {
                        var tmp = list.LastOrDefault();
                        list.Remove(tmp);
                        list.Insert(0, tmp);
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", list));
        }

        /// <summary>
        /// 05. Bomb Numbers
        /// </summary>
        public static void BombNumbers()
        {
            var list = Console.ReadLine().Split().Select(int.Parse).ToList();
            var bomb = Console.ReadLine().Split().Select(int.Parse).ToList();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == bomb.FirstOrDefault())
                {
                    for (int j = 1; j <= bomb.LastOrDefault(); j++)
                    {
                        if (i - 1 >= 0)
                        {
                            list.RemoveAt(i - 1);
                            i--;
                        }

                        if (i + 1 < list.Count)
                        {
                            list.RemoveAt(i);
                        }
                    }

                    list.RemoveAt(i);
                    i--;
                }
            }

            Console.WriteLine(list.Sum());
        }

        /// <summary>
        /// 06. Cards Game
        /// </summary>
        public static void CardsGame()
        {
            var list1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            var list2 = Console.ReadLine().Split().Select(int.Parse).ToList();

            for (int i = 0; i < list1.Count(); i++)
            {
                if (list1[i] > list2[i])
                {
                    var tmp1 = list1[i];
                    list1.RemoveAt(i);
                    list1.Add(tmp1);

                    var tmp2 = list2[i];
                    list2.RemoveAt(i);

                    list1.Add(tmp2);
                }
                else if (list1[i] < list2[i])
                {
                    var tmp1 = list2[i];
                    list2.RemoveAt(i);
                    list2.Add(tmp1);

                    var tmp2 = list1[i];
                    list1.RemoveAt(i);

                    list2.Add(tmp2);
                }
                else
                {
                    list1.RemoveAt(i);
                    list2.RemoveAt(i);
                }

                i--;

                if (list1.Count() == 0 || list2.Count() == 0)
                {
                    break;
                }
            }

            Console.WriteLine($"{(list1.Count() > 0 ? "First" : "Second")} player wins! Sum: {(list1.Count() > 0 ? list1.Sum() : list2.Sum())}");
        }

        /// <summary>
        /// 07. Append Arrays
        /// </summary>
        public static void AppendArrays()
        {
            var list = Console.ReadLine().Trim().Split("|").Reverse().ToList();
            var result = new List<int>();

            foreach (var item in list)
            {
                var numbers = item.Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                result.AddRange(numbers);
            }

            Console.WriteLine(string.Join(" ", result));
        }

        /// <summary>
        /// 08. Anonymous Threat 80/100
        /// </summary>
        public static void AnonymousThreat()
        {
            var list = Console.ReadLine().Split().ToList();

            var input = Console.ReadLine();

            while (input != "3:1")
            {
                var commands = input.Split().ToList();
                var command = commands.FirstOrDefault();

                if (command == "merge")
                {
                    MergeItems(list, commands);
                }
                else if (command == "divide")
                {
                    DivideItem(list, commands);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", list));
        }

        private static void DivideItem(List<string> list, List<string> commands)
        {
            var index = commands.Skip(1).Select(int.Parse).FirstOrDefault();
            var partitions = commands.Skip(2).Select(int.Parse).FirstOrDefault();
            var element = list.ElementAt(index);
            list.RemoveAt(index);
            var size = element.Length / partitions;

            var divided = new List<string>();

            for (int i = 0; i < partitions; i++)
            {
                if (i == partitions - 1)
                {
                    divided.Add(element.Substring(i * size));
                }
                else
                {
                    divided.Add(element.Substring(i * size, size));
                }
            }

            divided.Reverse();

            foreach (var item in divided)
            {
                list.Insert(index, item);
            }
        }

        private static void MergeItems(List<string> list, List<string> commands)
        {
            var start = commands.Skip(1).Select(int.Parse).FirstOrDefault();
            var end = commands.Skip(2).Select(int.Parse).FirstOrDefault();

            if (start < 0 || start >= list.Count())
            {
                start = 0;
            }

            if (end < 0 || end >= list.Count())
            {
                end = list.Count() - 1;
            }

            var tmpString = "";

            for (int i = start; i <= end; i++)
            {
                var tmp = list[start];
                list.RemoveAt(start);
                tmpString += tmp;
            }

            list.Insert(start > list.Count() ? 0 : start, tmpString);
        }

        /// <summary>
        /// 09. Pokemon Don't Go
        /// </summary>
        public static void PokemonDontGo()
        {
            var pokemons = Console.ReadLine().Split().Select(int.Parse).ToList();
            var sum = 0;

            while (pokemons.Count() > 0)
            {
                var index = int.Parse(Console.ReadLine());

                var toIncrease = 0;

                if (index < 0)
                {
                    toIncrease = pokemons.FirstOrDefault();
                    pokemons.RemoveAt(0);
                    pokemons.Insert(0, pokemons.LastOrDefault());
                }
                else if (index > pokemons.Count() - 1)
                {
                    toIncrease = pokemons.LastOrDefault();
                    pokemons.RemoveAt(pokemons.Count() - 1);
                    pokemons.Add(pokemons.FirstOrDefault());
                }
                else
                {
                    toIncrease = pokemons.ElementAt(index);
                    pokemons.RemoveAt(index);
                }

                sum += toIncrease;

                for (int i = 0; i < pokemons.Count(); i++)
                {
                    if (pokemons[i] <= toIncrease)
                    {
                        pokemons[i] += toIncrease;
                    }
                    else
                    {
                        pokemons[i] -= toIncrease;
                    }
                }
            }

            Console.WriteLine(sum);
        }

        /// <summary>
        /// 10. SoftUni Course Planning
        /// </summary>
        public static void SoftUniCoursePlanning()
        {
            var courses = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();

            var commands = Console.ReadLine();

            while (commands != "course start")
            {
                var command = commands.Split(":");

                if (command.FirstOrDefault() == "Add")
                {
                    if (!courses.Contains(command.LastOrDefault()))
                    {
                        courses.Add(command.LastOrDefault());
                    }
                }
                else if (command.FirstOrDefault() == "Insert")
                {
                    var index = int.Parse(command.LastOrDefault());

                    if (!courses.Contains(command.Skip(1).FirstOrDefault()))
                    {
                        if (index < courses.Count() && index >= 0)
                        {
                            courses.Insert(index, command.Skip(1).FirstOrDefault());
                        }
                    }
                }
                else if (command.FirstOrDefault() == "Remove")
                {
                    courses.RemoveAll(c => c.Contains(command.LastOrDefault()));
                }
                else if (command.FirstOrDefault() == "Swap")
                {
                    var first = command.Skip(1).FirstOrDefault();
                    var last = command.LastOrDefault();

                    if (courses.Contains(first) && courses.Contains(last))
                    {
                        var index1 = courses.IndexOf(first);
                        var index2 = courses.LastIndexOf(last);

                        if (index1 > -1 && index2 > -1)
                        {
                            courses[index1] = last;
                            courses[index2] = first;

                            var ex1 = courses.IndexOf($"{first}-Exercise");
                            var ex2 = courses.IndexOf($"{last}-Exercise");

                            if (ex1 > -1)
                            {
                                courses.RemoveAt(ex1);
                                index1 = courses.IndexOf(first);
                                courses.Insert(index1 + 1, $"{first}-Exercise");
                            }
                            if (ex2 > -1)
                            {
                                courses.RemoveAt(ex2);
                                index2 = courses.IndexOf(last);
                                courses.Insert(index2 + 1, $"{last}-Exercise");
                            }
                        }
                    }
                }
                else if (command.FirstOrDefault() == "Exercise")
                {
                    if (courses.Contains(command.LastOrDefault()) && !courses.Contains($"{command.LastOrDefault()}-Exercise"))
                    {
                        var index = courses.IndexOf(command.LastOrDefault());
                        courses.Insert(index + 1, $"{command.LastOrDefault()}-Exercise");
                    }
                    else if (!courses.Contains(command.LastOrDefault()))
                    {
                        courses.Add(command.LastOrDefault());
                        courses.Add($"{command.LastOrDefault()}-Exercise");
                    }
                }

                commands = Console.ReadLine();
            }

            for (int i = 0; i < courses.Count(); i++)
            {
                Console.WriteLine($"{i + 1}.{courses[i]}");
            }
        }
    }
}
