using System;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;
using System.Reflection;


namespace ConsoleApp8
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Write("Enter Product Name: ");
            string productName = Console.ReadLine();

            Console.Write("Enter Product Price: ");
            double price = double.Parse(Console.ReadLine());

            Console.Write("Enter Discount Percentag: ");
            double discount = double.Parse(Console.ReadLine());

            
            double finalPrice = CalculateFinalPrice(price, discount);

         
            Console.WriteLine($"\nProduct: {productName}");
            Console.WriteLine($"Original Price: INR.{price}");
            Console.WriteLine($"Discount: {discount}%");
            Console.WriteLine($"Final Price: INR.{finalPrice}");

            Console.ReadLine();
        }
        static double CalculateFinalPrice(double p, double d)
        {
            
            double final = p - (p * d / 10); //Error Because of in the placeof 10 correct one is 100.
            return final;
        }


    }
}