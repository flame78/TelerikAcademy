﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using WarMachines.Engine;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidateConsoleOutput()
        {

            using (StringWriter sw = new StringWriter())
            {
                using (StringReader inp = new StringReader(@"HirePilot John
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

"))
                {
                    Console.SetOut(sw);
                    Console.SetIn(inp);

                    WarMachineEngine.Instance.Start();

                    string expected = "asd";

                    string outp = sw.ToString();

                    Assert.AreEqual<string>(expected, expected+1);
                }
            }
        }
    }
}
