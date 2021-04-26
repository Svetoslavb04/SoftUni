namespace AnimalCentre.Models.Procedures
{
    using AnimalCentre.Models.Contracts;
    using System;
    using System.Text;

    public class Chip : Procedure
    {
        public override string History()
        {
            var stringbuilder = new StringBuilder();

            stringbuilder.AppendLine($"{typeof(Chip)}");

            foreach (var animal in procedureHistory)
            {
                stringbuilder.AppendLine($"    - {animal.Name} - Happiness: {animal.Happiness} - Energy: {animal.Energy}");
            }

            return stringbuilder.ToString().Trim();
        }

        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.IsChipped)
            {
                throw new ArgumentException($"{animal.Name} is already chipped");
            }

            base.DoService(animal, procedureTime);
            
            animal.IsChipped = true;
            animal.Happiness -= 5;

            this.procedureHistory.Add(animal);
        }
    }
}
