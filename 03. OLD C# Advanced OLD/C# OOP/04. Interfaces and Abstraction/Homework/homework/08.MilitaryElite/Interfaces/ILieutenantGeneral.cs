namespace _08.MilitaryElite.Interfaces
{
    using System.Collections.Generic;

    public interface ILieutenantGeneral : IPrivate
    {
        IReadOnlyCollection<IPrivate> Privates { get; }
    }
}
