using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class DruidFactory : HeroFactory
    {
        private string name;

        public DruidFactory(string name)
        {
            this.name = name;
        }

        public override BaseHero CreateHero()
        {
            return new Druid(name);
        }
    }
}
