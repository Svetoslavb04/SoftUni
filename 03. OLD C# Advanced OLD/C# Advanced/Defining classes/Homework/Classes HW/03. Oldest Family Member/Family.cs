using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> family = new List<Person>();

        public void AddMember(Person person)
        {
            family.Add(person);
        }

        public Person GetOldestMember()
        {

            int[] ages = new int[family.Count];

            for (int i = 0; i < family.Count; i++)
            {
                ages[i] = family[i].Age;
            }

            Person oldest = new Person();

            for (int i = 0; i < family.Count; i++)
            {
                if (family[i].Age == ages.Max())
                {
                    oldest = family[i];
                }
            }
   
            return oldest;
        }
    }
}
