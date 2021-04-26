namespace LoggerHomework.Appenders.Contracts
{
    using LoggerHomework.Layouts.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout);
    }
}
