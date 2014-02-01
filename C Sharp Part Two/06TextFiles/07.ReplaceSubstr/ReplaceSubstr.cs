//Write a program that replaces all occurrences of the substring "start" with the substring "finish" in a text file. Ensure it will work with large files (e.g. 100 MB).

using System;
using System.IO;
using System.Text;


class ReplaceSubstr
{
    static void Main(string[] args)
    {
        StreamReader inputReader = new StreamReader(@"..\..\ReplaceSubstr.cs");
        StreamWriter outputWriter = new StreamWriter("result.txt");
        StringBuilder result = new StringBuilder();
        using (outputWriter)
        using (inputReader)
        {
            while (inputReader.EndOfStream != true)
            {
                string oneLine = inputReader.ReadLine();
                int startIndex = 0;
                int indexOfStart = oneLine.IndexOf("start", StringComparison.OrdinalIgnoreCase);
                if (indexOfStart < 0)
                {
                    result.Append(oneLine);
                }
                else
                {
                    while (indexOfStart >= 0)
                    {
                        string subStr = oneLine.Substring(startIndex, indexOfStart - startIndex);
                        startIndex = indexOfStart + 5;
                        indexOfStart = oneLine.IndexOf("start", startIndex, StringComparison.OrdinalIgnoreCase);
                        result.Append(subStr);
                        result.Append("finish");
                    }
                    int lastIndexOfStart = oneLine.LastIndexOf("start", StringComparison.OrdinalIgnoreCase);
                    string lastSubstring = oneLine.Substring(lastIndexOfStart + 5);
                    result.Append(lastSubstring);
                }
                outputWriter.WriteLine(result.ToString());
                result.Clear();
                outputWriter.Flush();
            }
        }
        Print.Print.PrintFile("result.txt");
    }
}
