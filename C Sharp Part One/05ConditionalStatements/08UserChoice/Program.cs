//Write a program that, depending on the user's choice inputs int, double or string variable. If the variable is integer or double, increases it with 1. If the variable is string, appends "*" at its end. The program must show the value of that variable as a console output. Use switch statement.

using System;


class UserChoice
{
    static void Main()
    {
        string input;

        double userDouble = 0;
        int userInt = 0, userChoice = 0;
        bool correctInput = false;


        while (userChoice == 0)
        {
            Console.Write("Choice 1=Int,2=Double,3=String :");
            input = Console.ReadLine();

            int.TryParse(input, out userChoice);
            if (userChoice < 1 || userChoice > 3) userChoice = 0;
        }

        switch (userChoice)
        {
            case 1:
                while (!correctInput)
                {
                    Console.Write("Enter Int :");
                    input = Console.ReadLine();

                    correctInput = int.TryParse(input, out userInt);

                }
                Console.WriteLine(userInt + 1);
                break;
            case 2:
                while (!correctInput)
                {
                    Console.Write("Enter Double :");
                    input = Console.ReadLine();

                    correctInput = double.TryParse(input, out userDouble);

                }
                Console.WriteLine(userDouble + 1);
                break;
            case 3:
                Console.Write("Enter String :");
                input = Console.ReadLine();

                Console.WriteLine(input + "*");
                break;

            default:
                break;
        }

    }
}

