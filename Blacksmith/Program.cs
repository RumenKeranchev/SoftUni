using System;
using System.Collections.Generic;
using System.Linq;

namespace Blacksmith
{
    /// <summary>
    /// 100/100
    /// https://judge.softuni.org/Contests/Practice/Index/3285#0
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            var steel = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
            var carbon = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
            var swords = new Dictionary<int, string>
            {
                { 70, "Gladius" },
                { 80, "Shamshir" },
                { 90, "Katana" },
                { 110, "Sabre" },
                { 150, "Broadsword" }
            };

            var craftedSwords = new Dictionary<string, int>();

            while (steel.Count > 0 && carbon.Count > 0)
            {
                var currentSum = steel.Dequeue() + carbon.Peek();

                if (swords.ContainsKey(currentSum))
                {
                    if (craftedSwords.ContainsKey(swords[currentSum]))
                    {
                        craftedSwords[swords[currentSum]]++;
                    }
                    else
                    {
                        craftedSwords.Add(swords[currentSum], 1);
                    }

                    carbon.Pop();
                }
                else
                {
                   var currentCarbon = carbon.Pop();
                    currentCarbon += 5;
                    carbon.Push(currentCarbon);
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            if (craftedSwords.Any())
            {
                Console.WriteLine($"You have forged {craftedSwords.Sum(c => c.Value)} swords.");
            }
            else
            {
                Console.WriteLine($"You did not have enough resources to forge a sword.");
            }

            if (!steel.Any())
            {
                Console.WriteLine("Steel left: none");
            }
            else
            {
                Console.WriteLine($"Steel left: {string.Join(", ", steel)}");
            }
            
            if (!carbon.Any())
            {
                Console.WriteLine("Carbon left: none");
            }
            else
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            }

            foreach (var sword in craftedSwords.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{sword.Key}: {sword.Value}");
            }
        }
    }
}
