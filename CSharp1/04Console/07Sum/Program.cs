//Write a program that gets a number n and after that gets more n numbers and calculates and prints their sum. 

using System;

class Sum
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        decimal sum = 0;

        for (int i = 1; i <= n; i++)
        {
            sum += decimal.Parse(Console.ReadLine());
        }

        Console.WriteLine(sum);
    }
}
