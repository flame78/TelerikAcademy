//Write program that asks for a digit and depending on the input shows the name of that digit (in English) using a switch statement.

using System;


    class NameOfDigit
    {
        static void Main()
        {
            byte digit=10;
            string input;

            while (digit == 10)
            {
                Console.Write("Enter Digit (0-9) = ");
                input = Console.ReadLine();

                if (!byte.TryParse(input, out digit)) digit = 10;
                if (digit < 0 || digit > 10 ) digit = 10;
            }

            switch (digit)
            {
                case 0:
                    Console.WriteLine("Zero");
                    break;
                case 1:
                    Console.WriteLine("One");
                    break;
                case 2:
                    Console.WriteLine("Two");
                    break;
                case 3:
                    Console.WriteLine("Three");
                    break;
                case 4:
                    Console.WriteLine("Four");
                    break;
                case 5:
                    Console.WriteLine("Five");
                    break;
                case 6:
                    Console.WriteLine("Six");
                    break;
                case 7:
                    Console.WriteLine("Seven");
                    break;
                case 8:
                    Console.WriteLine("Eight");
                    break;
                case 9:
                    Console.WriteLine("Nine");
                    break;

                default:
                    break;
            }
            
        }
    }

