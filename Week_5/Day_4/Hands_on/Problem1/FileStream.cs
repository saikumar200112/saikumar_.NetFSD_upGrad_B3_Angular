using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
      
        Console.Write("Enter your message: ");
        string message = Console.ReadLine();

      
        message = message + "\n";

        string fileName = @"C:\Users\HP\Desktop\C Sharp\logs.txt.txt";

       
        try
        {
          
            
            using (FileStream fs = new FileStream(fileName, FileMode.Append, FileAccess.Write))
            {
               
                byte[] data = Encoding.ASCII.GetBytes(message);

               
                fs.Write(data, 0, data.Length);
            }

            
            Console.WriteLine("Data written successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        Console.ReadLine();
    }
}