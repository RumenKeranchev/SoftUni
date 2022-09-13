using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var animals = new List<Animal>();

            while (true)
            {
                var animalType = Console.ReadLine();
                if (animalType == "Beast!")
                {
                    break;
                }
                var animalDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

                switch (animalType)
                {
                    case "Dog":
                        animals.Add(new Dog(animalDetails[0], int.Parse(animalDetails[1]), animalDetails[2]));
                        break;
                    case "Cat":
                        animals.Add(new Cat(animalDetails[0], int.Parse(animalDetails[1]), animalDetails[2]));
                        break;
                    case "Frog":
                        animals.Add(new Frog(animalDetails[0], int.Parse(animalDetails[1]), animalDetails[2]));
                        break;
                    case "Kitten":
                        animals.Add(new Kitten(animalDetails[0], int.Parse(animalDetails[1])));
                        break;
                    case "Tomcar":
                        animals.Add(new Tomcat(animalDetails[0], int.Parse(animalDetails[1])));
                        break;
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.GetType().Name);
                Console.WriteLine(animal);
                Console.WriteLine(animal.ProduceSound());
            }
        }
    }
}
