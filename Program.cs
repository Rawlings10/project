using NarrativeProject.Rooms;
using NarrativeProject.Stage1;
using NarrativeProject.Stage2;
using NarrativeProject.Stage3;
using NarrativeProject.Stage4;
using System;

namespace NarrativeProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            Start_Page intro = new Start_Page();
            intro.title();
            intro.Player_Details();
            game.Add(intro);      
            game.Add(new Bedroom());
            game.Add(new Bathroom());
            game.Add(new Basement());
            game.Add(new Corridor());
            game.Add(new Door1());
            game.Add(new Door2());
            game.Add(new Door3());
            game.Add(new Armory());
            game.Add(new StoreHouse());
            game.Add(new Garage());
            game.Add(new Lab());
            game.Add(new Libary());
            game.Add(new EndGame());
            

            

            while (!game.IsGameOver())
            {
                Console.WriteLine("--");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"                                                                                                 Player: {Game.name}");
                Console.WriteLine($"                                                                                                     HP: {Game.PlayerHP}");
                Console.WriteLine($"                                                                                                 Weapon: {Game.Ammunation}");
                Console.ResetColor();
                Console.WriteLine(game.CurrentRoomDescription);
                game.ReceiveChoice(Console.ReadKey().Key);
                Console.Clear();
            }
            Console.Clear();
            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine("ELIMINATED");
            Game.SetTimer(1000);
        }
    }
}
