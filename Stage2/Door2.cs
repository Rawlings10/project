using NarrativeProject.Rooms;
using NarrativeProject.Stage1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Stage2
{
    [Serializable]
    internal class Door2 : Room
    {
        internal override string CreateDescription() =>
$@"{Game.name}, you Entered the second door.     [STAGE 2]

MAP
Foward has an ILUSSIONAL DOOR that can take you back to the different places
but keep try to pass because it is the only way to the next STAGE
Backward leads back to the corridor.";
        internal override void PlayerMove(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    Random ilussion = new Random();
                    int ilussionalDoor = ilussion.Next(1, 4);
                    if (ilussionalDoor == 1)
                    {
                        Console.WriteLine("You find yourself in the Door1.");
                        Game.Transition<Door1>();
                    }
                    else if (ilussionalDoor == 2)
                    {
                        Console.WriteLine("You find yourself in the Corridor.");
                        Game.Transition<Corridor>();
                    }
                    else if (ilussionalDoor == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You passed the Portal.");
                        Game.SetTimer(1000);
                        Console.ResetColor();
                        Game.Transition<Armory>();
                        Game.SaveGame();
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
