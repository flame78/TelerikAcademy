namespace Phonebook.ConsoleClient.Strategy.Parser
{
    using System;

    using Phonebook.ConsoleClient.Contracts;

    internal class ConsoleCommandParser : ICommandParser
    {
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

            return new CommandData(command, arguments);
        }
    }
}