using System;
using System.Collections;
using System.Collections.Generic;
namespace Dictionaries_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var capitals = new SortedList<string, string>()
          {
              {"Sweden", "Stockholm"},
              {"NetherLands", "Amsterdam"},
              {"Portugal", "Lisbon"},
              {"Germany", "Berlin"},
              {"Denmark" ,"Copenhagen"},
              {"Finland" , "Helinski"},
              {"Italy", "Rome"},
              {"Australia", "Canberra"},
              {"Slovenia", "Ljubljana"},
              {"Ukraine" , "Kyiv"},
              {"Norway" , "Oslo"},
              {"South Korea", "Seoul"}

          };
            var countries = new List<string>(capitals.Keys);

            var random = new Random();
            int countryIndex = random.Next(capitals.Count);

            string countryName = countries[countryIndex];
            Console.WriteLine($"What is the capital of {countryName}");

            string capitalInput = Console.ReadLine();
            Console.WriteLine();
            string correctResult = capitals[countryName];

            if (correctResult == capitalInput)
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine($"Incorrect answer! The Capital is called {correctResult}");
            }
            Console.ReadKey(true);
        }
    }
}
