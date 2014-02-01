//Write a program to check if in a given expression the brackets are put correctly.
//Example of correct expression: ((a+b)/5-d).
//Example of incorrect expression: )(a+b)).

using System;
using System.Collections;
using System.Text;

class CheckBrackets
{
    static void Main(string[] args)
    {
        Console.Write("Enter expression : ");
        StringBuilder input = new StringBuilder(Console.ReadLine());
        Stack stack = new Stack();

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '(') stack.Push('(');
            else if (input[i] == ')')
                if (stack.Count > 0)
                    stack.Pop();
                else
                {
                    Console.WriteLine("Incorrect expression.");
                    return;
                }
        }
        if (stack.Count == 0) Console.WriteLine("Correct expression.");
        else Console.WriteLine("Incorrect expression.");
    }
}
