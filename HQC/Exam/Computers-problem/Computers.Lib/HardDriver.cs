namespace Computers.Lib
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HardDriver
    {
        private readonly int capacity;

        private readonly Dictionary<int, string> data;

        private readonly List<HardDriver> hds;

        private readonly bool isInRaid;

        private int hardDrivesInRaid;

        private SortedDictionary<int, string> info;

        public HardDriver()
        {
        }

        public HardDriver(int capacity, bool isInRaid, int hardDrivesInRaid)
        {
            this.isInRaid = isInRaid;
            this.hardDrivesInRaid = hardDrivesInRaid;

            this.capacity = capacity;
            this.data = new Dictionary<int, string>(capacity);

            this.hds = new List<HardDriver>();
        }

        public HardDriver(int capacity, bool isInRaid, int hardDrivesInRaid, List<HardDriver> hardDrives)
        {
            this.isInRaid = isInRaid;
            this.hardDrivesInRaid = hardDrivesInRaid;
            this.capacity = capacity;

            this.data = new Dictionary<int, string>(capacity);
            this.hds = new List<HardDriver>();
            this.hds = hardDrives;
        }

        private int Capacity
        {
            get
            {
                if (this.isInRaid)
                {
                    if (!this.hds.Any())
                    {
                        return 0;
                    }

                    return this.hds.First().Capacity;
                }

                return this.capacity;
            }
        }

        private void SaveData(int addr, string newData)
        {
            if (this.isInRaid)
            {
                foreach (var hardDrive in this.hds)
                {
                    hardDrive.SaveData(addr, newData);
                }
            }
            else
            {
                this.data[addr] = newData;
            }
        }

        private string LoadData(int address)
        {
            if (this.isInRaid)
            {
                if (!this.hds.Any())
                {
                    throw new OutOfMemoryException("No hard drive in the RAID array!");
                }

                return this.hds.First().LoadData(address);
            }

            if (true)
            {
                return this.data[address];
            }
        }
    }
}