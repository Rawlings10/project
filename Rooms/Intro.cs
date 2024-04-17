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
            Console.WriteLine("Please Enter your name to start Game.");
            Game.name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Welcome {Game.name}");
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("press any key to start");
            Console.ReadKey();
            Console.Beep();
            Console.Clear();
        }
        internal override string CreateDescription() =>
        $@"INTRO:
{Game.name}, You wake up in a mysterious mansion with no memory of how you got there.
As you explore, you realize the mansion is haunted.
Your goal is to find a way to escape before it's too late.



press [Enter] button to Proceed.
presss [Tab] how to play";
        
        internal override void PlayerMove(ConsoleKey key)
        {
            
            switch (key)
            {
                case ConsoleKey.Enter:
                    Game.Transition<Corridor>();
                    break;
                case ConsoleKey.Tab:
                    Console.WriteLine("Use the directional button for navigation to four courners of your location");
                    Console.WriteLine("When you find object type the name of the object to pick them up");
                    Console.WriteLine("when you see [map] it only shows the current exit point of your location");
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
