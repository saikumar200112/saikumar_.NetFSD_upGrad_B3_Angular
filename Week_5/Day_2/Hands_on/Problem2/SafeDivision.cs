using System;
namespace consoleApp1
{
    public class Calculator
    {
        public void Divide(int numerator, int denominator)
        {
            try
            {
               
                int result = numerator / denominator;
                Console.WriteLine($"Result: {result}");
            }
            catch (DivideByZeroException)
            {
                
                Console.WriteLine("Cannot divide by zero");
            }
            catch (Exception ex)
            {
              
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
            finally
            {
                
                Console.WriteLine("Operation completed safely");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator myCalc = new Calculator();


            
            myCalc.Divide(20, 0);  //error because 20 cannot divide by 0

           
            myCalc.Divide(20, 5);  //it will excute because 20 divide by 5

            Console.ReadLine();
           
        }
    }
}