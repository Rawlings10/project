using NarrativeProject.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Stage2
{
    internal class Door1 : Room
    {
        internal override string CreateDescription() =>
$@"{Game.name}, you Entered the first door.     [STAGE 2]

MAP
backward leads back to the corridor.";
       
    internal override void PlayerMove(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    Game.EmptySpace();
                    break;
                case ConsoleKey.RightArrow:                   
                    Game.FightScene();
                    break;
                case ConsoleKey.LeftArrow:
                    Game.FightScene();
                    break;
                case ConsoleKey.DownArrow:
                    Console.WriteLine("You return to the corridor");
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
