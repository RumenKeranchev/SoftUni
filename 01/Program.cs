using System;
using System.Collections.Generic;
using System.Linq;

namespace _01
{
    internal class Program
    {
        /// <summary>
        /// https://judge.softuni.org/Contests/Compete/Index/3349#1
        /// 90/100
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var water = new Queue<decimal>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToList());
            var flour = new Stack<decimal>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToList());
            var pastries = new Dictionary<(int water, int flour), string>
            {
                {(50, 50), "Croissant" },
                {(40, 60), "Muffin" },
                {(30, 70), "Baguette" },
                {(20, 80), "Bagel" }
            };

            var bakedGoods = new Dictionary<string, int>();

            while (water.Count > 0 && flour.Count > 0)
            {
                var currentWater = water.Dequeue();
                var currentFlour = flour.Peek();

                var currentSum = currentWater + currentFlour;

                var waterRatio = (int)((currentWater * 100) / currentSum);
                var flourRatio = (int)((currentFlour * 100) / currentSum);

                if (pastries.ContainsKey((waterRatio, flourRatio)))
                {
                    if (bakedGoods.ContainsKey(pastries[(waterRatio, flourRatio)]))
                    {
                        bakedGoods[pastries[(waterRatio, flourRatio)]]++;
                    }
                    else
                    {
                        bakedGoods.Add(pastries[(waterRatio, flourRatio)], 1);
                    }

                    flour.Pop();
                }
                else
                {
                    currentFlour = flour.Pop();
                    var remainingFlour = currentFlour - currentWater;

                    if (bakedGoods.ContainsKey(pastries[(50, 50)]))
                    {
                        bakedGoods[pastries[(50, 50)]]++;
                    }
                    else
                    {
                        bakedGoods.Add(pastries[(50, 50)], 1);
                    }

                    flour.Push(remainingFlour);
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;

            foreach (var goods in bakedGoods.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{goods.Key}: {goods.Value}");
            }

            Console.WriteLine($"Water left: {(water.Any() ? string.Join(", ", water) : "None")}");
            Console.WriteLine($"Flour left: {(flour.Any() ? string.Join(", ", flour) : "None")}");
        }
    }
}
