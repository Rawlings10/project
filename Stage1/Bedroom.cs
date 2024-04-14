using NarrativeProject.Stage1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;


namespace NarrativeProject.Rooms
{
    public void ArtifactMethod(Game gameinstance) 
    {
        gameinstance.
    }
    internal class Bedroom : Room 
    {
        internal override string CreateDescription() =>
@"You find yourself in a room. 
And you  are seeing walls of blood and strange objects.
The room creates a disturbing and gloomy atmosphere of mental desolation. 
You need to find way out of the room.
MAP
The door to forward is the exit
The door to your left to the basement
The door to your right to the bathroom

          [forward]
     [left]       [right]
         [backward]
.";


        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "forward":
                    Console.WriteLine("The Door is locked!!!");
                    Console.WriteLine("What is the keycode???");
                    string key = Console.ReadLine();
                    if (key != "bonjour")
                    {
                        Console.WriteLine("The door is locked.");
                    }
                    else if(key == "bonjour")
                    {
                        Console.WriteLine("You open the door with the key and leave your bedroom.");

                        Game.Transition<Room2>();
                    }
                    break;
                case "left":
                    Console.WriteLine("You entered the Basement");
                    Game.Transition<Basement>();
                    break;
                case "right":
                    Console.WriteLine("You entered the Bathroom");
                    Game.Transition<Bathroom>();
                    break;
                case "backward":
                    Console.WriteLine($"You find a [book] and a [{gameArtifact.knife}] on the table");
                    string pickItems = Console.ReadLine();
                    switch (pickItems)
                    {
                        case "book":
                            Console.WriteLine("you read the book and the it says, the passward to the door is: bonjour");
                            break;
                        case "knife":
                            
                            addArtifact<gameArtifact, myArtifact>(gameArtifact.knife);
                            Console.WriteLine($"The '{gameArtifact.knife}' has been added to your treasory.");
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
