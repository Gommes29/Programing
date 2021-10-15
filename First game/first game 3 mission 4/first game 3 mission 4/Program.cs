using System;

namespace first_game_3_mission_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();


            var dice = 0;
            var strength = 0;
            var hitPoints = 0;
            var armyHitPoints = 0;

            for (int strengthRoll = 0; strengthRoll < 3; strengthRoll++)
            {
                dice = random.Next(1, 7);
                strength += dice;

            }
           
            for (int HpRoll = 0; HpRoll < 8; HpRoll++)
            {
                dice = random.Next(1, 11);
                hitPoints += dice;

            }

            for (int army = 0; army < 100; army++)
            {
                for (int HpRoll = 0; HpRoll < 8; HpRoll++)
                {
                    dice = random.Next(1, 11);
                    armyHitPoints += dice;

                }
                armyHitPoints += 40;
            }
            hitPoints += 40;
            Console.WriteLine($"A character with strength {strength} was created.");
            Console.WriteLine($"A gelatinous cube with {hitPoints} HP appears!");
            Console.WriteLine($"Dear gods, am army of 100 cubes descends upon us with a total of {armyHitPoints} HP. We are DOOOMED!");
        }
    }
}
