using NarrativeProject.Rooms;
using NarrativeProject.Stage2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Stage3
{
    internal class StoreHouse : Room
    {
        internal override string CreateDescription() =>
$@"{Game.name}, You are in a Store House   [STAGE 3] 

MAP
go forward next room.";

        internal override void PlayerMove(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    Console.WriteLine("You Entered the Garage");
                    Game.Transition<Garage>();
                    break;
                case ConsoleKey.LeftArrow:
                    Game.MutlipleFightScene(2);
                    Game.HealthKit();
                    break;
                case ConsoleKey.RightArrow:
                    Game.MutlipleFightScene(2);
                    break;
                case ConsoleKey.DownArrow:
                    Console.WriteLine("You return to the Armory");
                    Game.Transition<Armory>();
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
