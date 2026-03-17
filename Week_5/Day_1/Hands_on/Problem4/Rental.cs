using System;

namespace VehicleRentalSystem
{
    
    public class Vehicle
    {
        private decimal _rentalRatePerDay;
        public string Brand { get; set; }

        public decimal RentalRatePerDay
        {
            get => _rentalRatePerDay;
            set
            {
                if (value < 0) throw new ArgumentException("Rate cannot be negative.");
                _rentalRatePerDay = value;
            }
        }

        public Vehicle(string brand, decimal rate)
        {
            Brand = brand;
            RentalRatePerDay = rate;
        }

        
        public virtual decimal CalculateRental(int days)
        {
            if (days <= 0) throw new ArgumentException("Days must be positive.");
            return RentalRatePerDay * days;
        }
    }

   
    public class Car : Vehicle
    {
        public Car(string brand, decimal rate) : base(brand, rate) { }

        public override decimal CalculateRental(int days)
        {
            decimal baseCost = base.CalculateRental(days);
            return baseCost + 500m; 
        }
    }

   
    public class Bike : Vehicle
    {
        public Bike(string brand, decimal rate) : base(brand, rate) { }

        public override decimal CalculateRental(int days)
        {
            decimal baseCost = base.CalculateRental(days);
            return baseCost-(baseCost * 0.05m);
        }
    }

   internal class Program
    {
        static void Main(string[] args)
        {
           
            Vehicle myCar = new Car("Toyota", 2000);
            int rentalDays = 3;

            Console.WriteLine($"Total Rental for {myCar.Brand}: {myCar.CalculateRental(rentalDays)}");

            Vehicle myBike = new Bike("Honda", 1000);
            Console.WriteLine($"Total Rental for {myBike.Brand}: {myBike.CalculateRental(rentalDays)}");

            Console.ReadLine();
        }
    }
}