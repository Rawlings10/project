using System;
using System.Collections.Generic;
using System.Media;

namespace NarrativeProject
{
    public enum gameArtifact
    {
        knife,
        key
    }
    enum myArtifact
    {
        

    }

    public class Game
    {
         List<myArtifact> artifacts = new List<myArtifact>();
        internal void Inventory(gameArtifact artifact) 
        {
            artifacts.Add((myArtifact)artifact);
            Console.WriteLine($"You picked up the {artifact}");

            foreach (string item in Enum.GetNames(typeof(myArtifact)))
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
          
        public int GetHp()
        {
            return HP;
        }
        public void SetHp(int newHP) 
        {
            HP = newHP; 
        }
        public void PlayerDamage(int damage)
        {          
            SetHp(HP - damage);
            if(HP <= 0)
            {
                Game.Finish();
            }
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
