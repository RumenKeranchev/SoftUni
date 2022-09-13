using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            products = new List<Product>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                name = value;
            }
        }
        public decimal Money
        {
            get => money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                money = value;
            }
        }

        public List<Product> Products => products;

        public string AddProduct(Product product)
        {
            if (money < product.Cost)
            {
                return $"{Name} can't afford {product.Name}";
            }

            money -= product.Cost;
            products.Add(product);

            return $"{Name} bought {product.Name}";
        }

        public override string ToString()
        {
            if (products.Any())
            {
                return $"{Name} - {string.Join(", ", products.Select(p => p.Name))}";
            }
            else
            {
                return $"{Name} - Nothing bought";
            }
        }
    }
}
