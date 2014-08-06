namespace Computers.UI.Console
{
    using Computers.Lib;
    using Computers.Lib.Contracts;

    // TODO: Simple Factory
    internal class SimpleComputersFactory
    {
        private readonly IComputersFactory computersFactory;

        public SimpleComputersFactory(IComputersFactory computersFactory)
        {
            this.computersFactory = computersFactory;
        }

        internal Computer GetComputer()
        {
            return this.computersFactory.CreateComputer(ComputerType.PC);
        }

        internal Computer GetServer()
        {
            return this.computersFactory.CreateComputer(ComputerType.SERVER);
        }

        internal Computer GetLaptop()
        {
            return this.computersFactory.CreateComputer(ComputerType.LAPTOP);
        }
    }
}