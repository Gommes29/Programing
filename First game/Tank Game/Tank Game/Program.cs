using System;

namespace Tank_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var battlefield = "";
            var bfLength = 79;
            var ground = "_";
            var artilery = "/";
            var tank = "T";
            var artpos = 1;
            var tankDistance = random.Next(40, 71);
            var shell = "*";
            var shellAim = "";
            var ammo = 5;

            Console.WriteLine("DANGER! A tank is approaching our position. Your artilery unit is our only hope!");
            Console.WriteLine("What is your name, commander?");
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();
            Console.WriteLine("Your name is: " + name);
            Console.WriteLine( "Here is the map of the battlefield:");
            for (int x = 0; x <= bfLength;)
            {
                if (x == artpos)
                {
                    battlefield = battlefield + artilery;
                }
                if (x == tankDistance)
                {
                    battlefield = battlefield + tank;
                }
                else
                {
                    battlefield = battlefield + ground;
                }
                x++;
            }
            Console.WriteLine(battlefield);
            Console.WriteLine($"Aim your shot, {name}");
            while ( ammo > 0) {
                Console.WriteLine("Enter distance: ");
                int aim = Convert.ToInt32(Console.ReadLine());

                if (aim == tankDistance)
                {
                    Console.WriteLine("BOOM! your aim is legendary and the tank is destroyed!");
                    break;
                }
                if (aim < tankDistance)
                {
                    Console.WriteLine("Alas the shell flies short!");
                    ammo--;
                    Console.WriteLine($"you have {ammo} left.");
                }
                if (aim > tankDistance)
                {
                    Console.WriteLine("Alas the shell flies past the tank.");
                    ammo--;
                    Console.WriteLine($"you have {ammo} left.");
                }

                for (int x = 0; x < aim;)
                {
                    shellAim = shellAim + " ";
                    x++;
                }

                shellAim = shellAim + shell;
                Console.WriteLine(shellAim);
                shellAim = "";
            }
            
        }
        
    }
}
