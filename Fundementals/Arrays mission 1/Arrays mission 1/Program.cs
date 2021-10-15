using System;
using System.Collections.Generic;

namespace Arrays_mission_1
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
        static string[] seasons = new string[]
        {
            "Spring",
            "Summer",
            "Fall",
            "Winter"
        };
        
        

        static string CreateDayDescription(int day, int season, int year)
        {
            string seasonName = seasons[season];
            
            string output = ($"{OrdinalNumber(day)} day of {seasonName} in the year {year}.");
            
            return output;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(CreateDayDescription(54, 3 , 1998));
        }
    }
}
