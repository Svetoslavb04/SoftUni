using SoftUniRestaurant.Models.Drinks.Contracts;
using System;
using System.Reflection;

namespace SoftUniRestaurant.Models.Drinks.Factories
{
    public class DrinkFactory : IDrinkFactory
    {
        public IDrink CreateDrink(string type, string name, int servingSize, string brand)
        {
            Type drinkType = Type.GetType($"SoftUniRestaurant.Models.Drinks.{type}");

            var drink = Activator.CreateInstance(drinkType, new object[] { name, servingSize, brand });

            return (IDrink)drink;
        }
    }
}
