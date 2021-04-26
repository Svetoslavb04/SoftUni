namespace AnimalCentre.Core
{
    using global::AnimalCentre.Core.Contracts;
    using global::AnimalCentre.Models.Contracts;
    using global::AnimalCentre.Models.Procedures;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AnimalCentre : IAnimalCentre
    {
        private IHotel hotel;
        private IAnimalFactory animalFactory;
        public AnimalCentre(IHotel hotel, IAnimalFactory animalFactory)
        {
            this.hotel = hotel;
            this.animalFactory = animalFactory;
        }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            IAnimal animal = animalFactory.CreateAnimal(type, name, energy, happiness, procedureTime);

            this.hotel.Accommodate(animal);

            return $"Animal {name} registered successfully";
        }

        public string Chip(string name, int procedureTime)
        {
            ValidateForExcistingAnimalInHotel(name);

            var chip = new Chip();
            var animal = this.hotel.Animals[name];
            chip.DoService(animal, procedureTime);

            return $"{name} had chip procedure";
        }

        public string Vaccinate(string name, int procedureTime)
        {
            ValidateForExcistingAnimalInHotel(name);

            var vaccinate = new Vaccinate();
            var animal = this.hotel.Animals[name];
            vaccinate.DoService(animal, procedureTime);

            return $"{name} had vaccinate procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            ValidateForExcistingAnimalInHotel(name);

            var fitness = new Fitness();
            var animal = this.hotel.Animals[name];
            fitness.DoService(animal, procedureTime);

            return $"{name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            ValidateForExcistingAnimalInHotel(name);

            var play = new Play();
            var animal = this.hotel.Animals[name];
            play.DoService(animal, procedureTime);

            return $"{name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            ValidateForExcistingAnimalInHotel(name);

            var dentalCare = new DentalCare();
            var animal = this.hotel.Animals[name];
            dentalCare.DoService(animal, procedureTime);

            return $"{name} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            ValidateForExcistingAnimalInHotel(name);

            var nailTrim = new NailTrim();
            var animal = this.hotel.Animals[name];
            nailTrim.DoService(animal, procedureTime);

            return $"{name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            ValidateForExcistingAnimalInHotel(animalName);

            IAnimal animal = this.hotel.Animals[animalName];

            if (animal.IsChipped)
            {
                this.hotel.Adopt(animalName, owner);

                return $"{owner} adopted animal with chip";
            }
            else
            {
                this.hotel.Adopt(animalName, owner);

                return $"{owner} adopted animal without chip";
            }
        }

        public string History(string type)
        {
            Type procedureType = GetType().Assembly.GetType($"AnimalCentre.Models.Procedures.{type}");

            var method = procedureType.GetMethod("History");

            return method.Invoke(procedureType, new object[0]).ToString();
        }

        private void ValidateForExcistingAnimalInHotel(string animalName)
        {
            if (!this.hotel.Animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }
        }
    }
}
