using RecursiveDirectoryCleanerTool;
namespace SolutionCleanerConsoleApp;
internal class Program
{
    static void Main(string[] args)
    {
        ValidateArgumentsAndExitIfInvalid(args);
        CleanerTool.CleanDirectory(args[0]);
    }

    private static void ValidateArgumentsAndExitIfInvalid(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("You need to have exactly one (1) command line argument after this program on the command line.");
            
            WriteUsageAndExit();
        }

        if (!Directory.Exists(args[0]))
        {
            Console.WriteLine($"'{args[0]}' is not a directory!");
            WriteUsageAndExit();
        }
    }

    private static void WriteUsageAndExit()
    {
        WriteUsage();
        Environment.Exit(-1);
    }

    private static void WriteUsage()
    {
        Console.WriteLine();
        Console.WriteLine("VS Solution Cleaner Tool");
        Console.WriteLine("------------------------");
        Console.WriteLine("Usage: solutioncleaner.exe directory-to-clean");
        Console.WriteLine(@"E.g. 'solutioncleaner.exe c:\users\me\code\myproject");
    }
}