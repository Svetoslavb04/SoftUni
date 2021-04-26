using System.Collections.Generic;

namespace Repository
{
    public class Repository
    {
        private Dictionary<int, Person> data;
        private int currentId = 0;

        public Repository()
        {
            this.data = new Dictionary<int, Person>();
        }

        public int Count => this.data.Count;


        public void Add(Person person)
        {
            this.data.Add(currentId, person);
            currentId++;
        }

        public Person Get(int id)
        {
            return this.data[id];
        }

        public bool Update(int id, Person newPerson)
        {
            if (data.ContainsKey(id))
            {
                this.data[id] = newPerson;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Delete(int id)
        {
            this.data.Remove(id);
        }
    }
}
