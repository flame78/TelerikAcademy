// Write a program that finds the maximal increasing sequence in an array. 
// Example: {3, 2, 3, 4, 2, 2, 4}  {2, 3, 4}.


using System;

class Program
{

    static void Main()
    {
  
        int elements,firstInSequence=0,lastInSequence=0;
        string input;
      
        Console.Write("Enter Array(Example:3, 2, 3, 4, 2, 2, 4):");

        input = Console.ReadLine();
        
        string[] tokens = input.Split(',');

        elements=tokens.Length;

        int[] array1= new int[elements];

        for (int i = 0; i < tokens.Length; i++)
        {
            array1[i] = int.Parse(tokens[i]);
        }
        

        for (int fis = 0; fis < elements - 1; fis++)
        {
            if (array1[fis]==array1[fis+1]-1)
            {
                for (int lis = fis+1; lis < elements-1; lis++)
                {
                    if(array1[lis]!=array1[lis+1]-1)
                    {
                        if(lastInSequence - firstInSequence<lis-fis)
                        {
                            lastInSequence = lis;
                            firstInSequence = fis;
                            fis = lis + 1;
                            break;
                        }
                    }
                    if (lis==elements-2)
                    {
                        if (lastInSequence - firstInSequence < lis - fis)
                        {
                            lastInSequence = elements - 1;
                            firstInSequence = fis;
                            fis = lastInSequence;
                            break;
                        }
                    }
                }
            }
        }

        for (int i = firstInSequence; i <= lastInSequence; i++)
        {
            Console.Write(array1[i]);
            if (i != lastInSequence) Console.Write(", ");
            
        }
        Console.WriteLine();
    }
}

