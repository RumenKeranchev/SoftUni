using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses3
{
    public static class _08
    {
        public static void Execute()
        {
            var nEngines = int.Parse(Console.ReadLine());
            var engines = new List<Engine>();

            for (int i = 0; i < nEngines; i++)
            {
                var input = Console.ReadLine().Split();
                var model = input[0];
                var power = int.Parse(input[1]);
                var dispNotNull = int.TryParse(input.Skip(2).FirstOrDefault(), out var disp);
                var eff = input.Skip(dispNotNull ? 3 : 2).FirstOrDefault();

                engines.Add(new Engine(model, power, dispNotNull ? disp : default(int?), eff));
            }

            var nCars = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < nCars; i++)
            {
                var input = Console.ReadLine().Split();
                var model = input[0];
                var engineModel = input[1];
                var weightNotNull = int.TryParse(input.Skip(2).FirstOrDefault(), out var weight);
                var color = input.Skip(weightNotNull ? 3 : 2).FirstOrDefault();

                var engine = engines.First(e => e.Model == engineModel);

                cars.Add(new Car(model, engine, weightNotNull ? weight : default(int?), color));
            }

            foreach (var car in cars)
            {
                Console.Write(car);
            }
        }
    }

    public class Car
    {
        public Car(string model, Engine engine, int? weight, string color)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
        }

        public string Model { get; private set; }
        public Engine Engine { get; private set; }
        public int? Weight { get; private set; }
        public string Color { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Model}:");
            sb.AppendLine($"  {Engine.Model}:");
            sb.AppendLine($"    Power: {Engine.Power}");
            sb.AppendLine($"    Displacement: {(Engine.Displacement.HasValue ? Engine.Displacement.Value.ToString() : "n/a")}");
            sb.AppendLine($"    Efficiency: {(!string.IsNullOrEmpty(Engine.Efficiency) ? Engine.Efficiency : "n/a")}");
            sb.AppendLine($"  Weight: {(Weight.HasValue ? Weight.Value.ToString() : "n/a")}");
            sb.AppendLine($"  Color: {(!string.IsNullOrEmpty(Color) ? Color : "n/a")}");

            return sb.ToString();
        }
    }

    public class Engine
    {
        public Engine(string model, int power, int? displacement, string efficiency)
        {
            Model = model;
            Power = power;
            Displacement = displacement;
            Efficiency = efficiency;
        }
        public string Model { get; private set; }
        public int Power { get; private set; }
        public int? Displacement { get; private set; }
        public string Efficiency { get; private set; }
    }
}
