using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public abstract class Entity
    {
        private string name;

        protected Entity(string name)
        {
            Name = name;
        }

        public string Name { get => name; set => name = value; }
    }
}
