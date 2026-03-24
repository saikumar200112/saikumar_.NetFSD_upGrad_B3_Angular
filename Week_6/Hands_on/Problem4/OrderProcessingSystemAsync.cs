using System;using System.IO;using System.Threading.Tasks;using System.Net.Http;namespace ConsoleApp8{    class Program    {        static async Task Main(string[] args)        {
            Console.WriteLine("Start Application");
            await ProcessOrderAsync();
           
          
            Console.ReadLine();        }
        static async Task ProcessOrderAsync()
        {
            Console.WriteLine("Start processing");
            await VerifyPaymentAsync();
            await CheckInventoryAsync();
            await ConfirmOrderAsync();
            Console.WriteLine("Process completed");
        }
       static async Task VerifyPaymentAsync()
        {
            Console.WriteLine("Verifying payment");
            await Task.Delay(1500);
            Console.WriteLine("Payment verified");
        }        static async Task CheckInventoryAsync()
        {
            Console.WriteLine("Checking warehouse stock");
            await Task.Delay(1500);
            Console.WriteLine("Items are in stock");
        }
        static async Task ConfirmOrderAsync()
        {
            Console.WriteLine("Sending conformation to your phone");
            await Task.Delay(1000);
            Console.WriteLine("Order confirmed");
        }

    }
}