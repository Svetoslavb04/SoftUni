using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm.Foods
{
    public abstract class Food
    {
        public Food(string name, int quantity)
        {
            this.Quantity = quantity;
            this.Name = name;
        }
        public int Quantity { get; set; }
        public string Name { get; set; }
    }
}
