using _03.WildFarm.Foods;

namespace _03.WildFarm.Animals.Birds
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        protected override double WeightPerFood => 0.35;

        public override void Eat(Food food)
        {
            this.FoodEaten += food.Quantity;
            this.Weight += (this.WeightPerFood * food.Quantity);
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
