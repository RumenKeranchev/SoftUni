using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double consumptionPerKm, double tankCapacity) : base(fuelQuantity, consumptionPerKm, tankCapacity)
        {
        }

        public override string Drive(double km)
        {
            ConsumptionPerKm += 1.4;
            var result = base.Drive(km);
            ConsumptionPerKm -= 1.4;
            return result;
        }

        public string DriveEmpty(double km)
        {
            return base.Drive(km);
        }
    }
}
