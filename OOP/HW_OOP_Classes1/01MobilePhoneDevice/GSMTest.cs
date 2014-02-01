//7. Write a class GSMTest to test the GSM class:
//Create an array of few instances of the GSM class.
//Display the information about the GSMs in the array.
//Display the information about the static property IPhone4S.

using System;
using _01MobilePhoneDevice;
using System.Collections.Generic;

namespace _01MobilePhoneDevice
{
    class GSMTest
    {
       
        static void Main()
        {

            List<GSM> arrGSM=new List<GSM>();

            arrGSM.Add(new GSM("Blade", "ZTE"));
            arrGSM.Add(new GSM("Blade", "ZTE",80,"Macko Piskov","BL3-E",240,4,Battery.BatteryType.LiIon,3.5,Display.ColorDepth._16Bit));
            arrGSM.Add(GSM.IPhone4S);


            foreach (var item in arrGSM)
            {
                Console.WriteLine(item);
            }

            
            Console.WriteLine("\n--------------->Call GSMCallHistoryTest.Test()\n");
            

            GSMCallHistoryTest.Test();
        }
    }
}
