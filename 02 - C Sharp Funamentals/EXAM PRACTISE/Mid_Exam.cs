using System;
using System.Linq;

namespace _02_C_Sharp_Funamentals.EXAM_PRACTISE
{
    public static class Mid_Exam
    {
        /// <summary>
        /// 01. Cooking Masterclass
        /// </summary>
        public static void CookingMasterclass()
        {
            var budget = decimal.Parse(Console.ReadLine());
            var students = int.Parse(Console.ReadLine());
            var flourPrice = decimal.Parse(Console.ReadLine());
            var eggPrice = decimal.Parse(Console.ReadLine());
            var apronPrice = decimal.Parse(Console.ReadLine());

            var freeFlour = students / 5;
            var allStudentsTotal = apronPrice * Math.Ceiling(students * 1.2m) + eggPrice * 10 * students + flourPrice * (students - freeFlour);

            if (allStudentsTotal <= budget)
            {
                Console.WriteLine($"Items purchased for {allStudentsTotal:f2}$.");
            }
            else
            {
                Console.WriteLine($"{allStudentsTotal - budget:f2}$ more needed.");
            }
        }

        /// <summary>
        /// 02. Numbers
        /// </summary>
        public static void Numbers()
        {
            var list = Console.ReadLine().Split().Select(int.Parse).ToList();

            var input = Console.ReadLine();

            while (input != "Finish")
            {
                var commands = input.Split().ToList();
                var value = int.Parse(commands[1]);

                if (commands[0] == "Add")
                {
                    list.Add(value);
                }
                else if (commands[0] == "Remove")
                {
                    list.Remove(value);
                }
                else if (commands[0] == "Replace")
                {
                    var replacement = int.Parse(commands[2]);

                    var index = list.IndexOf(value);

                    if (index >= 0)
                    {
                        list[index] = replacement;
                    }
                }
                else if (commands[0] == "Collapse")
                {
                    list.RemoveAll(l => l < value);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", list));
        }

        /// <summary>
        /// 03. Phone Shop
        /// </summary>
        public static void PhoneShop()
        {
            var list = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var input = Console.ReadLine();

            while (input != "End")
            {
                var commands = input.Split(new[] { " - " }, StringSplitOptions.RemoveEmptyEntries).ToList();
                var phone = commands[1];

                if (commands[0] == "Add")
                {
                    if (!list.Contains(phone))
                    {
                        list.Add(phone);
                    }
                }
                else if (commands[0] == "Remove")
                {
                    list.Remove(phone);
                }
                else if (commands[0] == "Bonus phone")
                {
                    var phones = phone.Split(":").ToList();
                    var index = list.IndexOf(phones[0]);
                    if (index >= 0)
                    {
                        list.Insert(index + 1, phones[1]);
                    }

                }
                else if (commands[0] == "Last")
                {
                    var index = list.IndexOf(phone);
                    if (index >= 0)
                    {
                        list.RemoveAt(index);
                        list.Add(phone);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", list));
        }
    }
}
