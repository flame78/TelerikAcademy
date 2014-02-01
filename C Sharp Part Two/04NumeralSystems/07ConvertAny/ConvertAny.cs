// Write a program to convert from any numeral system of given base s to any other numeral system of base d (2 ≤ s, d ≤  16).

using System;

    class ConvertAny
    {
        static void Main()
        {
            int s = 16;
            int d = 8;
            string num = "ABCDEF";
            
            ulong decVal = NumeralToDecimal(num,s);
            Console.WriteLine(DecimalToNumeral(decVal, d));


        }

        private static string DecimalToNumeral(ulong tmp, int numBase)
        {
            string res="";
            do
            {
                if ((tmp % (ulong)numBase) < 10)
                    res = (char)((tmp%(ulong)numBase) + 48) + res;    
                else
                    res = (char)((tmp % (ulong)numBase) + 65 - 10) + res;
                tmp =tmp/(ulong)numBase;                    
            } while (tmp > 0);

            return res;
        }

        private static ulong NumeralToDecimal(string num, int numBase)
        {
            ulong res=0;
            for (int i = 0; i < num.Length; i++)
            {
                res *= (ulong)numBase;     

                if (num[i]<10+48)
                    res += (ulong)((num[i]-48)%numBase); 
                else
                    res += (ulong)((num[i]-65)%numBase+10);

            }

            return res;
        }

    }

