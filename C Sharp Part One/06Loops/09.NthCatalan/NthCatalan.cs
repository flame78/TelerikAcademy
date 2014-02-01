//Write a program to calculate the Nth Catalan number by given N.

using System;
using System.Numerics;

    class NthCatalan
    {
        static void Main()
        {
            int numberN = int.Parse(Console.ReadLine());
        
            BigInteger nMultp2Factorial = 1, nFactorial = 1, nPlus1Factorial = 1;

            for (int i = 1; i <= numberN*2; i++)
            {
                nMultp2Factorial *= i;
                if (i == numberN + 1) nPlus1Factorial = nMultp2Factorial;
                if (i == numberN) nFactorial = nMultp2Factorial;
            }

            Console.WriteLine(nMultp2Factorial /(nPlus1Factorial *nFactorial));
        }
    }

