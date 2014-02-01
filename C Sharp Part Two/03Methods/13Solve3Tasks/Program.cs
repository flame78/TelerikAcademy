// Write a program that can solve these tasks:
//Reverses the digits of a number
//Calculates the average of a sequence of integers
//Solves a linear equation a * x + b = 0
//        Create appropriate methods.
//        Provide a simple text-based menu for the user to choose which task to solve.
//        Validate the input data:
//The decimal number should be non-negative
//The sequence should not be empty
//a should not be equal to 0

using System;


class Solve3Tasks
{
    static void ReverseDigit()
    {
        Console.Write("Enter number:");
        string input = Console.ReadLine();
        decimal n;
       
        if (decimal.TryParse(input, out n) && n >= 0)
        {
            string output = "";
            for (int i = input.Length-1; i >=0 ; i--)
            {
                output += input[i];
            }
            Console.Write("The number in reverse is:"+output);
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("The input number should be non-negative decimal");
        }


    }

    static void CalculateAvgSum()
    {
        string nStr = string.Empty;
        decimal n;
        string stop = "STOP";
        decimal counter = 0;
        decimal sum = 0;

        Console.WriteLine("Enter your sequence of numbers");
        Console.WriteLine("When you finish write \"stop\"");
        nStr = Console.ReadLine();
        if (nStr != string.Empty)
        {
            while (nStr != stop)
            {
                nStr = Console.ReadLine();
                if (nStr.Equals(stop, StringComparison.OrdinalIgnoreCase))
                {
                    if (nStr == string.Empty)
                    {
                        Console.WriteLine("Input can NOT be Empty String");
                    }
                    break;
                }
                if (decimal.TryParse(nStr, out n))
                {
                    counter++;
                    sum = sum + n;
                }
            }
            decimal avgSum = sum / counter;
            Console.WriteLine("Avg={0:F2}", avgSum);
            Console.WriteLine();
        }
    }

    static void SolveLinearEq()
    {

        Console.Write("a=");
        decimal a = decimal.Parse(Console.ReadLine());
        if (a != 0)
        {
            Console.Write("b=");
            decimal b = decimal.Parse(Console.ReadLine());
            decimal x = - b / a;
            Console.WriteLine();
            Console.WriteLine("a * x + b = 0");
            Console.WriteLine("x={0}", x);
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Input 'a' can NOT be Zero!");
        }

    }
    static void PrintMenu()
    {
        Console.WriteLine("                      MENU:");
        Console.WriteLine();
        Console.WriteLine("*** Press 1 *** Reverses the digits of a number ");
        Console.WriteLine("*** Press 2 *** Calculates the average of a sequence of integers ");
        Console.WriteLine("*** Press 3 *** Solves a linear equation a * x + b = 0 ");
        Console.Write("Menu:");
        int menu = int.Parse(Console.ReadLine());
        if (menu == 1)
        {
            ReverseDigit();
        }
        else if (menu == 2)
        {
            CalculateAvgSum();
        }
        else if (menu == 3)
        {
            SolveLinearEq();
        }
        else
        {
            Console.WriteLine("Invalid MENU OPTION!");
        }
    }
    static void Main()
    {
        PrintMenu();
    }
}
