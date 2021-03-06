using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading;

namespace ActionAdventure
{

    class Player
    {
        public char Symbol;
        public int xPosition;
        public int yPosition;
        public ConsoleColor Color = ConsoleColor.DarkYellow;
        public char charUnderPlayer;
        public ConsoleColor underColor;
    }

    class Minotaur
    {
        public char Symbol;
        public int xPosition;
        public int yPosition;
        public ConsoleColor Color = ConsoleColor.Red;
        public bool Alive = true;
    }

    class Tree
    {
        public char Symbol;
        public ConsoleColor Color = ConsoleColor.Green;
    }


    class Program
    {
        static int charSpeed = 10;
        static int rowspeed = 100;


        static int width;
        static int height;
        static char[,] mapData = new char[width, height];
        static ConsoleColor wallColor = ConsoleColor.DarkGray;



        static void Main(string[] args)
        {
            string levelNameRegex = @"(\w+.\w+\s\w+\n)";
            string sizeRegex = @"(\d+)x(\d+)";
            string playerRegex = @"\n\s*(\S)\s*\n";
            string minotaurRegex = @"\s*(\w)\s*\S \S";

            string file = "MazeLevel.txt";
            string filemapString = File.ReadAllText(file);
            string[] filemap = File.ReadAllLines(file);

            Match levelNameMatch = Regex.Match(filemapString, levelNameRegex);
            Match sizeMatch = Regex.Match(filemapString, sizeRegex);
            Match playerMatch = Regex.Match(filemapString, playerRegex);
            Match minotaurMatch = Regex.Match(filemapString, minotaurRegex);

            width = Convert.ToInt32(sizeMatch.Groups[1].Value);
            height = Convert.ToInt32(sizeMatch.Groups[2].Value) + 2;
            mapData = new char[width, height];

            Player player = new Player();
            player.Symbol = playerMatch.Groups[1].Value[0];
            player.charUnderPlayer = ' ';

            Minotaur minotaur = new Minotaur();
            minotaur.Symbol = minotaurMatch.Groups[1].Value[0];

            Tree tree = new Tree();
            tree.Symbol = '♠';

            for (int y = 3; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (filemap[y].ToCharArray()[x] == player.Symbol)
                    {
                        player.xPosition = x;
                        player.yPosition = y;
                    }
                    mapData[x, y - 2] = filemap[y].ToCharArray()[x];
                }
            }

            DrawCool(new string[] { $"Get ready for: { levelNameMatch.Groups[1].Value}" }, charSpeed, rowspeed);
            Console.WriteLine();
            Thread.Sleep(rowspeed);
            DrawCool(new string[] { $"Press any key to start " }, charSpeed, rowspeed, false);
            Console.ReadKey();
            Console.Clear();

            GenerateForest(tree, player);
            player.yPosition -= 2;
            DrawMap(player, minotaur, tree);

            while (minotaur.Alive)
            {

                ConsoleKeyInfo input = Console.ReadKey();

                MovePlayer(input, player, minotaur);
            }
            Console.SetCursorPosition(mapData.GetLength(0), mapData.GetLength(1));
            Console.WriteLine();
            Console.WriteLine("You've defeated the Minotaur! Well fought!");



        }

