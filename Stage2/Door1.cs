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
$@"{Game.name}, you Entered the first door. 
you happen to appear in a desert and got beaten by a snake.

MAP
backward to the corridor
        
         [backward]
.";
       
    internal override void PlayerMove(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.DownArrow:
                    Console.WriteLine("You return to the corridor");
                    Game.Transition<Corridor>();
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
