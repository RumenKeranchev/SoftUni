using System;
using System.Collections.Generic;
using System.Linq;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var animals = new List<Animal>();
            var counter = 0;

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                var parameters = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                Animal animal = null;
                var type = parameters[0];

                try
                {
                    if (counter % 2 == 0)
                    {
                        var name = parameters[1];
                        var weight = double.Parse(parameters[2]);


                        if (type == nameof(Cat) || type == nameof(Tiger))
                        {
                            var livingRegion = parameters[3];
                            var breed = parameters[4];

                            if (type == nameof(Cat))
                            {
                                animal = new Cat(name, weight, livingRegion, breed);
                            }
                            else
                            {
                                animal = new Tiger(name, weight, livingRegion, breed);
                            }
                        }
                        else if (type == nameof(Owl) || type == nameof(Hen))
                        {
                            var wingSize = double.Parse(parameters[3]);

                            if (type == nameof(Owl))
                            {
                                animal = new Owl(name, weight, wingSize);
                            }
                            else
                            {
                                animal = new Hen(name, weight, wingSize);
                            }
                        }
                        else
                        {
                            var livingRegion = parameters[3];

                            if (type == nameof(Mouse))
                            {
                                animal = new Mouse(name, weight, livingRegion);
                            }
                            else
                            {
                                animal = new Dog(name, weight, livingRegion);
                            }
                        }

                        animals.Add(animal);
                    }
                    else
                    {
                        animal = animals.LastOrDefault();

                        Food food = type switch
                        {
                            nameof(Vegetable) => new Vegetable(int.Parse(parameters[1])),
                            nameof(Fruit) => new Fruit(int.Parse(parameters[1])),
                            nameof(Meat) => new Meat(int.Parse(parameters[1])),
                            nameof(Seeds) => new Seeds(int.Parse(parameters[1])),
                            _ => throw new NotImplementedException()
                        };

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(animal.ProduceSound());
                        animal.EatFood(food);
                        Console.ResetColor();
                    }
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                }

                counter++;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
            Console.ResetColor();
        }
    }
}
