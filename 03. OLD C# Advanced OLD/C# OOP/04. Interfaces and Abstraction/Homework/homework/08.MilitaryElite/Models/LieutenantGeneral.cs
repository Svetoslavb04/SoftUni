namespace _08.MilitaryElite
{
    using System.Collections.Generic;
    using System.Text;
    using _08.MilitaryElite.Interfaces;

    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private List<IPrivate> privates;

        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
        }

        IReadOnlyCollection<IPrivate> ILieutenantGeneral.Privates => this.privates;

        public void AddPrivate(Private newPrivate)
        {
            this.privates.Add(newPrivate);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(base.ToString());
            stringBuilder.AppendLine("Privates");
            foreach (var priv in privates)
            {
                stringBuilder.AppendLine(priv.ToString());
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
