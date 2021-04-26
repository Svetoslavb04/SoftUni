namespace SoftUniRestaurant.Models.Drinks
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Alcohol : Drink
    {
        private const decimal AlcoholPrice = 3.50m;

        public Alcohol(string name, int servingSize, string brand)
            : base(name, servingSize, AlcoholPrice, brand)
        {
        }
    }
}
