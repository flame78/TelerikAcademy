// Write a program that finds the maximal sequence of equal elements in an array.
//		Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1}  {2, 2, 2}.

using System;

class Program
{

    static void Main()
    {
        bool correctInput = false;
        int elements;//,sequenceOfEqualElements=0;
        int? maxElement=null,maxSequence=null;

        do
        {
            Console.Write("Enter elements in Array(integer>0):=");
            correctInput = int.TryParse(Console.ReadLine(), out elements);
            if (elements < 1) correctInput = false;

        } while (!correctInput);

        int[] array1 = new int[elements];

        for (int i = 0; i < elements; i++)
        {
            correctInput = false;
            do
            {
                Console.Write("Enter element[{0}] in Array(integer):=", i);
                correctInput = int.TryParse(Console.ReadLine(), out array1[i]);
            } while (!correctInput);
        }

       
        for (int i = 1; i < elements; i++)
        {
            if (array1[i] == array1[i - 1])
            {
                if (i == elements - 1)
                {
                    if (maxSequence == null) { maxSequence = 2; maxElement = array1[i - 1]; }
                    else if (maxSequence < 2) { maxSequence = 2; maxElement = array1[i - 1]; }
                    break;
                }
                for (int i2 = i + 1; i2 < elements; i2++)
                {
                    if (array1[i2] != array1[i2 - 1])
                    {
                        if (maxSequence == null) { maxSequence = i2 - i + 1; maxElement = array1[i2 - 1]; }
                        else if (maxSequence < (i2 - (i - 1))) { maxSequence = i2 - i + 1; maxElement = array1[i2 - 1]; }
                        i=i2-1;
                        break;
                    }
                    else if (i2==elements-1)
                    {
                        if (maxSequence == null) { maxSequence = i2 - i + 2; maxElement = array1[i2 - 1]; }
                        else if (maxSequence < (i2 - (i - 2))) { maxSequence = i2 - i + 2; maxElement = array1[i2 - 1]; }
                        i = i2;
                        break;
                    }
                }
            }
        }

        for (int i = 0; i < maxSequence; i++)
        {
            Console.Write(maxElement);
            if (i<maxSequence-1) Console.Write(",");
        }
        Console.WriteLine();


    }
}

