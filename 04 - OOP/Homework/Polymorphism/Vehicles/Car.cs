using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double consumptionPerKm, double tankCapacity) : base(fuelQuantity, consumptionPerKm + 0.9, tankCapacity)
        {
        }
    }
}
