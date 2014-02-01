//Write a program that, for a given two integer numbers N and X, calculates the sum
//S = 1 + 1!/X + 2!/X2 + … + N!/XN

using System;
using System.Numerics;

class SumAndFactorial
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int x = int.Parse(Console.ReadLine());
        BigInteger nFactorial = 1, sum=1;

        for (int i = 1; i <= n; i++)
        {
            nFactorial *= i;
            sum += nFactorial / x * i;
        }

        Console.WriteLine(sum);
    }
}
