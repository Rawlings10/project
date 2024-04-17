using NarrativeProject.Stage1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;


namespace NarrativeProject.Rooms
{
    internal class Bedroom : Room 
    {
        Game artifact = new Game();
                 
        internal override string CreateDescription() =>
$@"{Game.name}, You find yourself in a room. 
And you  are seeing walls of blood and strange objects.
The room creates a disturbing and gloomy atmosphere of mental desolation. 
You need to find way out of the room.
MAP
The door to forward is the exit
The door to your left to the basement
The door to your right to the bathroom

.";


        internal override void PlayerMove(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    Console.WriteLine($"{Game.name}, the Door is locked!!!");
                    Console.WriteLine("What is the keycode???");
                    string code = Console.ReadLine();
                    if (code != "bonjour")
                    {
                        Console.WriteLine("The door is locked.");
                    }
                    else if(code == "bonjour")
                    {
                        Console.WriteLine($"{Game.name}, you open the door with the key and leave the bedroom.");

                        Game.Transition<Corridor>();
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    Console.WriteLine($"{Game.name}, you entered the Basement");
                    
                    Game.Transition<Basement>();
                    break;
                case ConsoleKey.RightArrow:
                    Console.WriteLine($"{Game.name}, you entered the Bathroom");
                    Game.Transition<Bathroom>();
                    break;
                case ConsoleKey.DownArrow:
                    Console.WriteLine($"{Game.name}, you find a [book] [{gameArtifact.key}] and a [{gameArtifact.knife}] on the table");
                    string pickItems = Console.ReadLine();
                    switch (pickItems)
                    {
                        case "book":
                            Console.WriteLine("you read the book and the it says, the passward to the door is: bonjour");
                            break;
                        case "knife":
                            Game.Inventory(gameArtifact.knife);
                            
                            break;
                        case "key":
                            Game.Inventory(gameArtifact.key);
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
