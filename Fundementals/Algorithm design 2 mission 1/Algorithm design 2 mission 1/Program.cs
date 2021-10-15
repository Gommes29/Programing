using System;
using System.Collections.Generic;

namespace Algorithm_design_2_mission_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> partylist = new List<string>
          {
              "Bob",
              "Jeff",
              "Jan",
              "Antonio",
              "Eva",
              "Julio"
          };
            Console.WriteLine("The participants are: ");
            foreach (string name in partylist)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();
            Console.WriteLine("The starting order is: ");
            List<string> newlist = ShuffleList(partylist);
            foreach (string name in newlist)
            {
                Console.WriteLine(name);
            }
        }
        static List<string> ShuffleList(List<string> items)
        {
            int count = items.Count;
            var random = new Random();
            for (int i = count - 1; i >= 0; --i)
            {
                int x = random.Next(i, count);
                string temp = items[i];
                items[i] = items[x];
                items[x] = temp;
            }
            return items;
        }
    }
}
