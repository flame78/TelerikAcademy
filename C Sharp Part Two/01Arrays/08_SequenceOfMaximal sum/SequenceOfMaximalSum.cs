//Write a program that finds the sequence of maximal sum in given array. Example:
//	{2, 3, -6, -1, 2, -1, 6, 4, -8, 8}  {2, -1, 6, 4}
//	Can you do it with only one loop (with single scan through the elements of the array)?

using System;

    class SequenceOfMaximalSum
    {
        static void Main()
        {
            string input;
            int length, sum=0,maxSum=0,maxSumfirstElement=0;
            int maxSumLastElement=0,sumFirstElement=0;
            

            Console.Write("Enter Array(Example:3, 2, 3, 4, 2, 2, 4):");

            input = Console.ReadLine();

            string[] tokens = input.Split(',');

            length = tokens.Length;

            int[] array = new int[length];

            
            for (int i = 0; i < tokens.Length; i++)
            {
                array[i] = int.Parse(tokens[i]);

                if (sum + array[i] >= 0)
                {
                    sum += array[i];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxSumLastElement = i;
                        maxSumfirstElement = sumFirstElement;
                    }
                }
                else
                {
                    sum = 0;
                    sumFirstElement = i + 1;
                }
            }

            int[] subArray=new int[maxSumLastElement - maxSumfirstElement+1];
            Array.Copy(array, maxSumfirstElement, subArray,0, maxSumLastElement - maxSumfirstElement+1);

            Console.WriteLine(String.Join(", ",subArray));
        }
    }

