using System;using System.IO;using System.Threading.Tasks;using System.Net.Http;namespace ConsoleApp8{    class Program    {        static async Task Main(string[] args)        {
            Console.WriteLine("Financial Report Start");
            DateTime starttime = DateTime.Now;
;            Task task1 = Task.Run(() =>
            {
                GenerateSalesReport();
            });
            Task task2 = Task.Run(() =>
            {
                GenerateInventoryReport();
            });
            Task task3 = Task.Run(() =>
            {
                GenerateCustomerReport();
            });
            await Task.WhenAll(task1, task2, task3);
            DateTime endtime = DateTime.Now;
            TimeSpan totalTime = endtime - starttime;
            Console.WriteLine("All Reports Completed");
            Console.WriteLine($"Total Processing Time:{totalTime.Seconds} Seconds");
            Console.ReadLine();        }
        static void GenerateSalesReport()
        {
            Console.WriteLine("[start] Generating Sales Report");            Task.Delay(2000).Wait();            Console.WriteLine("[finsh] Sales Report Ready");        }
        static void GenerateInventoryReport()
        {
            Console.WriteLine("[start] Generating Inventory Report");            Task.Delay(2000).Wait();            Console.WriteLine("[finsh] Inventory Report Ready");        }
        static void GenerateCustomerReport()
        {
            Console.WriteLine("[start] Generating Customer Report");            Task.Delay(2000).Wait();            Console.WriteLine("[finsh] Customer Report Ready");        }
                
    }
}