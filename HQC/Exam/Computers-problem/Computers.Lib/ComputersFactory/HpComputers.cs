namespace Computers.Lib.ComputersFactory
{
    using System;
    using System.Collections.Generic;

    using Computers.Lib.Contracts;

    public class HpComputers : IComputersFactory
    {
        private const bool IsColor = true;

        private const bool IsMonochrome = false;

        private const int PcCpuCores = 2;

        private const int PcNumberOfBits = 32;

        private const int PcRam = 2;

        private const int PcHardDriveSize = 500;

        private const int LaptopCpuCores = 2;

        private const int LaptopNumberOfBits = 64;

        private const int LaptopRam = 4;

        private const int LaptopHardDriveSize = 500;

        private const int ServerCpuCores = 4;

        private const int ServerNumbersOfBits = 32;

        private const int ServerRam = 32;

        private const int ServerHardDriveSize = 1000;

        public Computer CreateComputer(ComputerType computerType)
        {
            if (computerType == ComputerType.PC)
            {
                return new Computer(
                    new Motherboard(PcCpuCores, PcNumberOfBits, new Ram(PcRam), new VideoCard(IsColor)), 
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