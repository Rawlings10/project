using System;
using System.Collections.Generic;

namespace NarrativeProject
{
    internal abstract class Room
    {
        internal abstract string CreateDescription();
        internal abstract void PlayerMove(ConsoleKey key);
    }
}
