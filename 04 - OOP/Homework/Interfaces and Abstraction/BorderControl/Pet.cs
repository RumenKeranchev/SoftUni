using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Pet : Entity, IBirthable
    {
        private string birthdate;

        public Pet(string name, string birthdate) : base(name)
        {
            Birthdate = birthdate;
        }

        public string Birthdate { get => birthdate; set => birthdate = value; }

        public bool IsBornIn(string year)
        {
            return Birthdate.EndsWith(year);
        }
    }
}
