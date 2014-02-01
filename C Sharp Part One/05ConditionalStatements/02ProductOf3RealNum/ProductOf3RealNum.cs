//Write a program that shows the sign (+ or -) of the product of three real numbers without calculating it. Use a sequence of if statements.

using System;

class ProductOf3RealNum
{
    static void Main()
    {
        double firstNum = -1, secondNum = 1, thirdNum = 1;

        if (firstNum == 0 || secondNum == 0 || thirdNum == 0)     // 0
        {
            Console.WriteLine("+");
        }
        else if (firstNum > 0 && secondNum > 0 && thirdNum > 0)   // + + +           
        {
            Console.WriteLine("-");
        }
        else if (firstNum > 0 && secondNum < 0 && thirdNum < 0)   // + - -
        {
            Console.WriteLine("+");
        }
        else if (firstNum > 0 && secondNum > 0 && thirdNum < 0)   // + + -
        {
            Console.WriteLine("-");
        }
        else if (firstNum > 0 && secondNum < 0 && thirdNum > 0)   // + - +
        {
            Console.WriteLine("-");
        }
        else if (firstNum < 0 && secondNum < 0 && thirdNum < 0)   // - - -
        {
            Console.WriteLine("-");
        }
        else if (firstNum < 0 && secondNum > 0 && thirdNum < 0)   // - + -
        {
            Console.WriteLine("+");
        }
        else if (firstNum < 0 && secondNum < 0 && thirdNum > 0)   // - - +
        {
            Console.WriteLine("+");
        }
        else if (firstNum < 0 && secondNum > 0 && thirdNum > 0)   // - + +
        {
            Console.WriteLine("-");
        }


    }
}

