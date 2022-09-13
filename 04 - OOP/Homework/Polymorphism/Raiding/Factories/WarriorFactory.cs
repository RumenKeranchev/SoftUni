using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class WarriorFactory : HeroFactory
    {
        private string name;

        public WarriorFactory(string name)
        {
            this.name = name;
        }

        public override BaseHero CreateHero()
        {
            return new Warrior(name);
        }
    }
}
