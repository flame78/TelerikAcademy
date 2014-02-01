using System;

class ExchangeValues
{
    static void Main()
    {
        int firstValue = 5;
        int secondValue = 10;
        int tempValue;

        tempValue = firstValue;
        firstValue = secondValue;
        secondValue = tempValue;
    }
}
