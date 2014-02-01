//Write a program that calculates the greatest common divisor (GCD) of given two numbers. Use the Euclidean algorithm (find it in Internet).

using System;

class EuclideanAlgorithm
{
    static void Main(string[] args)
    {

        int numberA = int.Parse(Console.ReadLine());
        int numberB = int.Parse(Console.ReadLine());
        int tmp;

        while (numberB != 0)
        {
            tmp = numberB;
            numberB = numberA % numberB;
            numberA = tmp;
        }


        //while (numberA != numberB)
        //{
        //    if (numberA > numberB) 
        //        numberA = numberA - numberB;
        //    else 
        //        numberB = numberB - numberA;
        //}

        Console.WriteLine(numberA);
    }
}
