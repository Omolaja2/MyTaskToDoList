using System;
using System.Collections.Generic;

namespace MyToDo_List
{
    public class ToDoTask
    {
        public int Id { get; set; }
        public string? Task { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDone { get; set; }

        public void MarkTask()
        {
            IsDone = true;
        }
    }

    public class AllTasks
    {
        private List<ToDoTask> tasks;

        public AllTasks()
        {
            tasks = [];
        }

        public ToDoTask AddTaskInput()
        {
            Console.WriteLine("Enter a task you're adding:");
            string taskInput = Console.ReadLine()!;

            return new ToDoTask
            {
                Task = taskInput
            };
        }

        public void AddTask()
        {
            
            int id = tasks.Count > 0 ? tasks.Count + 1 : 1;
            var addTaskInput = AddTaskInput();

            var newTask = new ToDoTask
            {
                Id = id,
                Task = addTaskInput.Task,
                CreatedAt = DateTime.Now
            };

            tasks.Add(newTask);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Your Task => '{newTask.Task}' and ID {newTask.Id} created successfully!");
            Console.ResetColor();
            Console.WriteLine(" ");

        }
        public void DeleteTax()
        {
            Console.Write("Enter the ID of Tax: ");
            int id = int.Parse(Console.ReadLine()!);
            var task = tasks.Find(x => x.Id == id);

            if (task is null)
            {
                Console.WriteLine("the Tax  you are trying to delete does not exist!", ConsoleColor.Red);
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"Tax {task.Id} Deleted Sharp", ConsoleColor.Green);

            }

            Console.ResetColor();

        }

        public void ViewAll()

        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("There is no Task in Data BAse yet!. Add a new tasks", ConsoleColor.Cyan);
                return;
            }
            foreach (var ViewAllTask in tasks)
            {
                Console.WriteLine(string.Join(" ", ViewAllTask.Task + " Was Created At :", ViewAllTask.CreatedAt));
            }
            Console.ResetColor();
        }

        public void MarkTask()
        {
            Console.WriteLine("Enter Id Of The Task You want to Mark");
            int id = int.Parse(Console.ReadLine()!);
            var task = GetById(id);

            if (task != null)
            {
                tasks[id-1].MarkTask();
                Console.WriteLine("Task Complete", ConsoleColor.Yellow);
                Console.ResetColor();

            }
            else
            {
                Console.WriteLine("Not Found");
            }

        }

        public void UpdateTask()
        {
            Console.Write("Enter the ID of the task to update: ");
            int id = int.Parse(Console.ReadLine()!);
            var task = GetById(id);

            if (task is null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The task you are trying to update does not exist!");
            }
            else
            {
                Console.WriteLine($"Current Task: {task.Task}");
                Console.Write("Enter the new task : ");
                string updatedTask = Console.ReadLine()!;

                task.Task = updatedTask;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Task {task.Id} updated successfully To => '{task.Task}'.");
            }

            Console.ResetColor();

        }
        private ToDoTask? GetById(int id){
            return tasks.Find(x => x.Id == id);

        }


    }
}




