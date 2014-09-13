namespace Computers.Lib.ComputersFactory
{
    using System;
    using System.Collections.Generic;

    using Computers.Lib.Contracts;

    public class LenovoComputers : IComputersFactory
    {
        private const bool IsColor = true;

        private const bool IsMonochrome = false;

        private const int PcCpuCores = 2;

        private const int PcNumberOfBits = 64;

        private const int PcRam = 4;

        private const int PcHardDriveSize = 2000;

        private const int LaptopCpuCores = 2;

        private const int LaptopNumberOfBits = 64;

        private const int LaptopRam = 16;

        private const int LaptopHardDriveSize = 1000;

        private const int ServerCpuCores = 2;

        private const int ServerNumbersOfBits = 128;

        private const int ServerRam = 8;

        private const int ServerHardDriveSize = 500;

        public Computer CreateComputer(ComputerType computerType)
        {
            if (computerType == ComputerType.PC)
            {
                return
                    new Computer(
                        new Motherboard(PcCpuCores, PcNumberOfBits, new Ram(PcRam), new VideoCard(IsMonochrome)), 
                        new[] { new HardDriver(PcHardDriveSize, false, 0) });
            }

            if (computerType == ComputerType.SERVER)
            {
                return
                    new Computer(
                        new Motherboard(
                            ServerCpuCores, 
                            ServerNumbersOfBits, 
                            new Ram(ServerRam), 
                            new VideoCard(IsMonochrome)), 
                        new List<HardDriver>
                            {
                                new HardDriver(
                                    0, 
                                    true, 
                                    2, 
                                    new List<HardDriver>
                                        {
                                            new HardDriver(
                                                ServerHardDriveSize, 
                                                false, 
                                                0), 
                                            new HardDriver(
                                                ServerHardDriveSize, 
                                                false, 
                                                0)
                                        })
                            });
            }

            if (computerType == ComputerType.LAPTOP)
            {
                return
                    new Computer(
                        new Motherboard(LaptopCpuCores, LaptopNumberOfBits, new Ram(LaptopRam), new VideoCard(IsColor)), 
                        new[] { new HardDriver(LaptopHardDriveSize, false, 0) }, 
                        new Battery());
            }

            throw new ArgumentOutOfRangeException("computerType", "Invalid Computer Type");
        }
    }
}