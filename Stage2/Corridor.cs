using NarrativeProject.Stage2;
using System;

namespace NarrativeProject.Rooms
{
    internal class Corridor : Room
    {
        private int damage;
        
        internal override string CreateDescription() =>
$@"{Game.name}, you are in a Corridor with three different doors.     [STAGE 2]
Only one door is the right door, 

MAP
go left - door 1
go right -door 3
go forward - door 2
go backward - bedroom";

        internal override void PlayerMove(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    Console.WriteLine("You open the second door.");
                    Game.Transition<Door2>();
                    break;
                case ConsoleKey.LeftArrow:
                    Console.WriteLine("You open the third door.");
                    Game.Transition<Door1>();
                    
                    break;
                case ConsoleKey.RightArrow:
                    Console.WriteLine("You open the first door");
                    Game.Transition<Door3>();
                    break;
                case ConsoleKey.DownArrow:
                    Console.WriteLine("You return to the bedroom.");
                    Game.Transition<Bedroom>();
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
