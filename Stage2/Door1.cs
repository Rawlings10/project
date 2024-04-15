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
@"You Entered the first door. 
you entered a desert and got beaten by a snake.
you need to kill the snake!!!!
MAP
backward to the corridor
        
         [backward]
.";
        
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "backward":
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
