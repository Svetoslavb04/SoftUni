namespace _08.MilitaryElite
{
    using _08.MilitaryElite.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private Corps corps;

        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
        }

        public string Corps
        {
            get
            {
                return this.corps.ToString();
            }

            set
            {
                Corps corps;

                if (!Enum.TryParse<Corps>(value, out corps))
                {
                    throw new ArgumentException();
                }

                this.corps = corps;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine(base.ToString())
                .AppendLine($"Corps: {Corps}");

            return builder.ToString().TrimEnd();
        }
    }
}
