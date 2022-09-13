using Gym.Models.Equipment.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    public abstract class Equipment : IEquipment
    {
        private double _weight;
        private decimal _price;

        public Equipment(double weight, decimal price)
        {
            _weight = weight;
            _price = price;
        }

        public double Weight => _weight;

        public decimal Price => _price;
    }
}
