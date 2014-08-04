namespace PhonebookConsoleClient.Contracts
{
    using System.Collections.Generic;

    public interface ICommandsFactory
    {
        Dictionary<string, IPhonebookCommand> GetCommands();
    }
}