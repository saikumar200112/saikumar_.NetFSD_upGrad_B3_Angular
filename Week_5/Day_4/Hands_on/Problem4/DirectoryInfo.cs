
using System.IO;
namespace consoleApp1
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Root Path");
            string rootPath =Console.ReadLine();



            if (Directory.Exists(rootPath))
            {
                try
                {

                    DirectoryInfo rootDir = new DirectoryInfo(rootPath);


                    DirectoryInfo[] subDirs = rootDir.GetDirectories();




                    foreach (DirectoryInfo dir in subDirs)
                    {

                        FileInfo[] files = dir.GetFiles();
                        int count = files.Length;


                        Console.WriteLine("Folder Name: " + dir.Name);
                        Console.WriteLine("Number of Files: " + count);
                        Console.WriteLine();
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("The path you entered does not exist.");
            }


            Console.ReadLine();
        }

    }
}