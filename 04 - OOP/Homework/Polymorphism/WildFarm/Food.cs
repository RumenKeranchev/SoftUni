using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Food
    {
        private int quantity;

        protected Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get => quantity; private set => quantity = value; }
    }

    public class Vegetable : Food
    {
        public Vegetable(int quantity) : base(quantity)
        {
        }
    }

    public class Fruit : Food
    {
        public Fruit(int quantity) : base(quantity)
        {
        }
    }

    public class Meat : Food
    {
        public Meat(int quantity) : base(quantity)
        {
        }
    }

    public class Seeds : Food
    {
        public Seeds(int quantity) : base(quantity)
        {
        }
    }
}
