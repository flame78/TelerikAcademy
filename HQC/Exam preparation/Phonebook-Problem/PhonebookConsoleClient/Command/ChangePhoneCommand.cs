namespace Phonebook.ConsoleClient.Command
{
    using System;

    using Phonebook.ConsoleClient.Contracts;
    using Phonebook.Lib.Contracts;

    internal class ChangePhoneCommand : IPhonebookCommand
    {
        private readonly IPrinter printer;

        private readonly IPhonebookRepository repository;

        public ChangePhoneCommand(IPhonebookRepository repository, IPrinter printer)
        {
            this.printer = printer;
            this.repository = repository;
        }

        public void Execute(string[] arguments)
        {
            if (arguments.Length != 2)
            {
                throw new ArgumentException("Invalid Parameters");
            }

            var currentNumber = arguments[0];
            var newNumber = arguments[1];
            var numberOfChanges = this.repository.ChangePhone(currentNumber, newNumber);
            this.printer.Print(numberOfChanges + " numbers changed");
        }
    }
}