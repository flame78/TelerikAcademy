//Write a method that reverses the digits of given decimal number. Example: 256  652

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter decimal number:");
        decimal dec = decimal.Parse(Console.ReadLine());
        Console.WriteLine(ReverseDecimal(dec));
    }

    private static decimal ReverseDecimal(decimal dec)
    {
        string decStr = dec.ToString();
        string tmp = "";
        for (int i = decStr.Length - 1; i >= 0; i--)
        {
            tmp += decStr[i];
        }
        return decimal.Parse(tmp);
    }
}

