using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Person
    {
        private string name;
        private int age;

        public Person () :this("No name", 1)
        {
        }

        public Person (int age) :this("No name", age)
        {
        }

        public Person(string name, int age)
        {
            this.Age = age;
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length < 1)
                {
                    throw new ArgumentException("Name length must be greater than one.");
                }
                this.name = value;
            }

        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 0 )
                {
                    throw new ArgumentException("Age must be positive number.");
                }
                this.age = value;
            }

        }

    }
}
