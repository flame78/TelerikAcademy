namespace Phonebook.ConsoleClient.Command
{
    using Phonebook.ConsoleClient.Contracts;
    using Phonebook.Lib.Contracts;

    internal class ChangePhoneCommand : IPhonebookCommand
    {
        private readonly IPhoneNumberFormater formater;

        private readonly IPrinter printer;

        private readonly IPhonebookRepository repository;

        public ChangePhoneCommand(IPhonebookRepository repository, IPhoneNumberFormater formater, IPrinter printer)
        {
            this.printer = printer;
            this.repository = repository;
            this.formater = formater;
        }

        public void Execute(string[] arguments)
        {
            var currentNumber = this.formater.Format(arguments[0]);
            var newNumber = this.formater.Format(arguments[1]);
            var numberOfChanges = this.repository.ChangePhone(currentNumber, newNumber);
            this.printer.Print(numberOfChanges + " numbers changed");
        }
    }
}