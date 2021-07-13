using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double mililiters = 50;
        private const decimal price = 3.5m;

        public Coffee(string name, double caffeine)
            : base(name, price, mililiters)
        {
            Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
    }
}
