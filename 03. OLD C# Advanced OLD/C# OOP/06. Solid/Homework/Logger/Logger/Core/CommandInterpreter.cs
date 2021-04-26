using LoggerHomework.Appenders;
using LoggerHomework.Appenders.Contracts;
using LoggerHomework.Core.Contracts;
using LoggerHomework.Layouts;
using LoggerHomework.Layouts.Contracts;
using LoggerHomework.Loggers.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerHomework.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private ICollection<IAppender> appenders;
        private IAppenderFactory appenderFactory;
        private ILayoutFactory layoutFactory;

        public CommandInterpreter()
        {
            this.appenders = new List<IAppender>();
            this.appenderFactory = new AppenderFactory();
            this.layoutFactory = new LayoutFactory();
        }

        public ILayout Layout { get; private set; }

        public void AddAppender(string[] args)
        {
            string typeAppender = args[0];
            string typeLayout = args[1];
            ReportLevel reportLevel = ReportLevel.INFO;

            if (args.Length == 3)
            {
                reportLevel = Enum.Parse<ReportLevel>(args[2]);
            }

            ILayout layout = this.layoutFactory.CreateLayout(typeLayout);

            IAppender appender = (this.appenderFactory.CreateAppender(typeAppender, layout));

            appender.ReportLevel = reportLevel;

            appenders.Add(appender);
        }

        public void AddReport(string[] args)
        {
            ReportLevel reportType = Enum.Parse<ReportLevel>(args[0]);
            string dateTime = args[1];
            string message = args[2];


            foreach (var appender in appenders)
            {
                appender.Append(dateTime, reportType, message);
            }
        }

        public void PrintInfo()
        {
            StringBuilder printer = new StringBuilder();
            printer.AppendLine("Logger Info");

            foreach (var appender in appenders)
            {
                printer.AppendLine(appender.ToString());
            }

            Console.WriteLine(printer);
        }
    }
}
