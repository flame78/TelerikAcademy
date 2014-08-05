namespace Phonebook.ConsoleClient
{
    using System;

    using Phonebook.ConsoleClient.Factory;
    using Phonebook.ConsoleClient.Strategy.Parser;
    using Phonebook.ConsoleClient.Strategy.Printer;
    using Phonebook.ConsoleClient.Visitor;
    using Phonebook.Lib;
    using Phonebook.Lib.Formater;

    public class PhonebookConsoleClient
    {
        public static void Main()
        {
            var printer = new StringBuilderPrinter();
            var phonebookRepository = new PhonebookRepository(new PhoneNumberFormater());
            var consoleCommandsFactory = new CommandsFactory(phonebookRepository, printer);

            var commands = consoleCommandsFactory.GetCommands();
            var commandParser = new ConsoleCommandParser(commands);

            while (true)
            {
                var commandLine = Console.ReadLine();
                if (commandLine == null || commandLine.ToLowerInvariant() == "end")
                {
                    break;
                }

                var command = commandParser.Parse(commandLine);

                commands[command.Name].Execute(command.Arguments);
            }

            printer.Visit(new PrintVisitor());
        }
    }
}