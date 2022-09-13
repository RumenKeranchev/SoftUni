using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_C_Sharp_Advanced.Exercises
{
    public class SetsAndDictionaries
    {
        /// <summary>
        /// 01. Unique Usernames
        /// </summary>
        public static void UniqueUsernames()
        {
            var n = int.Parse(Console.ReadLine());
            var set = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                set.Add(Console.ReadLine());
            }

            foreach (var item in set)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// 02. Sets of Elements
        /// </summary>
        public static void SetsOfElements()
        {
            var ns = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var set1 = new HashSet<int>();
            var set2 = new HashSet<int>();
            var resSet = new HashSet<int>();

            for (int i = 0; i < ns[0]; i++)
            {
                set1.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < ns[1]; i++)
            {
                set2.Add(int.Parse(Console.ReadLine()));
            }

            resSet = new HashSet<int>(set1.Intersect(set2));

            Console.WriteLine(string.Join(" ", resSet));
        }

        /// <summary>
        /// 03. Periodic Table
        /// </summary>
        public static void PeriodicTable()
        {
            var n = int.Parse(Console.ReadLine());
            var set = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split().ToList();

                foreach (var item in input)
                {
                    set.Add(item);
                }
            }

            Console.WriteLine(string.Join(" ", set));
        }

        /// <summary>
        /// 04. Even Times
        /// </summary>
        public static void EvenTimes()
        {
            var n = int.Parse(Console.ReadLine());

            var dict = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                var input = int.Parse(Console.ReadLine());

                if (!dict.ContainsKey(input))
                {
                    dict.Add(input, 0);
                }

                dict[input]++;
            }

            var res = dict.FirstOrDefault(d => d.Value % 2 == 0);

            Console.WriteLine(res.Key);
        }

        /// <summary>
        /// 05. Count Symbols
        /// </summary>
        public static void CountSymbols()
        {
            var input = Console.ReadLine().ToCharArray();

            var dict = new SortedDictionary<char, int>();

            foreach (var chara in input)
            {
                if (!dict.ContainsKey(chara))
                {
                    dict.Add(chara, 0);
                }

                dict[chara]++;
            }

            foreach (var chara in dict)
            {
                Console.WriteLine($"{chara.Key}: {chara.Value} time/s");
            }
        }

        /// <summary>
        /// 06. Wardrobe
        /// </summary>
        public static void Wardrobe()
        {
            var n = int.Parse(Console.ReadLine());

            var dict = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                if (!dict.ContainsKey(input[0]))
                {
                    dict.Add(input[0], new Dictionary<string, int>());
                }

                var clothes = input[1].Split(",", StringSplitOptions.RemoveEmptyEntries).ToList();

                foreach (var cloth in clothes)
                {
                    if (!dict[input[0]].ContainsKey(cloth))
                    {
                        dict[input[0]].Add(cloth, 0);
                    }

                    dict[input[0]][cloth]++;
                }
            }

            var search = Console.ReadLine().Split().ToList();

            if (dict.ContainsKey(search[0]))
            {
                if (dict[search[0]].ContainsKey(search[1]))
                {
                    dict[search[0]][search[1]] *= -1;
                }
            }

            foreach (var color in dict)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var kvp in color.Value)
                {
                    Console.WriteLine($"* {kvp.Key} - {(kvp.Value < 0 ? kvp.Value * -1 : kvp.Value)} {(kvp.Value < 0 ? "(found!)" : "")}");
                }
            }
        }
    }
}
