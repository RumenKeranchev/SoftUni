using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var car = new Car("Skoda", "Fabia", 65, "CC1856BG");
            var car2 = new Car("Audi", "A3", 110, "EB8787MN");

            Console.WriteLine(car.ToString());
            //Make: Skoda
            //Model: Fabia
            //HorsePower: 65
            //RegistrationNumber: CC1856BG

            var parking = new Parking(5);
            Console.WriteLine(parking.AddCar(car));
            //Successfully added new car Skoda CC1856BG

            Console.WriteLine(parking.AddCar(car));
            //Car with that registration number, already exists!

            Console.WriteLine(parking.AddCar(car2));
            //Successfully added new car Audi EB8787MN

            Console.WriteLine(parking.GetCar("EB8787MN").ToString());
            //Make: Audi
            //Model: A3
            //HorsePower: 110
            //RegistrationNumber: EB8787MN

            Console.WriteLine(parking.RemoveCar("EB8787MN"));
            //Successfullyremoved EB8787MN

            Console.WriteLine(parking.Count); //1
        }

        public class Car
        {
            public Car(string make, string model, int horsePower, string registrationNumber)
            {
                Make = make;
                Model = model;
                HorsePower = horsePower;
                RegistrationNumber = registrationNumber;
            }

            public string Make { get; set; }
            public string Model { get; set; }
            public int HorsePower { get; set; }
            public string RegistrationNumber { get; set; }

            public override string ToString()
            {
                var sb = new StringBuilder();
                sb.AppendLine($"Make: {Make}");
                sb.AppendLine($"Model: {Model}");
                sb.AppendLine($"HorsePower: {HorsePower}");
                sb.AppendLine($"RegistrationNumber: {RegistrationNumber}");
                return sb.ToString().Trim();
            }

        }

        public class Parking
        {
            private List<Car> cars;
            private int capacity;

            public Parking(int capacity)
            {
                cars = new List<Car>();
                this.capacity = capacity;
            }

            public int Count => cars.Count;

            public string AddCar(Car car)
            {
                if (cars.Any(c => c.RegistrationNumber.ToLowerInvariant() == car.RegistrationNumber.ToLowerInvariant()))
                {
                    return "Car with that registration number, already exists!";
                }

                if (cars.Count + 1 > capacity)
                {
                    return "Parking is full!";
                }

                cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }

            public string RemoveCar(string registrationNumber)
            {
                var car = cars.FirstOrDefault(c => c.RegistrationNumber.ToLowerInvariant() == registrationNumber.ToLowerInvariant());
                if (car == null)
                {
                    return "Car with that registration number, doesn't exist!";
                }

                cars.Remove(car);
                return $"Successfully removed {registrationNumber}";
            }

            public Car GetCar(string registrationNumber)
            {
                return cars.FirstOrDefault(c => c.RegistrationNumber.ToLowerInvariant() == registrationNumber.ToLowerInvariant());
            }

            public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
            {
                cars.RemoveAll(c => registrationNumbers.Any(r => r.ToLowerInvariant() == c.RegistrationNumber.ToLowerInvariant()));
            }
        }
    }
}
