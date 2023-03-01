namespace RecursiveDirectoryCleanerTool;
public static class CleanerTool
{

    private readonly static string[] DirectoriesToClean = new string[] { "obj", "bin" };
    public static void CleanDirectory(string directoryPath)
    {
        ValidateDirectoryExistenceAndThrowIfNotExists(directoryPath);
        CleanDirectoryRecursive(directoryPath);
    }


    private static void ValidateDirectoryExistenceAndThrowIfNotExists(string directoryPath)
    {
        if (!Directory.Exists(directoryPath))
        {
            throw new DirectoryNotFoundException($"Directory {directoryPath} does not exist.");
        }
    }
    private static void CleanDirectoryRecursive(string directoryPath)
    {
        var directoriesFound = Directory.GetDirectories(directoryPath);
        foreach (var directory in directoriesFound)
        {
            if (!DeleteIfObjOrBin(directory))
            {
                CleanDirectoryRecursive(directory);
            }
        }
    }

    private static bool DeleteIfObjOrBin(string directory)
    {
        string directoryName = Path.GetFileName(directory).ToLower();

        if (DirectoriesToClean.Contains(directoryName))
        {
            Directory.Delete(directory, true);
            return true;
        }
        return false;
    }
}