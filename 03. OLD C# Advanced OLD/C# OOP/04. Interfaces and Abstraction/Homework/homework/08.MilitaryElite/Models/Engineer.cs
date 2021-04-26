namespace _08.MilitaryElite
{
    using System.Collections.Generic;
    using System.Text;
    using _08.MilitaryElite.Interfaces;
    using _08.MilitaryElite.Models;

    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private List<Repair> repairs;

        public Engineer(string id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
        }

        public IReadOnlyCollection<IRepair> Repairs => this.repairs;

        public void AddRepair(Repair repair)
        {
            this.repairs.Add(repair);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine(base.ToString())
                .AppendLine("Repairs:");

            foreach (var repair in this.repairs)
            {
                builder.AppendLine(repair.ToString());
            }

            return builder.ToString().TrimEnd();
        }
    }
}
