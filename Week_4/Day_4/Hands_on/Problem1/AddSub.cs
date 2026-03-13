namespace ConsoleApp1
{
    class Calculator
    {

        public int Add(int a, int b)
        {
            ;
            return a + b;
        }
        public int Subtract(int a, int b)
        {

            return a - b;
        }


    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter First Number");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Scond Number");
            int b = int.Parse(Console.ReadLine());

            Calculator c = new Calculator();
            int Add = c.Add(a,b);
            int Sub = c.Subtract(a,b);
            Console.WriteLine($"Addition of Two Numbers :{Add}");
            Console.WriteLine($"Subtraction of Two Numbers :{Sub}");

        }
    }
}
