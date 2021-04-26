using _03.WildFarm.Foods;
using System;

namespace _03.WildFarm
{
    public abstract class Animal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }
        protected abstract double WeightPerFood { get; }

        public abstract void Eat(Food food);
        public abstract string ProduceSound();
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
