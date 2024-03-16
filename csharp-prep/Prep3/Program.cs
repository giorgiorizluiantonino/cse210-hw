using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {

        Random randomgenerator = new Random();
        int magic_number  = randomgenerator.Next(1,10);

        int guess = -1;
       

        
        while (guess !=  magic_number){
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());


            if (magic_number > guess)
            {
                Console.WriteLine("Higher");
            }

            else if (magic_number < guess)
            {
                Console.WriteLine("Lower");
            }

            else 
            {
                Console.WriteLine("You guessed it!");
            }


        }

    }
}