//Write a program that reads a year from the console and checks whether it is a leap. Use DateTime.

using System;

namespace LeapYear
{
    class LeapYear
    {
        static void Main()
        {
            int year;
            Console.Write("Enter year = ");
            int.TryParse(Console.ReadLine(),out year);

            if (DateTime.IsLeapYear(year))
                Console.WriteLine("Year {0} is leap",year);
            else
                Console.WriteLine("Year {0} is not leap", year);
        }
    }
}
