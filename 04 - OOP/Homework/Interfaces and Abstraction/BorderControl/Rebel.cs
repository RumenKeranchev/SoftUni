using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Rebel : Human
    {
        private string group;

        public Rebel(string name, int age, string group) : base(name, age, 5)
        {
            this.group = group;
        }
    }
}
