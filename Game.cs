using System;
using System.Collections.Generic;
using System.Timers;
using System.ComponentModel;
using System.Media;

namespace NarrativeProject
{
    public enum gameArtifact
    {
        knife,
        key
    }
    

    public class Game
    {
        static List<gameArtifact> artifacts = new List<gameArtifact>();
        
        internal static void Inventory(gameArtifact artifact) 
        {
            artifacts.Add(artifact);
            Console.WriteLine($"You picked up the {artifact}");

            foreach(gameArtifact item in artifacts) 
            {
                Console.WriteLine(item);
            }
        }
        
        List<Room> rooms = new List<Room>();
        Room currentRoom;
        internal bool IsGameOver() => isFinished;
        static bool isFinished;
        static string nextRoom = "";
        public static int HP = 100;
        public static string name;
        static string keycode;
        public static int score;
          
        public static int GetHp()
        {
            return HP;
        }
        public static void SetHp(int newHP) 
        {
            HP = newHP; 
        }
        public static void PlayerDamage(int damage)
        {          
            SetHp(HP - damage);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"You took a damage of: {damage}");
            if (HP <= 0)
            {
                Game.Finish();
            }
        }

        public static void SetTimer(int miliseconds) 
        {
            Timer timer = null;
            timer = new Timer(miliseconds);
        }

        internal void Add(Room room)
        {
            rooms.Add(room);
            if (currentRoom == null)
            {
                currentRoom = room;
            }
        }

        internal string CurrentRoomDescription => currentRoom.CreateDescription();
        

        internal void ReceiveChoice(ConsoleKey key)
        {
            currentRoom.PlayerMove(key);
            CheckTransition();
        }

        internal static void Transition<T>() where T : Room
        {
            nextRoom = typeof(T).Name;
        }

        internal static void Finish()
        {
            isFinished = true;
        }

        internal void CheckTransition()
        {
            foreach (var room in rooms)
            {
                if (room.GetType().Name == nextRoom)
                {
                    nextRoom = "";
                    currentRoom = room;
                    break;
                }
            }
        }
    }
}
