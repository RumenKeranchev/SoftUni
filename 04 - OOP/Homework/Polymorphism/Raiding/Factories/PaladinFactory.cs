using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class PaladinFactory : HeroFactory
    {
        private string name;

        public PaladinFactory(string name)
        {
            this.name = name;
        }

        public override BaseHero CreateHero()
        {
            return new Paladin(name);
        }
    }
}
