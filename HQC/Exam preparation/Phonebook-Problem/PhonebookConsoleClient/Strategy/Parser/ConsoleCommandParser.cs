// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleCommandParser.cs" company="">
// </copyright>
// <summary>
//   The console command parser.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace PhonebookConsoleClient.Strategy.Parser
{
    using System;
    using System.Collections.Generic;

    using Contracts;

    /// <summary>
    ///     The console command parser.
    /// </summary>
    internal class ConsoleCommandParser : ICommandParser
    {
        /// <summary>
        ///     The commands.
        /// </summary>
        private readonly Dictionary<string, IPhonebookCommand> commands;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleCommandParser"/> class.
        /// </summary>
        /// <param name="commands">
        /// The commands.
        /// </param>
        internal ConsoleCommandParser(Dictionary<string, IPhonebookCommand> commands)
        {
            this.commands = commands;
        }

        /// <summary>
        /// The parse.
        /// </summary>
        /// <param name="commandLine">
        /// The command line.
        /// </param>
        /// <returns>
        /// The <see cref="CommandData"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// </exception>
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