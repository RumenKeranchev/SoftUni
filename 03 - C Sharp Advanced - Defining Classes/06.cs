using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses1
{
    public static class _06
    {
        public static void Execute()
        {
            var n = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                var car = new Car
                {
                    Model = input[0],
                    FuelAmount = double.Parse(input[1]),
                    FuelConsumptionPerKilometer = double.Parse(input[2]),
                };

                if (!cars.Any(c => c.Model == car.Model))
                {
                    cars.Add(car);
                }
            }

            var commandInput = Console.ReadLine();

            while (commandInput != "End")
            {
                var commands = commandInput.Split(" ");
                var car = cars.FirstOrDefault(c => c.Model == commands[1]);
                car.Drive(int.Parse(commands[2]));

                commandInput = Console.ReadLine();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
            Console.ResetColor();
        }
    }

    public class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public void Drive(int amountOfKm)
        {
            var consumedFuel = amountOfKm * FuelConsumptionPerKilometer;

            if (consumedFuel <= FuelAmount)
            {
                TravelledDistance += amountOfKm;
                FuelAmount -= consumedFuel;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Insufficient fuel for the drive");
                Console.ResetColor();
            }
        }

        public override string ToString()
        {
            return $"{Model} {FuelAmount:f2} {TravelledDistance}";
        }
    }
}
