namespace AnimalCentre.Factories
{
    using AnimalCentre.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AnimalFactory
    {
        public IAnimal CreateAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            Type animalType = Type.GetType($"AnimalCentre.Models.Animals.{type}");

            var animal = Activator.CreateInstance(animalType, name, energy, happiness, procedureTime);

            return (IAnimal)animal;
        }
    }
}
