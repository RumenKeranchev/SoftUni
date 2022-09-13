using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_C_Sharp_Funamentals.EXAM_PRACTISE
{
    //https://judge.softuni.org/Contests/Practice/Index/2517#0
    public static class _01_Mid_Exam
    {
        /// <summary>
        /// 01. Computer Store
        /// </summary>
        public static void ComputerStore()
        {
            var input = Console.ReadLine();
            var tax = 0m;
            var sum = 0m;
            var total = 0m;
            var customer = string.Empty;

            while (true)
            {
                if (input == "special" || input == "regular")
                {
                    customer = input;
                    break;
                }

                var price = decimal.Parse(input);

                if (price < 0)
                {
                    Console.WriteLine("Invalid price!");
                    input = Console.ReadLine();
                }
                else
                {
                    sum += price;
                    input = Console.ReadLine();
                }
            }

            total = sum * 1.2m;
            tax = total - sum;

            if (customer == "special")
            {
                total *= 0.9m;
            }

            if (total == 0)
            {
                Console.WriteLine("Invalid order!");
            }
            else
            {
                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {sum:f2}$");
                Console.WriteLine($"Taxes: {tax:f2}$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {total:f2}$");
            }
        }

        /// <summary>
        /// 02. The Lift
        /// </summary>
        public static void TheLift()
        {
            var peopleCount = int.Parse(Console.ReadLine());
            var liftPositions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var occupiedPositions = liftPositions.Sum();
            var availablePositions = liftPositions.Length * 4 - occupiedPositions;
            var queue = peopleCount - availablePositions;

            for (int i = 0; i < liftPositions.Length; i++)
            {
                if (peopleCount > 0)
                {
                    for (int j = 1; j <= 4; j++)
                    {
                        if (liftPositions[i] < 4)
                        {
                            liftPositions[i]++;
                            peopleCount--;

                            if (peopleCount == 0)
                            {
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            if (liftPositions.Any(l => l < 4) && queue <= 0)
            {
                Console.WriteLine("The lift has empty spots!");
            }
            else if (liftPositions.All(l => l == 4) && queue > 0)
            {
                Console.WriteLine($"There isn't enough space! {queue} people in a queue!");
            }
            Console.WriteLine(string.Join(" ", liftPositions));
        }

        /// <summary>
        /// 03. Memory Game
        /// </summary>
        public static void MemoryGame()
        {
            var arr = Console.ReadLine().Split().ToList();

            var input = Console.ReadLine();
            var moves = 1;

            while (input != "end")
            {
                var indexes = input.Trim().Split().Select(int.Parse).ToArray();

                if (indexes.Any(i => i >= arr.Count() || i < 0) || indexes.Skip(1).All(i => i == indexes.FirstOrDefault()))
                {
                    arr.InsertRange((arr.Count()) / 2, new string[] { $"-{moves}a", $"-{moves}a" });
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                }
                else
                {
                    if (arr[indexes[0]] == arr[indexes[1]])
                    {
                        Console.WriteLine($"Congrats! You have found matching elements - {arr[indexes[0]]}!");
                        arr.RemoveAt(indexes[0]);
                        arr.RemoveAt(indexes[1] - 1 < 0 ? 0 : indexes[1] - 1);
                    }
                    else
                    {
                        Console.WriteLine("Try again!");
                    }
                }

                if (arr.Count() == 0)
                {
                    Console.WriteLine($"You have won in {moves} turns!");
                    break;
                }

                moves++;
                input = Console.ReadLine();
            }

            if (arr.Count() > 0)
            {
                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine(string.Join(" ", arr));
            }
        }
    }
}
