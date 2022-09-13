using System;
using System.Linq;

namespace PizzaCalories
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            try
            {
                Pizza pizza = null;

                while (true)
                {
                    var input = Console.ReadLine();

                    if (input == "END")
                    {
                        break;
                    }

                    var parameters = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

                    if (parameters.FirstOrDefault().ToLowerInvariant() == "dough")
                    {
                        var doughtInputs = parameters.Skip(1).ToList();
                        var dough = new Dough(doughtInputs[0], doughtInputs[1], double.Parse(doughtInputs[2]));

                        if (pizza != null)
                        {
                            pizza.Dough = dough;
                        }
                    }
                    else if (parameters.FirstOrDefault().ToLowerInvariant() == "topping")
                    {
                        var toppingInputs = parameters.Skip(1).ToList();
                        var topping = new Topping(toppingInputs[0], double.Parse(toppingInputs[1]));

                        if (pizza != null)
                        {
                            pizza.AddTopping(topping);
                        }
                    }
                    else
                    {
                        pizza = new Pizza(parameters.Skip(1).FirstOrDefault());
                    }
                }

                Console.ForegroundColor = ConsoleColor.Red;
                if (pizza != null)
                {
                    Console.WriteLine(pizza);
                }
                Console.ResetColor();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
        }
    }
}
