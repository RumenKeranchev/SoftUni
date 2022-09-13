using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02_C_Sharp_Funamentals.Exercises
{
    /// <summary>
    /// https://judge.softuni.org/Contests/Compete/Index/1215#0
    /// </summary>
    public static class ObjectsAndClasses
    {
        #region 01

        /// <summary>
        /// 01. Advertisement Message
        /// </summary>
        public static class AdsMessages
        {
            public static void Execute()
            {
                var n = int.Parse(Console.ReadLine());

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine(MessageGenerator.Generate());
                }
            }
        }

        static class MessageGenerator
        {
            public static string Generate()
            {
                return $"{Phrases.GetPhrase()} {Events.GetEvent()} {Authors.GetAuthor()} - {Cities.GetCity()}";
            }
        }

        static class Phrases
        {
            private static readonly Random Random = new Random();
            private static readonly List<string> Messages = new List<string>
        {
            "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product."
        };

            public static string GetPhrase()
            {
                var index = Random.Next(0, Messages.Count - 1);

                return Messages[index];
            }
        }

        static class Events
        {
            private static readonly Random Random = new Random();
            private static readonly List<string> Messages = new List<string>
        {
            "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!"
        };

            public static string GetEvent()
            {
                var index = Random.Next(0, Messages.Count - 1);

                return Messages[index];
            }
        }

        static class Authors
        {
            private static readonly Random Random = new Random();
            private static readonly List<string> Messages = new List<string>
        {
            "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"
        };

            public static string GetAuthor()
            {
                var index = Random.Next(0, Messages.Count - 1);

                return Messages[index];
            }
        }

        static class Cities
        {
            private static readonly Random Random = new Random();
            private static readonly List<string> Messages = new List<string>
        {
            "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"
        };

            public static string GetCity()
            {
                var index = Random.Next(0, Messages.Count - 1);

                return Messages[index];
            }
        }

        #endregion

        #region 02

        /// <summary>
        /// 02. Articles
        /// </summary>
        public static class Articles
        {
            public static void Execute()
            {
                var input = GetInput(", ");
                var article = new Article(input);

                var n = int.Parse(Console.ReadLine());

                for (int i = 0; i < n; i++)
                {
                    var commands = GetInput(": ");

                    if (commands[0] == "Edit")
                    {
                        article.Edit(commands[1]);
                    }
                    else if (commands[0] == "ChangeAuthor")
                    {
                        article.ChangeAuthor(commands[1]);
                    }
                    else if (commands[0] == "Rename")
                    {
                        article.Rename(commands[1]);
                    }
                }

                Console.WriteLine(article);
            }

            private static string[] GetInput(string delimiter)
            {
                return Console.ReadLine().Split(new[] { delimiter }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }
        }

        class Article
        {
            public Article(string[] input)
            {
                Title = input[0];
                Content = input[1];
                Author = input[2];
            }

            public string Title { get; private set; }

            public string Content { get; private set; }

            public string Author { get; private set; }

            public void Edit(string newContent)
            {
                Content = newContent;
            }

            public void ChangeAuthor(string newAuthor)
            {
                Author = newAuthor;
            }

            public void Rename(string newTitle)
            {
                Title = newTitle;
            }

            public override string ToString()
            {
                return $"{Title} - {Content}: {Author}";
            }
        }

        #endregion

        #region 03



        /// <summary>
        /// 03. Articles 2.0
        /// </summary>
        public static class Articles_2_0
        {
            public static void Execute()
            {
                var articles = new List<Article>();

                var n = int.Parse(Console.ReadLine());

                for (int i = 0; i < n; i++)
                {
                    var input = GetInput(", ");

                    articles.Add(new Article(input));
                }

                var orderBy = Console.ReadLine();

                if (orderBy == "title")
                {
                    articles = articles.OrderBy(a => a.Title).ToList();
                }
                else if (orderBy == "content")
                {
                    articles = articles.OrderBy(a => a.Content).ToList();
                }
                else if (orderBy == "author")
                {
                    articles = articles.OrderBy(a => a.Author).ToList();
                }

                foreach (var article in articles)
                {
                    Console.WriteLine(article);
                }
            }

            private static string[] GetInput(string delimiter)
            {
                return Console.ReadLine().Split(new[] { delimiter }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }
        }

        #endregion

        #region 04

        /// <summary>
        /// 04. Students
        /// </summary>
        public static class Students
        {
            public static void Execute()
            {
                var list = new List<Student>();
                var n = int.Parse(Console.ReadLine());

                for (int i = 0; i < n; i++)
                {
                    var input = Console.ReadLine().Split().ToArray();

                    list.Add(new Student(input));
                }

                list = list.OrderByDescending(s => s.Grade).ToList();

                foreach (var student in list)
                {
                    Console.WriteLine(student);
                }
            }
        }

        class Student
        {
            public Student(string[] input)
            {
                FirstName = input[0];
                LastName = input[1];
                Grade = decimal.Parse(input[2]);
            }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public decimal Grade { get; set; }

            public override string ToString()
            {
                return $"{FirstName} {LastName}: {Grade}";
            }
        }

        #endregion

        #region 05

        /// <summary>
        /// 05. Teamwork Projects
        /// </summary>
        public static class Teamwork
        {
            public static void Execute()
            {
                var teams = CreateTeams();

                AddMembers(teams);

                PrintResult(teams);

            }

            private static List<Team> CreateTeams()
            {
                var n = int.Parse(Console.ReadLine());
                var teams = new List<Team>();

                for (int i = 0; i < n; i++)
                {
                    var team = new Team(GetInput(Console.ReadLine(), "-"));

                    if (teams.Any(t => t.Name == team.Name))
                    {
                        Console.WriteLine($"Team {team.Name} was already created!");
                        continue;
                    }
                    if (teams.Any(t => t.Creator.Name == team.Creator.Name))
                    {
                        Console.WriteLine($"{team.Creator.Name} cannot create another team!");
                        continue;
                    }

                    teams.Add(team);
                    Console.WriteLine($"Team {team.Name} has been created by {team.Creator.Name}!");
                }

                return teams;
            }

            private static void AddMembers(List<Team> teams)
            {
                var input = Console.ReadLine();

                while (input != "end of assignment")
                {
                    var data = GetInput(input, "->");
                    var userName = data[0];
                    var teamName = data[1];

                    var team = teams.FirstOrDefault(t => t.Name == teamName);

                    if (team == null)
                    {
                        Console.WriteLine($"Team {teamName} does not exist!");
                    }
                    else if (teams.Any(t => t.Creator.Name == userName || t.Members.Any(m => m.Name == userName)))
                    {
                        Console.WriteLine($"Member {userName} cannot join team {teamName}!");
                    }
                    else
                    {
                        team.Members.Add(new User(userName));
                    }

                    input = Console.ReadLine();
                }
            }

            private static void PrintResult(List<Team> teams)
            {
                foreach (var team in teams.Where(t => t.Members.Count > 0).OrderByDescending(t => t.Members.Count()).ThenBy(t => t.Name))
                {
                    Console.WriteLine(team.Name);
                    Console.WriteLine($"- {team.Creator.Name}");

                    foreach (var member in team.Members.OrderBy(m => m.Name))
                    {
                        Console.WriteLine($"-- {member.Name}");
                    }
                }

                Console.WriteLine("Teams to disband:");
                foreach (var team in teams.Where(t => t.Members.Count == 0).OrderBy(t => t.Name))
                {
                    Console.WriteLine(team.Name);
                }
            }

            private static string[] GetInput(string input, string delimiter)
            {
                return input.Split(new[] { delimiter }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }
        }

        class User
        {
            public User(string name)
            {
                Name = name;
            }

            public string Name { get; set; }
        }

        class Team
        {
            public Team(string[] input)
            {
                Name = input[1];
                Creator = new User(input[0]);
                Members = new List<User>();
            }

            public string Name { get; set; }

            public User Creator { get; set; }

            public List<User> Members { get; set; }
        }

        #endregion

        #region 06


        /// <summary>
        /// 06. Vehicle Catalogue
        /// </summary>
        public static class VehicleCatalogue
        {
            public static void Execute()
            {
                var input = Console.ReadLine();
                var vehicles = new List<Vehicle>();

                while (input != "End")
                {
                    var info = input.Split().ToArray();

                    if (Enum.TryParse(info[0], true, out Type type))
                    {
                        vehicles.Add(new Vehicle(type, info));
                    }

                    input = Console.ReadLine();
                }

                input = Console.ReadLine();

                while (input != "Close the Catalogue")
                {
                    var vehicle = vehicles.FirstOrDefault(v => v.Model == input.Trim());
                    Console.WriteLine(vehicle);

                    input = Console.ReadLine();
                }


                var cars = vehicles.Any(v => v.Type == Type.Car) ? vehicles.Where(v => v.Type == Type.Car).Average(v => v.Horsepower) : 0.0;
                var trucks = vehicles.Any(v => v.Type == Type.Truck) ? vehicles.Where(v => v.Type == Type.Truck).Average(v => v.Horsepower) : 0.0;

                Console.WriteLine($"Cars have average horsepower of: {cars:f2}.");
                Console.WriteLine($"Trucks have average horsepower of: {trucks:f2}.");
            }
        }

        class Vehicle
        {
            public Vehicle(Type type, string[] input)
            {
                Type = type;
                Model = input[1];
                Color = input[2];
                Horsepower = int.Parse(input[3]);
            }

            public Type Type { get; }

            public string Model { get; }

            public string Color { get; }

            public int Horsepower { get; }

            public override string ToString()
            {
                var sb = new StringBuilder();
                sb.AppendLine($"Type: {Type}");
                sb.AppendLine($"Model: {Model}");
                sb.AppendLine($"Color: {Color}");
                sb.Append($"Horsepower: {Horsepower}");

                return sb.ToString();
            }
        }

        enum Type
        {
            Car,
            Truck
        }

        #endregion

        #region 07



        /// <summary>
        /// 07. Order by Age
        /// </summary>
        public static class OrderByAge
        {
            public static void Execute()
            {
                var people = new List<Person>();

                while (true)
                {
                    var input = Console.ReadLine();
                    if (input == "End")
                    {
                        break;
                    }

                    var details = input.Split().ToArray();

                    var person = people.FirstOrDefault(p => p.Id == details[1]);

                    if (person != null)
                    {
                        person.Edit(details[0], int.Parse(details[2]));
                    }
                    else
                    {
                        person = new Person(details);
                        people.Add(person);
                    }
                }

                foreach (var person in people.OrderBy(p => p.Age))
                {
                    Console.WriteLine(person);
                }
            }
        }

        class Person
        {
            public Person(string[] input)
            {
                Id = input[1];
                Name = input[0];
                Age = int.Parse(input[2]);
            }

            public string Id { get; }

            public string Name { get; private set; }

            public int Age { get; private set; }

            public void Edit(string name, int age)
            {
                Name = name;
                Age = age;
            }

            public override string ToString()
            {
                return $"{Name} with ID: {Id} is {Age} years old.";
            }
        }

        #endregion
    }
}
