namespace LoggerHomework.Appenders
{
    using LoggerHomework.Appenders.Contracts;
    using LoggerHomework.Layouts.Contracts;
    using LoggerHomework.Loggers.Enums;
    using System;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
        {
            base.layout = layout;
        }
        
        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (this.ReportLevel <= reportLevel)
            {
                base.MessagesAppended++;
                Console.WriteLine(string.Format(layout.Format, dateTime, reportLevel, message));
            }
        }

        public override string ToString()
        {
            return $"Appender type: {nameof(ConsoleAppender)}, Layout type: {this.layout}, Report level: {this.ReportLevel}, Messages appended: {this.MessagesAppended}";
        }
    }
}
