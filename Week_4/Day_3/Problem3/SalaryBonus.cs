namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Employee Name");
            string ename=Console.ReadLine();

            Console.WriteLine("Enter Salary");
            double salary = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter Experience");
            int expereience = int.Parse(Console.ReadLine());

            double bonusPercentage;
            if (expereience < 2)
            {
                bonusPercentage = 0.05;
            }
            else if (expereience <= 5)
            {
                bonusPercentage = 0.10;
            }
            else
            {
                bonusPercentage = 0.15; 
            }
            double bonus = salary * bonusPercentage;
            double finalAmount = (salary > 0) ? (salary + bonus) : 0;
            Console.WriteLine($"Employee :{ename}");
            Console.WriteLine($"Bonus :{bonus}");
            Console.WriteLine($"Final Salary :{finalAmount}");
        }
    }
}
