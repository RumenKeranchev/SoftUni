using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    public class BoxingGloves : Equipment
    {
        private const double defaultWeight = 227;
        private const decimal defaultPrice = 120;

        public BoxingGloves() : base(defaultWeight, defaultPrice)
        {
        }
    }
}
