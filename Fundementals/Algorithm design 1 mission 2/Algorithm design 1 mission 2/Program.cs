using System;
using System.Collections.Generic;

namespace Algorithm_design_1_mission_2
{
    class Program
    {
        static string JoinWithAnd(List<string> items, bool useSerialComma = true)
        {
            int count = items.Count;
            if (count == 0)
            {
                return "";
            }
            else if (count == 1)
            {
                return items[0];
            }
            else if (count == 2)
            {
                return string.Join(" and ", items);
            }
            else
            {
                List<string> itemsCopy = new List<string>(items);
                if (useSerialComma)
                {
                    itemsCopy[^1] = "and " + itemsCopy[^1];
                }
                else
                {
                    itemsCopy[^2] = itemsCopy[^2] + " and " + itemsCopy[^1];
                    itemsCopy.RemoveAt(count - 1);
                }
                return string.Join(", ", itemsCopy);
            }

        }
        static void Main(string[] args)
        {
            List<string> players = new List<string>()
            {
                "Joey",
                "Bob",
                "Dave",
                "Sam"
            };
            string outputText = "";

            outputText = $"The guys in the group are: {JoinWithAnd(players, true)}.";



            Console.WriteLine(outputText);



        }

    }
}