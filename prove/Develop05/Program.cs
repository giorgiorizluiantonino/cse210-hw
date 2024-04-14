using System;
using System.IO;
using System.Collections.Generic;

class TaskManager
{
    private int experiencePoints = 0;
    private int level = 1;
    private List<string> tasks = new List<string>();

    public void CompleteTask(string task)
    {
        experiencePoints += 10;
        tasks.Add(task);
        Console.WriteLine("Task completed! You earned 10 experience points.");
        
        if (experiencePoints >= 100)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        level++;
        experiencePoints -= 100;
        Console.WriteLine("Congratulations! You leveled up to level " + level + "!");
    }

    public void ViewProfile()
    {
        Console.WriteLine("\nProfile:");
        Console.WriteLine("Level: " + level);
        Console.WriteLine("Experience Points: " + experiencePoints);
        Console.WriteLine("\nTasks:");
        foreach (var task in tasks)
        {
            Console.WriteLine("- " + task);
        }
    }

    public void SerializeTasks(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (var task in tasks)
            {
                outputFile.WriteLine(task);
            }
        }
        Console.WriteLine("Tasks serialized to " + filename);
    }

    public void DeserializeTasks(string filename)
    {
        tasks.Clear(); // Clear existing tasks
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            tasks.AddRange(lines);
            Console.WriteLine("Tasks deserialized from " + filename);
        }
        else
        {
            Console.WriteLine("File not found: " + filename);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        TaskManager taskManager = new TaskManager();
        string filename = "tasks.txt";

        Console.WriteLine("Welcome to the Gamified Task Manager!");

        while (true)
        {
            DisplayMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter task: ");
                    string task = Console.ReadLine();
                    taskManager.CompleteTask(task);
                    break;
                case "2":
                    taskManager.ViewProfile();
                    break;
                case "3":
                    taskManager.SerializeTasks(filename);
                    break;
                case "4":
                    taskManager.DeserializeTasks(filename);
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("\nMain Menu:");
        Console.WriteLine("1. Complete Task");
        Console.WriteLine("2. View Profile");
        Console.WriteLine("3. Serialize Tasks");
        Console.WriteLine("4. Deserialize Tasks");
        Console.WriteLine("5. Exit");
        Console.Write("Enter your choice: ");
    }
}