using System;
using System.Linq;

namespace ShoppingSpree
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            try
            {
                var people = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => new Person(s.Split("=").FirstOrDefault(), decimal.Parse(s.Split("=").Skip(1).FirstOrDefault())))
                    .ToList();
                
                var products = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => new Product(s.Split("=").FirstOrDefault(), decimal.Parse(s.Split("=").Skip(1).FirstOrDefault())))
                    .ToList();

                while (true)
                {
                    var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

                    if (input[0] == "END")
                    {
                        break;
                    }

                    var person = people.FirstOrDefault(p => p.Name == input[0]);
                    var product = products.FirstOrDefault(p => p.Name == input[1]);

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(person.AddProduct(product));
                    Console.ResetColor();
                }

                Console.ForegroundColor = ConsoleColor.Red;
                foreach (var person in people)
                {
                    Console.WriteLine(person);
                }
                Console.ResetColor();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}