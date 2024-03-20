using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Tracing;

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
class Journal{

    private List<JournalEntry> entries = new List<JournalEntry>();
    public void AddEntry(string date, string prompt, string response)
    {
        entries.Add(new JournalEntry(date, prompt, response));
    }

    public void DisplayEntries()
    {
      foreach (var entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}\n");
        }
   
    } 

    
    public void SavetoFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }   
        }
        Console.WriteLine("Save Successfully.");

    }
    public void LoadFromFile(string filename)
    {
        entries.Clear();
        try
        {
        using(StreamReader reader = new StreamReader(filename))
        {
             string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        entries.Add(new JournalEntry(parts[0], parts[1], parts[2]));
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
       
        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();
        

        Random randomGenerator = new Random();
        string [] questions = {"Who was the most interesting person I interacted with today? ", "What was the best part of my day? ",
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
                journal.SavetoFile(saveFilename);
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