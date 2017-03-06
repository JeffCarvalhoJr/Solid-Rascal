using Solid_Rascal.UI;
using Solid_Rascal.Map_Gen;
using Solid_Rascal.Characters;
using Solid_Rascal.Characters.Player;
using Solid_Rascal.Characters.AI;
using Solid_Rascal.GameMasters;
using Solid_Rascal.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal
{
    class MainGame
    {
        //This is random
        public static Random rand = new Random();

        //Debug
        public static int TRIES = 0;
        bool bQuit;

        ///UI
        //public string playerAnswer;
        Alert alert;
        Stats playerInfo;

        ///Amazing GFX
        public Tileset TILESET;

        ///Map
        public Map mapGen;
        public int MAPHeight;
        public int MAPWidth;
        public int MaxRooms;

        ///Ai
        Pathfind mPathF;

        ///Game
        //Player
        public string playerName;
        public Player newPlayer;
        //Battle
        Battle battle;
        //Level
        public static int currentLevel;
        public static Tile[,] currentMap;
        public List<Tile> visibleMap;
        bool nextLevel;

        //Enemies
        EnemySpawner enemySpawner;
        int maxEnemies;

        int[] enemyPool;
        int[] enemyPool2;
        int[] enemyPool3;
        public static List<Character> activeEnemies;


        //Input
        public ConsoleKeyInfo userCKI;

        //Items
        ItemSpawner itemSpawner;
        int[] itemPool1;
        public static List<Item> activeItems;
        public static List<Item> activeFoods;


        public MainGame()
        {
            bQuit = false;

            //Ui
            alert = new Alert();

            //GFX
            TILESET = new Tileset();

            //Map
            mPathF = new Pathfind();
            visibleMap = new List<Tile>();

            //Items
            activeItems = new List<Item>();
            activeFoods = new List<Item>();

            //Actors
            activeEnemies = new List<Character>();

            //Spawners
            enemySpawner = new EnemySpawner();
            itemSpawner = new ItemSpawner();

            //Enemies pool, placeholder for test.
            enemyPool = new int[] { 100, 101, 102, 103, 104, 105, 106, 107, 108, 109 };
            enemyPool2 = new int[] { 110, 111, 112, 113, 114, 115, 116, 117, 118, 119 };
            enemyPool3 = new int[] { 120, 121, 122, 123, 124, 125 };

            //Items pool, placeholder for test.

            itemPool1 = new int[] { 100, 101, 102, 103, 150, 151, 152, 153, 154, 200, 201, 202, 251 };
            //HolderPool { 100, 101, 102, 103, 150, 151, 152, 153, 154, 200, 201, 202, 251 };

            Console.CursorVisible = true;
            playerName = alert.Question("Who are you?");
            Console.CursorVisible = false;
            GameStart();

        }

        void GameStart()
        {
            currentLevel = 0;
            maxEnemies = rand.Next(10,21);

            MAPWidth = 90;
            MAPHeight = 30;
            MaxRooms = 9;

            //init player
            newPlayer = new Player(playerName);

            //Game loop
            do
            {
                nextLevel = false;
                activeEnemies.Clear();
                FillEnemyList();
                FillItemList();
                //Setup map
                Console.Clear();
                visibleMap.Clear();
                mapGen = new Map(MAPWidth, MAPHeight);
                currentMap = mapGen.GetMap();

                currentLevel++;    

                PlaceExit();
                //Setup Actors
                PlaceActors();
                PlaceItems();

                PrintMap();

                //
                playerInfo = new Stats(MAPHeight, newPlayer);
                while (!(newPlayer.sHP < 1) && nextLevel == false && !bQuit)
                {    
                    PlayerMovement();
                    EnemiesTurn();
                    EndTurn();
                }
               
            } while (!(newPlayer.sHP < 1) && !bQuit);

            Console.Clear();

            if (newPlayer.sHP < 1)
            {
                alert.Warning("You are dead");
            }
            else
            {
                alert.Warning("Bye");
            }

            alert.Warning("Thanks for playing Solid Rascal Ver.0.1");
            Console.ReadLine();

        }

        void PlaceExit()
        {
            int randRoomX;
            int randRoomY;
            Room spawnRoom;

            int tileX, tileY;

            randRoomX = rand.Next(0, 3);
            randRoomY = rand.Next(0, 3);
            spawnRoom = mapGen._RoomsL[randRoomX, randRoomY];


            tileX = rand.Next((spawnRoom.X + 1), spawnRoom.X + spawnRoom.Width - 1);
            tileY = rand.Next((spawnRoom.Y + 1), spawnRoom.Y + spawnRoom.Height - 1);

            currentMap[tileY, tileX].SetExit();
        }

        void PlaceActors()
        {
            Tile tileToCheck;

            int randRoomX;
            int randRoomY;
            Room spawnRoom;

            int playerX, playerY;
            int enemyX, enemyY;

            do
            {
                randRoomX = rand.Next(0, 3);
                randRoomY = rand.Next(0, 3);
                spawnRoom = mapGen._RoomsL[randRoomX, randRoomY];

                playerX = rand.Next((spawnRoom.X + 1), spawnRoom.X + spawnRoom.Width - 1);
                playerY = rand.Next((spawnRoom.Y + 1), spawnRoom.Y + spawnRoom.Height - 1);

                tileToCheck = currentMap[playerY, playerX];
            } while (tileToCheck.hasChar);

            newPlayer.SetNewPosition(playerX, playerY);
            currentMap[newPlayer.yPos, newPlayer.xPos].SetCharacter(newPlayer);
            currentMap[newPlayer.yPos, newPlayer.xPos].SetVisible();
            currentMap[newPlayer.yPos, newPlayer.xPos].PrintTile();

            //Enemies for battle tests! 
            for (int i = 0; i < activeEnemies.Count; i++)
            {
                do
                {
                    randRoomX = rand.Next(0, 3);
                    randRoomY = rand.Next(0, 3);
                    spawnRoom = mapGen._RoomsL[randRoomX, randRoomY];

                    enemyX = rand.Next((spawnRoom.X + 1), spawnRoom.X + spawnRoom.Width - 1);
                    enemyY = rand.Next((spawnRoom.Y + 1), spawnRoom.Y + spawnRoom.Height - 1);

                    tileToCheck = currentMap[enemyY, enemyX];
                } while (tileToCheck.hasChar);
                activeEnemies[i].SetNewPosition(enemyX, enemyY);

                currentMap[activeEnemies[i].yPos, activeEnemies[i].xPos].SetCharacter(activeEnemies[i]);
            }
            FogOfWarReveal();
        }

        void PlaceItems()
        {
            Tile tileToCheck;

            int randRoomX;
            int randRoomY;
            Room spawnRoom;

            int itemX, itemY;
          
            for (int i = 0; i < 3; i++)
            {
                int tries = 0;
                do
                {
                    randRoomX = rand.Next(0, 3);
                    randRoomY = rand.Next(0, 3);
                    spawnRoom = mapGen._RoomsL[randRoomX, randRoomY];

                    itemX = rand.Next((spawnRoom.X + 1), spawnRoom.X + spawnRoom.Width - 1);
                    itemY = rand.Next((spawnRoom.Y + 1), spawnRoom.Y + spawnRoom.Height - 1);

                    tileToCheck = currentMap[itemY, itemX];
                    tries++;
                } while (tileToCheck.hasItem && tries < 100);
                activeItems[i].SetNewPosition(itemX, itemY);

                currentMap[activeItems[i].yPos, activeItems[i].xPos].SetItem(activeItems[i]);
            }

            for (int i = 0; i < activeFoods.Count; i++)
            {
                int tries = 0;
                do
                {
                    randRoomX = rand.Next(0, 3);
                    randRoomY = rand.Next(0, 3);
                    spawnRoom = mapGen._RoomsL[randRoomX, randRoomY];

                    itemX = rand.Next((spawnRoom.X + 1), spawnRoom.X + spawnRoom.Width - 1);
                    itemY = rand.Next((spawnRoom.Y + 1), spawnRoom.Y + spawnRoom.Height - 1);

                    tileToCheck = currentMap[itemY, itemX];
                    tries++;
                } while (tileToCheck.hasItem && tries < 100);
                activeFoods[i].SetNewPosition(itemX, itemY);

                currentMap[activeFoods[i].yPos, activeFoods[i].xPos].SetItem(activeFoods[i]);
            }

        }
        //probably need an update
        void PrintMap()
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            for (int i = 0; i < MAPHeight; i++)
            {
                for (int j = 0; j < MAPWidth; j++)
                {
                    currentMap[i, j].PrintTile();
                }
            }
        }

        void FillEnemyList()
        {
            int nextEnemy;
            int rN;

            for (int i = 0; i < maxEnemies; i++)
            {
                //low level enemies
                if (currentLevel < 11)
                {
                    rN = rand.Next(0, 10);
                    nextEnemy = enemyPool[rN];
                    activeEnemies.Add(enemySpawner.GetEnemy(nextEnemy));
                } //mid level enemies
                else if (currentLevel < 21)
                {
                    rN = rand.Next(0, 10);
                    nextEnemy = enemyPool2[rN];
                    activeEnemies.Add(enemySpawner.GetEnemy(nextEnemy));
                }   //high level enemies
                else if (currentLevel > 20)
                {
                    rN = rand.Next(0, 6);
                    nextEnemy = enemyPool3[rN];
                    activeEnemies.Add(enemySpawner.GetEnemy(nextEnemy));
                }
            }
        }

        void FillItemList()
        {
            int nextItem;
            int rN;

            for (int i = 0; i < 100; i++)
            {
                rN = rand.Next(0, itemPool1.Length);
                nextItem = itemPool1[rN];
                activeItems.Add(itemSpawner.GetItem(nextItem));
            }

            // food

            int randomFoodN = rand.Next(1, 10);

            for (int i = 0; i < randomFoodN; i++)
            {
                activeFoods.Add(itemSpawner.GetItem(250));
            }

        }

        void CharacterMovement(int dir, Character actor)
        {
            switch (dir)
            {
                //1 north
                case 1:

                    //Walk
                    currentMap[actor.yPos, actor.xPos].RemoveChar();
                    currentMap[actor.yPos, actor.xPos].PrintTile();

                    actor.yPos--;

                    currentMap[actor.yPos, actor.xPos].SetCharacter(actor);
                    currentMap[actor.yPos, actor.xPos].PrintTile();

                    break;
                //2 south
                case 2:

                    //Walk
                    currentMap[actor.yPos, actor.xPos].RemoveChar();
                    currentMap[actor.yPos, actor.xPos].PrintTile();

                    actor.yPos++;

                    currentMap[actor.yPos, actor.xPos].SetCharacter(actor);
                    currentMap[actor.yPos, actor.xPos].PrintTile();

                    break;
                //3 west
                case 3:
                    currentMap[actor.yPos, actor.xPos].RemoveChar();
                    currentMap[actor.yPos, actor.xPos].PrintTile();

                    actor.xPos--;

                    currentMap[actor.yPos, actor.xPos].SetCharacter(actor);
                    currentMap[actor.yPos, actor.xPos].PrintTile();

                    break;
                //4 east
                case 4:
                    currentMap[actor.yPos, actor.xPos].RemoveChar();
                    currentMap[actor.yPos, actor.xPos].PrintTile();

                    actor.xPos++;

                    currentMap[actor.yPos, actor.xPos].SetCharacter(actor);
                    currentMap[actor.yPos, actor.xPos].PrintTile();
                    break;
                //5 north west
                case 5:
                    currentMap[actor.yPos, actor.xPos].RemoveChar();
                    currentMap[actor.yPos, actor.xPos].PrintTile();

                    actor.yPos--;
                    actor.xPos--;

                    currentMap[actor.yPos, actor.xPos].SetCharacter(actor);
                    currentMap[actor.yPos, actor.xPos].PrintTile();
                    break;
                //6 north east
                case 6:
                    currentMap[actor.yPos, actor.xPos].RemoveChar();
                    currentMap[actor.yPos, actor.xPos].PrintTile();

                    actor.yPos--;
                    actor.xPos++;

                    currentMap[actor.yPos, actor.xPos].SetCharacter(actor);
                    currentMap[actor.yPos, actor.xPos].PrintTile();
                    break;
                //7 south east
                case 7:
                    currentMap[actor.yPos, actor.xPos].RemoveChar();
                    currentMap[actor.yPos, actor.xPos].PrintTile();

                    actor.yPos++;
                    actor.xPos++;

                    currentMap[actor.yPos, actor.xPos].SetCharacter(actor);
                    currentMap[actor.yPos, actor.xPos].PrintTile();
                    break;
                //8 south west
                case 8:
                    currentMap[actor.yPos, actor.xPos].RemoveChar();
                    currentMap[actor.yPos, actor.xPos].PrintTile();

                    actor.yPos++;
                    actor.xPos--;

                    currentMap[actor.yPos, actor.xPos].SetCharacter(actor);
                    currentMap[actor.yPos, actor.xPos].PrintTile();
                    break;
                default:
                    alert.Warning("Movement error");
                    break;
            }
        }

        void PlayerMovement()
        {

            Tile tileToCheck = currentMap[newPlayer.yPos, newPlayer.xPos];
            int moveId = 0;
            bool hasMoved = false;
            playerInfo.Action(newPlayer);
            userCKI = Console.ReadKey(true);

            if (userCKI.Key == ConsoleKey.UpArrow || userCKI.Key == ConsoleKey.NumPad8)
            {
                //North
                newPlayer.sHunger++;
                tileToCheck = currentMap[newPlayer.yPos - 1, newPlayer.xPos];
                moveId = 1;
                hasMoved = true;
            }
            else if (userCKI.Key == ConsoleKey.DownArrow || userCKI.Key == ConsoleKey.NumPad2)
            {
                //South
                newPlayer.sHunger--;
                tileToCheck = currentMap[newPlayer.yPos + 1, newPlayer.xPos];
                moveId = 2;
                hasMoved = true;
            }
            else if (userCKI.Key == ConsoleKey.LeftArrow || userCKI.Key == ConsoleKey.NumPad4)
            {
                //West
                tileToCheck = currentMap[newPlayer.yPos, newPlayer.xPos - 1];
                moveId = 3;
                hasMoved = true;
            }
            else if (userCKI.Key == ConsoleKey.RightArrow || userCKI.Key == ConsoleKey.NumPad6)
            {
                //East
                tileToCheck = currentMap[newPlayer.yPos, newPlayer.xPos + 1];
                moveId = 4;
                hasMoved = true;
            }
            else if (userCKI.Key == ConsoleKey.NumPad7)
            {
                //North West
                tileToCheck = currentMap[newPlayer.yPos - 1, newPlayer.xPos - 1];
                moveId = 5;
                hasMoved = true;
            }
            else if (userCKI.Key == ConsoleKey.NumPad9)
            {
                //North East
                tileToCheck = currentMap[newPlayer.yPos - 1, newPlayer.xPos + 1];
                moveId = 6;
                hasMoved = true;
            }
            else if (userCKI.Key == ConsoleKey.NumPad3)
            {
                //South East
                tileToCheck = currentMap[newPlayer.yPos + 1, newPlayer.xPos + 1];
                moveId = 7;
                hasMoved = true;

            }
            else if (userCKI.Key == ConsoleKey.NumPad1)
            {
                //South West
                tileToCheck = currentMap[newPlayer.yPos + 1, newPlayer.xPos - 1];
                moveId = 8;
                hasMoved = true;
            }
            else if (userCKI.Key == ConsoleKey.Spacebar)
            {
                tileToCheck = currentMap[newPlayer.yPos, newPlayer.xPos];
                if (tileToCheck.isExit)
                {
                    nextLevel = true;
                }
                //Skip Turn
            }
            else if (userCKI.Key == ConsoleKey.I)
            {
                Console.Clear();
                playerInfo.Inventory();
                Console.ReadKey();
                Console.Clear();
                PrintMap();
            }
            else if (userCKI.Key == ConsoleKey.Q)
            {
                //Consume items
                UseItem(3);
                PlayerMovement();

            }
            else if (userCKI.Key == ConsoleKey.W)
            {
                //Equip weapons
                UseItem(1);
                PlayerMovement();
            }
            else if (userCKI.Key == ConsoleKey.E)
            {
                //Equip Armors
                UseItem(2);
                PlayerMovement();
            }else if(userCKI.Key == ConsoleKey.D)
            {
                Dropitems();
            }
            else if (userCKI.Key == ConsoleKey.F)
            {
                //Cheaty cheat
                newPlayer.sHP += 50;
                alert.Action("More Health!");
            }
            else if (userCKI.Key == ConsoleKey.Escape)
            {
                bQuit = true;
            }

            if (hasMoved)
            {
                if (tileToCheck.isPassable)
                {
                    if (tileToCheck.hasItem)
                    {
                        Item itemToCheck = tileToCheck.tItem;
                        int itemType = itemToCheck.iCat;

                        if (newPlayer.inv.Count < 10)
                        {
                            alert.Action("You have found a " + itemToCheck.iName);
                            itemToCheck.Collect(newPlayer);
                            tileToCheck.Removetem();
                            CollectItem(itemToCheck);
                        }
                        else
                        {
                            alert.Action("inventory full");
                        }
                    }
                    CharacterMovement(moveId, newPlayer);
                    FogOfWarReveal();
                }
                else if (tileToCheck.hasChar)
                {
                    //Battle
                    battle = new Battle(newPlayer, tileToCheck.tChar);
                }
                else
                {
                    //bump nose
                    alert.Action("Stop trying hit the wall");
                }
            }
        }
        //End Turn events (effects, timers, etc)
        void EndTurn()
        {
            newPlayer.UpdateStatus();
            if(newPlayer.sHunger <= 0)
            {
                newPlayer.sHP = -1;
                alert.Warning("You starved to death");
            }
        }

        void UseItem(int type)
        {
            if (newPlayer.inv.Count <= 0)
            {
                alert.Action("Your inventory is empty.");
            }
            else
            {
                do
                {
                    switch (type)
                    {
                        //Weapons
                        case 1:
                            alert.Action("Choose an Weapon to wield (press i to check your inventory)");
                            break;
                        //Armor
                        case 2:
                            alert.Action("Choose an Armor to wear (press i to check your inventory)");
                            break;
                        //Consumables
                        case 3:
                            alert.Action("Choose an Item to use (press i to check your inventory)");
                            break;
                        default:
                            break;
                    }
                    userCKI = Console.ReadKey();
                    int i_Index;

                    if (userCKI.Key == ConsoleKey.I)
                    {
                        Console.Clear();
                        playerInfo.Inventory();
                        Console.ReadKey();
                        Console.Clear();
                        PrintMap();
                    }
                    else if (char.IsDigit(userCKI.KeyChar))
                    {
                        i_Index = int.Parse(userCKI.KeyChar.ToString());
                        switch (type)
                        {
                            //Weapons
                            case 1:
                                newPlayer.Wield(i_Index);
                                break;
                            //Armor
                            case 2:
                                newPlayer.Wear(i_Index);
                                break;
                            //Potions
                            case 3:
                                newPlayer.Use(i_Index);
                                break;
                            default:
                                break;
                        }
                        break;
                    }
                } while (userCKI.Key != ConsoleKey.Escape);
            }
        }

        void Dropitems()
        {
            if (newPlayer.inv.Count <= 0)
            {
                alert.Action("Your inventory is empty.");
            }
            else
            {
                alert.Action("Pick an item to drop (press i to check your inventory).");
                userCKI = Console.ReadKey();
                int i_Index;

                if (userCKI.Key == ConsoleKey.I)
                {
                    Console.Clear();
                    playerInfo.Inventory();
                    Console.ReadKey();
                    Console.Clear();
                    PrintMap();
                }
                else if (char.IsDigit(userCKI.KeyChar))
                {
                    try
                    {
                        i_Index = int.Parse(userCKI.KeyChar.ToString());

                        if (newPlayer.inv[i_Index].isEquipped)
                        {
                            alert.Warning("You must unequip the item to drop it");
                        }else
                        {
                            if (currentMap[newPlayer.yPos, newPlayer.xPos].hasItem)
                            {
                                alert.Warning("There is already an item here");
                            }
                            else
                            {
                                alert.Action("You dropped the " + newPlayer.inv[i_Index].iName);
                                currentMap[newPlayer.yPos, newPlayer.xPos].SetItem(newPlayer.inv[i_Index]);
                                newPlayer.inv.RemoveAt(i_Index);
                            }
                        }
                    }                       
                    catch
                    {
                        alert.Warning("Invalid choice");
                    }
                }
            }
        }

        void EnemiesTurn()
        {
            int index = 0;
            int AiChoice;
            foreach (Character enemy in activeEnemies)
            {
                CheckForPlayer(activeEnemies[index]);
                if (activeEnemies[index]._AiState == 1)
                {
                    AiChoice = activeEnemies[index].AiMovement();
                    EnemyMovement(activeEnemies[index], AiChoice);
                }
                else if (activeEnemies[index]._AiState == 2)
                {
                    mPathF.CreatePath(activeEnemies[index], newPlayer, currentMap);
                    activeEnemies[index].SetMovLib(mPathF.GetDirections());
                    EnemyMovement(activeEnemies[index], activeEnemies[index].GetNextTile());
                }

                index++;
            }
        }

        void EnemyMovement(Character enemy, int direction)
        {
            Tile tileToCheck = currentMap[enemy.yPos, enemy.xPos];
            int moveId = 0;

            if (direction == 1)
            {
                tileToCheck = currentMap[enemy.yPos - 1, enemy.xPos];
                moveId = 1;
            }
            else if (direction == 2)
            {
                tileToCheck = currentMap[enemy.yPos + 1, enemy.xPos];
                moveId = 2;
            }
            else if (direction == 3)
            {
                tileToCheck = currentMap[enemy.yPos, enemy.xPos - 1];
                moveId = 3;
            }
            else if (direction == 4)
            {
                tileToCheck = currentMap[enemy.yPos, enemy.xPos + 1];
                moveId = 4;
            }
            else if (direction == 5)
            {
                tileToCheck = currentMap[enemy.yPos - 1, enemy.xPos - 1];
                moveId = 5;
            }
            else if (direction == 6)
            {
                tileToCheck = currentMap[enemy.yPos - 1, enemy.xPos + 1];
                moveId = 6;
            }
            else if (direction == 7)
            {
                tileToCheck = currentMap[enemy.yPos + 1, enemy.xPos + 1];
                moveId = 7;
            }
            else if (direction == 8)
            {
                tileToCheck = currentMap[enemy.yPos + 1, enemy.xPos - 1];
                moveId = 8;
            }

            if (tileToCheck.isPassable)
            {
                CharacterMovement(moveId, enemy);
            }
            else if (tileToCheck.hasPlayer)
            {
                battle = new Battle(enemy, tileToCheck.tChar);
            }
        }

        void FogOfWarReveal()
        {
            int eastWall = 0;
            int westWall = 0;
            int northWall = 0;
            int southWall = 0;

            int roomSizeX;
            int roomSizeY;

            //reset previous revealed tiles
            int index = 0;
            foreach (Tile tile in visibleMap)
            {
                visibleMap[index].Reset();
                index++;
            }

            visibleMap.Clear();

            northWall = DistanceToWall(1) + 1;
            southWall = DistanceToWall(2) + 1;
            westWall = DistanceToWall(3) + 1;
            eastWall = DistanceToWall(4) + 1;

            roomSizeY = (northWall + southWall);
            roomSizeX = (eastWall + westWall);

            for (int y = newPlayer.yPos - northWall; y < newPlayer.yPos + southWall + 1; y++)
            {
                for (int x = newPlayer.xPos - westWall; x < newPlayer.xPos + eastWall + 1; x++)
                {
                    visibleMap.Add(currentMap[y, x]);
                }
            }

            index = 0;
            foreach (Tile tile in visibleMap)
            {
                visibleMap[index].SetVisible();
                index++;
            }

        }

        int DistanceToWall(int wall)
        {
            int index = 1;
            int distance = 0;

            switch (wall)
            {
                case 1:
                    //north wall
                    while (currentMap[newPlayer.yPos - index, newPlayer.xPos].tID == 0 || currentMap[newPlayer.yPos - index, newPlayer.xPos].tID == 11)
                    {
                        distance++;
                        index++;
                    }
                    return distance;
                case 2:
                    //south wall
                    while (currentMap[newPlayer.yPos + index, newPlayer.xPos].tID == 0 || currentMap[newPlayer.yPos + index, newPlayer.xPos].tID == 11)
                    {
                        distance++;
                        index++;
                    }
                    return distance;
                case 3:
                    //west wall
                    while (currentMap[newPlayer.yPos, newPlayer.xPos - index].tID == 0 || currentMap[newPlayer.yPos, newPlayer.xPos - index].tID == 11)
                    {
                        distance++;
                        index++;
                    }
                    return distance;
                case 4:
                    //east wall
                    while (currentMap[newPlayer.yPos, newPlayer.xPos + index].tID == 0 || currentMap[newPlayer.yPos, newPlayer.xPos + index].tID == 11)
                    {
                        distance++;
                        index++;
                    }
                    return distance;
            }
            return 0;
        }

        void CollectItem(Item item)
        {
            for (int i = 0; i < activeItems.Count; i++)
            {
                Item itemTC = activeItems[i];
                if (itemTC == item)
                {
                    activeItems.RemoveAt(i);
                }
            }
        }

        public static void KillAnCharacter(Character actor)
        {
            for (int i = 0; i < activeEnemies.Count; i++)
            {
                Character enemyTC = activeEnemies[i];
                if (enemyTC == actor)
                {
                    currentMap[enemyTC.yPos, enemyTC.xPos].RemoveChar();
                    activeEnemies.RemoveAt(i);
                }
            }
        }

        void CheckForPlayer(Character actor)
        {
            for (int x = -1; x < 2; x++)
            {
                for (int y = -1; y < 2; y++)
                {
                    if (currentMap[actor.yPos + y, actor.xPos + x].hasPlayer)
                    {
                        actor._AiState = 2;
                    }
                }
            }
        }
    }
}