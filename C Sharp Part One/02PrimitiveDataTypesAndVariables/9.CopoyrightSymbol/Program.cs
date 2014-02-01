using System;

class CopoyrightSymbol
{
    static void Main()
    {
        char crSymb = '\u00A9'; // '©' or (char)169
        Console.WriteLine(new string(' ',2)+crSymb+new string(' ',2));
        Console.WriteLine(" " + new string(crSymb,3));
        Console.WriteLine(new string(crSymb, 5));

        string crTriangle = @"  ©
 ©©©
©©©©©";

        Console.WriteLine("\n\a"+crTriangle);
    }
}
