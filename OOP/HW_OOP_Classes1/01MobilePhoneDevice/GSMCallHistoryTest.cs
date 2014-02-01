//12. Write a class GSMCallHistoryTest to test the call history functionality of the GSM class.
//Create an instance of the GSM class.
//Add few calls.
//Display the information about the calls.
//Assuming that the price per minute is 0.37 calculate and print the total price of the calls in the history.
//Remove the longest call from the history 
//and calculate the total price again.
//Finally clear the call history and print it.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _01MobilePhoneDevice;

namespace _01MobilePhoneDevice
{
    class GSMCallHistoryTest
    {
        internal static void Test()
        {
            GSM testGSM = new GSM("Blade", "ZTE", 80, "Macko Piskov", "BL3-E", 240, 4, Battery.BatteryType.LiIon, 3.5, Display.ColorDepth._16Bit);

            testGSM.AddCallToHistory(DateTime.Now, "112", 60);
            testGSM.AddCallToHistory(DateTime.Now, "116", 120);
            testGSM.AddCallToHistory(DateTime.Now, "180", 30);

            testGSM.PrintCallHistory();
            Console.WriteLine("\nPrice of all calls at {0:C} per minute is {1:C}\n", 0.37, testGSM.PriceOfCalls(0.37M));

//Remove the longest call from the history 
            int longestCall=0, longestCallIndex=0;

            for (int i = 0; i < testGSM.CallHistoryCount()-1; i++)
            {
                int callDuration = testGSM[i, Call.Element.CallDuration];
                if (callDuration>longestCall)
                {
                    longestCall=callDuration;
                    longestCallIndex=i;
                }
            }

         

            testGSM.RemoveCallFromHistory(longestCallIndex);
            testGSM.PrintCallHistory();
            Console.WriteLine("\nPrice of all calls at {0:C} per minute is {1:C}\n", 0.37, testGSM.PriceOfCalls(0.37M));

            testGSM.ClearCallHistory();
            Console.WriteLine("Start Print cleared History");
            testGSM.PrintCallHistory();
            Console.WriteLine("End Print cleared History");
        }
    }
}
