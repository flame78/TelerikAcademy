//Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file

using System;
using System.Collections.Generic;
using System.IO;

namespace _06_SortTheStrings
{
    class SortTheList
    {
        static List<string> names = new List<string>();
        static void Main(string[] args)
        {
            StreamReader inputReader = new StreamReader(@"..\..\..\text6.txt");
            using (inputReader)
            {
                while (inputReader.EndOfStream != true)
                {

                    string oneLine = inputReader.ReadLine();
                    if (oneLine != null)
                    {
                        names.Add(oneLine);
                    }
                }
            }
            names.Sort();
            StreamWriter outputWriter = new StreamWriter("result.txt");
            using (outputWriter)
            {
                foreach (string name in names)
                {
                    outputWriter.WriteLine(name);
                }
            }
            Print.Print.PrintFile("result.txt");

        }
    }
}