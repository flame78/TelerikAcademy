namespace PhonebookConsoleClient.Command
{
    using System;

    using Contracts;

    using Phonebook.Contracts;

    internal class ListEntriesCommand : IPhonebookCommand
    {
        private readonly IPhoneNumberFormater formater;

        private readonly IPrinter printer;

        private readonly IPhonebookRepository repository;

        public ListEntriesCommand(IPhonebookRepository repository, IPhoneNumberFormater formater, IPrinter printer)
        {
            this.printer = printer;
            this.repository = repository;
            this.formater = formater;
        }

        public void Execute(string[] arguments)
        {
            try
            {
                var entries = this.repository.ListEntries(int.Parse(arguments[0]), int.Parse(arguments[1]));

                foreach (var entry in entries)
                {
                    this.printer.Print(entry.ToString());
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                this.printer.Print("Invalid range");
            }
        }
    }
}