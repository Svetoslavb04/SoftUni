namespace _03BarracksFactory.Contracts
{
    public interface ICommandInterpreter
    {
        IExecutable InterpredCommand(string[] data, string commandName);
    }
}
