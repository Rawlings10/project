using System;

namespace NarrativeProject.Rooms
{
    internal class AtticRoom : Room
    {
        internal static bool isKeyCollected;

        internal override string CreateDescription() =>
@"In the attic, it's dark and cold.
A chest is locked with the code [????].
You can return to your [bedroom].
";

        internal override void PlayerMove(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.A:
                    Console.WriteLine("You return to your bedroom.");
                    Game.Transition<Bedroom>();
                    break;
                case ConsoleKey.B:
                    Console.WriteLine("The chest opens and you get a key.");
                    isKeyCollected = true;
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
