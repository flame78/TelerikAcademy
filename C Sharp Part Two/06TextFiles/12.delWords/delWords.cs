//Write a program that removes from a text file all words listed in given another text file. Handle all possible exceptions in your methods.

using System;
using System.IO;
using System.Text;


class delWords
{
    static string[] words;
    static void Main(string[] args)
    {
        char[] separators = { ',', ' ', ';', ':', '.', };
        try
        {
            StreamReader forbiddenWordsReader = new StreamReader(@"..\..\..\words.txt");
            using (forbiddenWordsReader)
            {
                string allwords = forbiddenWordsReader.ReadToEnd();
                words = allwords.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            }
        }
        catch (FileNotFoundException)
        {
            Console.Error.WriteLine("The file with the words cannot be found!");
        }
        catch (DirectoryNotFoundException)
        {
            Console.Error.WriteLine("The dir of the file with the words cannot be found!");
        }
        catch (IOException ioEx)
        {
            Console.Error.WriteLine(ioEx.Message);
        }
        StringBuilder word = new StringBuilder();
        StringBuilder text = new StringBuilder();
        try
        {
            StreamReader inputReader = new StreamReader(@"..\..\delWords.cs");
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
                            foreach (string oneWord in words)
                            {
                                if (oneWord.ToUpper() == tempWord.ToUpper())
                                {
                                    word.Clear();
                                }
                            }
                            text.Append(word.ToString());
                            text.Append(symbol);
                            word.Clear();
                        }
                    }
                    text.Append("\r\n");
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.Error.WriteLine("The text file cannot be found!");
        }
        catch (DirectoryNotFoundException)
        {
            Console.Error.WriteLine("The dir of the text file cannot be found!");
        }
        catch (IOException ioEx)
        {
            Console.Error.WriteLine(ioEx.Message);
        }
        try
        {
            StreamWriter outputWriter = new StreamWriter("text.txt");
            using (outputWriter)
            {
                outputWriter.WriteLine(text.ToString());
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.Error.WriteLine("You are not authorized to oppen this file!");
        }
        catch (DirectoryNotFoundException)
        {
            Console.Error.WriteLine("The dir of the text file cannot be found!");
        }
        catch (PathTooLongException)
        {
            Console.Error.WriteLine("The path of the text file is to long!");
        }
        catch (System.Security.SecurityException sEx)
        {
            Console.Error.WriteLine(sEx.Message);
        }
        catch (IOException ioEx)
        {
            Console.Error.WriteLine(ioEx.Message);
        }
        Print.Print.PrintFile("text.txt");
    }

}
