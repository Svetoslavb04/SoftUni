using _03.WildFarm.Foods;
using System;

namespace _03.WildFarm.Animals.Mammals
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override double WeightPerFood => 0.30;

        public override void Eat(Food food)
        {
            if (food.Name == "Meat" || food.Name == "Vegetable")
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
            return "Meow";
        }
    }
}
