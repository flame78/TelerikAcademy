//Sort 3 real values in descending order using nested if statements.

using System;

class Sort3RealNum
{
    static void Main()
    {
        double firstNum = 7, secondNum = 5, thirdNum = 9;

        if (firstNum > secondNum)               // 1 2 3
        {
            if (secondNum > thirdNum)
            {
                Console.WriteLine(firstNum);
                Console.WriteLine(secondNum);
                Console.WriteLine(thirdNum);
            }
        }
        if (firstNum > thirdNum)                // 1 3 2
        {
            if (secondNum < thirdNum)
            {
                Console.WriteLine(firstNum);
                Console.WriteLine(thirdNum);
                Console.WriteLine(secondNum);
            }
        }

        if (firstNum < secondNum)               // 2 1 3
        {
            if (firstNum > thirdNum)
            {
                Console.WriteLine(secondNum);
                Console.WriteLine(firstNum);
                Console.WriteLine(thirdNum);
            }
        }
        if (thirdNum < secondNum)               // 2 3 1
        {
            if (firstNum < thirdNum)
            {
                Console.WriteLine(secondNum);
                Console.WriteLine(thirdNum);
                Console.WriteLine(firstNum);
            }
        }
        if (thirdNum > secondNum)               // 3 2 1
        {
            if (firstNum < secondNum)
            {
                Console.WriteLine(thirdNum);
                Console.WriteLine(secondNum);
                Console.WriteLine(firstNum);
            }
        }

        if (thirdNum > firstNum)               // 3 1 2
        {
            if (firstNum > secondNum)
            {
                Console.WriteLine(thirdNum);
                Console.WriteLine(firstNum);
                Console.WriteLine(secondNum);
            }
        }

    }
}


