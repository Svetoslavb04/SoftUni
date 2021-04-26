using _03.WildFarm.Foods;
using System;
using System.Collections.Generic;

namespace _03.WildFarm.Animals.Mammals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        protected override double WeightPerFood => 0.10;

        public override void Eat(Food food)
        {
            if (food.Name == "Vegetable" || food.Name == "Fruit")
            {
                this.FoodEaten += food.Quantity;
                this.Weight += (this.WeightPerFood * food.Quantity);
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.Name}!");
            }
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return base.ToString()+ $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
