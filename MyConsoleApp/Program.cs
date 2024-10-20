using System;
using System.Collections.Generic;

namespace TodoApp
{
    class Program
    {
        static List<string> todoList = new List<string>();

        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("Simple To-Do List App");
                Console.WriteLine("=======================");
                Console.WriteLine("1. View To-Do List");
                Console.WriteLine("2. Add a Task");
                Console.WriteLine("3. Remove a Task");
                Console.WriteLine("4. Mark Task as Complete");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        ViewTasks();
                        break;
                    case "2":
                        AddTask();
                        break;
                    case "3":
                        RemoveTask();
                        break;
                    case "4":
                        MarkTaskComplete();
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }

        static void ViewTasks()
        {
            Console.Clear();
            Console.WriteLine("Your To-Do List:");
            Console.WriteLine("================");

            if (todoList.Count == 0)
            {
                Console.WriteLine("Your to-do list is empty.");
            }
            else
            {
                for (int i = 0; i < todoList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {todoList[i]}");
                }
            }

            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        static void AddTask()
        {
            Console.Clear();
            Console.Write("Enter the task to add: ");
            string task = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(task))
            {
                todoList.Add(task);
                Console.WriteLine($"Task '{task}' added successfully!");
            }
            else
            {
                Console.WriteLine("Task cannot be empty.");
            }

            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        static void RemoveTask()
        {
            ViewTasks();
            Console.Write("Enter the task number to remove: ");
            if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= todoList.Count)
            {
                string taskToRemove = todoList[taskNumber - 1];
                todoList.RemoveAt(taskNumber - 1);
                Console.WriteLine($"Task '{taskToRemove}' removed successfully!");
            }
            else
            {
                Console.WriteLine("Invalid task number.");
            }

            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        static void MarkTaskComplete()
        {
            ViewTasks();
            Console.Write("Enter the task number to mark as complete: ");
            if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= todoList.Count)
            {
                todoList[taskNumber - 1] += " [COMPLETED]";
                Console.WriteLine($"Task '{todoList[taskNumber - 1]}' marked as complete!");
            }
            else
            {
                Console.WriteLine("Invalid task number.");
            }

            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }
    }
}
