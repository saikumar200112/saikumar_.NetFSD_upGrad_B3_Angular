namespace ConsoleApp1
{
    class Student
    {


        public double CalculateAverage(int m1, int m2, int m3)
        {
          
            return (m1 + m2 + m3) / 3.0;
        }
        public string GetGrade(double average)
        {
            if (average >= 80)
            {
                return "A";
            }
            else if (average >= 70)
            {
                return "B";
            }
            else if (average >= 60)
            {
                return "C";
            }
            else if (average >= 50)
            {
                return "D";
            }
            else
            {
                return "Fail";
            }
        }


    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int a, b, c;
            Console.WriteLine("enter marks");
            string str = Console.ReadLine();
            string[] st = str.Split(" ");
             a =int.Parse( st[0]);
             b = int.Parse(st[1]);
             c = int.Parse(st[2]);
            Student s = new Student();
            double avg = s.CalculateAverage(a,b,c);
            string Grade = s.GetGrade(avg);
            Console.WriteLine($"Average Marks :{avg}");
            Console.WriteLine($"Grade :{Grade}");

            Console.ReadLine();
        }
    }
}
