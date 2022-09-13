using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    public class Kettlebell : Equipment
    {
        private const double defaultWeight = 10000;
        private const decimal defaultPrice = 80;

        public Kettlebell() : base(defaultWeight, defaultPrice)
        {
        }
    }
}
