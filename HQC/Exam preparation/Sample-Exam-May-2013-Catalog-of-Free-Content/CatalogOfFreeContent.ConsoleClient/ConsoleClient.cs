namespace CatalogOfFreeContent.ConsoleClient
{
    using System;
    using System.Text;

    using CatalogOfFreeContent.ConsoleClient.Contracts;
    using CatalogOfFreeContent.Lib;

    public class ConsoleClient
    {
        public static void Main()
        {
            var output = new StringBuilder();
            ICommandExecutor commandExecutor = new CommandExecutor(new Catalog());

            while (true)
            {
                var commandLine = Console.ReadLine();

                if (commandLine == null || commandLine.Trim() == "End")
                {
                    break;
                }

                var command = new Command(commandLine);

                output.Append(commandExecutor.ExecuteCommand(command));
            }

            Console.Write(output.ToString());
        }
    }
}