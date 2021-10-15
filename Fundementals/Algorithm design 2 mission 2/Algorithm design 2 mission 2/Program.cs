using System;
using System.Collections.Generic;

namespace Algorithm_design_2_mission_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Factorial(10));
        }
      
        static int Factorial(int n)
        {
            int nfactorial;
            if (n == 0)
            {
                nfactorial = 1;
            }
            else
            {
                nfactorial = n * Factorial(n - 1);
            }
            return nfactorial;
        }
    }
}
