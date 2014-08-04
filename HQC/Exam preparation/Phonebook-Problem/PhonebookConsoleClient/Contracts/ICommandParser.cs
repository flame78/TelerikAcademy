namespace Phonebook.ConsoleClient.Contracts
{
    using Phonebook.ConsoleClient.Strategy.Parser;

    internal interface ICommandParser
    {
        CommandData Parse(string commandLine);
    }
}