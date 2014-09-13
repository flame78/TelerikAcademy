namespace Computers.UI.Console
{
    using System;

    using Computers.Lib.ComputersFactory;
    using Computers.Lib.Contracts;

    public class Program
    {
        public static void Main()
        {
            IComputersFactory computersFactory;

            var manufacturer = Console.ReadLine();

            if (manufacturer == "Lenovo")
            {
                computersFactory = new LenovoComputers();
            }
            else if (manufacturer == "HP")
            {
                computersFactory = new HpComputers();
            }
            else if (manufacturer == "Dell")
            {
                computersFactory = new DellComputers();
            }
            else
            {
                throw new InvalidArgumentException("Invalid manufacturer!");
            }

            var simpleComputersFactory = new SimpleComputersFactory(computersFactory);

            var pc = simpleComputersFactory.GetComputer();
            var laptop = simpleComputersFactory.GetLaptop();
            var server = simpleComputersFactory.GetServer();

            while (true)
            {
                var commandLine = Console.ReadLine();
                if (commandLine == null)
                {
                    break;
                }

                if (commandLine.StartsWith("Exit"))
                {
                    break;
                }

                var commandParameters = commandLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (commandParameters.Length != 2)
                {
                    {
                        throw new InvalidArgumentException("Invalid command!");
                    }
                }

                var command = commandParameters[0];
                var commandArgument = int.Parse(commandParameters[1]);

                if (command == "Charge")
                {
                    laptop.ChargeBattery(commandArgument);
                    continue;
                }

                if (command == "Process")
                {
                    server.Process(commandArgument);
                    continue;
                }

                if (command == "Play")
                {
                    pc.Play(commandArgument);
                    continue;
                }

                throw new InvalidArgumentException("Invalid command!");
            }
        }

        public class InvalidArgumentException : ArgumentException
        {
            public InvalidArgumentException(string message)
                : base(message)
            {
            }
        }
    }
}