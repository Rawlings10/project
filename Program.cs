using NarrativeProject.Rooms;
using NarrativeProject.Stage1;
using System;

namespace NarrativeProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            game.Add(new Start_Page());
            game.Add(new Bedroom());
            game.Add(new Bathroom());
            game.Add(new Basement());
            game.Add(new Room2());
            game.Add(new AtticRoom());
            game.Add(new Lab());

            

            while (!game.IsGameOver())
            {
                Console.WriteLine("--");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"                                                                                                      HP: {Game.HP}");
                Console.ResetColor();
                Console.WriteLine(game.CurrentRoomDescription);
                string choice = Console.ReadLine().ToLower() ?? "";
                Console.Clear();
                game.ReceiveChoice(choice);
            }

            Console.WriteLine("END");
            Console.ReadLine();
        }
    }
}
