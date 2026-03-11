namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Number");
            int n = int.Parse(Console.ReadLine());
            int evenCount = 0;
            int oddCount = 0;
            int totalSum = 0;
            
            for(int i = 1; i<=n; i++)
            {
                totalSum = totalSum + i;
                if (i % 2 == 0)
                {
                    evenCount++;
                }
                else
                {
                    oddCount++;
                }
            }
            Console.WriteLine($"Even Count: {evenCount}");
            Console.WriteLine($"Odd Count :{oddCount}");
            Console.WriteLine($"Total Sum :{totalSum}");

            Console.ReadLine();

        }
    }
}
