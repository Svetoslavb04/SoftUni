namespace LoggerHomework.Appenders
{
    using LoggerHomework.Appenders.Contracts;
    using LoggerHomework.Layouts.Contracts;
    using LoggerHomework.Loggers;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout)
        {
            string typeAsLower = type.ToLower();

            switch (typeAsLower)
            {
                case "consoleappender":
                    return new ConsoleAppender(layout);
                case "fileappender":
                    return new FileAppender(layout, new LogFile());
                default:
                    throw new ArgumentException("Invalid Appender Type");
            }
        }
    }
}
