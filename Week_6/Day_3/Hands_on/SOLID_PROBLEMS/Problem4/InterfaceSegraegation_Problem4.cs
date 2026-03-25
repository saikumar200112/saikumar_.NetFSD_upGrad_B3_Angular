using System.Collections.Generic;
namespace consoleApp1
{
    public interface IPrinter
    {
        void Print();
    }

    public interface IScanner
    {
        void Scan();
    }

    public interface IFax
    {
        void Fax();
    }
    public class BasicPrinter : IPrinter
    {
        public void Print()
        {
            Console.WriteLine("Basic Printer: Printing document...");
        }
    }
    public class AdvancedPrinter : IPrinter, IScanner, IFax
    {
        public void Print()
        {
            Console.WriteLine("Advanced Printer: Printing high-quality document...");
        }

        public void Scan()
        {
            Console.WriteLine("Advanced Printer: Scanning to PDF...");
        }

        public void Fax()
        {
            Console.WriteLine("Advanced Printer: Sending Fax...");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            BasicPrinter myBasic = new BasicPrinter();
            myBasic.Print();

            Console.WriteLine("--------------------------");
            AdvancedPrinter myPro = new AdvancedPrinter();
            myPro.Print();
            myPro.Scan();
            myPro.Fax();


            Console.ReadLine();
        }
    }
}