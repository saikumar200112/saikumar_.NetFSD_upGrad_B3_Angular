namespace ConsoleApp1
{
    


    
    internal class Program
    {
        static void Main(string[] args)
        {
 
            var emp = new Employee("Saikumar", 5000m, 30,101);

           // Console.WriteLine(emp.EmployeeId); 
            //emp.GiveRaise(10);
            //emp.Salary = 500;
            //emp.FullName="";
            //emp.GiveRaise(40);
            //emp.Age = 12;
            Console.WriteLine($"Full Name :{emp.FullName}");
            Console.ReadLine();


        }
    }
}
