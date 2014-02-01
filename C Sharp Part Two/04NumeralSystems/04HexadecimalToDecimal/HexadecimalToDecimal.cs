// Write a program to convert hexadecimal numbers to their decimal representation.

using System;
    class HexadecimalToDecimal
    {
        static void Main()
        {
            ulong decimalValue = 0;
            string hexadecimal = "123456789ABCDEF";

            for (int i = 0; i < hexadecimal.Length; i++)
            {
                decimalValue <<= 4;     

                if (hexadecimal[i]<10+48)
                    decimalValue += (ulong)(15 & (hexadecimal[i]-48)); 
                else
                    decimalValue += (ulong)(15 & (hexadecimal[i]-65)+10);

            }

            
            Console.WriteLine(hexadecimal);
            Console.WriteLine(decimalValue);
        }
    }

