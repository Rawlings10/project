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
$@"{Game.name}, you entered into a . 
it is dark, quiet and cold but got attack by scorpion.
MAP
The door backward leads to the corridor. 
.

         [backward]
.";
        internal override void PlayerMove(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.DownArrow:
                    Console.WriteLine("Back to the corridor");
                    Game.Transition<Corridor>();
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