        static void GenerateForest(Tree tree, Player player, int startHeight = 0, int endHeight = 3)
        {
            int chanceOfTree = 35;
            for (int y = startHeight; y < endHeight; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int random = new Random().Next(0, 100);
                    if (random <= chanceOfTree)
                    {
                        if (mapData[x, y] != player.Symbol)
                        {
                            mapData[x, y] = tree.Symbol;
                        }

                    }
                }
            }
        }


        static void DrawMap(Player player, Minotaur minotaur, Tree tree)
        {
            Console.SetCursorPosition(0, 0);
            for (int y = 0; y < mapData.GetLength(1); y++)
            {
                for (int x = 0; x < mapData.GetLength(0); x++)
                {
                    if (mapData[x, y] == player.Symbol)
                    {
                        Console.ForegroundColor = player.Color;

                    }
                    else if (mapData[x, y] == minotaur.Symbol)
                    {
                        Console.ForegroundColor = minotaur.Color;
                    }
                    else if (mapData[x, y] == tree.Symbol)
                    {
                        Console.ForegroundColor = tree.Color;
                    }
                    else
                    {
                        Console.ForegroundColor = wallColor;
                    }

                    Console.Write(mapData[x, y]);
                }
                Console.WriteLine();
            }
            Console.SetCursorPosition(player.xPosition, player.yPosition);
        }

        static void DrawCool(string[] input, int charSpeed, int rowSpeed, bool newRow = true)
        {

            foreach (string str in input)
            {
                foreach (char c in str)
                {
                    Console.Write(c);
                    Thread.Sleep(charSpeed);
                }
                Thread.Sleep(rowSpeed);
                if (newRow)
                {
                    Console.WriteLine();
                }
            }
        }

        static void MovePlayer(ConsoleKeyInfo input, Player player, Minotaur minotaur)
        {
            if (input.Key == ConsoleKey.DownArrow)
            {
                if (mapData[player.xPosition, player.yPosition + 1] == ' ' || mapData[player.xPosition, player.yPosition + 1] == minotaur.Symbol)
                {
                    if (mapData[player.xPosition, player.yPosition + 1] == minotaur.Symbol)
                    {
                        minotaur.Alive = false;
                    }
                    mapData[player.xPosition, player.yPosition] = player.charUnderPlayer;
                    Console.SetCursorPosition(player.xPosition, player.yPosition);
                    Console.Write(player.charUnderPlayer);
                    player.yPosition += 1;
                }

            }
            if (input.Key == ConsoleKey.UpArrow)
            {
                if (mapData[player.xPosition, player.yPosition - 1] == ' ' || mapData[player.xPosition, player.yPosition - 1] == minotaur.Symbol)
                {
                    if (mapData[player.xPosition, player.yPosition - 1] == minotaur.Symbol)
                    {
                        minotaur.Alive = false;
                    }
                    mapData[player.xPosition, player.yPosition] = player.charUnderPlayer;
                    Console.SetCursorPosition(player.xPosition, player.yPosition);
                    Console.Write(player.charUnderPlayer);
                    player.yPosition -= 1;
                }

            }
            if (input.Key == ConsoleKey.LeftArrow)
            {
                if (mapData[player.xPosition - 1, player.yPosition] == ' ' || mapData[player.xPosition - 1, player.yPosition] == minotaur.Symbol)
                {
                    if (mapData[player.xPosition - 1, player.yPosition] == minotaur.Symbol)
                    {
                        minotaur.Alive = false;
                    }
                    mapData[player.xPosition, player.yPosition] = player.charUnderPlayer;
                    Console.SetCursorPosition(player.xPosition, player.yPosition);
                    Console.Write(player.charUnderPlayer);
                    player.xPosition -= 1;
                }

            }
            if (input.Key == ConsoleKey.RightArrow)
            {
                if (mapData[player.xPosition + 1, player.yPosition] == ' ' || mapData[player.xPosition + 1, player.yPosition] == minotaur.Symbol)
                {
                    if (mapData[player.xPosition + 1, player.yPosition] == minotaur.Symbol)
                    {
                        minotaur.Alive = false;
                    }
                    mapData[player.xPosition, player.yPosition] = player.charUnderPlayer;
                    Console.SetCursorPosition(player.xPosition, player.yPosition);
                    Console.Write(player.charUnderPlayer);
                    player.xPosition += 1;

                }
            }

            Console.SetCursorPosition(player.xPosition, player.yPosition);
            player.charUnderPlayer = mapData[player.xPosition, player.yPosition];
            if (player.charUnderPlayer == player.Symbol)        
            {
                player.charUnderPlayer = ' ';
            }
            Console.ForegroundColor = player.Color;
            Console.Write(player.Symbol);

            Console.SetCursorPosition(player.xPosition, player.yPosition);
            mapData[player.xPosition, player.yPosition] = player.Symbol;

        }
    }
}
