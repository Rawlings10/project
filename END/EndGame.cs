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





Press any key to exit
" ;
        internal override void PlayerMove(ConsoleKey key)
        {
            Console.ReadKey();
            Game.Finish();
        }
    }
}
