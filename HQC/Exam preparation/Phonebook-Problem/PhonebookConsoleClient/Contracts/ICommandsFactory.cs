namespace Phonebook.ConsoleClient.Contracts
{
    using System.Collections.Generic;

    internal interface ICommandsFactory
    {
        Dictionary<string, IPhonebookCommand> GetCommands();
    }
}