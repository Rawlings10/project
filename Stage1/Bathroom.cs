using NarrativeProject.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Stage1
{
    internal class Bathroom : Room
    {
        internal override string CreateDescription() =>
 @"You are in the bathroom. 
the showers is down running, with stains of blood filled in the bathtub.
MAP
The door backward leads to the bedroom. 
.

          

         [backward]
.";
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "backward":
                    Console.WriteLine("You entered the Bedroom");
                    Game.Transition<Bedroom>();
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}