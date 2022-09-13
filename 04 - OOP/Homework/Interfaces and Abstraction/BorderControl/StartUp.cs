using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var entites = new List<Human>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var parameters = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

                if (entites.Any(e => e.Name.ToLowerInvariant() == parameters[0].ToLowerInvariant()))
                {
                    continue;
                }

                if (parameters.Count == 4)
                {
                    entites.Add(new Citizen(parameters[0], int.Parse(parameters[1]), parameters[2], parameters[3]));
                }
                else
                {
                    entites.Add(new Rebel(parameters[0], int.Parse(parameters[1]), parameters[2]));
                }
            }

            while (true)
            {
                var name = Console.ReadLine();

                if (name == "End")
                {
                    break;
                }

                if (!entites.Any(e => e.Name.ToLowerInvariant() == name.ToLowerInvariant()))
                {
                    continue;
                }

                var human = entites.First(e => e.Name.ToLowerInvariant() == name.ToLowerInvariant());
                human.BuyFood();
            }

            Console.WriteLine(entites.Sum(e => e.Food));
        }
    }
}