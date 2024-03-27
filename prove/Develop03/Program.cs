using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var scripture = new Scripture(new Reference("John", 3, 16), "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life");
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit:");
            var userInput = Console.ReadLine();
            if (userInput.Equals("quit", StringComparison.OrdinalIgnoreCase))
                break;

            scripture.HideRandomWords();
            if (scripture.IsCompletelyHidden())
                break;
        }
    }
}

class Scripture
{
    private List<Word> _entries;

    public Scripture(Reference reference, string text)
    {
        _entries = text.Split(' ').Select(word => new Word(word)).ToList();
        Reference = reference;
    }

    public Reference Reference { get; }

    public void HideRandomWords()
    {
        var random = new Random();
        int numToHide = random.Next(1, _entries.Count / 2); // Hide up to half of the words
        for (int i = 0; i < numToHide; i++)
        {
            int index = random.Next(_entries.Count);
            _entries[index].Hide();
        }
    }

    public string GetDisplayText()
    {
        return $"{Reference.GetDisplayText()}\n{_entries.Aggregate("", (current, word) => current + (word.IsHidden ? "______ " : word.GetDisplayText() + " "))}";
    }

    public bool IsCompletelyHidden()
    {
        return _entries.All(word => word.IsHidden);
    }
}

public class Word
{
    private string _text;
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        _text = text;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }

    public string GetDisplayText()
    {
        return _text;
    }
}

public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }

    public Reference(string book, int chapter, int verse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = endVerse;
    }

    public string GetDisplayText()
    {
        if (_endVerse == 0)
            return $"{_book} {_chapter}:{_verse}";
        else
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
    }
}
