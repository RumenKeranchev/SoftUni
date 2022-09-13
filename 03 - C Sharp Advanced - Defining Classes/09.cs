using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class _09
    {
        public static void Execute()
        {
            var trainers = new List<Trainer>();
            int id = 1;

            var input = Console.ReadLine();

            while (input != "Tournament")
            {
                var parameters = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                var name = parameters[0];
                var pokemonName = parameters[1];
                var element = parameters[2];
                var hp = int.Parse(parameters[3]);

                Trainer trainer;

                if (!trainers.Any(t => t.Name == name))
                {
                    trainer = new Trainer(id, name);
                    trainers.Add(trainer);
                }
                else
                {
                    trainer = trainers.FirstOrDefault(t => t.Name == name);
                };

                trainer.Pokemons.Add(new Pokemon(pokemonName, element, hp));

                id++;
                input = Console.ReadLine();
            }

            var elementInput = Console.ReadLine();

            while (elementInput != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.HasPokemonOfElemet(elementInput))
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        foreach (var pokemon in trainer.Pokemons)
                        {
                            pokemon.TakeDamage();
                        }

                        trainer.Pokemons.RemoveAll(p => !p.IsAlive);
                    }
                }

                elementInput = Console.ReadLine();
            }

            foreach (var trainer in trainers.OrderByDescending(t => t.NumberOfBadges).ThenBy(t => t.Id))
            {
                Console.WriteLine(trainer);
            }
        }

        public class Trainer
        {
            public int Id { get; set; }

            public Trainer(int id, string name)
            {
                Id = id;
                Name = name;
            }

            public string Name { get; set; }

            public int NumberOfBadges { get; set; }

            public List<Pokemon> Pokemons { get; set; } = new List<Pokemon>();

            public bool HasPokemonOfElemet(string element) => Pokemons.Any(p => p.Element == element);

            public override string ToString()
            {
                return $"{Name} {NumberOfBadges} {Pokemons.Count}";
            }

        }

        public class Pokemon
        {
            public Pokemon(string name, string element, int hp)
            {
                Name = name;
                Element = element;
                Health = hp;
            }

            public string Name { get; set; }

            public string Element { get; set; }

            public int Health { get; set; }

            public bool IsAlive => Health > 0;

            public void TakeDamage()
            {
                Health -= 10;
            }
        }
    }
}
