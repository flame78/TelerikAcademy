namespace PhonebookConsoleClient.Contracts
{
    public interface IPrinter
    {
        void Print(string data);

        string GetData();
    }
}