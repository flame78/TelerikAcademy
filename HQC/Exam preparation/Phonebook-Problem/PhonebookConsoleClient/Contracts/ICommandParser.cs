namespace PhonebookConsoleClient.Contracts
{
    using Strategy.Parser;

    public interface ICommandParser
    {
        CommandData Parse(string commandLine);
    }
}