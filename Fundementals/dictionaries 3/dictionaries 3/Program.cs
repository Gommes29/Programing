using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace dictionaries_3
{
    class Program
    {
        //static List<string> participants = new List<string> { "Gommes", "Arthur", "Viktor", "Marinix", "Max" };
        //static string[]participants = { "Gommes", "Arthur", "Viktor", "Max", "Marinix" };




        static void Main(string[] args)
        {
            IDictionary<string, int> highScores = new Dictionary<string, int>();

            string winnerName;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Winner! Enter name of the winner");
                Console.Write("ENTER NAME HERE : ");
                winnerName = Console.ReadLine();
                if (winnerName == "")
                {
                    break;
                }
                if (highScores.ContainsKey(winnerName))
                {
                    highScores[winnerName]++;
                }
                else
                {
                    highScores.Add(winnerName, 1);
                }
                string[] players = new List<string>(highScores.Keys).ToArray();
                int[] scores = new List<int>(highScores.Values).ToArray();
                Array.Sort(scores, players);
                Array.Reverse(players);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Array.Reverse(scores);

                Console.WriteLine();
                Console.WriteLine("RANKINGS");
                Console.ForegroundColor = ConsoleColor.Blue;
                for (int i = 0; i < players.Length; i++)
                {
                    Console.WriteLine(players[i] + " " + scores[i]);

                }
                
                Console.WriteLine();
            }


        }
    }
}
