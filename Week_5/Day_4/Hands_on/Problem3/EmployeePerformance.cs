
using System.IO;
namespace consoleApp1
{
                
    internal class Program
    {
        static void Main(string[] args)
        {
          

               
                Console.Write("Enter Employee Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Monthly Sales Amount: ");
                double sales = double.Parse(Console.ReadLine());

                Console.Write("Enter Customer Feedback Rating [1-5]: ");
                int rating = int.Parse(Console.ReadLine());

               
                var performanceData = GetPerformanceData(sales, rating);

             
                string category = performanceData switch
                {
                    ( >= 100000, >= 4) => "High Performer",
                    ( >= 50000, >= 3) => "Average Performer",
                    _ => "Needs Improvement" 
                };

             
                Console.WriteLine("\n--- Employee Evaluation ---");
                Console.WriteLine($"Employee Name: {name}");
                Console.WriteLine($"Sales Amount: {performanceData.Item1}");
                Console.WriteLine($"Rating: {performanceData.Item2}");
                Console.WriteLine($"Performance: {category}");

                

              Console.ReadLine();
        }

          
            static (double, int) GetPerformanceData(double s, int r)
            {
                return (s, r);
            }
        
    }
}