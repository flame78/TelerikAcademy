//Write a program that reads a text file and prints on the console its odd lines.

using System;
using System.IO;

namespace Print
{
    public class PrintOddLines
    {
        public static void Main(string[] args)
        {
            StreamReader reader;
            if (args.Length == 0) reader = new StreamReader(@"..\..\PrintOddLines.cs");
            else reader =  new StreamReader(args[0]);
            using (reader)
            {
                int lineNum = 1;
                string line = reader.ReadLine();
                while (line != null)
                {
                    if ((lineNum & 1) != 0)
                    {
                        Console.WriteLine(line);
                    }
                    lineNum++;
                    line = reader.ReadLine();
                }
            }
        }
    }
    public class Print
    {
        public static void PrintFile(string file)
        {
            string line = "";
            StreamReader reader = new StreamReader(file);
            using (reader)
            {
                Console.WriteLine(line = reader.ReadLine());
                while (line != null)
                {
                    Console.WriteLine(line = reader.ReadLine());
                }
            }
        }
    }
}
