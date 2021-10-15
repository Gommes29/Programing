using System;
using System.Collections.Generic;

namespace Battle_simulator
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

        static List<string> pcNames = new List<string> { "Jazylyn", "Theron", "Dayana", "Rolando" };
        static List<string> enemyTypes = new List<string> { "orc", "Mage", "troll" };
        static List<int> enemyHPs = new List<int> { };
        static List<int> dcValues = new List<int> { 12, 20, 18 };
        static void Main(string[] args)
        {
            int orcHP = 0;
            int mageHP = 0;
            int trollHP = 0;


            orcHP = DiceRoll(2, 8, 6);
            mageHP = DiceRoll(9, 8);
            trollHP = DiceRoll(8, 10, 40);

            enemyHPs.Add(orcHP);
            enemyHPs.Add(mageHP);
            enemyHPs.Add(trollHP);

            Console.WriteLine("A party of warriors {0}", string.Join(", ", pcNames));
            Console.WriteLine(" Decends into the dungeon.");
            Console.WriteLine();
            while (enemyTypes.Count > 0 && pcNames.Count > 0)
            {
                SimulateBattle(pcNames, enemyTypes[0], enemyHPs[0], dcValues[0]);
            }
            if (pcNames.Count > 0)
            {
                Console.WriteLine("The players leave the dungeon, the surviving members are {0},", string.Join(", ", pcNames));
            }
            else
            {
                Console.WriteLine("The warriors fail their quest to clear the dungeon");
            }

        }
        static void SimulateBattle(List<string> pcNames, string monster, int monsterHP, int savingThrowDC)
        {
            int hitTarget = 0;
            var random = new Random();
            int greatSword = 0;
            int constitution = 5;
            var conSave = 0;

            Console.WriteLine($"A {monster} with {monsterHP} HP appears!");
            Console.WriteLine();
           

            while (monsterHP > 0)
            {
                foreach (string name in pcNames)
                {
                    greatSword = DiceRoll(2, 6);
                    monsterHP -= greatSword;
                    Console.WriteLine($"{name} deals {greatSword} damage to the foe.");

                    if (monsterHP <= 0)
                    {
                        monsterHP = 0;
                        Console.WriteLine($"the {monster} collapses to the ground and the heroes celebrate their victory!");
                        Console.WriteLine();
                        enemyTypes.RemoveAt(0);
                        enemyHPs.RemoveAt(0);
                        dcValues.RemoveAt(0);
                        break;
                    }
                    Console.WriteLine($" the {monster} has {monsterHP} HP left");
                }


                if (monsterHP > 0)
                {

                    hitTarget = random.Next(0, pcNames.Count);
                    conSave = DiceRoll(1, 21);
                    Console.WriteLine($"The {monster} atacks {pcNames[hitTarget]}. They roll a constituion save and rolls {conSave}");
                    if (conSave < savingThrowDC)
                    {
                        Console.WriteLine($"{pcNames[hitTarget]} fails their check and is slain.");
                        Console.WriteLine();
                        pcNames.RemoveAt(hitTarget);
                        if (pcNames.Count == 0)
                        {
                            
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{pcNames[hitTarget]} succeeds their saving throw and dodge a fatal blow.");
                        Console.WriteLine();
                    }
                }


            }
        }
    }
}
