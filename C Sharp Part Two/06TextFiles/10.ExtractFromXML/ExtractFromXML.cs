//Write a program that extracts from given XML file all the text without the tags. 

using System;
using System.IO;
using System.Text;

class ExtractFromXML
{
    static void Main(string[] args)
    {
        StreamReader inputReader = new StreamReader(@"..\..\..\text10.xml");
        using (inputReader)
        {
            string inputText = inputReader.ReadToEnd();
            StringBuilder outputText = new StringBuilder();
            bool inTag = false;
            foreach (char symbol in inputText)
            {
                if (symbol == '<')
                {
                    inTag = true;
                }
                if (symbol == '>')
                {
                    inTag = false;
                    continue;
                }
                if (inTag == false)
                {
                    outputText.Append(symbol);
                }
            }
            Console.WriteLine(outputText.ToString());
        }
    }
}
