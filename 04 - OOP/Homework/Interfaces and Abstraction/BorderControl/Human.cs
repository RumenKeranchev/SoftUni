using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public abstract class Human : Entity, IAgeable, IBuyer
    {
        private int age;
        private int food;
        private int foodAmount;

        protected Human(string name, int age, int foodAmount) : base(name)
        {
            Age = age;
            this.foodAmount = foodAmount;
        }

        public int Age { get => age; set => age = value; }
        public int Food { get => food; set => food = value; }

        public void BuyFood()
        {
            food += foodAmount;
        }
    }
}
