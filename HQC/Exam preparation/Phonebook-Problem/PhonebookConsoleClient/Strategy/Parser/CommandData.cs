namespace Phonebook.ConsoleClient.Strategy.Parser
{
    internal class CommandData
    {
        internal CommandData(string command, string[] numbers)
        {
            this.Name = command;
            this.Arguments = numbers;
        }

        internal string Name { get; set; }

        internal string[] Arguments { get; set; }
    }
}