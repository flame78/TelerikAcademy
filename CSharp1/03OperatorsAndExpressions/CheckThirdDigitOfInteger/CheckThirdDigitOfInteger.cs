using System;

//Write an expression that checks for given integer if its third digit (right-to-left) is 7. E. g. 1732  true.


class CheckThirdDigitOfInteger
{
    static void Main()
    {
        int intValue = 34705532;
        int tmpValue;
        int tmp2Value;
        byte digNum = 5;
        byte digValue = 0;
        bool isValue;
        tmpValue = intValue / (int)Math.Pow(10, digNum - 1); // move right (digNum-1) positions
        tmp2Value = (tmpValue / 10) * 10; // zero last digit
        isValue = ((tmpValue-digValue) == tmp2Value);  

        Console.WriteLine(isValue);
    }
}

