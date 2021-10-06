using System;
using System.IO;

namespace VsSolutionCleaner
{
    class Program
    {
        static void Main(string[] args)
        {

            if (args.Length == 1)
            {
                string parameter = args[0];
                if (IsDirectory(parameter))
                {
                    CleanDirectory(parameter);
                }
            }
            else
            {
                WriteUsage();
            }
            Console.WriteLine("ENTER to end.");
            Console.ReadLine();
        }

        private static void CleanDirectory(string directoryPath)
        {
            Console.WriteLine($"Looking for BIN and OBJ directories in '{directoryPath}'");
            foreach (var directory in Directory.GetDirectories(directoryPath))
            {
                string subDirectoryPath = Path.GetDirectoryName(directory);
                string uppercaseDirectoryName = new DirectoryInfo(subDirectoryPath).Name.ToUpper();
                if (uppercaseDirectoryName == "OBJ" || uppercaseDirectoryName == "BIN")
                {
                    Console.WriteLine($"  Deleting '{directory}'...");
                    Directory.Delete(subDirectoryPath, true);
                }
                else
                {
                    CleanDirectory(directory);
                }
            }
        }

        private static bool IsDirectory(string directoryPath)
        {
            return Directory.Exists(directoryPath);
        }

        private static void WriteUsage()
        {
            Console.WriteLine("VS SOLUTION CLEANER");
            Console.WriteLine("  - deletes obj and bin folders in VS solutions and subfolders");
            Console.WriteLine("Usage: VsSolutionCleaner.exe [Path to solution folder]");
            Console.WriteLine(@"Example: VsSolutionCleaner.exe 'c:\users\me\source\repos\mysolution'");
            Console.WriteLine();
        }
    }
}