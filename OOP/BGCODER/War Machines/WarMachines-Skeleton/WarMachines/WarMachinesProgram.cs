using System;
using WarMachines.Interfaces;
using WarMachines.Machines;

namespace WarMachines
{
    using WarMachines.Engine;

    public class WarMachinesProgram
    {
        public static void Main()
        {
           WarMachineEngine.Instance.Start();
        }
    }
}
