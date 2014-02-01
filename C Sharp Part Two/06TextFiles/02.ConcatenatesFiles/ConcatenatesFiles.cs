//Write a program that concatenates two text files into another text file.

using System;
using System.IO;

class ConcatenatesFiles
{
    static void Main(string[] args)
    {
        StreamReader firstReader = new StreamReader(@"..\..\..\HW-Text Files\PrintOddLines.cs");
        string firstText;
        using (firstReader)
        {
            firstText = firstReader.ReadToEnd();
        }
        StreamReader secondReader = new StreamReader(@"..\..\..\\02.ConcatenatesFiles\ConcatenatesFiles.cs");
        string secondText;
        using (firstReader)
        {
            secondText = secondReader.ReadToEnd();
        }
        StreamWriter resultWriter = new StreamWriter(@"..\..\resultText.txt");
        using (resultWriter)
        {
            resultWriter.WriteLine(firstText);
            resultWriter.WriteLine(secondText);
        }

        Print.Print.PrintFile( @"..\..\resultText.txt" );
    }
}
