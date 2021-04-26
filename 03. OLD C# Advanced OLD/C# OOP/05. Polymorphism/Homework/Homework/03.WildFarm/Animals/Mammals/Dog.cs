using _03.WildFarm.Foods;
using System;

namespace _03.WildFarm.Animals.Mammals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        protected override double WeightPerFood => 0.40;

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
            return "Woof!";
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
