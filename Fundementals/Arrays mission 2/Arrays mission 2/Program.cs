using System;

namespace Arrays_mission_2
{
    class Program
    {
         static int DiceRoll(int numberOfRolls, int diceSides, int fixedBonus = 0)
        {
            var random = new Random();
            int result = 0;
            for (int i = 0; i < numberOfRolls; i++)
            {
                result += random.Next(1, diceSides + 1);
            }
            result += fixedBonus;
            return result;
        }
        static void Main(string[] args)
        { 
            int[] monstersPerLvl = new int[10];
            for (int i = 0; i < monstersPerLvl.Length; i++)
            {
                monstersPerLvl[i] = DiceRoll(1, 30);
            }
           

            Array.Sort(monstersPerLvl);

           

            Console.WriteLine("[{0}]", string.Join(", ", monstersPerLvl));
                
            
        }
    }
}
