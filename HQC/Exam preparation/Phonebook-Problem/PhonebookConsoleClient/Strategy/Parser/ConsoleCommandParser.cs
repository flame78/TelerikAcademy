namespace Phonebook.ConsoleClient.Strategy.Parser
{
    using System;
    using System.Collections.Generic;

    using Phonebook.ConsoleClient.Contracts;

    internal class ConsoleCommandParser : ICommandParser
    {
        private readonly Dictionary<string, IPhonebookCommand> commands;

        internal ConsoleCommandParser(Dictionary<string, IPhonebookCommand> commands)
        {
            this.commands = commands;
        }

        public CommandData Parse(string commandLine)
        {
            var indexOfFirstOpeningParanthesis = commandLine.IndexOf('(');
            if (indexOfFirstOpeningParanthesis == -1)
            {
                throw new ArgumentException("Invalid Command");
            }

            var command = commandLine.Substring(0, indexOfFirstOpeningParanthesis);
            if (!commandLine.EndsWith(")"))
            {
                throw new ArgumentException("Invalid Command");
            }

            var parameters = commandLine.Substring(
                indexOfFirstOpeningParanthesis + 1, 
                commandLine.Length - indexOfFirstOpeningParanthesis - 2);
            var arguments = parameters.Split(',');
            for (var j = 0; j < arguments.Length; j++)
            {
                arguments[j] = arguments[j].Trim();
            }

            if (!this.commands.ContainsKey(command) || (command == "AddPhone" && arguments.Length < 2)
                || (command != "AddPhone" && arguments.Length != 2))
            {
                throw new ArgumentException("Invalid Command");
            }

            return new CommandData(command, arguments);
        }
    }
}