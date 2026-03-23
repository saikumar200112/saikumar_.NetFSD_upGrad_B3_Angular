
using System.IO;
namespace consoleApp1
{
                
    internal class Program
    {
        static void Main(string[] args)
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();

         
            foreach (DriveInfo d in allDrives)
            {
           
                if (d.IsReady)
                {
             
                    long totalGB = d.TotalSize / 1024 / 1024 / 1024;
                    long freeGB = d.AvailableFreeSpace / 1024 / 1024 / 1024;

                 
                    Console.WriteLine("Drive: " + d.Name);
                    Console.WriteLine("Type: " + d.DriveType);
                    Console.WriteLine("Total Size: " + totalGB + " GB");
                    Console.WriteLine("Free Space: " + freeGB + " GB");

         
                    double percentage = ((double)freeGB / totalGB) * 100;

                    if (percentage < 15)
                    {
                        Console.WriteLine("!! WARNING: Low Space (" + percentage + "% remaining) !!");
                    }

                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Drive " + d.Name + " is not ready.");
                
                }
            }



            Console.ReadLine();
        }
 
    }
}