namespace Phonebook.ConsoleClient.Command
{
    using System;

    using Phonebook.ConsoleClient.Contracts;
    using Phonebook.Lib;

    internal class RemoveCommand : IPhonebookCommand
    {
        private readonly IPrinter printer;

        private readonly PhonebookRepositoryWithRemove repository;

        public RemoveCommand(PhonebookRepositoryWithRemove repository, IPrinter printer)
        {
            this.printer = printer;
            this.repository = repository;
        }

        public void Execute(string[] arguments)
        {
            if (arguments.Length != 1)
            {
                throw new ArgumentException("Invalid Parameters");
            }

            try
            {
                if (!this.repository.Remove(arguments[0]))
                {
                    this.printer.Print("Phone number could not be found");
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                this.printer.Print("Invalid phone number");
            }
        }
    }
}