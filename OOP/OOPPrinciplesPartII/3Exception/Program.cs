﻿/* Define a class InvalidRangeException<T> that holds information about an error condition 
 * related to invalid range. It should hold error message and a range definition [start … end].
 * Write a sample application that demonstrates the InvalidRangeException<int> and 
 * InvalidRangeException<DateTime> by entering numbers in the range [1..100] and dates in 
 * the range [1.1.1980 … 31.12.2013]. */
using System;

    class GenericRangeException
    {
        static void Main()
        {
            {
                try
                {
                    int rangeStart = 10;
                    int rangeEnd = 155;

                    int variableToCheck = 200;

                    if (!(rangeStart < variableToCheck && variableToCheck < rangeEnd))
                        throw new InvalidRangeException<int>(rangeStart, rangeEnd);
                }

                catch (InvalidRangeException<int> iRError)
                {
                    Console.WriteLine(iRError.Message);
                    Console.WriteLine("Start: {0}; End {1};", iRError.Start, iRError.End);
                }
            }
            Console.WriteLine("Date check:");
            {
                try
                {
                    DateTime startDate = new DateTime(1984, 08, 17);
                    DateTime endDate = new DateTime(2215, 12, 31);

                    DateTime dateToCheck = DateTime.MinValue;

                    if (!(startDate < dateToCheck && dateToCheck < endDate))
                        throw new InvalidRangeException<DateTime>(startDate, endDate);
                }

                catch (InvalidRangeException<DateTime> iRError)
                {
                    Console.WriteLine(iRError.Message);
                    Console.WriteLine("Start: {0}; End {1};", iRError.Start, iRError.End);
                }
            }
        }
    }
