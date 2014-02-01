using System;

// Write an expression that checks if given positive integer number n (n ≤ 100) is prime. E.g. 37 is prime

class PrimeNumber
{
    static void Main()
    {
        uint n;
        bool isPrime=true;
        string strNum=" ";

        while (!uint.TryParse(strNum, out n) || (n>100))
        {
            Console.Write("Enter positive integer number (n ≤ 100) n =");
            strNum = Console.ReadLine();
        }

        for (uint i = 2; i < n ; i++)
        {
            if (0 == n % i)
            {
                isPrime = false;
                break;
            }
        }

        Console.WriteLine("{0} is " + (isPrime?"":"not ")+"prime.",n);
    }
}

