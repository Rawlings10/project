using NarrativeProject.Stage2;
using System;

namespace NarrativeProject.Rooms
{
    internal class Corridor : Room
    {
        private int damage;
        public Corridor(Game newHP)
        {
            damage = newHP.GetHp();   
        }
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

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "forward":
                    Console.WriteLine("You open the third door.");
                    Game.Transition<Door3>();
                    break;
                case "left":
                    Console.WriteLine("You open the second door.");
                    Game.Transition<Door2>();
                    attack.PlayerDamage(1);
                    break;
                case "right":
                    Console.WriteLine("You open the first door");
                    Game.Transition<Door1>();
                    break;
                case "backward":
                    Console.WriteLine("You return to the bedroom.");
                    Game.Transition<Bedroom>();
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
