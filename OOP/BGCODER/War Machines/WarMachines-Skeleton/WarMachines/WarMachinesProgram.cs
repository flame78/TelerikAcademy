﻿using System;
using WarMachines.Interfaces;
using WarMachines.Machines;

namespace WarMachines
{
    using System.IO;
    using WarMachines.Engine;

    public class WarMachinesProgram
    {
        public static void Main()
        {
            using (StringWriter sw = new StringWriter())
            {
                var inp = new StringReader(@"HirePilot John
HirePilot Nelson
Report Bender
ManufactureTank T-72 100 100
ManufactureFighter Kingcobra 150 90 StealthON
Report John
Engage John T-72
Engage John Kingcobra
Report John
Report Nelson
Engage Nelson T-72
Engage Nelson Kingcobra
ManufactureFighter Boeing 180 90 StealthOFF
Engage Nelson Boeing
Attack T-72 Kingcobra
Attack T-72 Boeing
DefenseMode T-72
DefenseMode Kingcobra
DefenseMode Boeing
Attack T-72 Kingcobra
Attack T-72 Boeing
StealthMode Kingcobra
StealthMode Boeing
StealthMode T-72
Attack Kingcobra T-72
Attack Boeing T-72
Report Nelson
Report John
");
                //Console.SetIn(inp);
                //Console.SetOut(sw);
                WarMachineEngine.Instance.Start();

              //  StreamWriter standardOut =new StreamWriter(Console.OpenStandardOutput());
              //  standardOut.AutoFlush = true;
              //  Console.SetOut(standardOut);
               

              ////  var str = sw.ToString();
              //  Console.WriteLine(sw.ToString());
            }
        }
    }
}
