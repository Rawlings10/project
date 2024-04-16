using System;
using System.Collections.Generic;

namespace NarrativeProject
{
    internal abstract class Room
    {
        internal abstract string CreateDescription();
        internal abstract void PlayerMove(ConsoleKey key);

        public static void addArtifact<T1, T2>(T1 items)
        {
            string itemString = items.ToString();
            if (Enum.TryParse<myArtifact>(itemString, out myArtifact destinationItem))
            {
                Console.WriteLine("Item Picked.");
            }
        }
    }

    internal interface IDetails
    {
        void title();
        void Player_Details();

    }
}
