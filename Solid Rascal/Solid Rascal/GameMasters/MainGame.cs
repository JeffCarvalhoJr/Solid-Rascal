using Solid_Rascal.UI;
using Solid_Rascal.Map_Gen;
using Solid_Rascal.Characters;
using Solid_Rascal.Characters.Player;
using Solid_Rascal.Characters.Enemies;
using Solid_Rascal.Characters.AI;
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
        Slime newSlime;

        ///UI
        public string playerAnswer;
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
        Pathfind pathF;

        ///Game
        //Player
        Player newPlayer;
        //Battle
        Battle battle;
        //Level
        public static int currentLevel;
        public static Tile[,] currentMap;
        public List<Tile> visibleMap;
        //Enemies
        Character[] enemyPool1;
        Character[] enemyPool2;
        Character[] enemyPool3;
        public static List<Character> activeEnemies;



        //Input
        public ConsoleKeyInfo userCKI;


        public MainGame()
        {
            alert = new Alert();
            pathF = new Pathfind();
            visibleMap = new List<Tile>();
            activeEnemies = new List<Character>();
            TILESET = new Tileset();
            GameStart();

        }


        void GameStart()
        {
            currentLevel = 0;
            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.UTF8;
            MAPWidth = 90;
            MAPHeight = 30;

            MaxRooms = 9;

            //init player
          

            //generating map loop
            do
            {
                //Setup map
                Console.Clear();
                visibleMap.Clear();
                mapGen = new Map(MAPWidth, MAPHeight);
                currentMap = mapGen.GetMap();
                PrintMap();
                currentLevel++;

                newPlayer = new Player();


                //Setup Actors
                PlaceActors();

                //
                playerInfo = new Stats(MAPHeight, newPlayer);
                PlayerMovement();

                try
                {
                    playerAnswer = alert.Question("Want to generate again? (y/n)");
                }
                catch
                {
                    playerAnswer = "y";
                }
            } while (playerAnswer.Equals("Y") || playerAnswer.Equals("y"));

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
            } while (tileToCheck.HasCharacter());

            newPlayer.SetNewPosition(playerX, playerY);
            currentMap[newPlayer.yPos, newPlayer.xPos].SetCharacter(newPlayer);
            currentMap[newPlayer.yPos, newPlayer.xPos].SetVisible();
            currentMap[newPlayer.yPos, newPlayer.xPos].PrintTile();

            //Slimes for battle tests!
            for (int i = 0; i < 20; i++)
            {
                newSlime = new Slime();
                do
                {
                    randRoomX = rand.Next(0, 3);
                    randRoomY = rand.Next(0, 3);
                    spawnRoom = mapGen._RoomsL[randRoomX, randRoomY];

                    enemyX = rand.Next((spawnRoom.X + 1), spawnRoom.X + spawnRoom.Width - 1);
                    enemyY = rand.Next((spawnRoom.Y + 1), spawnRoom.Y + spawnRoom.Height - 1);

                    tileToCheck = currentMap[enemyY, enemyX];
                } while (tileToCheck.HasCharacter());
                newSlime.SetNewPosition(enemyX, enemyY);
               
                currentMap[newSlime.yPos, newSlime.xPos].SetCharacter(newSlime);
                activeEnemies.Add(newSlime);
            }
            FogOfWarReveal();

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
                    //System.Threading.Thread.Sleep(1);//function to see the map being printed on the console with a delay (kinda nice)
                }
            }
        }

        void UpdateMap()
        {
            foreach (Tile tile in visibleMap)
            {

                int index = 0;
                visibleMap[index].PrintTile();
                index++;

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
                    while (currentMap[newPlayer.yPos - index, newPlayer.xPos].TYPE == 0)
                    {
                        distance++;
                        index++;
                    }
                    return distance;
                case 2:
                    //south wall
                    while (currentMap[newPlayer.yPos + index, newPlayer.xPos].TYPE == 0)
                    {
                        distance++;
                        index++;
                    }
                    return distance;
                case 3:
                    //west wall
                    while (currentMap[newPlayer.yPos, newPlayer.xPos - index].TYPE == 0)
                    {
                        distance++;
                        index++;
                    }
                    return distance;
                case 4:
                    //east wall
                    while (currentMap[newPlayer.yPos, newPlayer.xPos + index].TYPE == 0)
                    {
                        distance++;
                        index++;
                    }
                    return distance;
            }
            return 0;
        }

        void PlayerMovement()
        {

            while (true)
            {
                Tile tileToCheck;
                playerInfo.Action(newPlayer);
                userCKI = Console.ReadKey(true);

                if (userCKI.Key == ConsoleKey.UpArrow || userCKI.Key == ConsoleKey.NumPad8)
                {
                    tileToCheck = currentMap[newPlayer.yPos - 1, newPlayer.xPos];

                    if (tileToCheck.CanPass())
                    {
                        CharacterMovement(1, newPlayer);
                        FogOfWarReveal();
                        alert.Action("North");
                    }
                    else if (tileToCheck.HasCharacter())
                    {
                        //Battle
                        battle = new Battle(newPlayer, tileToCheck._Char);
                    }
                    else
                    {
                        //bump nose
                        alert.Action("Stop trying hit the wall");
                    }
                    //move enemy
                }
                else if (userCKI.Key == ConsoleKey.DownArrow || userCKI.Key == ConsoleKey.NumPad2)
                {
                    tileToCheck = currentMap[newPlayer.yPos + 1, newPlayer.xPos];

                    if (tileToCheck.CanPass())
                    {
                        CharacterMovement(2, newPlayer);
                        FogOfWarReveal();
                        alert.Action("South");
                    }
                    else if (tileToCheck.HasCharacter())
                    {
                        //Battle
                        battle = new Battle(newPlayer, tileToCheck._Char);
                    }
                    else
                    {
                        //bump head
                        alert.Action("Stop trying hit the Wall");
                    }
                    //move enemy
                }
                else if (userCKI.Key == ConsoleKey.LeftArrow || userCKI.Key == ConsoleKey.NumPad4)
                {
                    tileToCheck = currentMap[newPlayer.yPos, newPlayer.xPos - 1];

                    if (tileToCheck.CanPass())
                    {
                        CharacterMovement(3, newPlayer);
                        FogOfWarReveal();
                        alert.Action("West");
                    }
                    else if (tileToCheck.HasCharacter())
                    {
                        battle = new Battle(newPlayer, tileToCheck._Char);
                    }
                    else
                    {
                        alert.Action("Stop trying to hit the wall");
                    }
                }
                else if (userCKI.Key == ConsoleKey.RightArrow || userCKI.Key == ConsoleKey.NumPad6)
                {
                    tileToCheck = currentMap[newPlayer.yPos, newPlayer.xPos + 1];

                    if (tileToCheck.CanPass())
                    {
                        CharacterMovement(4, newPlayer);
                        FogOfWarReveal();
                        alert.Action("East");
                    }
                    else if (tileToCheck.HasCharacter())
                    {
                        battle = new Battle(newPlayer, tileToCheck._Char);
                    }
                    else
                    {
                        alert.Action("Stop trying hit the wall");
                    }
                }
                else if (userCKI.Key == ConsoleKey.NumPad7)
                {
                    //North West
                    tileToCheck = currentMap[newPlayer.yPos - 1, newPlayer.xPos - 1];

                    if (tileToCheck.CanPass())
                    {
                        CharacterMovement(5, newPlayer);
                        FogOfWarReveal();
                        alert.Action("North West");
                    }
                    else if (tileToCheck.HasCharacter())
                    {
                        battle = new Battle(newPlayer, tileToCheck._Char);
                    }
                    else
                    {
                        alert.Action("Stop trying hit the wall");
                    }
                }
                else if (userCKI.Key == ConsoleKey.NumPad9)
                {
                    //North East
                    tileToCheck = currentMap[newPlayer.yPos - 1, newPlayer.xPos + 1];

                    if (tileToCheck.CanPass())
                    {
                        CharacterMovement(6, newPlayer);
                        FogOfWarReveal();
                        alert.Action("North East");
                    }
                    else if (tileToCheck.HasCharacter())
                    {
                        battle = new Battle(newPlayer, tileToCheck._Char);
                    }
                    else
                    {
                        alert.Action("Stop trying hit the wall");
                    }
                }
                else if (userCKI.Key == ConsoleKey.NumPad3)
                {
                    //South East
                    tileToCheck = currentMap[newPlayer.yPos + 1, newPlayer.xPos + 1];

                    if (tileToCheck.CanPass())
                    {
                        CharacterMovement(7, newPlayer);
                        FogOfWarReveal();
                        alert.Action("South East");
                    }
                    else if (tileToCheck.HasCharacter())
                    {
                        battle = new Battle(newPlayer, tileToCheck._Char);
                    }
                    else
                    {
                        alert.Action("Stop trying hit the wall");
                    }
                }
                else if (userCKI.Key == ConsoleKey.NumPad1)
                {
                    //South West
                    tileToCheck = currentMap[newPlayer.yPos + 1, newPlayer.xPos - 1];

                    if (tileToCheck.CanPass())
                    {
                        CharacterMovement(8, newPlayer);
                        FogOfWarReveal();
                        alert.Action("South West");
                    }
                    else if (tileToCheck.HasCharacter())
                    {
                        battle = new Battle(newPlayer, tileToCheck._Char);
                    }
                    else
                    {
                        alert.Action("Stop trying hit the wall");
                    }
                }
                else if (userCKI.Key == ConsoleKey.Spacebar)
                {
                    //Skip Turn
                }
                else if (userCKI.Key == ConsoleKey.F)
                {
                    newPlayer.sHP++;
                    alert.Action("More Health!" + " new health: " + newPlayer.sHP);
                }
                else if (userCKI.Key == ConsoleKey.Escape)
                {
                    break;
                }
                else
                {
                    alert.Action("I Dont know this command");
                }
                EnemiesTurn();
            }
        }

        void EnemyMovement(Character enemy, int direction)
        {
            Tile tileToCheck;

            if (direction == 1)
            {
                tileToCheck = currentMap[enemy.yPos - 1, enemy.xPos];
                if (tileToCheck.CanPass())
                {
                    CharacterMovement(1, enemy);
                }else if (tileToCheck.HasPlayer())
                {
                    battle = new Battle(enemy, tileToCheck._Char);
                }
            }
            else if (direction == 2)
            {
                tileToCheck = currentMap[enemy.yPos + 1, enemy.xPos];
                if (tileToCheck.CanPass())
                {
                    CharacterMovement(2, enemy);
                }
                else if (tileToCheck.HasPlayer())
                {
                    //Battle
                    battle = new Battle(enemy, tileToCheck._Char);
                }
            }
            else if (direction == 3)
            {
                tileToCheck = currentMap[enemy.yPos, enemy.xPos - 1];
                if (tileToCheck.CanPass())
                {
                    CharacterMovement(3, enemy);
                }
                else if (tileToCheck.HasPlayer())
                {
                    //Battle
                    battle = new Battle(enemy, tileToCheck._Char);
                }
            }
            else if (direction == 4)
            {
                tileToCheck = currentMap[enemy.yPos, enemy.xPos + 1];
                if (tileToCheck.CanPass())
                {
                    CharacterMovement(4, enemy);
                }
                else if (tileToCheck.HasPlayer())
                {
                    //Battle
                    battle = new Battle(enemy, tileToCheck._Char);
                }
            }
            else if (direction == 5)
            {
                tileToCheck = currentMap[enemy.yPos-1, enemy.xPos - 1];
                if (tileToCheck.CanPass())
                {
                    CharacterMovement(5, enemy);
                }
                else if (tileToCheck.HasPlayer())
                {
                    //Battle
                    battle = new Battle(enemy, tileToCheck._Char);
                }
            }
            else if (direction == 6)
            {
                tileToCheck = currentMap[enemy.yPos- 1, enemy.xPos + 1];
                if (tileToCheck.CanPass())
                {
                    CharacterMovement(6, enemy);
                }
                else if (tileToCheck.HasPlayer())
                {
                    //Battle
                    battle = new Battle(enemy, tileToCheck._Char);
                }
            }
            else if (direction == 7)
            {
                tileToCheck = currentMap[enemy.yPos + 1, enemy.xPos + 1];
                if (tileToCheck.CanPass())
                {
                    CharacterMovement(7, enemy);
                }
                else if (tileToCheck.HasPlayer())
                {
                    //Battle
                    battle = new Battle(enemy, tileToCheck._Char);
                }
            }
            else if (direction == 8)
            {
                tileToCheck = currentMap[enemy.yPos + 1, enemy.xPos - 1];
                if (tileToCheck.CanPass())
                {
                    CharacterMovement(8, enemy);
                }
                else if (tileToCheck.HasPlayer())
                {
                    //Battle
                    battle = new Battle(enemy, tileToCheck._Char);
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
                }else if(activeEnemies[index]._AiState == 2)
                {
                    pathF.CreatePath(activeEnemies[index], newPlayer, currentMap);
                    activeEnemies[index].SetMovLib(pathF.GetDirections());
                    EnemyMovement(activeEnemies[index], activeEnemies[index].GetNextTile());
                }

                index++;
            }
        }

        public static void KillAnEnemy(Character enemy)
        {
            for(int i = 0; i < activeEnemies.Count; i++)
            {
                Character enemyTC = activeEnemies[i];
                if (enemyTC == enemy)
                {
                    currentMap[enemyTC.yPos, enemyTC.xPos].RemoveChar();
                    activeEnemies.RemoveAt(i);
                }
            }
        }

        void CheckForPlayer(Character actor)
        {
            for(int x = -1; x <2; x++)
            {
                for(int y = -1; y < 2; y++)
                {
                    if(currentMap[actor.yPos + y, actor.xPos + x].HasPlayer())
                    {
                        actor._AiState = 2;
                    }
                }
            }   
        }

        public static void UpdateMapTile(int y, int x)
        {
            currentMap[y, x].RemoveChar();
        }
    }
}
