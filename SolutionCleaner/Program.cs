namespace SolutionCleaner
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public static class Program
    {
        private static readonly List<String> DirectoryNames = new List<string> { "bin", "obj", "packages", ".vs" };

        private static bool dontAsk = false;

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
                string confirmation = String.Empty;

                if (DirectoryNames.Contains(directory.Split('\\').Last()))
                {
                    Console.WriteLine(new string('!', 40));
                    Console.WriteLine(directory);

                    if (dontAsk)
                    {
                        Directory.Delete(directory, true);
                        continue;
                    }

                    Console.WriteLine("ARE YOU SURE TO DELETE FOLDER ?!(y/n/a)");
                    confirmation = Console.ReadLine();

                    switch (confirmation)
                    {
                        case "a":
                            dontAsk = true;
                            Directory.Delete(directory, true);
                            continue;
                        case "y":
                            Directory.Delete(directory, true);
                            Console.WriteLine(directory + "  DELETED!");
                            continue;
                    }
                }

                DeleteDirectories(directory);
            }
        }
    }
}