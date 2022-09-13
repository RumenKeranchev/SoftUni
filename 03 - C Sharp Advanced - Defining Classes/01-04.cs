using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    /// <summary>
    /// 1. Define a Class Person
    /// 2. Creating Constructors
    /// 3. Oldest Family Member
    /// 4. Opinion Poll
    /// </summary>
    public static class _01_04
    {
        public static void People()
        {
            var n = int.Parse(Console.ReadLine());
            var family = new Family();

            for (int i = 0; i < n; i++)
            {
                var personInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                var person = new Person(personInput[0], int.Parse(personInput[1]));

                family.AddMember(person);
            }

            family.PrintOlderThan30();
        }
    }

    public class Family
    {
        private List<Person> persons = new List<Person>();

        public void AddMember(Person person)
        {
            persons.Add(person);
        }

        public Person GetOldestMember()
        {
            return persons.OrderByDescending(p => p.Age).FirstOrDefault();
        }

        public void PrintOlderThan30()
        {
            var olderThan30 = persons.Where(p => p.Age > 30).OrderBy(p => p.Name).ToList();

            foreach (var person in olderThan30)
            {
                Console.WriteLine(person);
            }
        }
    }

    public class Person
    {
        private string name;
        private int age;

        public Person()
        {
            name = "No name";
            age = 1;
        }

        public Person(int age) : this()
        {
            this.age = age;
        }

        public Person(string name) : this()
        {
            this.name = name;
        }

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }

        public override string ToString()
        {
            return $"{name} - {age}";
        }
    }
}
