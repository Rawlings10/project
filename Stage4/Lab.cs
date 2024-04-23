using NarrativeProject.Stage3;
using NarrativeProject.Stage4;
using System;

namespace NarrativeProject.Rooms
{
    internal class Lab : Room
    {
        internal static bool isKeyCollected;

        internal override string CreateDescription() =>
$@"{Game.name}, You are in a Lab    [STAGE 4] 

MAP
go left for libary.";


        internal override void PlayerMove(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    Game.MutlipleFightScene(3);
                    Game.AddtoInventory(gameArtifact.silver);
                    Game.AmmunationHP();
                    break;
                case ConsoleKey.LeftArrow:
                    Game.MutlipleFightScene(2);
                    break;
                case ConsoleKey.RightArrow:
                    Game.MutlipleFightScene(2);
                    Console.WriteLine("You entered the Libary");
                    Game.Transition<Libary>();
                    break;
                case ConsoleKey.DownArrow:
                    Console.WriteLine("You back to the Garage");
                    Game.Transition<Garage>();
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
