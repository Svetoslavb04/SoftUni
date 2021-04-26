using LoggerHomework.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerHomework.Core
{
    public class Engine : IEngine
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            int appendersCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < appendersCount; i++)
            {
                string[] appendersArgs = Console.ReadLine().Split();

                this.commandInterpreter.AddAppender(appendersArgs);
            }

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "END") { break; }

                string[] reportArgs = input.Split("|");

                this.commandInterpreter.AddReport(reportArgs);
            }

            this.commandInterpreter.PrintInfo();
        }
    }
}
