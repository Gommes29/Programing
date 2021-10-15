using System;

namespace Switches_1
{
    class Program
    {
        static void Equaition(string numbers)
        {
            string[] numbersArray = numbers.Split(' ');
            double x = Convert.ToInt32(numbersArray[0]);
            double y = Convert.ToInt32(numbersArray[2]);
            double result = 0;

            switch (numbersArray[1])
            {
                case "+":
                    result = x + y;
                    break;
                case "-":
                    result = x - y;
                    break;
                case "*":
                    result = x * y;
                    break;
                case "/":
                    result = x / y;
                    break;
            }
            Console.WriteLine($"The price was set to {result}");
        }
        static void Main(string[] args)
        {
            Console.Write("Set the price: ");
            string input = Console.ReadLine();

            Equaition(input);
            Console.ReadKey(true);
        }
    }
}
