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

        public Map currentMap;
        public Tileset TILESET;

        //map Variables
        public int MAPHeight;
        public int MAPWidth;
        public int MaxRooms;

        //public static List<Room> _RoomsL;
        public Room[,] _RoomsL;

        //public int min_room_h;
        //public int max_room_h;
        //public int min_room_w;
        //public int max_room_w;

        public int playerAnswer;

        //Corridors variables
        public static List<Corridor> _CorridorsL;


        public MainGame()
        {
            TILESET = new Tileset();
            GameStart();

        }


        void GameStart()
        {
            //Menu - Map Generator
            //MAPWidth = Int32.Parse(Question("Type the map Width"));
            //MAPHeight = Int32.Parse(Question("Type the map Height"));
            MAPWidth = 90;
            MAPHeight = 30;
            //MaxRooms = Int32.Parse(Question("Type the max Numbers of rooms"));//mark for deletion
            MaxRooms = 2;
            //min_room_h = Int32.Parse(Question("Type the min Height of the rooms to be generated"));
            //max_room_h = Int32.Parse(Question("Type the max Height of the rooms to be generated"));
            //min_room_w = Int32.Parse(Question("Type the min Width of the rooms to be generated"));
            //max_room_w = Int32.Parse(Question("Type the max Width of the rooms to be generated"));

            //generating map
            do
            {
                currentMap = new Map(MAPWidth, MAPHeight);

                //_RoomsL = new List<Room>(MaxRooms);
                _RoomsL = new Room[3, 3];
                _CorridorsL = new List<Corridor>(MaxRooms);

                GenerateRooms(MaxRooms);
                Warning("Rooms Generated");
                PrintMap();

                Console.ReadLine();
                GenerateCorridors();
                PlaceCorridors();
                //ReplaceRooms();
                Warning("Corridors generated!");
                PrintMap();
                Warning("Map is ready!");
                try
                {
                    playerAnswer = Int32.Parse(Question("Want to generate again?"));
                }
                catch
                {
                    playerAnswer = 0;
                }
            } while (playerAnswer != 1);

        }

        void ReplaceRooms()
        {
            foreach (Room room in _RoomsL)
            {
                NextRoomPosition(room);
            }
        }

        void GenerateRooms(int RoomsNumber)
        {
            int minX = 0;
            int maxX = 0;
            int minY = 0;
            int maxY = 0;

            Room newRoom;

            int roomIndex = 0;

            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    roomIndex++;
                    minX = x * 30;
                    maxX = (x + 1) * 30;
                    minY = y * 10;
                    maxY = (y + 1) * 10;

                    newRoom = new Room(minX, maxX, minY, maxY, roomIndex);
                    //_RoomsL.Add(newRoom);
                    _RoomsL[x, y] = newRoom;
                    NextRoomPosition(newRoom);
                    //PrintMap();
                    //Console.WriteLine("Sala: " + roomIndex);
                    //Console.ReadLine();
                }
            }


        }

        bool CheckOverlap(Room room, List<Room> rooms)
        {
            //most recent created room values
            int x = room.X;
            int y = room.Y;
            int w = room.Width;
            int h = room.Height;

            //the code will pass by each created room on the list
            foreach (Room c_Room in rooms)
            {
                //will compare the rectangles dimensions to see if they overlap with the current room being checked
                //Thanks Shade for the algorithm
                if (x < (c_Room.X + c_Room.Width) &&
                    c_Room.X < (x + w) &&
                    y < (c_Room.Y + c_Room.Height) &&
                    c_Room.Y < (y + h))
                {
                    TRIES++;
                    return true;
                }
            }
            TRIES = 0;
            return false;
        }

        void NextRoomPosition(Room room)
        {
            for (int y = room.Y; y < (room.Y + room.Height); y++)
            {
                for (int x = room.X; x < (room.X + room.Width); x++)
                {
                    //The conditions are to see the borders of the room, borders will receive wall tiles, the others floor tiles
                    if (y == room.Y && x == room.X)
                    {
                        currentMap.SetMapTile(y, x, 6); //╔
                    }
                    else if (y == room.Y && x == room.X + room.Width - 1)
                    {
                        currentMap.SetMapTile(y, x, 4);//╗
                    }
                    else if (y == room.Y + room.Height - 1 && x == room.X)
                    {
                        currentMap.SetMapTile(y, x, 7);//╚
                    }
                    else if (x == room.X + room.Width - 1 && y == room.Y + room.Height - 1)
                    {
                        currentMap.SetMapTile(y, x, 5);//╝
                    }
                    else if (y > room.Y && y < room.Y + room.Height - 1 && x == room.X || x == room.X + room.Width - 1)
                    {
                        currentMap.SetMapTile(y, x, 3);//║
                    }
                    else if (y == room.Y || y == room.Y + room.Height - 1 && x > room.X && x < room.X + room.Width - 1)
                    {
                        currentMap.SetMapTile(y, x, 8);//═
                    }
                    else
                    {
                        currentMap.SetMapTile(y, x, 0);
                    }
                }
            }
        }

        void GenerateCorridors()
        {

            //binary random coin
            int coin;
            Corridor newCorridor;

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    //flip da coin
                    coin = rand.Next(0, 2);

                    //if is the last room of the row, do nothing
                    //cant create a corridor up nor right.
                    if (x == 2 && y == 0)
                    {
                        //do nothing
                    }
                    else if (x == 2 && y == 2)
                    {
                        //if is the last room of the matriz, can just go up
                        newCorridor = new Corridor(_RoomsL[x, y], _RoomsL[x, y - 1]);
                        _CorridorsL.Add(newCorridor);
                    }
                    else if (x == 2)
                    {
                        //if is the last room of x can just go up
                        newCorridor = new Corridor(_RoomsL[x, y], _RoomsL[x, y - 1]);
                        _CorridorsL.Add(newCorridor);
                    }
                    else if (y == 0)
                    {
                        //if if is the first room of the matrix can only go right
                        newCorridor = new Corridor(_RoomsL[x, y], _RoomsL[x + 1, y]);
                        _CorridorsL.Add(newCorridor);
                    }
                    else
                    {
                        if (coin == 0)
                        {
                            newCorridor = new Corridor(_RoomsL[x, y], _RoomsL[x + 1, y]);
                            _CorridorsL.Add(newCorridor);
                        }
                        else
                        {
                            newCorridor = new Corridor(_RoomsL[x, y], _RoomsL[x, y - 1]);
                            _CorridorsL.Add(newCorridor);
                        }
                    }
                }
            }

            PlaceCorridors();
        }

        void PlaceCorridors()
        {
            for (int i = 0; i < _CorridorsL.Count(); i++)
            {
                Corridor nextCorridor = _CorridorsL[i];

                ///this is harsh
                ///Place corridors function, have 4 variations one for each direction (up, down, left and right)
                ///

                //First condition is to see if is positive
                if (_CorridorsL[i].POSITIVE)
                {
                    //second condition is to see if its vertical or horizontal
                    if (nextCorridor.VERTICAL)
                    {
                        //Vertical(+) Right
                        //X = ++
                        //X2 = --
                        //Intersection = Y

                        //Corridor from room 1
                        for (int x = 0; x < nextCorridor.c1; x++)
                        {
                            //if is the first block of corridor, put a door tile on it;
                            if (x == 0)
                            {
                                currentMap.SetMapTile(nextCorridor.cY1, nextCorridor.cX1 + x, 10);
                            }//else a corridor tile
                            else
                            {
                                currentMap.SetMapTile(nextCorridor.cY1, nextCorridor.cX1 + x, 9);
                            }
                        }

                        //Corridor from room 2
                        for (int x2 = nextCorridor.c2; x2 > -1; x2--)
                        {
                            if (x2 == 0)
                            {
                                currentMap.SetMapTile(nextCorridor.cY2, nextCorridor.cX2 - x2, 10);
                            }
                            else
                            {
                                currentMap.SetMapTile(nextCorridor.cY2, nextCorridor.cX2 - x2, 9);
                            }
                        }

                        //Middle intersection corridor (between room 1 and 2)
                        //#Tricky if the corridor from room 1 Y coordinate is bigger than the Y from the room 2
                        //the value of c should be subtracted else added
                        if (nextCorridor.cY1 > nextCorridor.cY2)
                        {
                            for (int c = 0; c < nextCorridor.cConnection; c++)
                            {
                                currentMap.SetMapTile(nextCorridor.cY1 - c, nextCorridor.cX1 + nextCorridor.c1, 9);
                            }
                        }
                        else
                        {
                            for (int c = 0; c < nextCorridor.cConnection; c++)
                            {
                                currentMap.SetMapTile(nextCorridor.cY1 + c, nextCorridor.cX1 + nextCorridor.c1, 9);
                            }
                        }
                    }
                    else
                    {
                        //Horizontal (+) Down
                        //Y = --
                        //Y 2 = ++
                        //Intersection = X
                        for (int y = 0; y < nextCorridor.c1; y++)
                        {
                            //Corredor sala 1
                            if (y == 0)
                            {
                                currentMap.SetMapTile(nextCorridor.cY1 - y, nextCorridor.cX1, 10);
                            }
                            else
                            {
                                currentMap.SetMapTile(nextCorridor.cY1 - y, nextCorridor.cX1, 9);
                            }

                        }

                        for (int y2 = nextCorridor.c2; y2 > -1; y2--)
                        {
                            //Corredor sala 2
                            if (y2 == 0)
                            {
                                currentMap.SetMapTile(nextCorridor.cY2 + y2, nextCorridor.cX2, 10);
                            }
                            else
                            {
                                currentMap.SetMapTile(nextCorridor.cY2 + y2, nextCorridor.cX2, 9);
                            }
                        }

                        //Link corredor 1 e 2
                        if (nextCorridor.cX1 > nextCorridor.cX2)
                        {
                            for (int c = 0; c < nextCorridor.cConnection; c++)
                            {
                                currentMap.SetMapTile(nextCorridor.cY1 - nextCorridor.c1, nextCorridor.cX1 - c, 9);
                            }
                        }
                        else
                        {
                            for (int c = 0; c < nextCorridor.cConnection; c++)
                            {
                                currentMap.SetMapTile(nextCorridor.cY1 - nextCorridor.c1, nextCorridor.cX1 + c, 9);
                            }
                        }
                    }
                }
                else
                {
                    if (nextCorridor.VERTICAL)
                    {
                        //Vertical(-)
                        //X = --
                        //X2 = ++
                        //Intersection = Y
                        for (int x = 0; x < nextCorridor.c1; x++)
                        {
                            currentMap.SetMapTile(nextCorridor.cY1, nextCorridor.cX1 - x, 9);
                        }

                        for (int x2 = nextCorridor.c2; x2 > 0; x2--)
                        {
                            currentMap.SetMapTile(nextCorridor.cY2, nextCorridor.cX2 + x2, 9);
                        }

                        if (nextCorridor.cY1 > nextCorridor.cY2)
                        {
                            for (int c = 0; c < nextCorridor.cConnection; c++)
                            {
                                currentMap.SetMapTile(nextCorridor.cY1 - c, nextCorridor.cX1 - nextCorridor.c1, 9);
                            }
                        }
                        else
                        {
                            for (int c = 0; c < nextCorridor.cConnection; c++)
                            {
                                currentMap.SetMapTile(nextCorridor.cY1 + c, nextCorridor.cX1 - nextCorridor.c1, 9);
                            }
                        }
                    }
                    else
                    {
                        //Horizontal(-)
                        //Y = ++
                        //Y2 = --
                        //Intersection = X
                        for (int y = 0; y < nextCorridor.c1; y++)
                        {
                            if (y == 0)
                            {
                                currentMap.SetMapTile(nextCorridor.cY1 - y, nextCorridor.cX1, 10);
                            }
                            else
                            {
                                currentMap.SetMapTile(nextCorridor.cY1 - y, nextCorridor.cX1, 9);
                            }
                        }

                        for (int y2 = nextCorridor.c2; y2 < 0; y2--)
                        {
                            if (y2 == 0)
                            {
                                currentMap.SetMapTile(nextCorridor.cY2 + y2, nextCorridor.cX2, 10);
                            }
                            else
                            {
                                currentMap.SetMapTile(nextCorridor.cY2 + y2, nextCorridor.cX2, 9);
                            }
                        }

                        if (nextCorridor.cX1 > nextCorridor.cX2)
                        {
                            for (int c = 0; c < nextCorridor.cConnection; c++)
                            {
                                currentMap.SetMapTile(nextCorridor.cY1 - nextCorridor.c1, nextCorridor.cX1 - c, 9);
                            }
                        }
                        else
                        {
                            for (int c = 0; c < nextCorridor.cConnection; c++)
                            {
                                currentMap.SetMapTile(nextCorridor.cY1 - nextCorridor.c1, nextCorridor.cX1 + c, 9);
                            }
                        }
                    }
                }
            }
        }

        void PrintMap()
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            for (int i = 0; i < MAPHeight; i++)
            {
                if (i > 0)
                    Console.Write("\n");
                for (int j = 0; j < MAPWidth; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.Write(TILESET.TileType(currentMap.MAP[i, j]));
                    //System.Threading.Thread.Sleep(1);//function to see the map being printed on the console with a delay (kinda nice)
                }
            }
        }

        //method to receive input for the user
        //put the cursor of the Console on the bottom of the map
        //Clear the line and type in the Message.
        string Question(string QUESTION)
        {
            ClearLine();
            if (MAPHeight > 0)
            {
                Console.SetCursorPosition(0, MAPHeight + 1);
            }
            else
            {
                Console.SetCursorPosition(0, Console.CursorTop);
            }

            Console.Write("" + QUESTION + ": ");

            return Console.ReadLine();
        }

        //method to display messages of information for the user
        //as the Question method, the cursor of the console will be placed on the bottom of the map
        //the line will be cleared and the message will be typed in
        void Warning(string WARNING)
        {

            ClearLine();
            if (MAPHeight > 0)
            {
                Console.SetCursorPosition(0, MAPHeight + 1);
            }
            else
            {
                Console.SetCursorPosition(0, Console.CursorTop);
            }
            Console.Write("" + WARNING + "!");
            Console.ReadLine();
        }

        //Method to clear a single line for the console
        //Mainly to be used with the Question and Warning methods
        void ClearLine()
        {
            for (int i = 0; i < 100; i++)
            {
                if (MAPHeight > 0)
                    Console.SetCursorPosition(i, MAPHeight + 1);
                else
                    Console.SetCursorPosition(i, Console.CursorTop);
                Console.Write(" ");
            }
        }
    }
}
