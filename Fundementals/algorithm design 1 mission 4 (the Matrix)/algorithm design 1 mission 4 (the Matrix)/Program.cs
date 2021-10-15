using System;
using System.Collections.Generic;
using System.Threading;

namespace algorithm_design_1_mission_4__the_Matrix_
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var streams = new List<int> { };
            var symbols = "!@#$%^&*()_+-=[];',./~{}:|<>?";

            for (int i = 0; i < 10; i++)
            {
                streams.Add(random.Next(0, 80));
            }
            Console.ForegroundColor = ConsoleColor.Red;

            while (true)
            {
                for (int x = 0; x < 80; x++)
                {
                    Console.Write(streams.Contains(x) ? symbols[random.Next(symbols.Length)] : ' ');
                }

                Console.WriteLine();
                Thread.Sleep(100);


                if (random.Next(3) == 0 || streams.Count == 0)
                {
                    streams.Add(random.Next(0, 80));
                }
                if (random.Next(3) == 0)
                {
                    streams.RemoveAt(random.Next(streams.Count));
                }
            }
        }
    }
}
