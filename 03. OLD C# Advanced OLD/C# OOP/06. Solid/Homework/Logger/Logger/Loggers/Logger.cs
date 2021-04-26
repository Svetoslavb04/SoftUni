namespace LoggerHomework.Loggers
{
    using System;
    using LoggerHomework.Appenders.Contracts;
    using LoggerHomework.Loggers.Contracts;
    using LoggerHomework.Loggers.Enums;

    public class Logger : ILogger
    {
        private IAppender consoleAppender;
        private IAppender fileAppender;

        public Logger(IAppender consoleAppender)
        {
            this.consoleAppender = consoleAppender;
        }

        public Logger(IAppender consoleAppender, IAppender fileAppender)
            :this(consoleAppender)
        {
            this.consoleAppender = consoleAppender;
            this.fileAppender = fileAppender;
        }

        public void Critical(string dateTime, string criticalMessage)
        {
            Append(dateTime, ReportLevel.CRITICAL, criticalMessage);
        }

        public void Warning(string dateTime, string warningMessage)
        {
            Append(dateTime, ReportLevel.WARNING, warningMessage);
        }

        public void Fatal(string dateTime, string fatalMessage)
        {
            Append(dateTime, ReportLevel.FATAL, fatalMessage);
        }

        public void Error(string dateTime, string errorMessage)
        {
            Append(dateTime, ReportLevel.ERROR, errorMessage);
        }

        public void Info(string dateTime, string infoMessage)
        {
            Append(dateTime, ReportLevel.INFO, infoMessage);
        }

        private void Append(string dateTime, ReportLevel type, string infoMessage)
        {
            fileAppender?.Append(dateTime, type, infoMessage);
            consoleAppender?.Append(dateTime, type, infoMessage);
        }
    }
}
