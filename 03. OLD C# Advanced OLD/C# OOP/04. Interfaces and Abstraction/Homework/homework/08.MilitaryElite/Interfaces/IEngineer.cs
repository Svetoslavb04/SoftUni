using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Interfaces
{
    public interface IEngineer : ISpecialisedSoldier
    {
        IReadOnlyCollection<IRepair> Repairs { get; }
    }
}
