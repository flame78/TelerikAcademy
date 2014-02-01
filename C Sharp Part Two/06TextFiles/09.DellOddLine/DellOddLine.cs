//Write a program that deletes from given text file all odd lines. The result should be in the same file.

using System;
using System.IO;
using System.Text;


class DellOddLine
{
    static void Main(string[] args)
    {
        StreamReader inputReader = new StreamReader(@"..\..\..\text9.txt");
        StringBuilder result = new StringBuilder();
        using (inputReader)
        {
            int lineNum = 0;
            result.Append("Result: \r\n");
            while (inputReader.EndOfStream != true)
            {
                string line = inputReader.ReadLine();
                lineNum++;
                if (lineNum % 2 == 0)
                {
                    result.Append(line);
                    result.Append("\r\n");
                }
            }
        }
        StreamWriter outputWreiter = new StreamWriter(@"..\..\..\text9.txt", true);//true - to append to existing file; false - to replace the content.
        using (outputWreiter)
        {
            outputWreiter.WriteLine();
            outputWreiter.WriteLine(result.ToString());
        }
    }
}
