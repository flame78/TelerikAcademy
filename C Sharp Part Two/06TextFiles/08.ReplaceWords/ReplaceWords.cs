//Modify the solution of the previous problem to replace only whole words (not substrings).

using System;
using System.IO;
using System.Text;

class ReplaceWords
{
    static void Main(string[] args)
    {
        StreamReader inputReader = new StreamReader(@"..\..\..\07.ReplaceSubstr\ReplaceSubstr.cs");
        StreamWriter outputWriter = new StreamWriter("result.txt");
        StringBuilder word = new StringBuilder();
        StringBuilder line = new StringBuilder();
        using (outputWriter)
        using (inputReader)
        {
            while (inputReader.EndOfStream != true)
            {
                string oneLine = inputReader.ReadLine();
                foreach (char symbol in oneLine)
                {
                    if ((symbol >= '0' && symbol <= '9') || (symbol >= 'A' && symbol <= 'Z') || (symbol >= 'a' && symbol <= 'z'))
                    {
                        word.Append(symbol);
                    }
                    else
                    {
                        string tempWord = word.ToString();
                        if ("start".ToUpper() == word.ToString().ToUpper())
                        {
                            tempWord = "finish";
                        }
                        line.Append(tempWord);
                        line.Append(symbol);
                        word.Clear();
                    }
                }
                outputWriter.WriteLine(line.ToString());
                line.Clear();
                outputWriter.Flush();
            }
        }
        Print.Print.PrintFile("result.txt");
    }
}
