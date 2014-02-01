//Write a program to convert binary numbers to hexadecimal numbers (directly).

using System;

class BinaryToHexadecimal
{
    static void Main()
    {
        string hexadecimal = "";
        string binary = "1001000110100010101100111100010010000101010111100110111101111";

        int tmp = 0;

        for (int i = binary.Length - 1; i >= 0; i--)
        {
            if ((i & 3) == 0)
            {
                if (tmp < 10)
                    hexadecimal = tmp + hexadecimal;
                else
                    hexadecimal = (char)(tmp + 65 - 10) + hexadecimal;

                if (i == binary.Length - 1) hexadecimal = "";

                tmp = (binary[i] - 48);
            }
            else
            tmp += (binary[i] - 48) << 4-(i & 3);


        }

        if (tmp < 10)
            hexadecimal = tmp + hexadecimal;
        else
            hexadecimal = (char)(tmp + 65 - 10) + hexadecimal;

        tmp = 0;


        Console.WriteLine(binary);
        Console.WriteLine(hexadecimal);

    }
}

