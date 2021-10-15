using System;

namespace First_Game_3_Mission_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();

            int pinsStanding = 10;
            int throw1 = random.Next(0, pinsStanding + 1);
            pinsStanding = pinsStanding - throw1;
            int throw2 = random.Next(0, pinsStanding + 1);
            pinsStanding = pinsStanding - throw2;
            int summary = (throw1 + throw2);
            string throw1Output = throw1.ToString();
            string throw2Output = throw2.ToString();



            if (throw1 == 10)
            {
                throw1Output = "X";
            }
            if (throw1 == 0)
            {
                throw1Output = "-";
            }
            if (throw2 == 0)
            {
                throw2Output = "-";
            }
            if (summary == 10)
            {
                throw2Output = "/";

            }



            Console.WriteLine($"First roll:{throw1Output}");
            if (throw1 != 10)
            {
                Console.WriteLine($"Second roll:{throw2Output}");
            }

            Console.WriteLine($"Knocked pins:{summary}");
        }
    }
}

