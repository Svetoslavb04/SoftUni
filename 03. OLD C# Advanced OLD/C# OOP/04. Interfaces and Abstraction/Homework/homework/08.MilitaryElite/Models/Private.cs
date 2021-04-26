namespace _08.MilitaryElite
{
    using _08.MilitaryElite.Interfaces;

    public class Private : Solider, IPrivate
    {
        public Private(string id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; private set; }

        public override string ToString()
        {
            return $"Name: {base.ToString()} Salary: {Salary:F2}";
        }
    }
}
