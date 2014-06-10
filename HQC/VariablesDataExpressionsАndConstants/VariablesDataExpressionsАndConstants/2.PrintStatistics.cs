using System.Collections.Generic;

public static class Statistics
{
    public void Print(IList<double> numbers, int count)
    {
        this.PrintMax(this.Max(numbers, count));
        this.PrintMin(this.Min(numbers, count));
        this.PrintAvg(this.Average(numbers, count));
    }

    private void PrintMax(double max)
    {
        throw new System.NotImplementedException();
    }

    private void PrintMin(double min)
    {
        throw new System.NotImplementedException();
    }

    private void PrintAvg(double average)
    {
        throw new System.NotImplementedException();
    }

    private double Max(IList<double> numbers, int count)
    {
        var max = numbers[0];

        for (var i = 0; i < count; i++)
        {
            if (numbers[i] > max)
            {
                max = numbers[i];
            }
        }

        return max;
    }

    private double Min(IList<double> numbers, int count)
    {
        var min = numbers[0];

        for (var i = 0; i < count; i++)
        {
            if (numbers[i] > min)
            {
                min = numbers[i];
            }
        }

        return min;
    }

    private double Sum(IList<double> numbers, int count)
    {
        var sum = 0d;

        for (var i = 0; i < count; i++)
        {
            sum += numbers[i];
        }

        return sum;
    }

    private double Average(IList<double> numbers, int count)
    {
        var average = this.Sum(numbers, count) / count;

        return average;
    }
}
