﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        public Coffee(string name, double caffeine) : base(name, 3.5m, 50)
        {
            Caffeine = caffeine;
        }

        public double CoffeeMilliliters => Milliliters;
        public decimal CoffeePrice => Price;

        public double Caffeine { get; set; }
    }
}
