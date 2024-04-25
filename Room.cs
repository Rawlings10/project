using System;
using System.Collections.Generic;

namespace NarrativeProject
{
    [Serializable]
    internal abstract class Room
    {
        internal abstract string CreateDescription();
        internal abstract void PlayerMove(ConsoleKey key);
    }
}
