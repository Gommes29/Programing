using System;
using System.IO;

namespace Files_mission_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var player = "player-name.txt";

            if (File.Exists(player))
            {
                Console.WriteLine($"Welcome back, {File.ReadAllText(player)}, let's continue our adventure!");
            }
            else
            {
                Console.WriteLine("Welcome to your biggest adventure yet!");
                Console.WriteLine();
                Console.WriteLine("What is your name, traveler?");
                File.WriteAllText(player, Console.ReadLine());
                
                if (File.Exists(player))
                {
                    Console.WriteLine();
                    Console.WriteLine($"Nice to meet you {File.ReadAllText(player)}!");
                }


            }
            Console.ReadKey();



        }
    }
}
