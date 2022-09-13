using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Robot : Entity, IIdentifiable
    {
        private string id;

        public Robot(string name, string id) : base(name)
        {
            Id = id;
        }

        public string Id { get => id; set => id = value; }

        public bool IsIdentified(string validator)
        {
            return Id.EndsWith(validator);
        }
    }
}
