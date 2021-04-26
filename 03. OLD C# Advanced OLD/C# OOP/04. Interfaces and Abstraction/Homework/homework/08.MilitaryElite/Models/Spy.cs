namespace _08.MilitaryElite
{
    using _08.MilitaryElite.Interfaces;
    using System.Text;

    public class Spy : Solider, ISpy
    {
        public Spy(string id, string firstName, string lastName, int codeNumber) 
            : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine(base.ToString())
                .Append($"Code Number: {CodeNumber}");

            return builder.ToString();
        }
    }
}
