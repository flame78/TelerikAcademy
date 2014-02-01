//Write a program that deletes from a text file all words that start with the prefix "test". Words contain only the symbols 0...9, a...z, A…Z, _.
// testAlaBala

using System;
using System.IO;
using System.Text;

class DeleteWords
{
    static void Main(string[] args)
    {
        string prefix = "test";
        StringBuilder word = new StringBuilder();
        StringBuilder text = new StringBuilder();
        StreamReader inputReader = new StreamReader(@"..\..\DeleteWords.cs");
        using (inputReader)
        {
            while (inputReader.EndOfStream != true)
            {
                string oneLine = inputReader.ReadLine();
                foreach (char symbol in oneLine)
                {
                    if ((symbol >= '0' && symbol <= '9') || (symbol >= 'A' && symbol <= 'Z') || (symbol >= 'a' && symbol <= 'z') || symbol == '_')
                    {
                        word.Append(symbol);
                    }
                    else
                    {
                        string tempWord = word.ToString();
                        if (tempWord.Length > prefix.Length)
                        {
                            if (prefix == tempWord.Substring(0, prefix.Length))
                            {
                                word.Clear();
                            }
                        }
                        text.Append(word.ToString());
                        text.Append(symbol);
                        word.Clear();
                    }
                }
                text.Append("\n");
            }
        }
        StreamWriter outputWriter = new StreamWriter("result.txt");
        using (outputWriter)
        {
            outputWriter.WriteLine(text.ToString());
        }
        Print.Print.PrintFile("result.txt");
    }
}

// test!@#
// test123123asdadas
