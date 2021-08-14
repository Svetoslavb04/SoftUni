using System;
using System.Collections.Generic;
using System.Text;

namespace _3.Raiding
{
    public abstract class BaseHero
    {
        public BaseHero(string name)
        {
            this.Name = name;
        }
        public string Name { get; }
        public int Power { get; set; }

        public abstract string CastAbility();
    }
}
