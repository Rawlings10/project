using NarrativeProject.Stage1;
using System;
using System.Collections.Generic;
using System.ComponentModel;


namespace NarrativeProject.Rooms
{
    
    internal class Bedroom : Room 
    {
        internal override string CreateDescription() =>
@"You find yourself in a room. 
And you  are seeing walls of blood and strange objects.
The room creates a disturbing and gloomy atmosphere of mental desolation. 
You need to find way out of the room.

          [forward]
     [left]       [right]
         [backward]
.";


        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "forward":
                    
                    Console.WriteLine("You moved exit door what is the keycode???");
                    string key = Console.ReadLine();
                    if (key != "boy")
                    {
                        Console.WriteLine("The door is locked.");
                    }
                    else if(key == "boy")
                    {
                        Console.WriteLine("You open the door with the key and leave your bedroom.");
                        Game.Transition<Room2>();
                        Game.Finish();
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
                    Console.WriteLine("You find a [book] and a [knife] on the table");
                    string pickItems = Console.ReadLine();
                    switch (pickItems)
                    {
                        case "book":
                            Console.WriteLine("you read the book and the it says, the passward to the door is: bonjour");
                            break;
                        case "knife":
                            Bedroom.addArtifact<gameArtifact, myArtifact>(gameArtifact.knife);
                            Console.WriteLine($"The '{gameArtifact.knife}' has been added to your treasory.");
                            break;
                    }
                    break;
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
