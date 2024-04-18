using NarrativeProject.Stage2;
using System;

namespace NarrativeProject.Rooms
{
    internal class Corridor : Room
    {
        private int damage;
        
        internal override string CreateDescription() =>
@"You are in a corridor that is having three doors,
Only one door is the right door, 
find the right door else you would get hurt when you enter the wrong room.
MAP
[left] door1
[right] door2
[forward] door3
[backward] bedroom
";

        internal override void PlayerMove(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    Console.WriteLine("You open the third door.");
                    Game.Transition<Door3>();
                    Game.PlayerDamage(15);
                    break;
                case ConsoleKey.LeftArrow:
                    Console.WriteLine("You open the second door.");
                    Game.Transition<Door2>();
                    
                    break;
                case ConsoleKey.RightArrow:
                    Console.WriteLine("You open the first door");
                    Game.PlayerDamage(10);
                    Game.Transition<Door1>();
                    break;
                case ConsoleKey.DownArrow:
                    Console.WriteLine("You return to the bedroom.");
                    Game.Transition<Bedroom>();
                    break;
                case ConsoleKey.Tab:
                    Game.CheckInventory();
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
