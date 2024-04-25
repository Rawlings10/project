using NarrativeProject.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Stage1
{
    [Serializable]
    internal class Bathroom : Room
    {
        internal override string CreateDescription() =>
 $@"{Game.name}, you are in the bathroom.    [STAGE 1]
the showers is down running, with stains of blood filled in the bathtub.

MAP
The door backward leads to the bedroom.";
        internal override void PlayerMove(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    Console.WriteLine($"{Game.name}, Nothing found");
                    Game.SetTimer(500);
                    Game.Transition<Bathroom>();
                    break;
                case ConsoleKey.DownArrow:
                    Console.WriteLine("You entered the Bedroom");
                    Game.Transition<Bedroom>();
                    break;
                case ConsoleKey.RightArrow:
                    Console.WriteLine($"{Game.name}, Nothing found");
                    Game.SetTimer(500);
                    Game.Transition<Bathroom>();
                    break;
                case ConsoleKey.LeftArrow:
                    Console.WriteLine($"{Game.name}, Nothing found");
                    Game.SetTimer(500);
                    Game.Transition<Bathroom>();
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