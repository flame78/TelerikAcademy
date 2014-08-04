namespace PhonebookConsoleClient
{
    using System;

    using Phonebook;

    using Strategy.Formater;

    using Strategy.Parser;

    using Strategy.Printer;

    public class PhonebookConsoleClient
    {
        public static void Main()
        {
            var printer = new StringBuilderPrinter();
            var phonebookRepository = new PhonebookRepository();
            var formater = new PhoneNumberFormater();
            var consoleCommandsFactory = new CommandsFactory.CommandsFactory(phonebookRepository, formater, printer);

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

            Console.Write(printer.GetData());
        }
    }
}