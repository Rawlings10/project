using NarrativeProject.Rooms;
using NarrativeProject.Stage1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Stage2
{
    internal class Door2 : Room
    {
        internal override string CreateDescription() =>
@"You Opened the right door. 
this room has one door straight that takes you to the next stage.
but note the door is ilusional, it take can you to different places.
but you have to find you way back and keep trying until you enter the next stage.
MAP
go forward
 
          [forward]
.";
        internal override void PlayerMove(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    Random ilussion = new Random();
                    int ilussionalDoor = ilussion.Next(0, 5);
                    if (ilussionalDoor == 0)
                    {
                        Console.WriteLine("You find yourself in the Basement.");
                        Game.Transition<Basement>();
                    }
                    else if (ilussionalDoor == 1)
                    {
                        Console.WriteLine("You find yourself in the Bathroom.");
                        Game.Transition<Bathroom>();
                    }
                    else if (ilussionalDoor == 2)
                    {
                        Console.WriteLine("You find yourself in the Corridor.");
                        Game.Transition<Corridor>();
                    }
                    else if (ilussionalDoor == 3)
                    {
                        Console.WriteLine("You find yourself in the Corridor.");
                        Game.Transition<Door2>();
                    }
                    else if (ilussionalDoor == 4)
                    {
                        Console.WriteLine("You find yourself in the Corridor.");
                        Game.Transition<Room3>();
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
