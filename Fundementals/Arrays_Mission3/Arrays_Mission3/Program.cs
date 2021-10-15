using System;

namespace Arrays_Mission3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Settings for windowsize + how many roads
            int width = 60;
            int height = 20;
            int numberOfRoads = 4;
            // Road symbols
            char[] symbols = { ' ', '═', '║', '╬', '╣', '╠', '╩', '╦' };

            var roads = new bool[width, height];
            Random random = new Random();
            //calculating the road placements and if there will be any intersections
            for (int i = 0; i < numberOfRoads; i++)
            {
                int po = random.Next(99);
                if (po <= 70-1)
                {
                    GenerateIntersection(roads, random.Next(0, width), random.Next(0, height));
                }
                else
                {
                    GenerateRoad(roads, random.Next(0, width), random.Next(0, height), random.Next(4));
                }
            }
            
            // Checking if any roads cross and replace them acordingly to correct symbol
            for (int y = 0; y < height; y++)
            {

                for (int x = 0; x < width; x++)
                {

                    if (roads[x, y])
                    {
                        
                        bool neighbourLeft = x != 0 && roads[x - 1, y] ;
                        bool neighbourRight = x != width - 1 && roads[x + 1, y];
                        bool neighbourUp = y != 0 && roads[x, y-1];
                        bool neighbourDown = y != height - 1 && roads[x, y + 1];
                        //Intrersection
                        if (neighbourDown && neighbourLeft && neighbourRight && neighbourUp)
                        {
                            Console.Write("╬");
                        }
                        //road from south lead in to a road
                        else if (neighbourDown && neighbourLeft && neighbourRight)
                        {
                            Console.Write("╦");
                        }
                        //road from north lead in to a road
                        else if (neighbourUp && neighbourLeft && neighbourRight)
                        {
                            Console.Write("╩");
                        }
                        //road from west lead in to a road
                        else if (neighbourUp && neighbourLeft && neighbourDown)
                        {
                            Console.Write("╣");
                        }
                        //road from east lead in to a road
                        else if (neighbourUp && neighbourRight && neighbourDown)
                        {
                            Console.Write("╠");
                        }
                        //straight road(east and west)
                        else if (x != 0 && roads[x - 1, y] || roads[x + 1, y])
                        {
                            Console.Write("═");
                        }
                        //straight road(north and south)
                        else
                        {
                            Console.Write("║");
                        }

                        
                    }
                    else
                    {
                        
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            
        }
        //Method to generate the roads.
        static void GenerateRoad(bool[,] roads, int startX, int startY, int direction)
        {

            if (direction == 0)
            {
                //direction = right
                for (int x = 0; x <= roads.GetLength(0) - 1; x++)
                {
                    if (x >= startX)
                    {
                        roads[x, startY] = true;
                    }
                }


            }
            if (direction == 1)
            {
                //direction = down
                for (int y = 0; y <= roads.GetLength(1) - 1; y++)
                {
                    if (y >= startY)
                    {
                        roads[startX, y] = true;
                    }
                }
            }
            if (direction == 2)
            {
                //direction = left
                for (int x = 0; x <= roads.GetLength(0) - 1; x++)
                {
                    if (x <= startX)
                    {
                        roads[x, startY] = true;
                    }
                }


            }
            if (direction == 3)
            {
                //direction = down
                for (int y = 0; y <= roads.GetLength(1) - 1; y++)
                {
                    if (y <= startY)
                    {
                        roads[startX, y] = true;
                    }
                }


            }

        }
        // method to check for intersections.
        static void GenerateIntersection(bool[,] roads, int x, int y)
        {
            for (int i = 0; i < 4; i++)
            {
                GenerateRoad(roads, x, y, i);
            }
        }
    }
}
