//Write a program that reads two arrays from the console and compares them element by element.

using System;

class Program
{

    static void Main()
    {
        bool correctInput = false;
        int elements;

        do
        {
            Console.Write("Enter elements in Array's(integer>0):=");
            correctInput = int.TryParse(Console.ReadLine(), out elements);
            if (elements < 1) correctInput = false;

        } while (!correctInput);

        decimal[] array1 = new decimal[elements];
        decimal[] array2 = new decimal[elements];

        for (int i = 0; i < elements; i++)
        {
            correctInput = false;
            do
            {
                Console.Write("Enter element[{0}] in First Array(Decimal):=",i);
                correctInput = decimal.TryParse(Console.ReadLine(), out array1[i]);
            } while (!correctInput);
        }

        for (int i = 0; i < elements; i++)
        {
            correctInput = false;
            do
            {
                Console.Write("Enter element[{0}] in Second Array(Decimal):=",i);
                correctInput = decimal.TryParse(Console.ReadLine(), out array2[i]);
            } while (!correctInput);
        }

        for (int i = 0; i < elements; i++)
        {
            if (array1[i] == array2[i]) Console.WriteLine(array1[i]+"="+array2[i]);
            else if (array1[i] > array2[i]) Console.WriteLine(array1[i] + ">" + array2[i]);
            else if (array1[i] < array2[i]) Console.WriteLine(array1[i] + "<" + array2[i]);
        }



    }
}

