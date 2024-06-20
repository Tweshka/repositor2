using System;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

using System;
using System.Runtime;


public class FolderCleaner
{
    private static readonly TimeSpan TimeLimit = TimeSpan.FromMinutes(30); 

    public static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Необходимо указать путь к папке в качестве аргумента.");
            return;
        }

        string folderPath = args[0];

        if (!Directory.Exists(folderPath))
        {
            Console.WriteLine($"Папка '{folderPath}' не найдена.");
            return;
        }

        CleanFolder(folderPath);

        Console.WriteLine($"Папка '{folderPath}' очищена.");
    }

    private static void CleanFolder(string folderPath)
    {
        foreach (string filePath in Directory.EnumerateFiles(folderPath))
        {
            if (IsFileOlderThanTimeLimit(filePath))
            {
                DeleteFile(filePath);
                Console.WriteLine($"Удален файл: {filePath}");
            }
        }

        foreach (string subFolderPath in Directory.EnumerateDirectories(folderPath))
        {
            CleanFolder(subFolderPath);

            if (IsDirectoryEmpty(subFolderPath))
            {
                DeleteDirectory(subFolderPath);
                Console.WriteLine($"Удалена папка: {subFolderPath}");
            }
        }
    }

    private static bool IsFileOlderThanTimeLimit(string filePath)
    {
        DateTime lastWriteTime = File.GetLastWriteTime(filePath);
        return DateTime.Now - lastWriteTime > TimeLimit;
    }

    private static bool IsDirectoryEmpty(string directoryPath)
    {
        return !Directory.EnumerateFileSystemEntries(directoryPath).Any();
    }

    private static void DeleteFile(string filePath)
    {
        try
        {
            File.Delete(filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при удалении файла '{filePath}': {ex.Message}");
        }
    }

    private static void DeleteDirectory(string directoryPath)
    {
        try
        {
            Directory.Delete(directoryPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при удалении папки '{directoryPath}': {ex.Message}");
        }
    }
}
































