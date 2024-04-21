using NarrativeProject.Rooms;
using NarrativeProject.Stage1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Stage2
{
    internal class Door2 : Room
    {
        internal override string CreateDescription() =>
$@"{Game.name}, you Entered the second door.     [STAGE 2]

MAP
Backward leads back to the corridor.";
        internal override void PlayerMove(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    Random ilussion = new Random();
                    int ilussionalDoor = ilussion.Next(1, 4);
                    if (ilussionalDoor == 0)
                    {
                        Console.WriteLine("You find yourself in the Basement.");
                        Game.Transition<Basement>();
                    }
                    else if (ilussionalDoor == 1)
                    {
                        Console.WriteLine("You find yourself in the Bedroom.");
                        Game.Transition<Bedroom>();
                    }
                    else if (ilussionalDoor == 2)
                    {
                        Console.WriteLine("You find yourself in the Corridor.");
                        Game.Transition<Corridor>();
                    }
                    else if (ilussionalDoor == 3)
                    {
                        Console.WriteLine("You passed the Portal.");
                        Game.Transition<Armory>();
                    }
                    break;
                case ConsoleKey.RightArrow:
                    Game.EmptySpace();
                    break;
                case ConsoleKey.LeftArrow:
                    Game.AmmunationHP();
                    break;
                case ConsoleKey.DownArrow:
                    Console.WriteLine("You back to the corridor");
                    Game.Transition<Corridor>();
                    break;
                case ConsoleKey.Tab:
                    Game.CheckInventory();
                    Game.SetTimer(1000);
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
