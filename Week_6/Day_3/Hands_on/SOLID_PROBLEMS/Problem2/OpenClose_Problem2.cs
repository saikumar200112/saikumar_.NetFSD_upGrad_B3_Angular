using System.Collections.Generic;
namespace consoleApp1
{
    public interface IDiscountStrategy
    {
        double CalculateDiscount(double amount);
    }

    public class RegularCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.1;
        }
    }


    public class PremiumCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.2;
        }
    }


    public class VipCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.3;
        }
    }
    public class PriceCalculator
    {

        public IDiscountStrategy CurrentStrategy;

        public double GetFinalPrice(double amount)
        {
            double discountValue = CurrentStrategy.CalculateDiscount(amount);
            return amount - discountValue;
        }
    }


   internal class Program
    {
        static void Main(string[] args)
        {
            double bill = 1000;


            PriceCalculator manager = new PriceCalculator();


            manager.CurrentStrategy = new VipCustomerDiscount();


            double total = manager.GetFinalPrice(bill);

            Console.WriteLine("Total to pay: " + total);

            Console.ReadLine();
        }
    }
}