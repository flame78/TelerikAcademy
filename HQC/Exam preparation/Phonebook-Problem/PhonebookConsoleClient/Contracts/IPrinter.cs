namespace Phonebook.ConsoleClient.Contracts
{
    internal interface IPrinter
    {
        void Print(string data);

        string GetData();
    }
}