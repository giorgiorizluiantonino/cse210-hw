using System;
using System.Threading;

// Base class for all activities
public abstract class Activity
{
    protected int durationInSeconds;
    protected string name;

    public Activity(string name, int duration)
    {
        this.name = name;
        durationInSeconds = duration;
    }

    // Method to perform the activity
    public virtual void PerformActivity()
    {
        DisplayStartingMessage();
        DoActivity();
        DisplayEndingMessage();
    }

    // Method to display starting message
    protected void DisplayStartingMessage()
    {
        Console.WriteLine($"Starting {name} Activity...");
        Console.WriteLine($"Duration set to {durationInSeconds} seconds.");
        Thread.Sleep(2000);
    }

    // Method to display ending message
    protected void DisplayEndingMessage()
    {
        Console.WriteLine($"Congratulations! You've completed the {name} Activity.");
        Console.WriteLine($"Time taken: {durationInSeconds} seconds.");
        Thread.Sleep(2000);
    }

    // Abstract method to perform the activity specific actions
    protected abstract void DoActivity();
}

// Breathing Activity class
public class BreathingActivity : Activity
{
    public BreathingActivity(int duration) : base("Breathing", duration) { }

    protected override void DoActivity()
    {
        Console.WriteLine("Breathing in...");
        Thread.Sleep(1000);
        Console.WriteLine("Breathing out...");
        Thread.Sleep(1000);
    }
}

// Reflection Activity class
public class ReflectionActivity : Activity
{
    private string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] questions = {
        "Why was this experience meaningful to you?",
        "How did you feel when it was complete?",
        "What did you learn about yourself through this experience?"
    };

    public ReflectionActivity(int duration) : base("Reflection", duration) { }

    protected override void DoActivity()
    {
        Random rand = new Random();
        Console.WriteLine(prompts[rand.Next(prompts.Length)]);

        foreach (string question in questions)
        {
            Console.WriteLine(question);
            Thread.Sleep(2000);
        }
    }
}

// Listing Activity class
public class ListingActivity : Activity
{
    private string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(int duration) : base("Listing", duration) { }

    protected override void DoActivity()
    {
        Random rand = new Random();
        Console.WriteLine(prompts[rand.Next(prompts.Length)]);

        Console.WriteLine("You have a few seconds to think...");
        Thread.Sleep(5000);

        Console.WriteLine("Start listing:");

        // Logic to capture user input could be added here

        Console.WriteLine("Number of items listed: [n]");
    }
}

// Main program
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Choose an activity:");
        Console.WriteLine("1. Breathing");
        Console.WriteLine("2. Reflection");
        Console.WriteLine("3. Listing");
        Console.Write("Enter your choice: ");
        int choice = int.Parse(Console.ReadLine());

        Activity activity;

        switch (choice)
        {
            case 1:
                Console.Write("Enter duration in seconds: ");
                int breathingDuration = int.Parse(Console.ReadLine());
                activity = new BreathingActivity(breathingDuration);
                break;
            case 2:
                Console.Write("Enter duration in seconds: ");
                int reflectionDuration = int.Parse(Console.ReadLine());
                activity = new ReflectionActivity(reflectionDuration);
                break;
            case 3:
                Console.Write("Enter duration in seconds: ");
                int listingDuration = int.Parse(Console.ReadLine());
                activity = new ListingActivity(listingDuration);
                break;
            default:
                Console.WriteLine("Invalid choice. Exiting...");
                return;
        }

        activity.PerformActivity();
    }
}
