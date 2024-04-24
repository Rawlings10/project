using NarrativeProject.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Stage2
{
    internal class Door3 : Room
    {
        internal override string CreateDescription() =>
$@"{Game.name}, you entered the third door .   [STAGE 2]

MAP
The door backward leads to the corridor.";
        internal override void PlayerMove(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    Game.EmptySpace();
                    break;
                case ConsoleKey.LeftArrow:
                    Game.HealthKit();
                    break;
                case ConsoleKey.RightArrow:
                    Game.AddtoInventory(gameArtifact.gold); 
                    Game.FightScene();
                    break;
                case ConsoleKey.DownArrow:
                    Console.WriteLine("Back to the corridor");
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
