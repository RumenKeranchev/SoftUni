using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        public Cake(string name) : base(name, 5, 250d, 1000d)
        {
        }

        public decimal CakePrice => Price;
    }
}
