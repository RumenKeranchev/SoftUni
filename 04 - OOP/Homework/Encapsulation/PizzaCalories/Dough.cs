using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private double grams;
        private double flourType;
        private double bakingTechnique;

        public Dough(string flourType, string bakingTechnique, double grams)
        {
            this.flourType = SetFlourType(flourType);
            this.bakingTechnique = SetBakingTechnique(bakingTechnique);
            Grams = grams;
        }

        private double SetFlourType(string flourType)
        {
            if (flourType.ToLowerInvariant() == nameof(FlourType.White).ToLowerInvariant())
            {
                return FlourType.White;
            }
            else if (flourType.ToLowerInvariant() == nameof(FlourType.Wholegrain).ToLowerInvariant())
            {
                return FlourType.Wholegrain;
            }
            else
            {
                throw new ArgumentException("Invalid type of dough.");
            }
        }

        private double SetBakingTechnique(string bakingTechnique)
        {
            if (bakingTechnique.ToLowerInvariant() == nameof(BakingTechnique.Crispy).ToLowerInvariant())
            {
                return BakingTechnique.Crispy;
            }
            else if (bakingTechnique.ToLowerInvariant() == nameof(BakingTechnique.Chewy).ToLowerInvariant())
            {
                return BakingTechnique.Chewy;
            }
            else if (bakingTechnique.ToLowerInvariant() == nameof(BakingTechnique.Homemade).ToLowerInvariant())
            {
                return BakingTechnique.Homemade;
            }
            else
            {
                throw new ArgumentException("Invalid type of dough.");
            }
        }

        private double Grams
        {
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException($"{GetType().Name} weight should be in the range [{1}..{200}].");
                }

                grams = value;
            }
        }

        public double TotalCalories => (2 * grams) * flourType * bakingTechnique;
    }

    public struct FlourType
    {
        public const double White = 1.5;
        public const double Wholegrain = 1;
    }

    public struct BakingTechnique
    {
        public const double Crispy = 0.9;
        public const double Chewy = 1.1;
        public const double Homemade = 1;
    }
}
