namespace _08.MilitaryElite
{
    using System.Collections.Generic;
    using System.Text;
    using _08.MilitaryElite.Interfaces;
    using _08.MilitaryElite.Models;

    public class Commando : SpecialisedSoldier, ICommando
    {
        private List<Mission> missions;
        public Commando(string id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName, salary)
        {
        }

        public IReadOnlyCollection<IMission> Missions => this.missions;

        public void AddMission(Mission mission)
        {
            this.missions.Add(mission);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine(base.ToString())
                .AppendLine("Missions:");

            this.missions
                .ForEach(m => builder.AppendLine(m.ToString()));

            return builder.ToString().TrimEnd();
        }
    }
}
