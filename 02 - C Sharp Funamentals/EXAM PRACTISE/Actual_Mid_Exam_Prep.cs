using System;
using System.Linq;

namespace _02_C_Sharp_Funamentals.EXAM_PRACTISE
{
    /// <summary>
    /// https://judge.softuni.org/Contests/Practice/Index/1773#0
    /// </summary>
    public static class Actual_Mid_Exam_Prep
    {
        /// <summary>
        /// 01. Black Flag
        /// </summary>
        public static void BlackFlag()
        {
            var days = int.Parse(Console.ReadLine());
            var plunder = int.Parse(Console.ReadLine());
            var expected = decimal.Parse(Console.ReadLine());

            var bonusPlunder = plunder / 2m;
            var totalPlunder = 0m;

            for (int i = 1; i <= days; i++)
            {
                totalPlunder += plunder;

                if (i % 3 == 0)
                {
                    totalPlunder += bonusPlunder;
                }

                if (i % 5 == 0)
                {
                    totalPlunder *= 0.7m;
                }
            }

            if (totalPlunder >= expected)
            {
                Console.WriteLine($"Ahoy! {totalPlunder:f2} plunder gained.");
            }
            else
            {
                Console.WriteLine($"Collected only {(totalPlunder / expected) * 100:f2}% of the plunder.");
            }
        }

        /// <summary>
        /// 02. Treasure Hunt
        /// </summary>
        public static void TreasureHunt()
        {
            var treasures = Console.ReadLine().Split('|').ToList();
            var input = Console.ReadLine();

            while (input != "Yohoho!")
            {
                var commands = input.Split().ToList();

                if (commands[0] == "Loot")
                {
                    foreach (var item in commands.Skip(1).Where(c => !treasures.Contains(c)).ToList())
                    {
                        treasures.Insert(0, item);
                    }
                }
                else if (commands[0] == "Drop")
                {
                    var index = int.Parse(commands[1]);

                    if (index >= 0 && index <= treasures.Count() - 1)
                    {
                        var treasure = treasures[index];
                        treasures.RemoveAt(index);
                        treasures.Add(treasure);
                    }
                }
                else if (commands[0] == "Steal")
                {
                    var count = int.Parse(commands[1]);

                    var toRemove = treasures.Skip(treasures.Count() - count).Take(count).ToList();
                    for (int i = 0; i < toRemove.Count(); i++)
                    {
                        treasures.Remove(toRemove[i]);
                    }

                    Console.WriteLine(string.Join(", ", toRemove));
                }

                input = Console.ReadLine();
            }

            if (treasures.Count() > 0)
            {
                Console.WriteLine($"Average treasure gain: {treasures.Select(t => t.Length).DefaultIfEmpty().Sum() / (decimal)treasures.Count():f2} pirate credits.");
            }
            else
            {
                Console.WriteLine("Failed treasure hunt.");
            }
        }

        /// <summary>
        /// 03. Man O War
        /// </summary>
        public static void ManOWar()
        {
            var pirateShip = Console.ReadLine().Split('>').Select(int.Parse).ToList();
            var warship = Console.ReadLine().Split('>').Select(int.Parse).ToList();
            var sectionMaxHp = int.Parse(Console.ReadLine());

            var input = Console.ReadLine();

            while (input != "Retire")
            {
                var commands = input.Split().ToList();

                if (commands[0] == "Fire")
                {
                    var index = int.Parse(commands[1]);
                    var damage = int.Parse(commands[2]);

                    if (index >= 0 && index <= warship.Count() - 1)
                    {
                        warship[index] -= damage;

                        if (warship[index] <= 0)
                        {
                            Console.WriteLine("You won! The enemy ship has sunken.");
                            return;
                        }
                    }
                }
                else if (commands[0] == "Defend")
                {
                    var startIndex = int.Parse(commands[1]);
                    var endIndex = int.Parse(commands[2]);
                    var damage = int.Parse(commands[3]);

                    if (startIndex >= 0 && startIndex <= pirateShip.Count() - 1 && endIndex >= 0 && endIndex <= pirateShip.Count() - 1)
                    {
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            pirateShip[i] -= damage;

                            if (pirateShip[i] <= 0)
                            {
                                Console.WriteLine("You lost! The pirate ship has sunken.");
                                return;
                            }
                        }
                    }
                }
                else if (commands[0] == "Repair")
                {
                    var index = int.Parse(commands[1]);
                    var heal = int.Parse(commands[2]);

                    if (index >= 0 && index <= pirateShip.Count() - 1)
                    {
                        pirateShip[index] += heal;

                        if (pirateShip[index] > sectionMaxHp)
                        {
                            pirateShip[index] = sectionMaxHp;
                        }
                    }
                }
                else if (commands[0] == "Status")
                {
                    var minAmount = sectionMaxHp * 0.2m;
                    var count = pirateShip.Count(p => (decimal)p < minAmount);

                    Console.WriteLine($"{count} sections need repair.");
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Pirate ship status: {pirateShip.Sum()}");
            Console.WriteLine($"Warship status: {warship.Sum()}");
        }
    }
}
