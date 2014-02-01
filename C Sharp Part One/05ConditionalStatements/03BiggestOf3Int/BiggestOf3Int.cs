//Write a program that finds the biggest of three integers using nested if statements.

using System;

class BiggestOf3Int
{
    static void Main()
    {
        int firstInt = 9, secondInt = 6, thirdInt = 15;

        if (firstInt > secondInt)
        {
            if (firstInt > thirdInt)
            {
                Console.WriteLine(firstInt);
            }
            else
            {
                Console.WriteLine(thirdInt);
            }
        }
        else if (secondInt > thirdInt)
        {
            Console.WriteLine(secondInt);
        }
        else
        {
            Console.WriteLine(thirdInt);
        }
    }
}

