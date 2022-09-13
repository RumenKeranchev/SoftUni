using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses2
{
    public class _07
    {
        private static void Execute()
        {
            var n = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                cars.Add(new Car(Console.ReadLine()));
            }

            var filterFlag = Console.ReadLine();
            foreach (var car in cars.Where(c => c.GetFilterFlag(filterFlag)))
            {
                Console.WriteLine(car.Model);
            }
        }
    }

    public class Car
    {
        public Car(string input)
        {
            var parameters = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            Model = parameters[0];

            var speed = int.Parse(parameters[1]);
            var power = int.Parse(parameters[2]);

            var weight = decimal.Parse(parameters[3]);
            var type = parameters[4];

            var tire1Pressure = decimal.Parse(parameters[5]);
            var tire1ge = int.Parse(parameters[6]);
            var tire2Pressure = decimal.Parse(parameters[7]);
            var tire2ge = int.Parse(parameters[8]);
            var tire3Pressure = decimal.Parse(parameters[9]);
            var tire3ge = int.Parse(parameters[10]);
            var tire4Pressure = decimal.Parse(parameters[11]);
            var tire4ge = int.Parse(parameters[12]);

            Engine = new Engine { Power = power, Speed = speed };
            Cargo = new Cargo { Type = type, Weight = weight };
            Tires = new Tire[]
            {
                new Tire{ Age= tire1ge, Pressure= tire1Pressure },
                new Tire{ Age= tire2ge, Pressure= tire2Pressure },
                new Tire{ Age= tire3ge, Pressure= tire3Pressure },
                new Tire{ Age= tire4ge, Pressure= tire4Pressure },
            };

        }

        public string Model { get; private set; }
        public Engine Engine { get; private set; }
        public Cargo Cargo { get; private set; }
        public Tire[] Tires { get; private set; }

        public bool GetFilterFlag(string flagName)
        {
            if (flagName == "fragile")
            {
                return IsFragile;
            }
            else if (flagName == "flammable")
            {
                return IsFlammable;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public bool IsFragile => Cargo.Type == "fragile" && Tires.Any(t => t.Pressure < 1);
        public bool IsFlammable => Cargo.Type == "flammable" && Engine.Power > 250;
    }

    public class Engine
    {
        public int Speed { get; set; }

        public int Power { get; set; }
    }

    public class Cargo
    {
        public string Type { get; set; }

        public decimal Weight { get; set; }
    }

    public class Tire
    {
        public int Age { get; set; }

        public decimal Pressure { get; set; }
    }
}
