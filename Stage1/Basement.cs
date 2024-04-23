using NarrativeProject.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Stage1
{
    internal class Basement : Room
    {
        internal override string CreateDescription() =>
$@"{Game.name}, you Entered the basement    [STAGE 1]. 
The basement if full of stuff, be carefull of your direction, enermy might be around

MAP
The door forward is locked find the key
The door backward leads to the bedroom.";


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
                        Game.SetTimer(1000);
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
                case ConsoleKey.RightArrow:
                    Game.FightScene();
                    Game.SetTimer(500);
                    break;
                case ConsoleKey.LeftArrow:
                    Console.WriteLine($"{Game.name}, Nothing found");
                    Game.SetTimer(500);
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
