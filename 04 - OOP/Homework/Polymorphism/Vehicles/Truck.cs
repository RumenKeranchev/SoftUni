using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double consumptionPerKm, double tankCapacity) 
            : base(fuelQuantity, consumptionPerKm + 1.6, tankCapacity)
        {
        }

        public override void Refuel(double fuelAmount)
        {
            if (fuelAmount <= 0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }

            fuelAmount *= 0.95;

            if (fuelAmount > TankCapacity - FuelQuantity)
            {
                throw new InvalidOperationException($"Cannot fit {fuelAmount} fuel in the tank");
            }

            FuelQuantity += fuelAmount;
        }
    }
}
