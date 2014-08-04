namespace Phonebook.ConsoleClient.Strategy.Printer
{
    using System.Text;

    using Phonebook.ConsoleClient.Contracts;

    internal class StringBuilderPrinter : IPrinter
    {
        private readonly StringBuilder data = new StringBuilder();

        public void Print(string message)
        {
            this.data.AppendLine(message);
        }

        public string GetData()
        {
            return this.data.ToString();
        }
    }
}