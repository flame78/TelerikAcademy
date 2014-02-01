//14 Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers. Use variable number of arguments.
//15 * Modify your last program and try to make it work for any number type, not just integer (e.g. decimal, float, byte, etc.). Use generic method (read in Internet about generic methods in C#).

using System;

class MinMaxAvgSumProduct
{
    static T FindMax<T>(params T[] arr)
    {
        dynamic biggestNum = arr[0];
        int length = arr.Length;
        for (int i = 0; i < length; i++)
        {
            if (length > 0)
            {
                if (arr[i] > biggestNum)
                {
                    biggestNum = arr[i];
                }
            }
            else
            {
                return default(T);
            }
        }
        return biggestNum;
    }

    static T FindMin<T>(params T[] arr)
    {
        dynamic smallest = arr[0];
        int length = arr.Length;
        for (int i = 0; i < length; i++)
        {
            if (length > 0)
            {
                if (arr[i] < smallest)
                {
                    smallest = arr[i];
                }
            }
            else
            {
                return default(T);
            }
        }
        return smallest;
    }

    static T FindAvg<T>(params T[] arr)
    {
        dynamic counter = 0;
        dynamic sum = 0;
        dynamic sumAvg = 0;
        foreach (var number in arr)
        {
            sum = sum + number;
            counter++;
        }
        sumAvg = sum / counter;
        return sumAvg;
    }

    static T FindSum<T>(params T[] arr)
    {
        dynamic sum = 0;
        foreach (var number in arr)
        {
            sum += number;
        }
        return sum;
    }
    static T FindProduct<T>(params T[] arr)
    {
        dynamic product = 1;
        foreach (var number in arr)
        {
            product *= number;
        }
        return product;
    }
    static void Main()
    {
        Console.WriteLine("Min={0}", FindMin('a','b', 'c', 'd'));
        Console.WriteLine("Max={0}", FindMax(1, 2, 3, 4.0000004m));
        Console.WriteLine("Avg={0}", FindAvg(1d, 2d, 3d, 4d));
        Console.WriteLine("Sum={0}", FindSum(1L, 2L, 3L, 4L));
        Console.WriteLine("Product={0}", FindProduct(1, 2, 3, 4));
        Console.WriteLine();
    }
}