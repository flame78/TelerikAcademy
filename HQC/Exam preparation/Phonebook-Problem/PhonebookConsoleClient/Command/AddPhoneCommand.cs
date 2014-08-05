namespace Phonebook.ConsoleClient.Command
{
    using System.Linq;

    using Phonebook.ConsoleClient.Contracts;
    using Phonebook.Lib.Contracts;

    internal class AddPhoneCommand : IPhonebookCommand
    {
        private readonly IPrinter printer;

        private readonly IPhonebookRepository repository;

        public AddPhoneCommand(IPhonebookRepository repository, IPrinter printer)
        {
            this.printer = printer;
            this.repository = repository;
        }

        public void Execute(string[] arguments)
        {
            var name = arguments[0];
            var numbers = arguments.Skip(1);

            if (this.repository.AddPhone(name, numbers))
            {
                this.printer.Print("Phone entry created");
            }
            else
            {
                this.printer.Print("Phone entry merged");
            }
        }
    }
}