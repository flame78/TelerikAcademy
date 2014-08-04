namespace PhonebookConsoleClient.Contracts
{
    public interface IPhonebookCommand
    {
        void Execute(string[] arguments);
    }
}