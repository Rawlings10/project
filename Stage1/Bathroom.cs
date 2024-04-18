using NarrativeProject.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Stage1
{
    internal class Bathroom : Room
    {
        internal override string CreateDescription() =>
 $@"{Game.name}, you are in the bathroom. 
the showers is down running, with stains of blood filled in the bathtub.
MAP
The door backward leads to the bedroom. 

         [backward]
.";
        internal override void PlayerMove(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.DownArrow:
                    Console.WriteLine("You entered the Bedroom");
                    Game.Transition<Bedroom>();
                    break;
                case ConsoleKey.RightArrow:
                    Console.WriteLine($"{Game.name}, Nothing found");
                    Game.Transition<Bathroom>();
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}