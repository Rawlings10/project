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
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"[{keycode[0, 0]}][{keycode[0, 1]}]");
                Console.WriteLine($"[{keycode[1, 0]}][{keycode[1, 1]}]");
                Console.ResetColor();
                gate = true;
                Game.SetTimer(1000);
                Console.Beep();
                Game.Transition<EndGame>();
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
                    break;
                case ConsoleKey.LeftArrow:
                    Console.WriteLine("You see the first book");
                    Game.SetTimer(1000);
                    Console.Clear();
                    Console.WriteLine("you read the book and the it says");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("The first symbol to the gate is '@' \nThe second symbol is gate '#' ");
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Any any key to close the book.........");
                    Console.ReadKey();
                    break;
                case ConsoleKey.RightArrow:
                    Console.WriteLine("You see the second book");
                    Game.SetTimer(1000);
                    Console.Clear();
                    Console.WriteLine("you read the book and the it says");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("The third symbol to the gate is '$' \nThe second symbol is gate '%' ");
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Any any key to close the book.........");
                    Console.ReadKey();
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
