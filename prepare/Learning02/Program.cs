using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning02 World!");
        
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Apple";
        job1._startYear = 2019;
        job1._endYear = 2024;


        Job job2 = new Job();
        job2._jobTitle = "Nurse";
        job2._company = "St Lukes";
        job2._startYear = 2018;
        job2._endYear = 2023;

        Job job3 = new Job();
        job3._jobTitle = "Architect";
        job3._company = "RCF Company";
        job3._startYear = 2011;
        job3._endYear = 2022;

        Job job4 = new Job();
        job4._jobTitle = "Pilot";
        job4._company = "Luftansa";
        job4._startYear = 2017;
        job4._endYear = 2024;
        
        Resume myResume = new Resume();
        myResume._name = "Vanessa Tejada";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();

    }
}