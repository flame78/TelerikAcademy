using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    class Pilot : IPilot
    {
        private string name;
        private List<IMachine> machines;

        internal Pilot(string name)
        {
            this.name = name;
            this.machines= new List<IMachine>();
        }
        public string Name
        {
            get { return this.name; }
        }

        public void AddMachine(IMachine machine)
        {
           this.machines.Add(machine);
        }

        public string Report()
        {
           StringBuilder result = new StringBuilder();

            result.Append(this.name);
            result.Append(" - ");
            if (machines.Count() == 0) result.Append("no");
            else result.Append(machines.Count());
            if (machines.Count() != 1) result.Append(" machines\r\n");
            else result.Append(" machine\r\n");


            foreach (var machine in machines)
            {
                result.Append(machine);
                result.Append("\r\n");
            }
            result.Remove(result.Length - 1, 1);

            return result.ToString();
        }
    }
}
