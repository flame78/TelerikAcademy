//Write a program that reads an integer number and calculates and prints its square root. If the number is invalid or negative, print "Invalid number". In all cases finally print "Good bye". Use try-catch-finally.

using System;

class CalculateSquareRoot
{
    static void Main()
    {
        try
        {
            Console.Write("Enter integer number: ");
            int number = int.Parse(Console.ReadLine());
            if (number < 0)
            {
                throw new FormatException();
            }
            Console.WriteLine(Math.Sqrt(number));
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Invalid number!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid number!");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Invalid number!");
        }
        catch (Exception)
        {
            Console.WriteLine("Unexpected error!");
        }
        finally
        {
            Console.WriteLine("Good bye!");
        }
    }
}