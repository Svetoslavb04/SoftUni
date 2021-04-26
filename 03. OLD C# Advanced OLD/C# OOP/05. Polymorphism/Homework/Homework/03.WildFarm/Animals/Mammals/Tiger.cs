using _03.WildFarm.Foods;
using System;

namespace _03.WildFarm.Animals.Mammals
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override double WeightPerFood => 1.00;

        public override void Eat(Food food)
        {
            if (food.GetType().Name == "Meat")
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
            return "ROAR!!!";
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
