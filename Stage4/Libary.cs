using NarrativeProject.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Stage4
{
    internal class Libary : Room
    {
        internal override string CreateDescription() =>
$@"{Game.name}, You are in a Labary    [STAGE 4] 

MAP
go forward for EXIT maison.";


        internal override void PlayerMove(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    Game.Transition<EndGame>();
                    break;
                case ConsoleKey.LeftArrow:
                    Game.MutlipleFightScene(2);
                    break;
                case ConsoleKey.RightArrow:
                    Game.MutlipleFightScene(2);
                    Console.WriteLine("You entered the Libary");
                    Game.Transition<Libary>();
                    break;
                case ConsoleKey.DownArrow:
                    Console.WriteLine("You back to the Garage");
                    Game.Transition<Libary>();
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
