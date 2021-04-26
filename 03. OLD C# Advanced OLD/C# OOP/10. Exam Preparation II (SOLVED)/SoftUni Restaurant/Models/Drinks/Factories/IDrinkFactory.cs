using SoftUniRestaurant.Models.Drinks.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Drinks.Factories
{
    public interface IDrinkFactory
    {
        IDrink CreateDrink(string type, string name, int servingSize, string brand);
    }
}
