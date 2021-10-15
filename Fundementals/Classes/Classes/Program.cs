using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.IO;

namespace Classes
{
   
    class Location
    {
        public string Name;
        public string Description;
        public List<Neighbor> Neighbors = new List<Neighbor>();
        public List<Path> ShortestPath = new List<Path>();

        public override string ToString() => Name;
    }
    
    class Neighbor
    {
        public Location Location;
        public int Distance;
    }
   
    class Path
    {
        public Location Location;
        public int Distance;
        public List<string> StopNames = new List<string>();
    }

    class Program
    {
        static bool quitGame = false;
        static int charTimer = 50;
        static int charExtraLongTimer = 150;
        static int rowTimer = 200;
        static int rowLongTimer = 400;
        static int rowExtraLongTimer = 700;
        static ConsoleColor textColor = ConsoleColor.Yellow;
        static ConsoleColor askInputColor = ConsoleColor.DarkBlue;
        static ConsoleColor inputColor = ConsoleColor.Yellow;
        static ConsoleColor travelColor = ConsoleColor.White;

        static void Main(string[] args)
        {

            List<Location> locations = new List<Location> {
            new Location {
            Name = "Goldshire",
            Description = " a small town in the center of Elwynn Forest with a very popular Tavern"},
            new Location {
            Name = "Stormwind City",
            Description = "the capital, and the largest Human city of Azeroth, Located in the north of Elwynn Forest"},
            new Location {
            Name = "Sentinel Hill",
            Description = "a base in the west of Elwynn Forest and center of Westfall, now home to alot of homeless and  poor people, where the Defias brotherhood bandit plots the fall of Stormwind.."},
            new Location {
            Name = "Eastvale Logging Camp",
            Description = "a small settlement to the east in Elwynn Forest, that specialises in lumber and horses"},
            new Location {
            Name = "Darkshire",
            Description = "In the dark and gloomy forest of duskwood in the south, whom are having trouble with savage worgen and the undead"},
            new Location {
            Name = "Lakeshire",
            Description = "in the Redridge mountains to the east, whom are facing the threat of blackrock orcs from the north"},
            };            
            Dictionary<string, Location> locationsByName = new Dictionary<string, Location> { };

            foreach (Location location in locations)
            {
                locationsByName.Add(location.Name, location);
                
            }

            
            ConnectLocations(locationsByName["Goldshire"], locationsByName["Stormwind City"], 5);
            ConnectLocations(locationsByName["Goldshire"], locationsByName["Eastvale Logging Camp"], 8);
            ConnectLocations(locationsByName["Goldshire"], locationsByName["Sentinel Hill"], 17);
            ConnectLocations(locationsByName["Eastvale Logging Camp"], locationsByName["Lakeshire"], 10);
            ConnectLocations(locationsByName["Lakeshire"], locationsByName["Darkshire"], 21);
            ConnectLocations(locationsByName["Darkshire"], locationsByName["Sentinel Hill"], 25);
            ConnectLocations(locationsByName["Stormwind City"], locationsByName["Goldshire"], 5);
            ConnectLocations(locationsByName["Darkshire"], locationsByName["Lakeshire"], 21);
            ConnectLocations(locationsByName["Sentinel Hill"], locationsByName["Goldshire"], 17);

            foreach (Location location in locations)
            {
                Dijkstra(locations, location);
            }

            
            Location currentLocation = locations[new Random().Next(0,locations.Count)];
            while (!quitGame)
            {
                DisplayDestination(currentLocation);
                Path path = currentLocation.ShortestPath[AskForDirections(currentLocation) - 1];
                if (!quitGame)
                {
                    
                    currentLocation = path.Location;
                    Console.Clear();
                    if (path.StopNames.Count > 0)
                    {
                        string[] travellingThroughText = new string[] { "Travelling through", ".", ".", "." };
                        WriteCool(travellingThroughText, charTimer, rowExtraLongTimer, travelColor, false);
                        Console.WriteLine();
                        WriteCool(path.StopNames.ToArray(), charExtraLongTimer, rowLongTimer, travelColor);
                        WriteCool(new string[] { ".", ".", ".", ".", "." }, charTimer, rowExtraLongTimer, travelColor, false);
                        Console.Clear();
                    }
                }
                
                
            }
            Thread.Sleep(rowLongTimer);
            Console.Clear();

           
        }

