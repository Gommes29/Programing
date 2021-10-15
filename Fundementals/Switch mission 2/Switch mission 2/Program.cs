using System;

namespace Switch_mission_2
{
    class Program
    {
        static void Equation(string equation)
        {
            int firstSpaceIndex = equation.IndexOf(" ");
            int lastSpaceIndex = equation.LastIndexOf(" ");
            string operation = equation.Substring(firstSpaceIndex + 1, lastSpaceIndex - firstSpaceIndex - 1);

            double x = Convert.ToDouble(equation.Substring(0, firstSpaceIndex));
            double y = Convert.ToDouble(equation.Substring(lastSpaceIndex + 1, equation.Length - lastSpaceIndex - 1));
            double result = 0;

            switch (operation)
            {
                case "+":
                case "plus":
                case "add":
                    result = x + y;
                    break;
                case "-":
                case "minus":
                case "remove":
                    result = x - y;
                    break;
                case "*":
                case "multiplied by":
                case "times":
                    result = x * y;
                    break;
                case "/":
                case "divided by":
                    result = x / y;
                    break;
            }
            Console.WriteLine($"The price is {result}.");
        }
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Name your price!: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string input = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Equation(input);
            Console.ForegroundColor = ConsoleColor.White;

        }
    }
}
