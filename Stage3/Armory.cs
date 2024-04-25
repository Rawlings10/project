using NarrativeProject.Stage2;
using NarrativeProject.Stage3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Rooms
{
    [Serializable]
    internal class Armory : Room 
    {
        internal override string CreateDescription() =>
$@"{Game.name}, You are in a Armory    [STAGE 3] 

MAP
go forward next room.";

        internal override void PlayerMove(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    Console.WriteLine("You entered the Store House");
                    Game.SetTimer(1000);
                    Game.Transition<StoreHouse>();
                    break;
                case ConsoleKey.LeftArrow:
                    Game.AmmunationHP();
                    Game.SetTimer(500);
                    Game.HealthKit();
                    break; 
                case ConsoleKey.RightArrow:
                    Game.FightScene();
                    Game.AmmunationHP();
                    break;
                case ConsoleKey.DownArrow:
                    Console.WriteLine("You return to the ilusional door");
                    Game.SetTimer(1000);
                    Game.Transition<Door2>();
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
