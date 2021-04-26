namespace LoggerHomework.Appenders
{
    using LoggerHomework.Appenders.Contracts;
    using LoggerHomework.Layouts.Contracts;
    using LoggerHomework.Loggers.Contracts;
    using LoggerHomework.Loggers.Enums;
    using System;
    using System.IO;

    public class FileAppender : Appender
    {
        private ILogFile logFile;

        public FileAppender(ILayout layout, ILogFile logFile)
        {
            this.layout = layout;
            this.logFile = logFile;
        }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (this.ReportLevel <= reportLevel)
            {
                base.MessagesAppended++;
                string path = @"..\..\..\log.txt";
                string content = string.Format(this.layout.Format, dateTime, reportLevel, message) + Environment.NewLine;
                File.AppendAllText(path, content);
                this.logFile.Write(String.Format(layout.Format, dateTime, reportLevel, message));
            }
        }

        public override string ToString()
        {
            return $"Appender type: {nameof(ConsoleAppender)}, Layout type: {this.layout}, Report level: {this.ReportLevel}, Messages appended: {this.MessagesAppended}, File size: {logFile.Size}";
        }
    }
}
