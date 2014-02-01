//Write a program that prints all possible cards from a standard deck of 52 cards (without jokers). The cards should be printed with their English names. Use nested for loops and switch-case.

using System;

class PrintAllPossibleCards
{
    static void Main()
    {
        for (int i = 1; i <= 4; i++)
        {
            for (int i2 = 1; i2 <= 13; i2++)
            {
              

                switch (i2)
                {

                    case 1:
                        Console.Write("Ace");
                        break;
                    case 2:
                        Console.Write("2");
                        break;
                    case 3:
                        Console.Write("3");
                        break;
                    case 4:
                        Console.Write("4");
                        break;
                    case 5:
                        Console.Write("5");
                        break;
                    case 6:
                        Console.Write("6");
                        break;
                    case 7:
                        Console.Write("7");
                        break;
                    case 8:
                        Console.Write("8");
                        break;
                    case 9:
                        Console.Write("9");
                        break;
                    case 10:
                        Console.Write("10");
                        break;
                    case 11:
                        Console.Write("Jack");
                        break;
                    case 12:
                        Console.Write("Queen");
                        break;
                    case 13:
                        Console.Write("King");
                        break;


                    default:
                        break;
                }
                switch (i)
                {
                    case 1:
                        Console.WriteLine(" Club");
                        break;
                    case 2:
                        Console.WriteLine(" Diamond");
                        break;
                    case 3:
                        Console.WriteLine(" Heart");
                        break;
                    case 4:
                        Console.WriteLine(" Spade");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
