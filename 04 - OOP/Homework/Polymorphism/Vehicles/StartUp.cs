using System;
using System.Linq;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var carInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(double.Parse).ToList();
            var car = new Car(carInput[0], carInput[1], carInput[2]);

            var truckInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(double.Parse).ToList();
            var truck = new Truck(truckInput[0], truckInput[1], truckInput[2]);

            var busInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(double.Parse).ToList();
            var bus = new Bus(busInput[0], busInput[1], busInput[2]);

            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

                var command = commands[0].ToLowerInvariant();
                var vehicleType = commands[1].ToLowerInvariant();
                var value = double.Parse(commands[2]);

                try
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (command == "drive")
                    {
                        if (vehicleType == "car")
                        {
                            Console.WriteLine(car.Drive(value));
                        }
                        else if (vehicleType == "truck")
                        {
                            Console.WriteLine(truck.Drive(value));
                        }
                        else
                        {
                            Console.WriteLine(bus.Drive(value));
                        }
                    }
                    else if (command == "refuel")
                    {
                        if (vehicleType == "car")
                        {
                            car.Refuel(value);
                        }
                        else if (vehicleType == "truck")
                        {
                            truck.Refuel(value);
                        }
                        else
                        {
                            bus.Refuel(value);
                        }
                    }
                    else
                    {
                        Console.WriteLine(bus.DriveEmpty(value));
                    }
                    Console.ResetColor();
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                    continue;
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
            Console.ResetColor();
        }
    }
}
