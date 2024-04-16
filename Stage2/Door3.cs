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
@"You Entered the basement. 
it is dark, quiet and cold.
MAP
The door forward is locked
The door backward leads to the bedroom. 
.

          [forward]

         [backward]
.";
        internal override void PlayerMove(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    Console.WriteLine("The Door is look!!!");
                    Console.WriteLine("What is the keycode???");
                    string code = Console.ReadLine();
                    if (code != "salut")
                    {
                        Console.WriteLine("The door is locked.");
                    }
                    else if (code == "salut")
                    {
                        Console.WriteLine("You open the door with the key and leave your bedroom.");
                        Game.Transition<Corridor>();
                    }
                    break;
                case ConsoleKey.DownArrow:
                    Console.WriteLine("You entered the Bedroom");
                    Game.Transition<Bedroom>();
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
