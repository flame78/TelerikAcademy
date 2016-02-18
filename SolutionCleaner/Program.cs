namespace SolutionCleaner
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public static class Program
    {
        private static readonly List<String> DirectoryNames = new List<string> { "bin", "obj", "packages", ".vs" };

        public static void Main()
        {
            Console.WriteLine("Visual studio Solution Cleaner 1.0");
            Console.WriteLine("Working in: " + Environment.CurrentDirectory);

            Console.WriteLine("Deleting directories...");
            DeleteDirectories(Environment.CurrentDirectory);
            Console.WriteLine("Done!");
        }

        private static void DeleteDirectories(string currentDirectory)
        {
            var directories = Directory.GetDirectories(currentDirectory);
            foreach (var directory in directories)
            {
                if (DirectoryNames.Contains(directory.Split('\\').Last()))
                {
                    Console.WriteLine(new string('!',40));
                    Console.WriteLine(directory);
                    Console.WriteLine("ARE YOU SURE TO DELETE FOLDER ?!(y/n)");
                    var confirmation = Console.ReadLine();
                    if (confirmation == "y")
                    {
                        Directory.Delete(directory, true);
                        Console.WriteLine(directory + "  DELETED!");
                    }
                }
            }
        }
    }
}