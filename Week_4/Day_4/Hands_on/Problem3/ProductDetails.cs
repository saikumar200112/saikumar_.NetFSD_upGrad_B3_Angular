using System;

namespace ProductManagement
{
    class Product
    {
        private int _ProductId;
        private string _ProductName;
        private int _Quantity;
        private double _UnitPrice;

        public Product(int ProductId)
        {
            this._ProductId = ProductId;
        }
        public int ProductId
        {
            get
            {
                return this._ProductId;
            }
        }
        public string ProductName
        {
            get
            {
                return this._ProductName;
            }
            set
            {
                this._ProductName = value;
            }
        }
        public int Quantity
        {
            get
            {
                return this._Quantity;
            }
            set
            {
               
                    this._Quantity = value;
  
            }
        }
        public double UnitPrice
        {
            get
            {
                return this._UnitPrice;
            }
            set
            {
               
                    this._UnitPrice = value;
                
                   
            }
        }
        public void showproductDetails()
        {
            if (Quantity > 0)
            {
                double totalAmount = UnitPrice * Quantity;
                Console.WriteLine($"ProductId :{ProductId}");
                Console.WriteLine($"ProductName :{ProductName}");
                Console.WriteLine($"Quantity :{Quantity}");
                Console.WriteLine($"UnitPrice :{UnitPrice}");
                Console.WriteLine($"Total Amount :{totalAmount}");


                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Enter valid Quanty");
            }

        }

    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Product p = new Product(101);
            p.ProductName = "Apple";
            p.Quantity = 3;
            p.UnitPrice = 25000;
            p.showproductDetails();
        }
    }
}