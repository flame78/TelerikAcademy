namespace Phonebook.ConsoleClient.Contracts
{
    internal interface IPhonebookCommand
    {
        void Execute(string[] arguments);
    }
}