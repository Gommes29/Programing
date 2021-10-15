using System;
using System.Collections.Generic;

namespace Basilisk_fight
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> pcNames = new List<string> { "Jazlyn", "Theron", "Dayana", "Rolando" };
            Random random = new Random();
            string outputText = "";
            int basiliskTotalHP = 0;
            int dagger = 0;
            int constitution = 5;
            int conSave = 0;
            int basiliskDice = 0;
            int hitTarget = 0;

            Console.Write("A party of warriors {0}", string.Join(", ", pcNames));
            Console.Write(" descends into the dungeon.");
            Console.WriteLine();

            for (int x = 0; x < 7; ++x)
            {
                basiliskDice += random.Next(1, 9);
            }
            basiliskDice += 16;
            basiliskTotalHP = basiliskDice;
            Console.WriteLine($"A basilisk with {basiliskTotalHP} HP appears!");

            while (basiliskTotalHP > 0)
            {
                foreach (string name in pcNames)
                {
                    dagger = random.Next(1, 3);
                    basiliskTotalHP -= dagger;
                    if (basiliskTotalHP < 0 || basiliskTotalHP == 0)
                    {
                        basiliskTotalHP = 0;
                        Console.WriteLine($"{name} hits the basilisk for {dagger}. Basilisk has {basiliskTotalHP} HP left.");
                        break;
                    }
                    Console.WriteLine($"{name} hits the basilisk for {dagger}. Basilisk has {basiliskTotalHP} HP left.");

                }
                hitTarget = random.Next(0, pcNames.Count);
                conSave = random.Next(1, 21) + constitution;
                Console.WriteLine($"The basilisk casts petryfying gaze on {pcNames[hitTarget]}. They roll a constituion save with DC12 and rolls {conSave}");
                if (conSave < 12)
                {
                    Console.WriteLine($"{pcNames[hitTarget]} fails their check and is turned to stone. :c");
                    Console.WriteLine();
                    pcNames.RemoveAt(hitTarget);
                    if (pcNames.Count == 0)
                    {
                        Console.WriteLine("Game over. :c");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine($"{pcNames[hitTarget]} succeeds their saving throw and is not petrified.");
                    Console.WriteLine();
                }
            }
            if (basiliskTotalHP == 0)
            {
                Console.WriteLine("The basilisk collapses and the heroes celebrate their victory! :D");
            }

        }
    }
}
