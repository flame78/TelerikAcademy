namespace PhonebookConsoleClient.Command
{
    using System.Linq;

    using Contracts;

    using Phonebook.Contracts;

    internal class AddPhoneCommand : IPhonebookCommand
    {
        private readonly IPhoneNumberFormater formater;

        private readonly IPrinter printer;

        private readonly IPhonebookRepository repository;

        public AddPhoneCommand(IPhonebookRepository repository, IPhoneNumberFormater formater, IPrinter printer)
        {
            this.printer = printer;
            this.repository = repository;
            this.formater = formater;
        }

        public void Execute(string[] arguments)
        {
            var name = arguments[0];
            var number = arguments.Skip(1).ToList();
            for (var i = 0; i < number.Count; i++)
            {
                number[i] = this.formater.Format(number[i]);
            }

            if (this.repository.AddPhone(name, number))
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