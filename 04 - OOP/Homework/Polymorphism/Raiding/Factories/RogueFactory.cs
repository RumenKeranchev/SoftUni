using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class RogueFactory : HeroFactory
    {
        private string name;

        public RogueFactory(string name)
        {
            this.name = name;
        }

        public override BaseHero CreateHero()
        {
            return new Rogue(name);
        }
    }
}
