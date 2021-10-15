using System;
using System.Collections.Generic;

namespace Dictionaries_1
{
    class Program
    {
        static int RandomYear()
        {
            var random = new Random();

            int result = 2000 + random.Next(0, 11) * 2;
            return result;
        }
        static void olympicgamesDictionary(int year)
        {
            IDictionary<int, string> hostCountries = new Dictionary<int, string>();
            {
                hostCountries.Add(2000, "Australia");
                hostCountries.Add(2002, "USA");
                hostCountries.Add(2004, "Greece");
                hostCountries.Add(2006, "Italy");
                hostCountries.Add(2008, "China");
                hostCountries.Add(2010, "Canada");
                hostCountries.Add(2012, "UK");
                hostCountries.Add(2014, "Russia");
                hostCountries.Add(2016, "Brazil");
                hostCountries.Add(2018, "South Korea");
                hostCountries.Add(2020, "Japan");
            }
            Console.WriteLine($"Which country hosted the summer games in {year}?\n> ");
            string countryInput = Console.ReadLine();
            Console.WriteLine();

            if (hostCountries.ContainsKey(year)) ;
            {
                if (hostCountries[year] == countryInput)
                {
                    Console.WriteLine("Correct!");
                }
                else
                {
                    Console.WriteLine($"Incorrect!, the correct answer is {hostCountries[year]}");
                }
            }
        }
       
        static void Main(string[] args)
        {
            olympicgamesDictionary(RandomYear());
        }
    }
}
