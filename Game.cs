using System;
using System.Collections.Generic;
using System.Threading;
using System.ComponentModel;
using System.Media;
using System.Security.Policy;
using System.Runtime.InteropServices;

namespace NarrativeProject
{
    public enum gameArtifact
    {
        gun,
        key,
        gold
    }

    public class Game
    {
        public static List<gameArtifact> Inventory { get; private set; }

        public Game()
        {
            Inventory = new List<gameArtifact>();
        }

        public static void AddtoInventory(gameArtifact item) 
        {
            Inventory.Add(item);
            Console.WriteLine($"{item} added to found items");
            if(item == gameArtifact.gun)
            {
                SetAmmunation(Ammunation + 20);
            }
            SetTimer(2000);
        }
        public static void CheckInventory()
        {
            Console.WriteLine("INVENTORY");
            foreach (var item in Inventory)
            {
                Console.WriteLine(item);
            }
            Game.SetTimer(1000);
        }

        List<Room> rooms = new List<Room>();
        Room currentRoom;
        internal bool IsGameOver() => isFinished;
        static bool isFinished;
        static string nextRoom = "";
        public static int PlayerHP = 100;
        public static string name;
        public static int amorPower = 3;
        public static int Ammunation;
        public static int enermyHp = 15;
        internal static int enemyAttackDamage; 
        public static int PlayerAttackDamage;
        public static bool playerTurn = true;
        public static bool isAmorUsed;
          
        public static int GetHp()
        {
            return PlayerHP;
        }
        public static void SetHp(int newHP) 
        {
            PlayerHP = newHP; 
        }

        public static int GetAmmunation() 
        {
            return Ammunation;
        }
        public static void SetAmmunation(int amunation) 
        {
            Ammunation = amunation;
        }
        public static void AmmunationHP()
        {           
            SetAmmunation(Ammunation + 20);
        }

        public static int GetAmor()
        {
            return amorPower;
        }
        public static void SetAmor(int amor)
        {
            amorPower = amor;
        }
        public static void PlayerAttack()
        {
            if (Ammunation > 0)
            {
                Random hit = new Random();
                PlayerAttackDamage = hit.Next(2, 9); 
                Ammunation -= 3;
                enermyHp -= PlayerAttackDamage;
                Console.ForegroundColor = ConsoleColor.Red;
                if (enermyHp < 0)
                {
                    enermyHp = 0;
                }
                Console.WriteLine("BOOM!!!");
                Console.WriteLine($"   damage -{PlayerAttackDamage}                                                                                          Enemy Hp:{enermyHp}");
                Console.ResetColor();
                if(PlayerAttackDamage > 6)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Perfect Shot");
                    Console.ResetColor();
                }
                else if(PlayerAttackDamage > 3)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Good shot, try aiming better");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Poor Target!!!");
                    Console.ResetColor();
                }
            }
            else if (Ammunation <= 0)
            {           
                Console.WriteLine("OPPS, out of ammunation!!!");
            }
        }
        public static void EnemyAttack()
        {
            Random hit = new Random();
            enemyAttackDamage = hit.Next(4, 10);
            Console.WriteLine("Enermy turn");
            SetTimer(500);
            PlayerHP -= enemyAttackDamage;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("VOOOOOOOOO!!!!");
            Console.WriteLine($"Enemy Attacked, PlayerHP: -{enemyAttackDamage}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"   damage -{enemyAttackDamage}                                                                                          Player Hp:{PlayerHP}");
            Console.WriteLine($"                                                                                                       Ammuntion:{Ammunation}");
            Console.ResetColor();
        }
        public static void FightScene()
        {
            ConsoleKey key;
            Console.WriteLine("Enermy Spotted!!!");
            while (PlayerHP > 0 && enermyHp > 0)
            {                
                Console.WriteLine("Press A to Shot enemy");
                key = Console.ReadKey().Key;
                Console.Clear();
                switch (key)
                {
                    case ConsoleKey.A:
                        PlayerAttack();
                        SetTimer(1000);
                        EnemyAttack();
                        break;
                }
                if(PlayerHP <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Opps!!! Eliminated");
                    SetTimer(5000);
                    Game.Finish();
                }
                else if(enermyHp <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Enemy Defeated");
                    Console.ResetColor();
                    SetTimer(1000);
                }

            }
        }
        public static void EmptySpace()
        {
            Console.WriteLine($"{Game.name}, Nothing found here");
            Game.SetTimer(500);
        }
        public static void SetTimer(int time)
        {
            Thread.Sleep(time);
        }

        public static void HealthKit()
        {
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("Health Supplies Found +++");
            SetHp(PlayerHP + 25);
            Console.ResetColor();
            SetTimer(500);
            if (PlayerHP > 100)
            {
                SetHp(PlayerHP = 100);  
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
