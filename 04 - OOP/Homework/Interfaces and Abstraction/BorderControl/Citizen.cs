using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : Human, IIdentifiable, IBirthable
    {
        private string id;
        private string birthdate;

        public Citizen(string name, int age, string id, string birthdate) : base(name, age, 10)
        {
            Id = id;
            Birthdate = birthdate;
        }

        public string Id { get => id; set => id = value; }
        public string Birthdate { get => birthdate; set => birthdate = value; }

        public bool IsBornIn(string year)
        {
            return Birthdate.EndsWith(year);
        }

        public bool IsIdentified(string validator)
        {
            return Id.EndsWith(validator);
        }
    }
}
