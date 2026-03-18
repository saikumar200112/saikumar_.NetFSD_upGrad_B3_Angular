using System;

namespace consoleApp1
{
    public record Student(int Roll, string Name, string Course, double Marks);

    class Program
    {
        static void Main()
        {
            
            Console.Write("Enter number of students: ");
            int size = int.Parse(Console.ReadLine());
            Student[] students = new Student[size];
            int count = 0;

            bool exit = false;
            while (!exit)
            {
                
                Console.WriteLine("\n-------- MENU-------- ");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Display All");
                Console.WriteLine("3. Search by Roll No");
                Console.WriteLine("4. Exit");
                Console.Write("Select Option: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    count = AddStudentRecord(students, count);
                }
                else if (choice == "2")
                {
                    DisplayRecords(students, count);
                }
                else if (choice == "3")
                {
                    SearchRecord(students, count);
                }
                else if (choice == "4")
                {
                    exit = true;
                }
                else
                {
                    Console.WriteLine("Invalid choice!");
                }
            }
        }

        
        static int AddStudentRecord(Student[] students, int count)
        {
            if (count >= students.Length)
            {
                Console.WriteLine("Array is full!");
                return count;
            }

            Console.Write("Enter Roll Number: ");
            int roll = int.Parse(Console.ReadLine());

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Course: ");
            string course = Console.ReadLine();

            Console.Write("Enter Marks: ");
            double marks = double.Parse(Console.ReadLine());

            students[count] = new Student(roll, name, course, marks);
            Console.WriteLine("Record Saved!");

            return count + 1; 
        }

      
        static void DisplayRecords(Student[] students, int count)
        {
            Console.WriteLine("\nStudent Records:");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Roll No:  { students[i].Roll }  | Name:  { students[i].Name }  | Marks:  { students[i].Marks}");
            }
        }


        static void SearchRecord(Student[] students, int count)
        {
            Console.Write("Enter Roll Number to Search: ");
            int searchRoll = int.Parse(Console.ReadLine());
            bool found = false;

            for (int i = 0; i < count; i++)
            {
                if (students[i].Roll == searchRoll)
                {
                    Console.WriteLine("Student Found: " + students[i].Name + " (" + students[i].Course + ")");
                    found = true;
                    break;
                }
            }

            if (found == false)
            {
                Console.WriteLine("Record not found.");
            }
        }
    }
}