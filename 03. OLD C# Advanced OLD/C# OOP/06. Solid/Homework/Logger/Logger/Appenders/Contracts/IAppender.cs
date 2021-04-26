namespace LoggerHomework.Appenders.Contracts
{
    using LoggerHomework.Loggers.Enums;

    public interface IAppender
    {
        void Append(string dateTime, ReportLevel reportLevel, string message);

        ReportLevel ReportLevel { get; set; }
    }
}
