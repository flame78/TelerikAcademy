//You are given a text. Write a program that changes the text in all regions surrounded by the tags <upcase> and </upcase> to uppercase. The tags cannot be nested. Example:

//We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.
		
//The expected result:

//We are living in a YELLOW SUBMARINE. We don't have ANYTHING else.

using System;
using System.Collections;
using System.Text;

    class TextToUpCaseByTags
    {
        static void Main(string[] args)
        {
            char unitSeparator = (char)31;
            Console.Write("Enter string : ");

            string input = Console.ReadLine();
                                    
            input=input.Replace("<upcase>",unitSeparator.ToString());
            input=input.Replace("</upcase>",unitSeparator.ToString());

            string[] tokens = input.Split(unitSeparator);

            for (int i = 1 ; i < tokens.Length; i+=2)
            {
                tokens[i] = tokens[i].ToUpper();
            }

            foreach (var item in tokens)
            {
                Console.Write(item);
            }
            Console.WriteLine();
        }
    }

