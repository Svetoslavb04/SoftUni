namespace _03.WildFarm
{
    using _03.WildFarm.Animals.Birds;
    using _03.WildFarm.Animals.Mammals;
    using _03.WildFarm.Foods;
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main()
        {
            List<Animal> animals = new List<Animal>();

            while (true)
            {
                var command = Console.ReadLine().Split();
                if (command[0] == "End")
                {
                    break;
                }

                if (command.Length > 2)
                {
                    var animal = CreateAnimal(command);
                    animals.Add(animal);
                }
                else
                {
                    Food food = CreateFood(command, animals);
                    try
                    {
                        animals[animals.Count - 1].Eat(food);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        public static Food CreateFood(string[] command, List<Animal> animals)
        {
            Food food = null;
            if (command[0] == "Vegetable")
            {
                Food vegetable = new Vegetable(int.Parse(command[1]));
                food = vegetable;
            }
            else if (command[0] == "Fruit")
            {
                Food fruit = new Fruit(int.Parse(command[1]));
                food = fruit;
            }
            else if (command[0] == "Meat")
            {
                Food meat = new Meat(int.Parse(command[1]));
                food = meat;
            }
            else if (command[0] == "Seeds")
            {
                Food seeds = new Seeds(int.Parse(command[1]));
                food = seeds;
            }

            return food;
        }

        public static Animal CreateAnimal(string[] command)
        {
            Animal animal = null;
            if (command[0] == "Dog")
            {
                Animal dog = new Dog(command[1], double.Parse(command[2]), command[3]);
                animal = dog;
            }
            else if (command[0] == "Mouse")
            {
                Animal mouse = new Mouse(command[1], double.Parse(command[2]), command[3]);
                animal = mouse;
            }
            else if (command[0] == "Owl")
            {
                Animal owl = new Owl(command[1], double.Parse(command[2]), double.Parse(command[3]));
                animal = owl;
            }
            else if (command[0] == "Hen")
            {
                Animal hen = new Hen(command[1], double.Parse(command[2]), double.Parse(command[3]));
                animal = hen;
            }
            else if (command[0] == "Cat")
            {
                Animal cat = new Cat(command[1], double.Parse(command[2]), command[3], command[4]);
                animal = cat;
            }
            else if (command[0] == "Tiger")
            {
                Animal tiger = new Tiger(command[1], double.Parse(command[2]), command[3], command[4]);
                animal = tiger;
            }
            Console.WriteLine(animal.ProduceSound());
            return animal;
        }
    }
}

