using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_C_Sharp_Funamentals.Exercises
{
    /// <summary>
    /// https://judge.softuni.org/Contests/Compete/Index/1204#0
    /// </summary>
    public static class BasicSyntaxConditionalStatementsAndLoops
    {
        /// <summary>
        /// 01
        /// </summary>
        public static void Ages()
        {
            int age = int.Parse(Console.ReadLine());

            if (age >= 0 && age <= 2)
            {
                Console.WriteLine("baby");
            }
            else if (age >= 3 && age <= 13)
            {
                Console.WriteLine("child");
            }
            else if (age >= 14 && age <= 19)
            {
                Console.WriteLine("teenager");
            }
            else if (age >= 20 && age <= 65)
            {
                Console.WriteLine("adult");
            }
            else if (age >= 66)
            {
                Console.WriteLine("elder");
            }
        }

        /// <summary>
        /// 02
        /// </summary>
        public static void Divison()
        {
            int number = int.Parse(Console.ReadLine());
            var highestDivisor = 0;

            if (number % 2 == 0)
            {
                highestDivisor = 2;
            }
            if (number % 3 == 0)
            {
                highestDivisor = 3;
            }
            if (number % 6 == 0)
            {
                highestDivisor = 6;
            }
            if (number % 7 == 0)
            {
                highestDivisor = 7;
            }
            if (number % 10 == 0)
            {
                highestDivisor = 10;
            }

            Console.WriteLine(highestDivisor > 0 ? $"The number is divisible by {highestDivisor}" : "Not divisible");
        }

        /// <summary>
        /// 03
        /// </summary>
        public static void Vacation()
        {
            var peopleCount = int.Parse(Console.ReadLine());
            var type = Console.ReadLine();
            var day = Console.ReadLine();
            var sum = 0m;

            if (type == "Students")
            {
                if (day == "Friday")
                {
                    sum = peopleCount * 8.45m;
                }
                else if (day == "Saturday")
                {
                    sum = peopleCount * 9.8m;
                }
                else
                {
                    sum = peopleCount * 10.46m;
                }

                if (peopleCount >= 30)
                {
                    sum *= 0.85m;
                }
            }
            else if (type == "Business")
            {
                if (peopleCount >= 100)
                {
                    peopleCount -= 10;
                }

                if (day == "Friday")
                {
                    sum = peopleCount * 10.9m;
                }
                else if (day == "Saturday")
                {
                    sum = peopleCount * 15.6m;
                }
                else
                {
                    sum = peopleCount * 16m;
                }
            }
            else
            {
                if (day == "Friday")
                {
                    sum = peopleCount * 15m;
                }
                else if (day == "Saturday")
                {
                    sum = peopleCount * 20m;
                }
                else
                {
                    sum = peopleCount * 22.5m;
                }

                if (peopleCount >= 10 && peopleCount <= 20)
                {
                    sum *= 0.95m;
                }
            }

            Console.WriteLine($"Total price: {sum:F2}");
        }

        /// <summary>
        /// 04
        /// </summary>
        public static void PrintAndSum()
        {
            var start = int.Parse(Console.ReadLine());
            var end = int.Parse(Console.ReadLine());
            var sum = 0;

            for (int i = start; i <= end; i++)
            {
                if (i == end)
                {
                    Console.WriteLine(i);
                }
                else
                {
                    Console.Write(i + " ");
                }

                sum += i;
            }

            Console.WriteLine($"Sum: {sum}");
        }

        /// <summary>
        /// 05
        /// </summary>
        public static void Login()
        {
            var username = Console.ReadLine();
            var usernameArray = username.ToCharArray();
            Array.Reverse(usernameArray);
            var password = Console.ReadLine();
            var userPass = string.Join("", usernameArray);
            var count = 1;

            while (password != userPass)
            {
                count++;

                if (count > 4)
                {
                    break;
                }

                Console.WriteLine("Incorrect password. Try again.");
                password = Console.ReadLine();
            }

            if (count > 4)
            {
                Console.WriteLine($"User {username} blocked!");
            }
            else
            {
                Console.WriteLine($"User {username} logged in.");
            }
        }

        /// <summary>
        /// 06
        /// </summary>
        public static void StrongNumber()
        {
            var number = Console.ReadLine().ToCharArray().Select(x => int.Parse(x.ToString())).ToArray();

            var sum = 0;

            foreach (var chara in number)
            {
                var fact = 1;
                if (chara > 0)
                {
                    for (int i = 1; i <= chara; i++)
                    {
                        fact *= i;
                    }
                }
                sum += fact;
            }

            var originalNumber = int.Parse(string.Join("", number));

            Console.WriteLine(originalNumber == sum ? "yes" : "no");
        }

        /// <summary>
        /// 07
        /// </summary>
        public static void VendingMachine()
        {
            var coins = new List<decimal> { 0.1m, 0.2m, 0.5m, 1m, 2m };
            var products = new List<string> { "Nuts", "Water", "Crisps", "Soda", "Coke" };

            var coin = Console.ReadLine();
            var sum = 0m;

            while (coin != "Start")
            {
                var coinValue = decimal.Parse(coin);

                if (!coins.Contains(coinValue))
                {
                    Console.WriteLine($"Cannot accept {coinValue}");
                }
                else
                {
                    sum += coinValue;
                }

                coin = Console.ReadLine();
            }

            var product = Console.ReadLine();

            while (product != "End")
            {
                if (product == "Nuts")
                {
                    if (sum >= 2m)
                    {
                        sum -= 2m;
                        Console.WriteLine("Purchased nuts");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money.");
                    }
                }
                else if (product == "Water")
                {
                    if (sum >= 0.7m)
                    {
                        sum -= 0.7m;
                        Console.WriteLine("Purchased water");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money.");
                    }
                }
                else if (product == "Crisps")
                {
                    if (sum >= 1.5m)
                    {
                        sum -= 1.5m;
                        Console.WriteLine("Purchased crisps");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money.");
                    }
                }
                else if (product == "Soda")
                {
                    if (sum >= 0.8m)
                    {
                        sum -= 0.8m;
                        Console.WriteLine("Purchased soda");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money.");
                    }
                }
                else if (product == "Coke")
                {
                    if (sum >= 1m)
                    {
                        sum -= 1m;
                        Console.WriteLine("Purchased coke");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }

                product = Console.ReadLine();
            }

            Console.WriteLine($"Change: {sum:F2}");
        }

        /// <summary>
        /// 08
        /// </summary>
        public static void TriangleOfNumbers()
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (j == i)
                    {
                        Console.WriteLine(i);
                    }
                    else
                    {
                        Console.Write(i + " ");
                    }
                }
            }
        }

        /// <summary>
        /// 09
        /// </summary>
        public static void PadawanEquipment()
        {
            var money = decimal.Parse(Console.ReadLine());
            var studentCount = int.Parse(Console.ReadLine());
            var freeBelts = studentCount / 6;
            var lsbPrice = decimal.Parse(Console.ReadLine()) * (int)Math.Ceiling(studentCount * 1.1m);
            var robesPrice = decimal.Parse(Console.ReadLine()) * studentCount;
            var beltsPrice = decimal.Parse(Console.ReadLine()) * (studentCount - freeBelts);

            var sum = lsbPrice + robesPrice + beltsPrice;

            if (sum <= money)
            {
                Console.WriteLine($"The money is enough - it would cost {sum:F2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {sum - money}lv more.");
            }
        }

        /// <summary>
        /// 10
        /// </summary>
        public static void RageExpenses()
        {
            var games = int.Parse(Console.ReadLine());
            var headsetPrice = decimal.Parse(Console.ReadLine());
            var headsetCount = 0;
            var mousePrice = decimal.Parse(Console.ReadLine());
            var mouseCount = 0;
            var keyboardPrice = decimal.Parse(Console.ReadLine());
            var keyboardCount = 0;
            var displayPrice = decimal.Parse(Console.ReadLine());
            var displayCount = 0;

            for (int i = 1; i <= games; i++)
            {
                if (i % 2 == 0)
                {
                    headsetCount++;
                }
                if (i % 3 == 0)
                {
                    mouseCount++;
                }
                if (i % 2 == 0 && i % 3 == 0)
                {
                    keyboardCount++;
                    if (keyboardCount % 2 == 0)
                    {
                        displayCount++;
                    }
                }


            }

            var sum = (headsetPrice * headsetCount)
                + (mousePrice * mouseCount)
                + (keyboardPrice * keyboardCount)
                + (displayPrice * displayCount);

            Console.WriteLine($"Rage expenses: {sum:F2} lv.");
        }
    }
}
