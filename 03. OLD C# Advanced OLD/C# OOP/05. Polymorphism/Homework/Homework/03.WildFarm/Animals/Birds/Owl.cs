using _03.WildFarm.Foods;
using System;

namespace _03.WildFarm.Animals.Birds
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        protected override double WeightPerFood => 0.25;

        public override void Eat(Food food)
        {
            if (food.Name == "Meat")
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
            return "Hoot Hoot";
        }
    }
}
