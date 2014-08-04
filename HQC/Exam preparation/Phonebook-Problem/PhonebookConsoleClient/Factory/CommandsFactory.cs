namespace Phonebook.ConsoleClient.Factory
{
    using System.Collections.Generic;

    using Phonebook.ConsoleClient.Command;
    using Phonebook.ConsoleClient.Contracts;
    using Phonebook.Lib.Contracts;

    internal class CommandsFactory : ICommandsFactory
    {
        private readonly IPhoneNumberFormater formater;

        private readonly IPhonebookRepository phonebookRepository;

        private readonly IPrinter printer;

        public CommandsFactory(
            IPhonebookRepository phonebookRepository, 
            IPhoneNumberFormater formater, 
            IPrinter printer)
        {
            this.formater = formater;
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
                                     this.formater, 
                                     this.printer)
                                 }, 
                                 {
                                     "ChangePhone", 
                                     new ChangePhoneCommand(
                                     this.phonebookRepository, 
                                     this.formater, 
                                     this.printer)
                                 }, 
                                 {
                                     "List", 
                                     new ListEntriesCommand(
                                     this.phonebookRepository, 
                                     this.formater, 
                                     this.printer)
                                 }
                             };

            return result;
        }
    }
}