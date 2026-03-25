using System;using System.IO;using System.Threading.Tasks;using System.Net.Http;namespace ConsoleApp8{    class Program    {        static async Task Main(string[] args)        {            Console.WriteLine("Application Started");            Task task1 = WriteLogAsync("User Logged in");            Task task2 = WriteLogAsync("Required connection established");            Task task3 = WriteLogAsync("Payment processing successfully");            Console.WriteLine("Main Thread Still Resonsive and Doing Other Work");            await Task.WhenAll(task1, task2, task3);            Console.WriteLine("Application Closed");            Console.ReadLine();        }        static async Task WriteLogAsync(string message)
        {
            await Task.Delay(2000);
            Console.WriteLine($"Written at: {DateTime.Now}");
        }

    }}