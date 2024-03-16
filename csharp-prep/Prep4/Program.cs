using System;

class Program
{
    static void Main(string[] args)
     {
        List<int> numbers = new List<int>();
        
        int user_num = -1;
        while (user_num != 0)
        {
            Console.Write("Enter a number (0 to quit): ");
            
            string response = Console.ReadLine();
            user_num = int.Parse(response);
            
           
            if (user_num != 0)
            {
                numbers.Add(user_num);
            }
        }

      
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is: {sum}");

        
        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

      
        
        int max = numbers[0];

        foreach (int number in numbers)
        {
            if (number > max)
            {
                
                max = number;
            }
        }

        Console.WriteLine($"The max is: {max}");
    }
}