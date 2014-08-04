namespace PhonebookConsoleClient.Strategy.Printer
{
    using System.Text;

    using Contracts;

    internal class StringBuilderPrinter : IPrinter
    {
        private readonly StringBuilder data = new StringBuilder();

        public void Print(string data)
        {
            this.data.AppendLine(data);
        }

        public string GetData()
        {
            return this.data.ToString();
        }
    }
}