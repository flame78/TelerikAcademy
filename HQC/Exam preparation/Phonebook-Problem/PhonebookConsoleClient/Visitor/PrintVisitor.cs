
namespace Phonebook.ConsoleClient.Visitor
{
    using System;

    using Phonebook.ConsoleClient.Contracts;

    class PrintVisitor : IVisitor
    {
        public void Recieve(string data)
        {
            Console.Write(data);
        }
    }
}
