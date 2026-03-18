using System;
namespace consoleApp1
{
    class UndoSystem
    {
        private string[] stack;
        private int top;
        private int capacity;

        public UndoSystem(int size)
        {
            capacity = size;
            stack = new string[capacity];
            top = -1;
        }

        
        public void AddAction(string action)
        {
            if (top >= capacity - 1)
            {
                Console.WriteLine("Stack Overflow: Cannot add more actions.");
                return;
            }
            stack[++top] = action;
            Console.WriteLine($"Action Added: {action}");
        }

        
        public void Undo()
        {
            if (top < 0)
            {
                Console.WriteLine("Nothing to undo (Stack Empty).");
                return;
            }
            Console.WriteLine($"Undoing: {stack[top--]}");
        }

       
        public void DisplayState()
        {
            if (top < 0)
            {
                Console.WriteLine("Current State: [Empty]");
                return;
            }

            Console.Write("Current State: ");
            for (int i = 0; i <= top; i++)
            {
                Console.Write(stack[i] + " ");
            }
            Console.WriteLine();
        }
    }
    internal class program
    {
        static void Main(string[] args)
        {
            UndoSystem undo = new UndoSystem(5);

         
            undo.AddAction("Type A");
            undo.AddAction("Type B");
            undo.AddAction("Type C");

            undo.DisplayState();

            //  undo.Undo();
            //  undo.DisplayState();

            // undo.Undo();
            // undo.DisplayState();

            Console.ReadLine();
        }
    }
}