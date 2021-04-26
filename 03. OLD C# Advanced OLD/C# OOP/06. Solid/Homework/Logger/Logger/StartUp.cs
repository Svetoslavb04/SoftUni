namespace LoggerHomework
{
    using Appenders;
    using Appenders.Contracts;
    using Layouts;
    using Layouts.Contracts;
    using LoggerHomework.Core;
    using LoggerHomework.Core.Contracts;
    using LoggerHomework.Loggers.Enums;
    using Loggers;
    using Loggers.Contracts;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            Engine engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}
