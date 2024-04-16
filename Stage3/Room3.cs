using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Rooms
{
    internal class Room3 : Room 
    {
        internal override string CreateDescription() =>
@"You Entered the first door. 
you entered a desert and got beaten by a snake.
you need to kill the snake!!!!
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
