using System;
using System.Collections.Generic;
using System.Text;

namespace _3.Raiding
{
    public class Druid : BaseHero
    {
        public Druid(string name) : base(name)
        {
            this.Power = 80;
        }
        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
