//Write a program that reads a text file and inserts line numbers in front of each of its lines. The result should be written to another text file.

using System;
using System.IO;
using System.Text;


     class InsertLineNums
    {
        static void Main()
        {
            string file = @"..\..\InsertLineNums.cs";
            StreamReader reader = new StreamReader(file);
            StringBuilder resultText = new StringBuilder();

            using (reader)
            {
                int lineNum = 1;
                string line = reader.ReadLine();
                while (line != null)
                {
                    resultText.Append(lineNum);
                    resultText.Append(" ");
                    resultText.Append(line);
                    resultText.Append("\r\n");
                    line = reader.ReadLine();
                    lineNum++;
                }
            }
            StreamWriter outputWriter = new StreamWriter("result.txt");
            using (outputWriter)
            {
                outputWriter.Write(resultText.ToString());
            }
            PrintFile("result.txt");
        }

        static void PrintFile(string file)
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
