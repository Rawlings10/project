using NarrativeProject.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Stage4
{
    internal class Libary : Room
    {
        private static char[,] keycode;
        private static bool gate;
        private static void EndGamePassword()
        {
            int cols = 2;
            int rows = 2;
            string[] position = { "First", "Second", "Third", "Fourth" };
            keycode = new char[cols, rows];
            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    Console.WriteLine($"Write the {position[i]} symbol");
                    keycode[i, j] = char.Parse(Console.ReadLine());
                }
            }
            if (keycode[0, 0] == '@' && keycode[0, 1] == '#' && keycode[1, 0] == '$' && keycode[1, 1] == '%')
            {
                Console.WriteLine($"[{keycode[0, 0]}][{keycode[0, 1]}]");
                Console.WriteLine($"[{keycode[1, 0]}][{keycode[1, 1]}]");
                gate = true;
                Game.SetTimer(1000);
            }
            else 
            {
                Console.WriteLine("Wrong Key");
                gate = false;
                Game.SetTimer(1000);
            }
            
        }
        internal override string CreateDescription() =>
$@"{Game.name}, You are in a Libary    [STAGE 4] 
Find the books to the containing the four exit key

MAP
go forward for EXIT.";


        internal override void PlayerMove(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    Console.WriteLine("What is the Password [****]");
                    EndGamePassword();
                    if (gate = true)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("gate OPen");
                        Game.SetTimer(2000);
                        Console.ResetColor();
                        Game.Transition<EndGame>();
                    }
                    else
                    {
                        Console.WriteLine("Wrong Password");
                        Game.SetTimer(500);
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    
                    break;
                case ConsoleKey.RightArrow:
                    
                    break;
                case ConsoleKey.DownArrow:
                    Console.WriteLine("You back to the Garage");
                    Game.Transition<Libary>();
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
