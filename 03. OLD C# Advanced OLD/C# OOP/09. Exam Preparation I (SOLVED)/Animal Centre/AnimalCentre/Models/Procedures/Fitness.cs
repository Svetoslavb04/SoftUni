namespace AnimalCentre.Models.Procedures
{
    using AnimalCentre.Models.Contracts;
    using System;
    using System.Text;

    public class Fitness : Procedure
    {
        public override string History()
        {
            var stringbuilder = new StringBuilder();

            stringbuilder.AppendLine($"{typeof(Fitness)}");

            foreach (var animal in procedureHistory)
            {
                stringbuilder.AppendLine($"    - {animal.Name} - Happiness: {animal.Happiness} - Energy: {animal.Energy}");
            }

            return stringbuilder.ToString().Trim();
        }

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);

            animal.Happiness -= 3;
            animal.Energy += 10;

            this.procedureHistory.Add(animal);
        }
    }
}
