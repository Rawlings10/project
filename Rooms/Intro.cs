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
            Console.WriteLine("                        THE HUNTED MAISON                      ");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("press any key to continue!!!");
            Console.ReadKey();
            Console.Beep();
            Console.Clear();
        }
        public void Player_Details()
        {
            Console.WriteLine("Please Enter your name to start Game.");
            Game.name = Console.ReadLine();
            Console.WriteLine($"Welcome {Game.name} press");
        }
        internal override string CreateDescription() =>
        @"You wake up in a mysterious mansion with no memory of how you got there.
As you explore, you realize the mansion is haunted.
Your goal is to find a way to escape before it's too late.



press [Enter] button to game.
presss [Tab] how to play";
        
        internal override void PlayerMove(ConsoleKey key)
        {
            
            switch (key)
            {
                case ConsoleKey.Enter:
                     Game.Transition<Bedroom>();
                     break;
                case ConsoleKey.Tab:
                     Console.WriteLine("Use the directional button for navigation");
                    Console.WriteLine("When you find object type the name of the object to pick them up");
                    break;
               
                default: 
                     Console.WriteLine("invalid input!!!");
                     break;
            }
            
        }
    }

}
