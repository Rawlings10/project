using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Rooms
{
    internal class Start_Page : Room, IDetails
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



Type [start] to proceed to game
Type [rules] for how to play";
        
        internal override void ReceiveChoice(string choice)
        {
            
            switch (choice)
            {
                case "start":
                     Game.Transition<Bedroom>();
                     break;
                case "rules":
                     Console.WriteLine("this is the rules.............");
                     break;
                default: 
                     Console.WriteLine("invalid input!!!");
                     break;
            }
            
        }
    }

}
