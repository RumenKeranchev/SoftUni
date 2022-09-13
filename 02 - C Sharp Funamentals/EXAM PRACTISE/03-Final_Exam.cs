using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02_C_Sharp_Funamentals.EXAM_PRACTISE
{
    /// <summary>
    /// https://judge.softuni.org/Contests/Practice/Index/2307#0
    /// </summary>
    public class _03_Final_Exam
    {
        /// <summary>
        /// 01. Secret Chat
        /// </summary>
        public static void SecretChat()
        {
            var message = Console.ReadLine();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Reveal")
                {
                    break;
                }

                var split = input.Split(":|:").ToList();
                var command = split[0];
                var data1 = split[1];

                if (command == "InsertSpace")
                {
                    var index = int.Parse(data1);
                    message = message.Insert(index, " ");
                    Console.WriteLine(message);
                }
                else if (command == "Reverse")
                {
                    if (message.Contains(data1))
                    {
                        var indexOfSub = message.IndexOf(data1);
                        message = message.Remove(indexOfSub, data1.Length);
                        data1 = string.Join("", data1.Reverse());
                        message += data1;
                        Console.WriteLine(message);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (command == "ChangeAll")
                {
                    message = message.Replace(data1, split[2]);
                    Console.WriteLine(message);
                }
            }

            Console.WriteLine($"You have a new text message: {message}");
        }

        /// <summary>
        /// 02. Mirror Words
        /// </summary>
        public static void MirrorWords()
        {
            var pattern = @"([@|#])([a-zA-Z]{3,})\1{2}([a-zA-Z]{3,})\1";

            var regex = Regex.Matches(Console.ReadLine(), pattern);

            var results = new List<string>();


            foreach (Match match in regex)
            {
                if (match.Groups[2].Value == string.Join("", match.Groups[3].Value.Reverse()))
                {
                    results.Add($"{match.Groups[2]} <=> {match.Groups[3]}");
                }
            }

            if (regex.Count() > 0)
            {
                Console.WriteLine($"{regex.Count()} word pairs found!");
            }
            else
            {
                Console.WriteLine("No word pairs found!");
            }

            if (results.Count() > 0)
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", results));
            }
            else
            {
                Console.WriteLine("No mirror words!");
            }
        }

        /// <summary>
        /// 03. Need for Speed III
        /// </summary>
        public static void NeedforSpeedIII()
        {
            var n = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split("|").ToList();
                var name = input[0];
                var mileage = int.Parse(input[1]);
                var fuel = int.Parse(input[2]);

                if (!cars.Any(l => l.Name == name))
                {
                    cars.Add(new Car
                    {
                        Name = name,
                        Fuel = fuel,
                        Mileage = mileage
                    });
                }
            }

            while (true)
            {
                var commands = Console.ReadLine().Split(" : ").Select(x => x.Trim()).ToList();
                var command = commands[0];

                if (command == "Stop")
                {
                    break;
                }

                var carName = commands[1];
                var car = cars.FirstOrDefault(x => x.Name == carName);

                if (command == "Drive")
                {
                    var distance = int.Parse(commands[2]);
                    var fuel = int.Parse(commands[3]);

                    if (car.Fuel >= fuel)
                    {
                        car.Fuel -= fuel;
                        car.Mileage += distance;
                        Console.WriteLine($"{car.Name} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                    }
                    else
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }

                    if (car.Mileage > 100_000)
                    {
                        Console.WriteLine($"Time to sell the {car.Name}!");
                        cars.Remove(car);
                    }
                }
                else if (command == "Refuel")
                {
                    var fuel = int.Parse(commands[2]);

                    if (car.Fuel + fuel > 75)
                    {
                        fuel -= (car.Fuel + fuel) - 75;
                    }

                    car.Fuel += fuel;
                    Console.WriteLine($"{car.Name} refueled with {fuel} liters");
                }
                else if (command == "Revert")
                {
                    var distance = int.Parse(commands[2]);

                    car.Mileage -= distance;

                    if (car.Mileage > 10_000)
                    {
                        Console.WriteLine($"{car.Name} mileage decreased by {distance} kilometers");
                    }
                    else
                    {
                        car.Mileage = 10_000;
                    }
                }
            }

            foreach (var car in cars.OrderByDescending(c => c.Mileage).ThenBy(c => c.Name))
            {
                Console.WriteLine($"{car.Name} -> Mileage: {car.Mileage} kms, Fuel in the tank: {car.Fuel} lt.");
            }
        }
    }

    class Car
    {
        public string Name { get; set; }

        public int Mileage { get; set; }

        public int Fuel { get; set; }
    }
}
