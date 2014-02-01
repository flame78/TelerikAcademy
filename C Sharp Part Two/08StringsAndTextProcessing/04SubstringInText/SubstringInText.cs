//Write a program that finds how many times a substring is contained in a given text (perform case insensitive search).
//        Example: The target substring is "in". The text is as follows:

//We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.

//    The result is: 9.

using System;
using System.Text;


    class SubstringInText
    {
        static void Main(string[] args)
        {
            Console.Write("Enter string : ");
            string input = Console.ReadLine();
            Console.Write("Enter substring : ");
            string subStr =Console.ReadLine();

            input = input.ToLower();
            subStr = subStr.ToLower();

            int count = 0;
            int lastposition = 0;
            while (true)
            {
                lastposition = input.IndexOf(subStr,lastposition+1);
                if (lastposition < 0) break;
                count++;
            }

            Console.WriteLine(count);
        }
    }

