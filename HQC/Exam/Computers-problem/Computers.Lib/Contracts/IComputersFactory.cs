namespace Computers.Lib.Contracts
{
    public interface IComputersFactory
    {
        // TODO: Design Pattern Abstract Factory
        Computer CreateComputer(ComputerType computerType);
    }
}