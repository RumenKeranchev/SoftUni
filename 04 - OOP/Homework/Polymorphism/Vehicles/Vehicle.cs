using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double consumptionPerKm;
        private double tankCapacity;

        protected Vehicle(double fuelQuantity, double consumptionPerKm, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            ConsumptionPerKm = consumptionPerKm;
        }

        public double FuelQuantity
        {
            get => fuelQuantity;
            protected set
            {
                if (value > TankCapacity)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }
        public double ConsumptionPerKm { get => consumptionPerKm; set => consumptionPerKm = value; }
        public double TankCapacity { get => tankCapacity; set => tankCapacity = value; }

        public virtual string Drive(double km)
        {
            var consumedFuel = km * consumptionPerKm;

            if (consumedFuel <= FuelQuantity)
            {
                FuelQuantity -= consumedFuel;
                return $"{GetType().Name} travelled {km} km";
            }
            else
            {
                return $"{GetType().Name} needs refueling";
            }
        }

        public virtual void Refuel(double fuelAmount)
        {
            if (fuelAmount <= 0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }

            if (fuelAmount + FuelQuantity > TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {fuelAmount} fuel in the tank");
            }

            fuelQuantity += fuelAmount;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {Math.Round(fuelQuantity, 2):f2}";
        }
    }
}
