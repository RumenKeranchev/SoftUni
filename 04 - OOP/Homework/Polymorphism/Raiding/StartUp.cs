using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var heroes = new List<BaseHero>();
            HeroFactory heroFactory = null;

            while (n > heroes.Count)
            {
                try
                {
                    var name = Console.ReadLine();
                    var type = Console.ReadLine();

                    heroFactory = type switch
                    {
                        "Druid" => new DruidFactory(name),
                        "Paladin" => new PaladinFactory(name),
                        "Rogue" => new RogueFactory(name),
                        "Warrior" => new WarriorFactory(name),
                        _ => throw new Exception("Invalid Hero!"),
                    };

                    heroes.Add(heroFactory.CreateHero());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            var bossPower = long.Parse(Console.ReadLine());

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }

            long totalPower = heroes.Select(h => h.Power).Sum();
            Console.WriteLine(totalPower >= bossPower ? "Victory!" : "Defeat...");
        }
    }
}
