using LoggerHomework.Appenders.Contracts;
using LoggerHomework.Layouts.Contracts;
using LoggerHomework.Loggers.Enums;

namespace LoggerHomework.Appenders
{
    public abstract class Appender : IAppender
    {
        protected ILayout layout;
        public ReportLevel ReportLevel { get; set; }
        protected int MessagesAppended;

        public abstract void Append(string dateTime, ReportLevel reportLevel, string message);
    }
}
