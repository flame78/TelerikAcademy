//Write a program that compares two text files line by line and prints the number of lines that are the same and the number of lines that are different. Assume the files have equal number of lines.
using System;
using System.IO;

class CompareTwoFiles
{
    static void Main(string[] args)
    {
        StreamReader firstReader = new StreamReader(@"..\..\..\HW-Text Files\PrintOddLines.cs");
        StreamReader secondReader = new StreamReader(@"..\..\..\02.ConcatenatesFiles\ConcatenatesFiles.cs");
        int equalLines = 0;
        int differantLines = 0;
        using (firstReader)
        using (secondReader)
        {
            while (firstReader.EndOfStream != true || secondReader.EndOfStream != true)
            {
                string firstStr = firstReader.ReadLine();
                string secondStr = secondReader.ReadLine();
                if (firstStr == secondStr)
                {
                    equalLines++;
                }
                else
                {
                    differantLines++;
                }
            }
        }
        Console.WriteLine("The number of the same lines is: {0}", equalLines);
        Console.WriteLine("The number of the diferent lines is: {0}", differantLines);
    }
}
