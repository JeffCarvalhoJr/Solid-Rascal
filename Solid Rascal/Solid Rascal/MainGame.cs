using Solid_Rascal.UI;
using Solid_Rascal.Map_Gen;
using Solid_Rascal.Characters.Player;
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

        //Room Placement Tries
        public static int TRIES = 0;

        public Map mapGen;
        public Tile[,] currentMap;

        public Tileset TILESET;

        //map Variables
        public int MAPHeight;
        public int MAPWidth;
        public int MaxRooms;

        Player newPlayer;

        Alert alert = new Alert();

        public string playerAnswer;

        public ConsoleKeyInfo userCKI;


        public MainGame()
        {
            TILESET = new Tileset();
            GameStart();

        }


        void GameStart()
        {
            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.UTF8;
            MAPWidth = 90;
            MAPHeight = 30;

            MaxRooms = 9;

            //generating map loop
            do
            {
           
                mapGen = new Map(MAPWidth, MAPHeight);
                currentMap = mapGen.GetMap();
                PlaceExit();
                PrintMap();
                PlaceActors();
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
            //Only player for now
            int randRoomX = rand.Next(0, 3);
            int randRoomY = rand.Next(0, 3);
            Room spawnRoom = mapGen._RoomsL[randRoomX, randRoomY];

            int playerX, playerY;

            playerX = rand.Next((spawnRoom.X + 1), spawnRoom.X + spawnRoom.Width - 1);
            playerY = rand.Next((spawnRoom.Y + 1), spawnRoom.Y + spawnRoom.Height - 1);



            newPlayer = new Player(playerX, playerY);
            currentMap[newPlayer.yPos, newPlayer.xPos].SetPlayer();
            currentMap[newPlayer.yPos, newPlayer.xPos].PrintTile();
            
        }

        void PlaceExit()
        {
            /*
            int randRoomX = rand.Next(0, 3);
            int randRoomY = rand.Next(0, 3);
            Room spawnRoom = mapGen._RoomsL[randRoomX, randRoomY];

            int exitX, exitY;

            exitX = rand.Next((spawnRoom.X + 1), spawnRoom.X + spawnRoom.Width - 1);
            exitY = rand.Next((spawnRoom.Y + 1), spawnRoom.Y + spawnRoom.Height - 1);

            currentMap[exitY, exitX] = 11;
            */
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

        void PlayerMovement()
        {
            while (true)
            {
                userCKI = Console.ReadKey(true);
                if (userCKI.Key == ConsoleKey.UpArrow || userCKI.Key == ConsoleKey.W)
                {
                    if (currentMap[newPlayer.yPos - 1, newPlayer.xPos].CanPass())
                    {
                        currentMap[newPlayer.yPos, newPlayer.xPos].RemovePlayer();
                        currentMap[newPlayer.yPos, newPlayer.xPos].PrintTile();      

                        newPlayer.yPos--;
                        currentMap[newPlayer.yPos, newPlayer.xPos].SetPlayer();
                        currentMap[newPlayer.yPos, newPlayer.xPos].PrintTile();

                        //PrintMap();
                        alert.Action("North");
                    }
                    else
                    {
                        alert.Action("Stop trying hit the wall");
                    }
                }
                else if (userCKI.Key == ConsoleKey.DownArrow || userCKI.Key == ConsoleKey.X)
                {
                    if (currentMap[newPlayer.yPos + 1, newPlayer.xPos].CanPass())
                    {
                        currentMap[newPlayer.yPos, newPlayer.xPos].RemovePlayer();
                        currentMap[newPlayer.yPos, newPlayer.xPos].PrintTile();
                    
                        newPlayer.yPos++;
                        currentMap[newPlayer.yPos, newPlayer.xPos].SetPlayer();
                        currentMap[newPlayer.yPos, newPlayer.xPos].PrintTile();     
                        //PrintMap();
                        alert.Action("South");
                    }
                    else
                    {
                        alert.Action("Stop trying hit the wall");
                    }
                }
                else if (userCKI.Key == ConsoleKey.LeftArrow || userCKI.Key == ConsoleKey.A)
                {
                    if (currentMap[newPlayer.yPos, newPlayer.xPos - 1].CanPass())
                    {
                        currentMap[newPlayer.yPos, newPlayer.xPos].RemovePlayer();
                        currentMap[newPlayer.yPos, newPlayer.xPos].PrintTile();

                        newPlayer.xPos--;

                        currentMap[newPlayer.yPos, newPlayer.xPos].SetPlayer();
                        currentMap[newPlayer.yPos, newPlayer.xPos].PrintTile();
       
                        //PrintMap();
                        alert.Action("West");
                    }
                    else
                    {
                        alert.Action("Stop trying hit the wall");
                    }
                }
                else if (userCKI.Key == ConsoleKey.RightArrow || userCKI.Key == ConsoleKey.D)
                {
                    if (currentMap[newPlayer.yPos, newPlayer.xPos + 1].CanPass())
                    {
                        currentMap[newPlayer.yPos, newPlayer.xPos].RemovePlayer();
                        currentMap[newPlayer.yPos, newPlayer.xPos].PrintTile();

                        newPlayer.xPos++;

                        currentMap[newPlayer.yPos, newPlayer.xPos].SetPlayer();
                        currentMap[newPlayer.yPos, newPlayer.xPos].PrintTile();

                        //PrintMap();
                        alert.Action("East");
                    }
                    else
                    {
                        alert.Action("Stop trying hit the wall");
                    }
                }
                else if (userCKI.Key == ConsoleKey.Escape)
                {
                    break;
                }
                else
                {
                    alert.Action("I Dont know this command");
                }
            } 
        }

    }
}
