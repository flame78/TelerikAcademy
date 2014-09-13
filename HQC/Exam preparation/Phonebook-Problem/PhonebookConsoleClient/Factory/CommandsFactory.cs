namespace Phonebook.ConsoleClient.Factory
{
    using System.Collections.Generic;

    using Phonebook.ConsoleClient.Command;
    using Phonebook.ConsoleClient.Contracts;
    using Phonebook.Lib;

    internal class CommandsFactory : ICommandsFactory
    {
        private readonly PhonebookRepositoryWithRemove phonebookRepository;

        private readonly IPrinter printer;

        public CommandsFactory(PhonebookRepositoryWithRemove phonebookRepository, IPrinter printer)
        {
            this.phonebookRepository = phonebookRepository;
            this.printer = printer;
        }

        public Dictionary<string, IPhonebookCommand> GetCommands()
        {
            var result = new Dictionary<string, IPhonebookCommand>
                             {
                                 {
                                     "AddPhone", 
                                     new AddPhoneCommand(
                                     this.phonebookRepository, 
                                     this.printer)
                                 }, 
                                 {
                                     "ChangePhone", 
                                     new ChangePhoneCommand(
                                     this.phonebookRepository, 
                                     this.printer)
                                 }, 
                                 {
                                     "List", 
                                     new ListEntriesCommand(
                                     this.phonebookRepository, 
                                     this.printer)
                                 }, 
                                 {
                                     "Remove", 
                                     new RemoveCommand(
                                     this.phonebookRepository, 
                                     this.printer)
                                 }
                             };

            return result;
        }
    }
}