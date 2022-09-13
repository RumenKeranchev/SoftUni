using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Animal
    {
        private string name;
        private double weight;
        private int foodEaten;

        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get => name; private set => name = value; }
        public double Weight { get => weight; set => weight = value; }
        public int FoodEaten { get => foodEaten; set => foodEaten = value; }

        public abstract string ProduceSound();

        public abstract void EatFood(Food food);
    }
}
