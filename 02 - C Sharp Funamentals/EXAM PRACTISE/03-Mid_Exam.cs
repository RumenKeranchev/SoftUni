using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_C_Sharp_Funamentals.EXAM_PRACTISE
{
    /// <summary>
    /// https://judge.softuni.org/Contests/Practice/Index/2305#0
    /// </summary>
    public static class _03_Mid_Exam
    {
        /// <summary>
        /// 01. Counter-Strike
        /// </summary>
        public static void CounterStrike()
        {
            var energy = int.Parse(Console.ReadLine());
            var wonBattles = 0;
            var hasEnoughEnergy = true;

            var input = Console.ReadLine();

            while (input != "End of battle")
            {
                var distance = int.Parse(input);

                if (energy >= distance)
                {
                    energy -= distance;
                    wonBattles++;

                    if (wonBattles % 3 == 0)
                    {
                        energy += wonBattles;
                    }
                }
                else
                {
                    Console.WriteLine($"Not enough energy! Game ends with {wonBattles} won battles and {energy} energy");
                    hasEnoughEnergy = false;
                    break;
                }

                input = Console.ReadLine();
            }

            if (hasEnoughEnergy)
            {
                Console.WriteLine($"Won battles: {wonBattles}. Energy left: {energy}");
            }
        }

        /// <summary>
        /// 02. Shoot for the Win
        /// </summary>
        public static void ShootForTheWin()
        {
            var targets = Console.ReadLine().Split().Select(int.Parse).ToList();
            var shotTargets = new List<int>();

            var input = Console.ReadLine();

            while (input != "End")
            {
                var index = int.Parse(input);

                if (index >= 0 && index < targets.Count())
                {
                    var target = targets[index];

                    for (int i = 0; i < targets.Count(); i++)
                    {
                        if (!shotTargets.Contains(i))
                        {
                            if (i != index)
                            {
                                if (targets[i] > target)
                                {
                                    targets[i] -= target;
                                }
                                else
                                {
                                    targets[i] += target;
                                }
                            }
                            else
                            {
                                targets[i] = -1;
                                shotTargets.Add(i);
                            }
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Shot targets: {shotTargets.Count()} -> {string.Join(" ", targets)}");
        }

        /// <summary>
        /// 03. Moving Target
        /// </summary>
        public static void MovingTarget()
        {
            var targets = Console.ReadLine().Split().Select(int.Parse).ToList();
            var shotTargets = new List<int>();

            var input = Console.ReadLine();

            while (input != "End")
            {
                var commands = input.Split().ToList();

                if (commands[0] == "Shoot")
                {
                    var index = int.Parse(commands[1]);
                    var power = int.Parse(commands[2]);

                    if (index >= 0 && index < targets.Count())
                    {
                        targets[index] -= power;

                        if (targets[index] <= 0)
                        {
                            targets.RemoveAt(index);
                        }
                    }
                }
                else if (commands[0] == "Add")
                {
                    var index = int.Parse(commands[1]);
                    var value = int.Parse(commands[2]);

                    if (index >= 0 && index < targets.Count())
                    {
                        targets.Insert(index, value);
                    }
                    else
                    {
                        Console.WriteLine("Invalid placement!");
                    }
                }
                else if (commands[0] == "Strike")
                {
                    var index = int.Parse(commands[1]);
                    var radius = int.Parse(commands[2]);

                    if (index >= 0 && index < targets.Count())
                    {
                        if (index - radius >= 0 && index + radius < targets.Count())
                        {
                            targets.RemoveRange(index - radius, radius * 2 + 1);
                        }
                        else
                        {
                            Console.WriteLine("Strike missed!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Strike missed!");
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join("|", targets));
        }
    }
}
