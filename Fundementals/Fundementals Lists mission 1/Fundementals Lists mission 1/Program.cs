using System;
using System.Collections.Generic;

namespace Fundementals_Lists_mission_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> abilityScores = new List<int> ();
            int totalScores = 6;
            for (int x = 0; x < totalScores; ++x)
            {
                List<int> diceGeneration = new List<int> { 0, 0, 0, 0 };
                Random random = new Random { };
                int finalStat = 0;
                string rollText = "You roll ";
                for (int dice = 0; dice < diceGeneration.Count; ++dice)
                {
                    int diceOne = random.Next(1, 7);
                    diceGeneration[dice] = diceOne;
                    rollText = rollText + diceGeneration[dice];
                    if (dice == 3)
                    {
                        rollText = rollText + ", ";
                    }
                    else
                    {
                        rollText = rollText + ", ";
                    }
                            
                }
                diceGeneration.Sort();
                diceGeneration.RemoveAt(0);
                foreach (var i in diceGeneration)
                {
                    finalStat += i;
                }
                rollText = rollText + "The ability score is " + finalStat;
                Console.WriteLine(rollText);
            }

            
            
        }
    }
}
