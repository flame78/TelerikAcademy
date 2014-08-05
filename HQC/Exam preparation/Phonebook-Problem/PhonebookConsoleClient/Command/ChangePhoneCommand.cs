namespace Phonebook.ConsoleClient.Command
{
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
            var currentNumber = arguments[0];
            var newNumber = arguments[1];
            var numberOfChanges = this.repository.ChangePhone(currentNumber, newNumber);
            this.printer.Print(numberOfChanges + " numbers changed");
        }
    }
}