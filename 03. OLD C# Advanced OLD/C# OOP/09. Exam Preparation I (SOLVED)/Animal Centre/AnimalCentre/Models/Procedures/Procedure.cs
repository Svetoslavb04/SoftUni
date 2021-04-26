namespace AnimalCentre.Models.Procedures
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using AnimalCentre.Models.Contracts;

    public abstract class Procedure : IProcedure
    {
        protected List<IAnimal> procedureHistory;

        public Procedure()
        {
            this.procedureHistory = new List<IAnimal>();
        }

        public abstract string History();
        

        public virtual void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime < procedureTime)
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }

            animal.ProcedureTime -= procedureTime;
        }
    }
}
