//Write a method that returns the last digit of given integer as an English word. Examples: 512  "two", 1024  "four", 12309  "nine".

using System;

class Program
{
    static void Main()
    {
        int value = int.Parse(Console.ReadLine());
        Console.WriteLine(LastDigitOfInteger(value));
    }

    private static string LastDigitOfInteger(int value)
    {
        string lastDig = value.ToString();
        lastDig = lastDig.Substring(lastDig.Length - 1, 1);

        switch (lastDig)
        {
            case "0":
                return "zero";
            case "1":
                return "one";
            case "2":
                return "two";
            case "3":
                return "three";
            case "4":
                return "four";
            case "5":
                return "five";
            case "6":
                return "six";
            case "7":
                return "seven";
            case "8":
                return "eight";
            case "9":
                return "nine";
            default:
                return "";
        }

    }
}

