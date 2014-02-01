//Write a program that reads a number N and calculates the sum of the first N members of the sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …

using System;

    class SumOfTheFirstNOfFibonacci
    {
        static void Main()
        {
            int firstMember = 0, secondMember = 1, tmp,sum = 1;
            int n = int.Parse(Console.ReadLine());

            for (int i = 2; i <n; i++)
            {
                tmp = firstMember + secondMember;
                firstMember = secondMember;
                secondMember = tmp;
                sum +=tmp;
            }

            Console.WriteLine(sum);
        }
    }

