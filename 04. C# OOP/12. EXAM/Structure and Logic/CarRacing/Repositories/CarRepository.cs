using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> models;

        public CarRepository()
        {
            this.models = new List<ICar>();
        }

        public IReadOnlyCollection<ICar> Models 
        { 
            get { return this.models; }
        }

        public void Add(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            }

            this.models.Add(car);
        }

        public ICar FindBy(string property)
        {
            return Models.FirstOrDefault(x => x.VIN == property);
        }

        public bool Remove(ICar car)
        {
            if (Models.Contains(car))
            {
                models.Remove(car);

                return true;
            }

            return false;
        }
    }
}
