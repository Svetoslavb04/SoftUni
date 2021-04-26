using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> heroes;

        public HeroRepository()
        {
            heroes = new List<Hero>();
        }
        
        public int Count { get { return heroes.Count; } }

        public void Add(Hero hero)
        {
            heroes.Add(hero);
        }

        public void Remove(string name)
        {
            Hero heroToRemove = heroes.Find(h => h.Name == name);
            heroes.Remove(heroToRemove);
        }

        public Hero GetHeroWithHighestStrength()
        {
            heroes.OrderByDescending(h => h.Item.Strength);
            return heroes[0];
        }

        public Hero GetHeroWithHighestAbility()
        {
            heroes.OrderByDescending(h => h.Item.Ability);
            return heroes[0];
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            heroes.OrderByDescending(h => h.Item.Ability);
            return heroes[0];
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var hero in heroes)
            {
                stringBuilder.AppendLine(hero.ToString());
            }
            return stringBuilder.ToString();
        }
    }
}
