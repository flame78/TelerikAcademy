namespace PhonebookConsoleClient.Strategy.Parser
{
    public class CommandData
    {
        public CommandData(string command, string[] numbers)
        {
            this.Name = command;
            this.Arguments = numbers;
        }

        public string Name { get; set; }

        public string[] Arguments { get; set; }
    }
}