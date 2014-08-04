namespace PhonebookConsoleClient.CommandsFactory
{
    using System.Collections.Generic;

    using Command;

    using Contracts;

    using Phonebook;

    using Strategy.Formater;

    using Strategy.Printer;

    internal class CommandsFactory : ICommandsFactory
    {
        private readonly PhoneNumberFormater formater;

        private readonly PhonebookRepository phonebookRepository;

        private readonly StringBuilderPrinter printer;

        public CommandsFactory(
            PhonebookRepository phonebookRepository, 
            PhoneNumberFormater formater, 
            StringBuilderPrinter printer)
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