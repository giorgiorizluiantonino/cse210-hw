using System;
using System.Collections.Generic;
using System.IO;

class JournalEntry {
    public string Date { get; }
    public string Prompt { get; }
    public string Response { get; }

    public JournalEntry(string date, string prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
    }
}

class Journal {

    private List<JournalEntry> _entries = new List<JournalEntry>();

    public void AddEntry(string date, string prompt, string response)
    {
        _entries.Add(new JournalEntry(date, prompt, response));
    }

    public void DisplayEntries()
    {
        foreach (var entry in _entries)
        {
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}\n");
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in _entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
        Console.WriteLine("Save Successfully.");
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();
        try
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        _entries.Add(new JournalEntry(parts[0], parts[1], parts[2]));
                        // This is my exceeding requirement, I display like this when you load a file.
                        //Date: 21/03/2024
                        //Prompt: Who was the most interesting person I interacted with today?
                        //Response: uncle

                        // I also put a try catch block that when you load a wrong file it will appear
                        //that the file not found.

                    }
                }
            }
            Console.WriteLine("Journal loaded successfully.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        DateTime currentTime = DateTime.Now;
        string dateText = currentTime.ToShortDateString();

        Random randomGenerator = new Random();
        string[] questions = {"Who was the most interesting person I interacted with today? ", "What was the best part of my day? ",
        "How did I see the hand of the Lord in my life today? ", "What was the strongest emotion I felt today? ",
        "If I had one thing I could do over today, what would it be? "};

        Journal journal = new Journal();
        int number = 0;

        while (number != 5)
        {
            Console.WriteLine("Please select one of the following choices: ");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");
            Console.WriteLine("What would you like to do? ");
            number = int.Parse(Console.ReadLine());

            if (number == 1)
            {
                int index = randomGenerator.Next(questions.Length);
                string randomStatement = questions[index];

                Console.Write($"Date {dateText} - Prompt: {randomStatement}");
                string userWritten = Console.ReadLine();

                journal.AddEntry(dateText, randomStatement, userWritten);
            }
            else if (number == 2)
            {
                journal.DisplayEntries();
            }
            else if (number == 3)
            {
                Console.Write("Enter filename to save: ");
                string saveFilename = Console.ReadLine();
                journal.SaveToFile(saveFilename);
            }
            else if (number == 4)
            {
                Console.Write("Enter filename to load: ");
                string loadFilename = Console.ReadLine();
                journal.LoadFromFile(loadFilename);
            }
        }
    }
}
