// Write a method that calculates the number of workdays between today and given date, passed as parameter. Consider that workdays are all days from Monday to Friday except a fixed list of public holidays specified preliminary as array.

using System;

class NumberOfWorkdays
{
    public static void Main()
    {
        Console.Write("Enter a end date in YYYY/MM/DD format: ");
        string[] endDateStr = Console.ReadLine().Split('/');
        int day = int.Parse(endDateStr[2]);
        int month = int.Parse(endDateStr[1]);
        int year = int.Parse(endDateStr[0]);

        DateTime startDay = DateTime.Today;
        DateTime endDay = new DateTime(year, month, day);
        int timeLen = 0;

        if (startDay > endDay)
        {
            startDay = endDay;
            endDay = DateTime.Today;
        }
        timeLen = (endDay - startDay).Days;

        DateTime[] holidays = 
        { 
            new DateTime(2014, 3, 3), 
            new DateTime(2014, 4, 18), 
            new DateTime(2014, 5, 1), 
            new DateTime(2014, 5, 2), 
            new DateTime(2014, 5, 5), 
            new DateTime(2014, 5, 6),
            new DateTime(2014, 9, 22)
        };

        int workDayCounter = 0;
        bool isHoliday = false;


        for (int i = 0; i < timeLen; i++)
        {
            startDay = startDay.AddDays(1);
            if (startDay.DayOfWeek != DayOfWeek.Sunday && startDay.DayOfWeek != DayOfWeek.Saturday)
            {
                for (int j = 0; j < holidays.Length; j++)
                {
                    if (startDay == holidays[j])
                    {
                        isHoliday = true;
                        break;
                    }
                }

                if (!isHoliday)
                {
                    workDayCounter++;
                }

                isHoliday = false;
            }
        }

        Console.WriteLine(workDayCounter);
    }
}

