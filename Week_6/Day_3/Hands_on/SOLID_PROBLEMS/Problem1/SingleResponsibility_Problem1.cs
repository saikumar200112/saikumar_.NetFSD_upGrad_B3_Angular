using System.Collections.Generic;
namespace consoleApp1
{
    public class Student
    {
        public int StudentId;
        public string StudentName;
        public double Marks;
    }
    public class StudentRepository
    {

        public List<Student> StudentList = new List<Student>();

        public void AddStudent(Student s)
        {
            StudentList.Add(s);
        }
    }
    public class ReportGenerator
    {
        public void PrintReport(List<Student> students)
        {
            Console.WriteLine("ACADEMY REPORT");
            foreach (var s in students)
            {
                Console.WriteLine("ID: " + s.StudentId + "  Name: " + s.StudentName + "  Marks: " + s.Marks);
            }
            Console.WriteLine();
        }
    }

   internal class Program
    {
        static void Main(string[] args)
        {

            StudentRepository repo = new StudentRepository();


            Student s1 = new Student();
            s1.StudentId = 1;
            s1.StudentName = "Saikumar";
            s1.Marks = 85;
            repo.AddStudent(s1);

            Student s2 = new Student();
            s2.StudentId = 2;
            s2.StudentName = "Jaswanth";
            s2.Marks = 95;
            repo.AddStudent(s2);

            Student s3 = new Student();
            s3.StudentId = 3;
            s3.StudentName = "Satish";
            s3.Marks = 90;
            repo.AddStudent(s3);


            ReportGenerator reporter = new ReportGenerator();
            reporter.PrintReport(repo.StudentList);

            Console.ReadLine();
        }
    }
}