using System;
using System.Collections.Generic;
using System.Threading;
using System.ComponentModel;
using System.Media;
using System.Security.Policy;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;

namespace NarrativeProject
{
    public enum gameArtifact
    {
        gun,
        key,
        gold,
        silver
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
            Console.WriteLine();
            Inventory.Add(item);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("New Item Found");
            Console.WriteLine($"[{item}] added to found items");
            Console.ResetColor();
            if(item == gameArtifact.gun)
            {
                SetAmmunation(Ammunation + 20);
            }
            SetTimer(3000);
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
        public static int Ammunation;
        public static int enermyHp;
        internal static int enemyAttackDamage; 
        public static int PlayerAttackDamage;
        public static bool playerTurn = true;
          
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
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Amunation Found!!!");
            SetAmmunation(Ammunation + 20);
            SetTimer(1500);
            Console.ResetColor();   
        }

        public static void DetailsBoard()
        {
            Console.WriteLine($"                                                                                                 Player: {Game.name}");
            if (PlayerHP > 50)
            {
                Console.ForegroundColor= ConsoleColor.Green;
                Console.WriteLine($"                                                                                                     HP: {Game.PlayerHP}");
                Console.ResetColor();
            }
            else if(PlayerHP > 20)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"                                                                                                     HP: {Game.PlayerHP}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"                                                                                                     HP: {Game.PlayerHP}");
                Console.ResetColor();
            }

            if (Ammunation > 30)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"                                                                                                     HP: {Game.Ammunation}");
                Console.ResetColor();
            }
            else if (Ammunation > 15)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"                                                                                                     HP: {Game.Ammunation}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"                                                                                                     HP: {Game.Ammunation}");
                Console.ResetColor();
            }
            
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
            Console.WriteLine("Enemy turn");
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
        public static void FightScene(int enemy = 15)
        { 
            enermyHp = enemy; 
            ConsoleKey key;
            Console.WriteLine("Enemy Spotted!!!");

            while (PlayerHP > 0 && enermyHp > 0)
            {
                Console.WriteLine("Press A to Shoot enemy");
                key = Console.ReadKey().Key;
                Console.Clear();

                if (key == ConsoleKey.A)
                {
                    PlayerAttack();
                    if (enermyHp <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Enemy Defeated");
                        Console.ResetColor();
                        SetTimer(1000);
                    }
                    else
                    {
                        SetTimer(1000);
                        EnemyAttack();
                    }
                }
                else
                {
                    break;
                }

                if (PlayerHP <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Oops!!! Eliminated");
                    SetTimer(2000);
                    Game.Finish();
                    break; 
                }
            }
        }
        public static void MutlipleFightScene(int EnemyNumber)
        {
            for (int i = 0; i <= EnemyNumber; i++)
            {
                FightScene();
                Console.WriteLine();
                if(i < EnemyNumber)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("ANOTHER ENEMY INCOMING!!!");
                    SetTimer(500);
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("AREA CLEAR");
                    SetTimer(500);
                    Console.ResetColor();
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
        public static void SaveGame()
        {
            if (!File.Exists("SaveGame.txt"))
            {
                File.Create("SaveGame.txt");
            }
            using (StreamWriter writer = new StreamWriter("SaveGame.txt"))
            {
                writer.WriteLine(name);
                writer.WriteLine(PlayerHP);
                writer.WriteLine(Ammunation);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Game Saved Successfully");
            Console.ResetColor();
            SetTimer(2000);
        }

        public static void LoadGame()
        {
            if (File.Exists("SaveGame.txt"))
            {
                try
                {
                    using (StreamReader reader = new StreamReader("SaveGame.txt"))
                    {
                        name = reader.ReadLine();
                        string playerHPString = reader.ReadLine();
                        string ammunitionString = reader.ReadLine();
                        string inventoryJson = reader.ReadLine();

                        if (int.TryParse(playerHPString, out int playerHP) && int.TryParse(ammunitionString, out int ammunition))
                        {
                            PlayerHP = playerHP;
                            Ammunation = ammunition;

                           

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Game loaded successfully.");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine("Error: Invalid data format in the save file.");
                        }
                    }
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"Error loading game: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("No save game found.");
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
