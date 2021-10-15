using System;

namespace Algorithm_design_1_mission_3
{
    class Program
    {
        static string OrdinalNumber(int number)
        {
            int lasDig = number % 10;
            if (number > 10)
            {
                int secondLastDig = (number / 10) % 10;
                if (secondLastDig == 1)
                {
                    return number + "th";
                }
            }
            if (lasDig == 1)
            {
                return number + "st";
            }
            else if (lasDig == 2)
            {
                return number + "nd";
            }
            else if (lasDig == 3)
            {
                return number + "rd";
            }
            else
            {
                return number + "th";
            }
        }

        static void Main(string[] args)
        {
            
            for (int i = 1; i < 200; i++)
            {
                string output = OrdinalNumber(i);
                Console.WriteLine($"{output}");
                               
            }




        }
    }
}
