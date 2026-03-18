using System;
namespace consoleApp1
{
    public class EmployeeNode
    {
        public int Id;
        public string Name;
        public EmployeeNode Next;

        public EmployeeNode(int id, string name)
        {
            Id = id;
            Name = name;
            Next = null;
        }
    }
    public class EmployeeLinkedList
    {
        private EmployeeNode head;


        public void InsertAtBeginning(int id, string name)
        {
            EmployeeNode newNode = new EmployeeNode(id, name);
            newNode.Next = head;
            head = newNode;
        }


        public void InsertAtEnd(int id, string name)
        {
            EmployeeNode newNode = new EmployeeNode(id, name);
            if (head == null)
            {
                head = newNode;
                return;
            }

            EmployeeNode temp = head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            temp.Next = newNode;
        }


        public void DeleteById(int id)
        {
            if (head == null) return;


            if (head.Id == id)
            {
                head = head.Next;
                return;
            }

            EmployeeNode current = head;
            while (current.Next != null && current.Next.Id != id)
            {
                current = current.Next;
            }


            if (current.Next != null)
            {
                current.Next = current.Next.Next;
            }
        }


        public void Display()
        {
            EmployeeNode temp = head;
            while (temp != null)
            {
                Console.WriteLine($"{temp.Id} - {temp.Name}");
                temp = temp.Next;
            }
        }
    }
    internal class Program
    {
        static void Main()
        {
            EmployeeLinkedList list = new EmployeeLinkedList();


            list.InsertAtEnd(101, "saikumar");
            list.InsertAtEnd(102, "vamsi");
            list.InsertAtEnd(103, "jaswanth");

            Console.WriteLine("Original List:");
            list.Display();


            list.DeleteById(102);

            Console.WriteLine("\nEmployee List After Deletion:");
            list.Display();

            Console.ReadLine();
        }
    }
}