using System;
using System.Collections.Generic;
namespace consoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<string> tasks = new List<string>();
            bool running = true;

            while (running)
            {
                
                Console.WriteLine("\nTo-Do List ");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View Tasks");
                Console.WriteLine("3. Remove Task");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                      
                        Console.Write("Enter task: ");
                        string newTask = Console.ReadLine();

                        if (!string.IsNullOrWhiteSpace(newTask))
                        {
                            tasks.Add(newTask);
                            Console.WriteLine("Task added!");
                        }
                        else
                        {
                            Console.WriteLine("Task description cannot be empty.");
                        }
                        break;

                    case "2":
                        
                        Console.WriteLine("\nTasks:");
                        if (tasks.Count == 0)
                        {
                            Console.WriteLine("The list is empty.");
                        }
                        else
                        {
                            
                            for (int i = 0; i < tasks.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {tasks[i]}");
                            }
                        }
                        break;

                    case "3":
                       
                        if (tasks.Count == 0)
                        {
                            Console.WriteLine("Nothing to remove. The list is empty.");
                            break;
                        }

                        Console.Write("Enter task number to remove: ");
                        string input = Console.ReadLine();

                        
                        if (int.TryParse(input, out int taskNum) && taskNum >= 1 && taskNum <= tasks.Count)
                        {
                           
                            string removedTask = tasks[taskNum - 1];
                            tasks.RemoveAt(taskNum - 1);
                            Console.WriteLine($"Removed: {removedTask}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid task number.");
                        }
                        break;

                    case "4":
                        
                        running = false;
                        Console.WriteLine("Exiting... Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}