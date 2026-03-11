namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Your Name");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Your Marks");
            int marks = int.Parse(Console.ReadLine());

            string grade;
            if (marks >= 90)
            {
                grade = "A";
            }
            else if (marks >= 80)
            {
                grade = "B";
            }
            else if (marks >= 70)
            {
                grade = "C";
            }
            else if (marks >= 60)
            {
                grade = "D";
            }
            else
            {
                grade = "Fail";
            }
            Console.WriteLine($"Student Name :{name}");
            Console.WriteLine($"Marks :{marks}");
            Console.WriteLine($"Grade :{grade}");

            Console.ReadLine();
        }
    }
}
