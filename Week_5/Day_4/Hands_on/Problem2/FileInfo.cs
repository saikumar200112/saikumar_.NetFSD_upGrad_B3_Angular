
using System.IO;
namespace consoleApp1
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Folder Path");
            string folderPath = Console.ReadLine();

            DirectoryInfo dir = new DirectoryInfo(folderPath);

            FileInfo[] allFiles = dir.GetFiles();

            Console.WriteLine($"Total number of files: {allFiles.Length}");
            Console.WriteLine();
            foreach (FileInfo file in allFiles)
            {
                Console.WriteLine($"Name of File: {file.Name}");
                Console.WriteLine($"Size of File of File: {file.Length}");
                Console.WriteLine($"Creation Time of File: {file.CreationTime}");
                Console.WriteLine();
            }



            Console.ReadLine();

        }
    }
}