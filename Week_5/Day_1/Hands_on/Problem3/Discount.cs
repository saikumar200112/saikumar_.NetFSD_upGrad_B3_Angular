using System;

namespace Product
{
  public class Product
    {
        private decimal _price;
        public string Name { get; set; }

        public decimal Price
        {
            get => _price;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price Cannot Be Negative");
                }
                _price = value;
            }
        }
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
        public virtual decimal CalculateDiscount()
        {
            return Price;
        }
        
    }
    public class Electronics : Product
    {
        public Electronics(string name,decimal price) : base(name, price)
        {

        }
        public override decimal CalculateDiscount()
        {
            return Price - (Price * 0.05m);
        }
    }

    public class Clothing : Product
    {
        public Clothing(string name, decimal price) : base(name, price)
        {

        }
        public override decimal CalculateDiscount()
        {
            return Price - (Price * 0.15m);
        }
    }

    internal class Program
        {
            static void Main(string[] args)
            {
            Product laptop = new Electronics("samsung", 150000);
            Product shirt = new Clothing("Slim-Fit", 500);
            Console.WriteLine($"Final price for {laptop.Name} after 5% discount :INR.{laptop.CalculateDiscount()}");
            Console.WriteLine($"Final price for {shirt.Name} after 15% discount :INR.{shirt.CalculateDiscount()}");
            Console.ReadLine();
        }
      }
 }