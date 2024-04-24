using NarrativeProject.Rooms;
using NarrativeProject.Stage2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Stage3
{
    internal class Garage : Room
    {
        internal override string CreateDescription() =>
$@"{Game.name}, You are in a Garage   [STAGE 3] 

MAP
go forward next room.";

        internal override void PlayerMove(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    Game.MutlipleFightScene(2);
                    Console.WriteLine("You entered the Lab");
                    Game.SetTimer(1000);
                    Game.Transition<Lab>();
                    Game.SaveGame();
                    break;
                case ConsoleKey.LeftArrow:
                    Game.AmmunationHP();
                    Game.HealthKit();
                    break;
                case ConsoleKey.RightArrow:
                    Game.MutlipleFightScene(2);
                    break;
                case ConsoleKey.DownArrow:
                    Console.WriteLine("You return to the Store House");
                    Game.SetTimer(1000);
                    Game.Transition<StoreHouse>();
                    break;
                case ConsoleKey.Tab:
                    Game.CheckInventory();
                    Game.SetTimer(1000);
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    Game.SetTimer(1000);
                    break;
            }
        }
    }
}
