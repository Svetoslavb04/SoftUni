using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Beverage : Product
    {
        public Beverage(string name, decimal price, double milliliters)
            :base(name,price)
        {
            this.Mililiters = milliliters;
        }

        public double Mililiters { get; private set; }
    }
}
