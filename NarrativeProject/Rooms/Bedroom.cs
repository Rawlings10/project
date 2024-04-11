using System;

namespace NarrativeProject.Rooms
{
    internal class Bedroom : Room 
    {

        internal override string CreateDescription() =>
@"You find yourself in a room your hands are tied together.
And you  are seeing walls of blood and strange objects.
The room creates a disturbing and gloomy atmosphere of mental desolation. 
You need to find a way to loosen your hands. 

go [left] or [right] of the room!!!

.";


        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "left":
                    Console.WriteLine("You enter the bathroom.");
                    Game.Transition<Bathroom>();
                    break;
                case "right":
                    if (!AtticRoom.isKeyCollected)
                    {
                        Console.WriteLine("The door is locked."); 
                    }
                    else
                    {
                        Console.WriteLine("You open the door with the key and leave your bedroom.");
                        Game.Finish();
                    }
                    break;
                case "attic":
                    Console.WriteLine("You go up and enter your attic.");
                    Game.Transition<AtticRoom>();
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
