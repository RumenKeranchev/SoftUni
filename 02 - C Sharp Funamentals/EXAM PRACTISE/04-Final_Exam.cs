using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02_C_Sharp_Funamentals.EXAM_PRACTISE
{
    /// <summary>
    /// https://judge.softuni.org/Contests/Practice/Index/2303#0
    /// </summary>
    public static class _04_Final_Exam
    {
        /// <summary>
        /// 01. Password Reset
        /// </summary>
        public static void PasswordReset()
        {
            var password = Console.ReadLine();

            while (true)
            {
                var input = Console.ReadLine();
                var commands = input.Split().ToList();

                if (commands[0] == "Done")
                {
                    break;
                }

                if (input == "TakeOdd")
                {
                    password = string.Join("", password.Where((c, i) => i % 2 != 0));
                    Console.WriteLine(password);
                }
                else if (commands[0] == "Cut")
                {
                    var index = int.Parse(commands[1]);
                    var length = int.Parse(commands[2]);
                    password = password.Remove(index, length);
                    Console.WriteLine(password);
                }
                else if (commands[0] == "Substitute")
                {
                    if (password.Contains(commands[1]))
                    {
                        password = password.Replace(commands[1], commands[2]);
                        Console.WriteLine(password);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }
            }

            Console.WriteLine($"Your password is: {password}");
        }

        /// <summary>
        /// 02. Fancy Barcodes
        /// </summary>
        public static void FancyBarcodes()
        {
            var pattern = @"([@][#]+)(?<product>[A-Z][a-zA-Z0-9]{4,}[A-Z])([@][#]+)";

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();

                var regex = Regex.Match(input, pattern);

                if (regex.Success)
                {
                    var barcode = "";
                    var product = regex.Groups["product"].Value;

                    for (int j = 0; j < product.Length; j++)
                    {
                        if (char.IsDigit(product[j]))
                        {
                            barcode += product[j];
                        }
                    }

                    if (string.IsNullOrEmpty(barcode))
                    {
                        barcode = "00";
                    }
                    Console.WriteLine($"Product group: {barcode}");
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }

        /// <summary>
        /// 03. Heroes of Code and Logic VII
        /// </summary>
        public static class HeroesOfCodeAndLogicVII
        {
            public static void Play()
            {
                var n = int.Parse(Console.ReadLine());
                var heroes = new List<Hero>();

                for (int i = 0; i < n; i++)
                {
                    var hero = CreateHero();
                    if (!heroes.Any(h => h.Name == hero.Name))
                    {
                        heroes.Add(hero);
                    }
                }

                while (true)
                {
                    var commands = Console.ReadLine().Split(" - ").ToList();

                    if (commands[0] == "End")
                    {
                        break;
                    }

                    var hero = heroes.FirstOrDefault(h => h.Name == commands[1]);

                    if (commands[0] == "CastSpell")
                    {
                        CastSpell(hero, int.Parse(commands[2]), commands[3]);
                    }
                    else if (commands[0] == "TakeDamage")
                    {
                        TakeDamage(hero, heroes, int.Parse(commands[2]), commands[3]);
                    }
                    else if (commands[0] == "Recharge")
                    {
                        Recharge(hero, int.Parse(commands[2]));
                    }
                    else if (commands[0] == "Heal")
                    {
                        Heal(hero, int.Parse(commands[2]));
                    }
                }

                Print(heroes);
            }

            static Hero CreateHero()
            {
                var input = Console.ReadLine().Split().ToList();

                return new Hero
                {
                    Name = input[0],
                    Health = int.Parse(input[1]),
                    Mana = int.Parse(input[2]),
                };
            }

            static void CastSpell(Hero hero, int manaNeeded, string spellName)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                if (hero.Mana >= manaNeeded)
                {
                    hero.Mana -= manaNeeded;
                    Console.WriteLine($"{hero.Name} has successfully cast {spellName} and now has {hero.Mana} MP!", Console.ForegroundColor);
                }
                else
                {
                    Console.WriteLine($"{hero.Name} does not have enough MP to cast {spellName}!", Console.ForegroundColor);
                }
                Console.ForegroundColor = ConsoleColor.White;
            }

            static void TakeDamage(Hero hero, List<Hero> heroes, int damage, string attacker)
            {
                hero.Health -= damage;
                Console.ForegroundColor = ConsoleColor.Green;
                if (hero.Health > 0)
                {
                    Console.WriteLine($"{hero.Name} was hit for {damage} HP by {attacker} and now has {hero.Health} HP left!", Console.ForegroundColor);
                }
                else
                {
                    Console.WriteLine($"{hero.Name} has been killed by {attacker}!", Console.ForegroundColor);
                    heroes.Remove(hero);
                }
                Console.ForegroundColor = ConsoleColor.White;
            }

            static void Recharge(Hero hero, int amount)
            {
                if (hero.Mana + amount > 200)
                {
                    amount = 200 - hero.Mana;
                }

                hero.Mana += amount;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{hero.Name} recharged for {amount} MP!", Console.ForegroundColor);
                Console.ForegroundColor = ConsoleColor.White;
            }

            static void Heal(Hero hero, int amount)
            {
                if (hero.Health + amount > 100)
                {
                    amount = 100 - hero.Health;
                }

                hero.Health += amount;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{hero.Name} healed for {amount} HP!", Console.ForegroundColor);
                Console.ForegroundColor = ConsoleColor.White;
            }

            static void Print(List<Hero> heroes)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                foreach (var hero in heroes.OrderByDescending(h => h.Health).ThenBy(h => h.Name))
                {
                    Console.WriteLine(hero.ToString(), Console.ForegroundColor);
                }
                Console.ForegroundColor = ConsoleColor.White;
            }

            class Hero
            {
                public string Name { get; set; }

                public int Health { get; set; }

                public int Mana { get; set; }

                public override string ToString()
                {
                    return $"{Name}\r\n  HP: {Health}\r\n  MP: {Mana}";
                }
            }
        }
    }
}
