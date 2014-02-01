//Write a program that sorts an array of strings using the quick sort algorithm (find it in Wikipedia).

using System;
using System.Collections.Generic;

class QuickSortAlgorith
{
    static void Main()
    {
        Console.Write("Enter String Array separated with space(expample: Write a program that sorts an array of strings using the quick sort algorithm) : ");

        string[] ar = Console.ReadLine().Split(' ');

        List<string> array = new List<string>(ar);


        //foreach (var str in array)
        //{
        //    Console.WriteLine(str);
        //}

        //Console.WriteLine("------------------");

        List<string> sortedArray = QuickSort(array);

        foreach (var str in sortedArray)
        {
            Console.WriteLine(str);
        }
    }

    static List<string> QuickSort(List<string> array)
    {
        if (array.Count <= 1)
        {
            return array;
        }

        string pivot = array[array.Count / 2];
        List<string> less = new List<string>();
        List<string> greater = new List<string>();

        for (int i = 0; i < array.Count; i++)
        {
            if (i != (array.Count / 2))
            {
                if (CompareString(array[i], pivot))
                {
                    less.Add(array[i]);
                }
                else
                {
                    greater.Add(array[i]);
                }
            }
        }

        return ConcatenateArrays(QuickSort(less), pivot, QuickSort(greater));
    }

    static List<string> ConcatenateArrays(List<string> less, string pivot, List<string> greater)
    {
        List<string> result = new List<string>();

        for (int i = 0; i < less.Count; i++)
        {
            result.Add(less[i]);
        }

        result.Add(pivot);

        for (int i = 0; i < greater.Count; i++)
        {
            result.Add(greater[i]);
        }

        return result;
    }
    
    static bool CompareString(string s1, string s2)
    {
        int length, shortestArray = 1;
        if (s1.Length < s2.Length)
        {
            length = s1.Length;
            shortestArray = 1;
        }
        else
        {
            length = s2.Length;
            shortestArray = 2;
        }

        for (int i = 0; i < length; i++)
        {

            if (s1[i] < s2[i])
                return true;
            else if (s1[i] > s2[i])
            {
                return false;

            }

            if (i == length - 1 && shortestArray == 2)
                return false;

        }
        return true;
    }

}

