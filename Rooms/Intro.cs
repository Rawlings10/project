using NarrativeProject.Stage2;
using NarrativeProject.Stage4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Rooms
{
    internal class Start_Page : Room
    {
        public void title()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                        THE HUNTED MAISON                     ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("press any key to continue!!!");
            Console.ResetColor();
            Console.ReadKey();
            Console.Beep();
            Console.Clear();
        }
        public void Player_Details()
        {
            Console.WriteLine("Please Enter your name to start game.");
            Game.name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Welcome {Game.name}");
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("                             press any key to start");
            Console.ReadKey();
            Console.Beep();
            Console.Clear();
        }
        internal override string CreateDescription() =>
        $@"INTRO:
{Game.name}, You wake up in a mysterious mansion with no memory of how you got there.
As you explore, you realize the mansion is haunted with Monster.
Your goal is to find a way to escape the hunted house and escape from the Monsters..

First of all find a [weapon] around you for your safety. 
GOODLUCK!!!

press [Enter] button to Proceed.
press [Tab] how to play
press [space bar] to load game"            ;

        
        internal override void PlayerMove(ConsoleKey key)
        {
            
            switch (key)
            {
                case ConsoleKey.Enter:
                    Game.Transition<Bedroom>();
                    break;
                case ConsoleKey.Spacebar : 
                    Game.LoadGame(); 
                    break;
                case ConsoleKey.Tab:
                    Console.WriteLine();
                    Console.WriteLine("1- Use the directional button for navigation to four courners of your location");
                    Console.WriteLine("2- When you find object type the name of the object to pick them up");
                    Console.WriteLine("3- Press Tab at any time to check your inventory");
                    Console.WriteLine("4- When you see [map] it only shows the current exit point of your location, \nbut you can navigate around the room freely as you want");
                    Console.WriteLine("5- When enemy is spotted Press A to shot");
                    Console.WriteLine("6- When out of armor in fight press any key to run from enemy");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("Press any ESC key when you are done");
                    Console.ReadKey();
                    break;
               
                default: 
                    Console.WriteLine("invalid input!!!");
                    break;
            }
            
        }
    }

}