        static void DisplayDestination(Location currentLocation)
        {
            WriteCool(new string[] { $"Welcome to {currentLocation.Name},",$" {currentLocation.Description}." }, charTimer, rowExtraLongTimer, textColor, false);
            Console.WriteLine();
            Console.WriteLine();
            string[] availDestinations = new string[currentLocation.ShortestPath.Count+2];
            
            availDestinations[0] = "Available destinations are:";
            availDestinations[1] = "";
            for (int i = 0; i < currentLocation.ShortestPath.Count; i++)
            {
                Path neighbour = currentLocation.ShortestPath[i];
                availDestinations[i + 2] = $"{ 1 + i}. { neighbour.Location.Name} ({ neighbour.Distance})";
                
            }
            WriteCool(availDestinations, charTimer, rowExtraLongTimer -200, textColor);
            
        }

        static int AskForDirections(Location currentLocation)
        {
            string input;
            int travelDestination = 0;
            while (travelDestination == 0)
            {
                Console.WriteLine();
                WriteCool(new string[] { "Where would you like to travel?" }, charTimer, rowTimer, askInputColor);
                Console.ForegroundColor = inputColor;
                input = Console.ReadLine();
                Thread.Sleep(rowLongTimer);
                Console.WriteLine();
                try
                {
                    travelDestination = Convert.ToInt32(input);
                    
                    if (travelDestination > currentLocation.ShortestPath.Count)
                    {

                        travelDestination = 0;
                        WriteCool(new string[] { "Please enter the number of your destination."}, charTimer, rowTimer, askInputColor);
                        ResetCursor();
                        

                    }
                }
                catch (Exception)
                {
                    if (input == "q" || input == "Q")
                    {
                        quitGame = true;
                        travelDestination = 1;
                        break;
                    }
                    
                    WriteCool(new string[] { "Enter a number"}, charExtraLongTimer, rowExtraLongTimer, ConsoleColor.Red, false);
                    ResetCursor();
                }

            }
            return travelDestination;
        }

        static void ConnectLocations(Location a, Location b, int distance)
        {
            a.Neighbors.Add(new Neighbor { Location = b, Distance = distance });
            b.Neighbors.Add(new Neighbor { Location = a, Distance = distance });
        }

        static void Dijkstra(List<Location> map, Location source)
        {
            List<Location> Q = new List<Location> { };
            Dictionary<Location, int> dist = new Dictionary<Location, int> { };
            Dictionary<Location, Location> prev = new Dictionary<Location, Location> { };
            foreach (Location v in map)
            {
                dist.Add(v, 99);
                prev.Add(v, null);
                Q.Add(v);
            }
            dist[source] = 0;

            while (Q.Count != 0)
            {
                Location u = Q.OrderBy((v) => dist[v]).First();

                Q.Remove(u);
                for (int v = 0; v < u.Neighbors.Count; v++)
                {
                    Location neighbour = u.Neighbors[v].Location;
                    if (Q.Contains(u.Neighbors[v].Location))
                    {
                        int alt = dist[u] + u.Neighbors[v].Distance;
                        if (alt < dist[neighbour])
                        {
                            dist[neighbour] = alt;
                            prev[neighbour] = u;
                        }
                    }
                }
            }


            foreach (Location otherLocation in map)
            {

                if (otherLocation == source) continue;

                var path = new Path { Location = otherLocation, Distance = dist[otherLocation] };
                source.ShortestPath.Add(path);

                Location stop = prev[otherLocation];
                while (stop != source)
                {
                    path.StopNames.Insert(0, stop.Name);
                    stop = prev[stop];
                }
            }
            source.ShortestPath.Sort((a, b) => a.Distance.CompareTo(b.Distance));
        }

        static void WriteCool(string[] text, int charSpeed, int rowSpeed, ConsoleColor color, bool newRow = true)
        {
            Console.ForegroundColor = color;
            Console.WriteLine();
            for (int i = 0; i < text.Length; i++)
            {
                foreach (char c in text[i])
                {
                    Console.Write(c);
                    Thread.Sleep(charSpeed);
                }
                if (i == text.Length-1)
                {
                    Thread.Sleep(rowSpeed/2);
                }
                else
                {
                    Thread.Sleep(rowSpeed);
                }
                
                if (newRow)
                {
                    Console.WriteLine();
                }
            }
            
        }

        static void ResetCursor(int rows = 5)
        {
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - rows);
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine("                                                                                                    ");
            }
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - rows-2);
        }
    }
}
