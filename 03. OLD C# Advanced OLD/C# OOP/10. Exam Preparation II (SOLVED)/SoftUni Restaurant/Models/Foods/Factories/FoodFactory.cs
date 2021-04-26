using SoftUniRestaurant.Models.Foods.Contracts;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SoftUniRestaurant.Models.Foods.Factories
{
    public class FoodFactory : IFoodFactory
    {
        public IFood CreateFood(string type, string name, decimal price)
        {
            Type foodType = Assembly.GetExecutingAssembly().GetType($"SoftUniRestaurant.Models.Foods.{type}");

            var food = Activator.CreateInstance(foodType, new object[] { name, price });

            return (IFood)food;
        }
    }
}
