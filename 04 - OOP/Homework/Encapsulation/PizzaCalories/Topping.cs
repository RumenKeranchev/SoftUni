using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private double toppingTypeValue;
        private string toppingType;
        private double grams;

        public Topping(string toppingType, double grams)
        {
            this.toppingType = toppingType;
            toppingTypeValue = SetToppingType(toppingType);
            Grams = grams;
        }

        public double TotalCalories => 2 * grams * toppingTypeValue;

        private double Grams
        {
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{toppingType} weight should be in the range [{1}..{50}].");
                }

                grams = value;
            }
        }

        private double SetToppingType(string toppingType)
        {
            if (toppingType.ToLowerInvariant() == nameof(ToppingTypes.Meat).ToLowerInvariant())
            {
                return ToppingTypes.Meat;
            }
            else if (toppingType.ToLowerInvariant() == nameof(ToppingTypes.Veggies).ToLowerInvariant())
            {
                return ToppingTypes.Veggies;
            }
            else if (toppingType.ToLowerInvariant() == nameof(ToppingTypes.Cheese).ToLowerInvariant())
            {
                return ToppingTypes.Cheese;
            }
            else if (toppingType.ToLowerInvariant() == nameof(ToppingTypes.Sauce).ToLowerInvariant())
            {
                return ToppingTypes.Sauce;
            }
            else
            {
                throw new ArgumentException($"Cannot place {toppingType} on top of your pizza.");
            }
        }
    }

    public struct ToppingTypes
    {
        public const double Meat = 1.2;
        public const double Veggies = 0.8;
        public const double Cheese = 1.1;
        public const double Sauce = 0.9;
    }
}
