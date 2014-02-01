//Write a program to calculate n! for each n in the range [1..100]. Hint: Implement first a method that multiplies a number represented as array of digits by given integer number. 

using System;
class Program
{
    public class MyBigInt
    {
        private int length;
        private byte[] myBigInt;

        public MyBigInt(int len)
        {
            length = len;
            myBigInt = new byte[length];
        }

        public static implicit operator MyBigInt(long val)
        {
            string input = val.ToString();
            MyBigInt res = new MyBigInt(input.Length);
            for (int i = 0; i < input.Length; i++)
            {
                res[i] = input[i]-48;
            }
            return res;
        }

        public int this[int x]
        {
            get
            {
                return myBigInt[x];
            }
            set
            {
                if (value >= 0 && value <= 9)
                    myBigInt[x] = (byte)value;
                else throw new Exception("MyBigInt: Try to set element with non digit value.");
            }
        }



        public int Length()
        {
            return length;
        }

        public static MyBigInt operator *(MyBigInt ar1, MyBigInt ar2)
        {

            MyBigInt arLarge;
            MyBigInt arSmall;
            byte ostatyk = 0, tmp = 0;

            if (ar1.Length() > ar2.Length())
            {
                arLarge = ar1;
                arSmall = ar2;
            }
            else
            {
                arLarge = ar2;
                arSmall = ar1;
            }

            MyBigInt ar3 = new MyBigInt(arLarge.Length());
            MyBigInt ar4;
            MyBigInt ar5;
            MyBigInt result = new MyBigInt(1);
            result[0] = 0;

            for (int secDig = arSmall.Length() - 1; secDig >= 0; secDig--)
            {

                int dig = arSmall[secDig];
                ostatyk = 0;

                for (int i = arLarge.Length() - 1; i >= 0; i--)
                {

                    tmp = (byte)(arLarge[i] * dig + ostatyk);


                    if (tmp > 9) { ostatyk = (byte)(tmp / 10); ar3[i] = tmp - (tmp / 10) * 10; }
                    else { ar3[i] = tmp; ostatyk = 0; }
                }

                if (ostatyk > 0)
                {
                    ar4 = new MyBigInt(ar3.Length() + 1);
                    ar4[0] = (byte)(ostatyk);
                    for (int i = 0; i < ar3.Length(); i++)
                    {
                        ar4[i + 1] = ar3[i];
                    }
                }

                else ar4 = ar3;

                ar5 = new MyBigInt(ar4.Length() + (arSmall.Length() - 1 - secDig));
                for (int i = ar4.Length() - 1 + (arSmall.Length() - 1 - secDig); i >= 0; i--)
                {
                    if (i > ar4.Length() - 1) ar5[i] = 0;
                    else ar5[i] = ar4[i];
                }
                result += ar5;

            }
            return result;
        }

        public static MyBigInt operator +(MyBigInt ar1, MyBigInt ar2)
        {

            MyBigInt arLarge;
            MyBigInt arSmall;
            byte ostatyk = 0, tmp = 0;

            if (ar1.Length() > ar2.Length())
            {
                arLarge = ar1;
                arSmall = ar2;
            }
            else
            {
                arLarge = ar2;
                arSmall = ar1;
            }

            MyBigInt ar3 = new MyBigInt(arLarge.Length());

            for (int i = arLarge.Length() - 1; i >= 0; i--)
            {
                if ((arSmall.Length() - 1) - ((arLarge.Length() - 1) - i) >= 0)
                {
                    tmp = (byte)(arLarge[i] + arSmall[(arSmall.Length() - 1) - ((arLarge.Length() - 1) - i)] + ostatyk);

                }
                else tmp = (byte)(arLarge[i] + ostatyk);
                if (tmp > 9) { ostatyk = 1; ar3[i] = tmp - 10; }
                else { ar3[i] = tmp; ostatyk = 0; }
            }
            MyBigInt ar4;
            if (ostatyk == 1)
            {
                ar4 = new MyBigInt(ar3.Length() + 1);
                ar4[0] = (byte)1;
                for (int i = 0; i < ar3.Length(); i++)
                {
                    ar4[i + 1] = ar3[i];
                }
            }
            else ar4 = ar3;
            return ar4;
        }

        public override string ToString()
        {
            string output = "";
            for (int i = 0; i < length; i++)
            {
                output += myBigInt[i];
            }
            return output;
        }

    }

    static void Main()
    {
        MyBigInt nFact;
        
        nFact = 1;
        
        //Console.WindowWidth = 170;
        //Console.WindowHeight = 44;

        Console.WriteLine("{0,4} {1}", 1, nFact);
        for (int i = 2; i <= 100; i++)
        {
            nFact *= i;
            Console.WriteLine("{0,4} {1}", i, nFact);
        }
    }
}
