using System;
using System.IO;

namespace Files_mission_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] backers = File.ReadAllLines("backers.txt");

            Console.WriteLine("Welcome honoured guest and whom might you be?");
            Console.WriteLine();
            string name = Console.ReadLine();
            string output = "";
            foreach (string backer in backers)
            {
                if (backer == name)
                {
                    output = $"Ah i see... i do hope you enjoy your stay master {name}.";
                    break;
                }
                else
                {
                    output ="Pardon, but this exquisite party is for financial suporters only!, shoo shoo away with you!";
                   
                }
            }
            Console.WriteLine(output);


        }
    }
}
