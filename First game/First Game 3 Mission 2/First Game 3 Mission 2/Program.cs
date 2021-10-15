using System;

namespace First_Game_3_Mission_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();

            int healthPoints = random.Next(1, 101);
            
            

            

                Console.WriteLine($"Warrior HP: {healthPoints}");
                Console.WriteLine("the Regenerate spell is cast!");
            
            while (healthPoints < 50)
            {
                healthPoints = healthPoints + 10;
                Console.WriteLine($"Warrior HP: {healthPoints}");
            }


            Console.WriteLine("The Regeneration spell is complete.");
            






        }
    }
}
