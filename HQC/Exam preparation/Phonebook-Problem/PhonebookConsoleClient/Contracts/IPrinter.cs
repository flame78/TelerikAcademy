namespace Phonebook.ConsoleClient.Contracts
{
    internal interface IPrinter
    {
        void Print(string data);

        void Visit(IVisitor visitor);
    }
}