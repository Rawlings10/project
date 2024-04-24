using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Rooms
{
    internal class EndGame : Room
    {
        public EndGame() { }

        internal override string CreateDescription() =>
        $@"{Game.name}
CONGRATULATIONS, YOU FINISH THE GAME

       
        


CREDITS
by Rawlings & Jorge

Press any key to show your details.
" ;
        internal override void PlayerMove(ConsoleKey key)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{Game.name}");
            Console.WriteLine($"HP: {Game.PlayerHP}");
            Console.WriteLine($"AMUNATION: {Game.Ammunation}");
            Game.CheckInventory();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Press any key to end");
            Console.ResetColor();
            Console.ReadKey();
            Game.Finish();
        }
    }
}
