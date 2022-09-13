using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_C_Sharp_Advanced.Exercises
{

    /// <summary>
    /// https://judge.softuni.org/Contests/Compete/Index/1473#0
    /// </summary>
    public static class FunctionalProgramming
    {
        /// <summary>
        /// 01. Action Print
        /// </summary>
        public static void ActionPrint()
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            Action<List<string>> action = (strings) => strings.ForEach(s => Console.WriteLine(s));

            action(input);
        }

        /// <summary>
        /// 02. Knights of Honor
        /// </summary>
        public static void KnightsOfHonor()
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            Action<List<string>> action = (strings) => strings.ForEach(s => Console.WriteLine("Sir " + s));

            action(input);
        }

        /// <summary>
        /// 03. Custom Min Function
        /// </summary>
        public static void CustomMinFunction()
        {
            Func<List<int>, int> func = Min;
            var list = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            Console.WriteLine(func(list));

            static int Min(List<int> list)
            {
                var res = int.MaxValue;

                foreach (var x in list)
                {
                    if (x < res)
                    {
                        res = x;
                    }
                }

                return res;
            }
        }

        /// <summary>
        /// 04. Find Evens or Odds
        /// </summary>
        public static void FindEvensOrOdds()
        {
            var list = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var input = Console.ReadLine();

            Predicate<string> isEvenCommand = (s) => s.Equals("even");
            Predicate<int> isEvenNumber = (n) => n % 2 == 0;
            Func<bool, bool, bool> shouldAdd = (n, c) => n == c;

            var result = new List<int>();

            for (int i = list[0]; i <= list[1]; i++)
            {
                if (shouldAdd(isEvenNumber(i), isEvenCommand(input)))
                {
                    result.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }

        /// <summary>
        /// 05. Applied Arithmetics
        /// </summary>
        public static void AppliedArithmetics()
        {
            var list = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var input = Console.ReadLine();
            while (input != "end")
            {
                var function = GetFunc(input);
                list = function(list);

                input = Console.ReadLine();
            }

            List<int> Multiply(List<int> numbers)
            {
                return numbers.Select(n => n * 2).ToList();
            }

            List<int> Add(List<int> numbers)
            {
                return numbers.Select(n => n + 1).ToList();
            }

            List<int> Subtract(List<int> numbers)
            {
                return numbers.Select(n => n - 1).ToList();
            }

            List<int> Print(List<int> numbers)
            {
                Console.WriteLine(string.Join(" ", numbers));
                return numbers;
            }

            Func<List<int>, List<int>> GetFunc(string operation)
            {
                switch (operation)
                {
                    case "add":
                        return Add;
                    case "subtract":
                        return Subtract;
                    case "multiply":
                        return Multiply;
                    default:
                        return Print;
                }
            }
        }

        /// <summary>
        /// 06. Reverse And Exclude
        /// </summary>
        public static void ReverseAndExclude()
        {
            var list = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var input = int.Parse(Console.ReadLine());

            Func<int, int, bool> shouldRemove = (x, d) => x % d == 0;
            list.RemoveAll(x => shouldRemove(x, input));
            list.Reverse();

            Console.WriteLine(string.Join(" ", list));
        }

        /// <summary>
        /// 07. Predicate For Names
        /// </summary>
        public static void PredicateForNames()
        {
            var lenght = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            Predicate<string> filterNameLenght = (name) => name.Length > lenght;

            names.RemoveAll(n => filterNameLenght(n));

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }

        /// <summary>
        /// 08. List Of Predicates
        /// </summary>
        public static void ListOfPredicates()
        {
            var n = int.Parse(Console.ReadLine());
            var divisors = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var result = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                var flags = new List<bool>();
                Predicate<int> isDivisible = (n) => i % n == 0;
                Predicate<List<bool>> allDivisible = (list) => list.Count == divisors.Count;

                foreach (var divisor in divisors)
                {
                    if (isDivisible(divisor))
                    {
                        flags.Add(true);
                    }
                }

                if (allDivisible(flags))
                {
                    result.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }

        /// <summary>
        /// 09. Predicate Party!
        /// </summary>
        public static void PredicateParty()
        {
            var names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            var input = Console.ReadLine();

            while (input != "Party!")
            {
                var commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                var command = commands[0];
                var critiria = commands[1];
                var value = commands[2];

                Predicate<string> startsWith = (name) => name.StartsWith(value);
                Predicate<string> endsWith = (name) => name.EndsWith(value);
                Predicate<string> checkLen = (name) => name.Length == int.Parse(value);

                Predicate<string> GetPredicate(string criteria)
                {
                    return criteria switch
                    {
                        "StartsWith" => startsWith,
                        "EndsWith" => endsWith,
                        "Length" => checkLen,
                        _ => null
                    };
                }

                var pred = GetPredicate(critiria);

                if (command == "Double")
                {
                    var namesToDouble = names.Where(n => pred(n)).ToList();

                    foreach (var item in namesToDouble)
                    {
                        var index = names.IndexOf(item);
                        names.Insert(index + 1, item);
                    }
                }
                else if (command == "Remove")
                {
                    names.RemoveAll(n => pred(n));
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(names.Any() ? $"{string.Join(", ", names)} are going to the party!" : "Nobody is going to the party!");
        }

        /// <summary>
        /// 10. The Party Reservation Filter Module
        /// </summary>
        public static void ThePartyReservationFilterModule()
        {
            var people = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(p => new Person { Name = p }).ToList();

            var input = Console.ReadLine();

            while (input != "Print")
            {
                var commands = input.Split(";", StringSplitOptions.RemoveEmptyEntries).ToList();
                var command = commands[0];
                var critiria = commands[1];
                var value = commands[2];

                Func<Person, bool, bool> startsWith = (person, flag) => person.Name.StartsWith(value) && person.Visible == flag;
                Func<Person, bool, bool> endsWith = (person, flag) => person.Name.EndsWith(value) && person.Visible == flag;
                Func<Person, bool, bool> checkLen = (person, flag) => person.Name.Length == int.Parse(value) && person.Visible == flag;
                Func<Person, bool, bool> contains = (person, flag) => person.Name.Contains(value) && person.Visible == flag;

                Func<Person, bool, bool> GetPredicate(string criteria)
                {
                    return criteria switch
                    {
                        "Starts with" => startsWith,
                        "Ends with" => endsWith,
                        "Length" => checkLen,
                        "Contains" => contains,
                        _ => null
                    };
                }

                var pred = GetPredicate(critiria);

                if (command == "Add filter")
                {
                    var persons = people.Where(n => pred(n, true)).ToList();
                    if (persons.Any())
                    {
                        persons.ForEach(p => p.Visible = false);
                    }

                }
                else if (command == "Remove filter")
                {
                    var persons = people.Where(n => pred(n, false)).ToList();
                    if (persons.Any())
                    {
                        persons.ForEach(p => p.Visible = true);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", people.Where(p => p.Visible).Select(p => p.Name)));
        }

        /// <summary>
        /// 10. The Party Reservation Filter Module
        /// </summary>
        class Person
        {
            public string Name { get; set; }

            public bool Visible { get; set; } = true;
        }

        /// <summary>
        /// 11. TriFunction
        /// </summary>
        public static void TriFunction()
        {
            var length = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            Func<string, int, bool> checkSum = (name, length) => name.ToCharArray().Sum(c => c) >= length;
            Func<List<string>, Func<string, int, bool>, string> getName = (names, func) => names.FirstOrDefault(n => func(n, length));

            Console.WriteLine(getName(names, checkSum));
        }
    }
}
