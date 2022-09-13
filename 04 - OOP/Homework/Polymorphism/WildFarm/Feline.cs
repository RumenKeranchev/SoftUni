using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Feline : Mammal
    {
        private string breed;

        protected Feline(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion)
        {
            Breed = breed;
        }

        public string Breed { get => breed; private set => breed = value; }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, { Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }

    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }

        public override void EatFood(Food food)
        {
            if (food.GetType().Name != nameof(Vegetable) && food.GetType().Name != nameof(Meat))
            {
                throw new InvalidOperationException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }

            Weight += food.Quantity * WeightGain.Cat;
            FoodEaten += food.Quantity;
        }
    }

    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }

        public override void EatFood(Food food)
        {
            if (food.GetType().Name != nameof(Meat))
            {
                throw new InvalidOperationException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }

            Weight += food.Quantity * WeightGain.Tiger;
            FoodEaten += food.Quantity;
        }
    }
}
