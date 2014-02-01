//Write a program that reads a list of words from a file words.txt and finds how many times each of the words is contained in another file test.txt. The result should be written in the file result.txt and the words should be sorted by the number of their occurrences in descending order. Handle all possible exceptions in your methods.

using System;
using System.IO;
using System.Text;

class WordCounter
{
    static string[] words;

    static int[,] SortOneDimention(int[,] array)
    {
        for (int i = 0; i < array.GetLength(1); i++)
        {
            int indexMax = i;
            for (int j = i + 1; j < array.GetLength(1); j++)
            {
                if (array[1, j] > array[1, indexMax])
                {
                    indexMax = j;
                }
            }
            if (indexMax != i)
            {
                int tempFirstD = array[0, indexMax];
                int tempSecondD = array[1, indexMax];
                array[0, indexMax] = array[0, i];
                array[1, indexMax] = array[1, i];
                array[0, i] = tempFirstD;
                array[1, i] = tempSecondD;
            }
        }
        return array;
    }
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
        int[,] indexHolder = new int[2, words.Length];
        for (int i = 0; i < indexHolder.GetLength(1); i++)
        {
            indexHolder[0, i] = i;
        }
        try
        {
            StreamReader inputReader = new StreamReader(@"..\..\WordCounter.cs");
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
                            for (int i = 0; i < words.Length; i++)
                            {
                                if (words[i].ToUpper() == tempWord.ToUpper())
                                {
                                    indexHolder[1, i]++;
                                }
                            }
                            word.Clear();
                        }
                    }
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
        indexHolder = SortOneDimention(indexHolder);
        try
        {
            StreamWriter outputWriter = new StreamWriter("result.txt");
            using (outputWriter)
            {
                for (int i = 0; i < indexHolder.GetLength(1); i++)
                {
                    outputWriter.WriteLine("{0} - {1} time(s).", words[indexHolder[0, i]], indexHolder[1, i]);
                }
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.Error.WriteLine("You are not authorized to oppen this file!");
        }
        catch (DirectoryNotFoundException)
        {
            Console.Error.WriteLine("The dir of the result.txt file cannot be found!");
        }
        catch (PathTooLongException)
        {
            Console.Error.WriteLine("The path of the result.txt file is to long!");
        }
        catch (System.Security.SecurityException sEx)
        {
            Console.Error.WriteLine(sEx.Message);
        }
        catch (IOException ioEx)
        {
            Console.Error.WriteLine(ioEx.Message);
        }

        Print.Print.PrintFile("result.txt");
    }
}
