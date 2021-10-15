using System;

namespace Enums
{
    class Program
    {
        enum Symbols
        {
            Hearts,
            Spades,
            Clubs,
            Diamonds
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            for (int i = 1; i < 14; i++)
            {
                DrawCard(Symbols.Clubs, i);
            }
            static void DrawCard(Symbols symbol, int rank)
            {
                string ChosenSypmbol = "";
                switch (symbol)
                {
                    case Symbols.Hearts:
                        ChosenSypmbol = "♥";
                        break;
                    case Symbols.Spades:
                        ChosenSypmbol = "♠";
                        break;
                    case Symbols.Clubs:
                        ChosenSypmbol = "♣";
                        break;
                    case Symbols.Diamonds:
                        ChosenSypmbol = "♦";
                        break;
                }
                Console.WriteLine("╭─────────╮");
                switch (rank)
                {
                    case 1:
                        Console.WriteLine($"│A        │");
                        Console.WriteLine($"│         │");
                        Console.WriteLine($"│         │");
                        Console.WriteLine($"│    {ChosenSypmbol}    │");
                        Console.WriteLine($"│         │");
                        Console.WriteLine($"│         │");
                        Console.WriteLine($"│        A│");
                        break;
                    case 2:
                        Console.WriteLine($"│2        │");
                        Console.WriteLine($"│         │");
                        Console.WriteLine($"│    {ChosenSypmbol}    │");
                        Console.WriteLine($"│         │");
                        Console.WriteLine($"│    {ChosenSypmbol}    │");
                        Console.WriteLine($"│         │");
                        Console.WriteLine($"│        2│");
                        break;
                    case 3:
                        Console.WriteLine($"│3        │");
                        Console.WriteLine($"│         │");
                        Console.WriteLine($"│  {ChosenSypmbol}      │");
                        Console.WriteLine($"│    {ChosenSypmbol}    │");
                        Console.WriteLine($"│      {ChosenSypmbol}  │");
                        Console.WriteLine($"│         │");
                        Console.WriteLine($"│        3│");
                        break;
                    case 4:
                        Console.WriteLine($"│4        │");
                        Console.WriteLine($"│         │");
                        Console.WriteLine($"│  {ChosenSypmbol}   {ChosenSypmbol}  │");
                        Console.WriteLine($"│         │");
                        Console.WriteLine($"│  {ChosenSypmbol}   {ChosenSypmbol}  │");
                        Console.WriteLine($"│         │"); 
                        Console.WriteLine($"│        4│");
                        break;
                    case 5:
                        Console.WriteLine($"│5        │");
                        Console.WriteLine($"│         │");
                        Console.WriteLine($"│  {ChosenSypmbol}   {ChosenSypmbol}  │");
                        Console.WriteLine($"│    {ChosenSypmbol}    │");
                        Console.WriteLine($"│  {ChosenSypmbol}   {ChosenSypmbol}  │");
                        Console.WriteLine($"│         │");
                        Console.WriteLine($"│        5│");
                        break;
                    case 6:
                        Console.WriteLine($"│6        │");
                        Console.WriteLine($"│         │");
                        Console.WriteLine($"│  {ChosenSypmbol}   {ChosenSypmbol}  │");
                        Console.WriteLine($"│  {ChosenSypmbol}   {ChosenSypmbol}  │");
                        Console.WriteLine($"│  {ChosenSypmbol}   {ChosenSypmbol}  │");
                        Console.WriteLine($"│         │");
                        Console.WriteLine($"│        6│");
                        break;
                    case 7:
                        Console.WriteLine($"│7        │");
                        Console.WriteLine($"│         │");
                        Console.WriteLine($"│  {ChosenSypmbol}  {ChosenSypmbol}   │");
                        Console.WriteLine($"│  {ChosenSypmbol}{ChosenSypmbol} {ChosenSypmbol}   │");
                        Console.WriteLine($"│  {ChosenSypmbol}  {ChosenSypmbol}   │");
                        Console.WriteLine($"│         │");
                        Console.WriteLine($"│        7│");
                        break;
                    case 8:
                        Console.WriteLine($"│8        │");
                        Console.WriteLine($"│         │");
                        Console.WriteLine($"│   {ChosenSypmbol}  {ChosenSypmbol}  │");
                        Console.WriteLine($"│   {ChosenSypmbol}{ChosenSypmbol}{ChosenSypmbol}{ChosenSypmbol}  │");
                        Console.WriteLine($"│   {ChosenSypmbol}  {ChosenSypmbol}  │");
                        Console.WriteLine($"│         │");
                        Console.WriteLine($"│        8│");
                        break;
                    case 9:
                        Console.WriteLine($"│9        │");
                        Console.WriteLine($"│   {ChosenSypmbol}     │");
                        Console.WriteLine($"│   {ChosenSypmbol}  {ChosenSypmbol}  │");
                        Console.WriteLine($"│   {ChosenSypmbol}{ChosenSypmbol}{ChosenSypmbol}{ChosenSypmbol}  │");
                        Console.WriteLine($"│   {ChosenSypmbol}  {ChosenSypmbol}  │");
                        Console.WriteLine($"│         │");
                        Console.WriteLine($"│        9│");
                        break;
                    case 10:
                        Console.WriteLine($"│10       │");
                        Console.WriteLine($"│   {ChosenSypmbol}  {ChosenSypmbol}  │");
                        Console.WriteLine($"│   {ChosenSypmbol}  {ChosenSypmbol}  │");
                        Console.WriteLine($"│   {ChosenSypmbol}{ChosenSypmbol}{ChosenSypmbol}{ChosenSypmbol}  │");
                        Console.WriteLine($"│   {ChosenSypmbol}  {ChosenSypmbol}  │");
                        Console.WriteLine($"│         │");
                        Console.WriteLine($"│       10│");
                        break;
                    case 11:
                        Console.WriteLine($"│J┌─────┐ │");
                        Console.WriteLine($"│{ChosenSypmbol}│{ChosenSypmbol}\\__/│ │");
                        Console.WriteLine($"│ │|(_/|│ │");
                        Console.WriteLine($"│ │> / <│ │");
                        Console.WriteLine($"│ │|/_)|│ │");
                        Console.WriteLine($"│ │/ \\ {ChosenSypmbol}│{ChosenSypmbol}│");
                        Console.WriteLine($"│ └─────┘J│");
                        break;
                    case 12:
                        Console.WriteLine($"│Q┌─────┐ │");
                        Console.WriteLine($"│{ChosenSypmbol}│{ChosenSypmbol}(_(/│ │");
                        Console.WriteLine($"│ │  )/❀│ │");
                        Console.WriteLine($"│ │< / >│ │");
                        Console.WriteLine($"│ │❀/(  │ │");
                        Console.WriteLine($"│ │/) ){ChosenSypmbol}│{ChosenSypmbol}│");
                        Console.WriteLine($"│ └─────┘Q│");
                        break;
                    case 13:
                        Console.WriteLine($"│K┌─────┐ │");
                        Console.WriteLine($"│{ChosenSypmbol}│{ChosenSypmbol}\\__/│ │");
                        Console.WriteLine($"│ │ (_/|│ │");
                        Console.WriteLine($"│ │+ / +│ │");
                        Console.WriteLine($"│ │|/_) │ │");
                        Console.WriteLine($"│ │/  \\{ChosenSypmbol}│{ChosenSypmbol}│");
                        Console.WriteLine($"│ └─────┘K│");
                        break;
                }
                Console.WriteLine("╰─────────╯");
                
            }
        }
    }
}
