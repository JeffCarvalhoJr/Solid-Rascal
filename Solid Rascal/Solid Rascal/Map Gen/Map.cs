using Solid_Rascal.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal
{
    class Map
    {
        public int MAPHeight { get; set; }
        public int MAPWidth { get; set; }
        public int[,] MAP { get; set; }

        public Random rand = new Random();

        public Room[,] _RoomsL { get; set; }

        public List<Corridor> _CorridorsL;

        public Alert alert = new Alert();


        public Map(int Width, int Height)
        {
            MAPWidth = Width;
            MAPHeight = Height;

            MAP = new int[Height, Width];

            SetupMap();
        }

        public void SetupMap()
        {
            for (int i = 0; i < MAPHeight; i++)
            {
                for (int j = 0; j < MAPWidth; j++)
                {
                    //set the initial map to only have walls
                    MAP[i, j] = 1;
                }
            }

            GenerateMap();
        }

        void GenerateMap()
        {
            _RoomsL = new Room[3, 3];
            _CorridorsL = new List<Corridor>(9);

            GenerateRooms();
            alert.Warning("Rooms Generated");
            GenerateCorridors();
            PlaceCorridors();
            alert.Warning("Corridors Generated");
            alert.Warning("Map is ready!");
        }

        void GenerateRooms()
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
                    _RoomsL[x, y] = newRoom;
                    NextRoomPosition(newRoom);
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

        void NextRoomPosition(Room room)
        {
            for (int y = room.Y; y < (room.Y + room.Height); y++)
            {
                for (int x = room.X; x < (room.X + room.Width); x++)
                {
                    //The conditions are to see the borders of the room, borders will receive wall tiles, the others floor tiles
                    if (y == room.Y && x == room.X)
                    {
                        SetMapTile(y, x, 6); //╔
                    }
                    else if (y == room.Y && x == room.X + room.Width - 1)
                    {
                        SetMapTile(y, x, 4);//╗
                    }
                    else if (y == room.Y + room.Height - 1 && x == room.X)
                    {
                        SetMapTile(y, x, 7);//╚
                    }
                    else if (x == room.X + room.Width - 1 && y == room.Y + room.Height - 1)
                    {
                        SetMapTile(y, x, 5);//╝
                    }
                    else if (y > room.Y && y < room.Y + room.Height - 1 && x == room.X || x == room.X + room.Width - 1)
                    {
                        SetMapTile(y, x, 3);//║
                    }
                    else if (y == room.Y || y == room.Y + room.Height - 1 && x > room.X && x < room.X + room.Width - 1)
                    {
                        SetMapTile(y, x, 8);//═
                    }
                    else
                    {
                        SetMapTile(y, x, 0);
                    }
                }
            }
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
                                SetMapTile(nextCorridor.cY1, nextCorridor.cX1 + x, 10);
                            }//else a corridor tile
                            else
                            {
                                SetMapTile(nextCorridor.cY1, nextCorridor.cX1 + x, 9);
                            }
                        }

                        //Corridor from room 2
                        for (int x2 = nextCorridor.c2; x2 > -1; x2--)
                        {
                            if (x2 == 0)
                            {
                                SetMapTile(nextCorridor.cY2, nextCorridor.cX2 - x2, 10);
                            }
                            else
                            {
                                SetMapTile(nextCorridor.cY2, nextCorridor.cX2 - x2, 9);
                            }
                        }

                        //Middle intersection corridor (between room 1 and 2)
                        //#Tricky if the corridor from room 1 Y coordinate is bigger than the Y from the room 2
                        //the value of c should be subtracted else added
                        if (nextCorridor.cY1 > nextCorridor.cY2)
                        {
                            for (int c = 0; c < nextCorridor.cConnection; c++)
                            {
                                SetMapTile(nextCorridor.cY1 - c, nextCorridor.cX1 + nextCorridor.c1, 9);
                            }
                        }
                        else
                        {
                            for (int c = 0; c < nextCorridor.cConnection; c++)
                            {
                                SetMapTile(nextCorridor.cY1 + c, nextCorridor.cX1 + nextCorridor.c1, 9);
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
                                SetMapTile(nextCorridor.cY1 - y, nextCorridor.cX1, 10);
                            }
                            else
                            {
                                SetMapTile(nextCorridor.cY1 - y, nextCorridor.cX1, 9);
                            }

                        }

                        for (int y2 = nextCorridor.c2; y2 > -1; y2--)
                        {
                            //Corredor sala 2
                            if (y2 == 0)
                            {
                                SetMapTile(nextCorridor.cY2 + y2, nextCorridor.cX2, 10);
                            }
                            else
                            {
                                SetMapTile(nextCorridor.cY2 + y2, nextCorridor.cX2, 9);
                            }
                        }

                        //Link corredor 1 e 2
                        if (nextCorridor.cX1 > nextCorridor.cX2)
                        {
                            for (int c = 0; c < nextCorridor.cConnection; c++)
                            {
                                SetMapTile(nextCorridor.cY1 - nextCorridor.c1, nextCorridor.cX1 - c, 9);
                            }
                        }
                        else
                        {
                            for (int c = 0; c < nextCorridor.cConnection; c++)
                            {
                                SetMapTile(nextCorridor.cY1 - nextCorridor.c1, nextCorridor.cX1 + c, 9);
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
                            SetMapTile(nextCorridor.cY1, nextCorridor.cX1 - x, 9);
                        }

                        for (int x2 = nextCorridor.c2; x2 > 0; x2--)
                        {
                            SetMapTile(nextCorridor.cY2, nextCorridor.cX2 + x2, 9);
                        }

                        if (nextCorridor.cY1 > nextCorridor.cY2)
                        {
                            for (int c = 0; c < nextCorridor.cConnection; c++)
                            {
                                SetMapTile(nextCorridor.cY1 - c, nextCorridor.cX1 - nextCorridor.c1, 9);
                            }
                        }
                        else
                        {
                            for (int c = 0; c < nextCorridor.cConnection; c++)
                            {
                                SetMapTile(nextCorridor.cY1 + c, nextCorridor.cX1 - nextCorridor.c1, 9);
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
                                SetMapTile(nextCorridor.cY1 - y, nextCorridor.cX1, 10);
                            }
                            else
                            {
                                SetMapTile(nextCorridor.cY1 - y, nextCorridor.cX1, 9);
                            }
                        }

                        for (int y2 = nextCorridor.c2; y2 < 0; y2--)
                        {
                            if (y2 == 0)
                            {
                                SetMapTile(nextCorridor.cY2 + y2, nextCorridor.cX2, 10);
                            }
                            else
                            {
                                SetMapTile(nextCorridor.cY2 + y2, nextCorridor.cX2, 9);
                            }
                        }

                        if (nextCorridor.cX1 > nextCorridor.cX2)
                        {
                            for (int c = 0; c < nextCorridor.cConnection; c++)
                            {
                                SetMapTile(nextCorridor.cY1 - nextCorridor.c1, nextCorridor.cX1 - c, 9);
                            }
                        }
                        else
                        {
                            for (int c = 0; c < nextCorridor.cConnection; c++)
                            {
                                SetMapTile(nextCorridor.cY1 - nextCorridor.c1, nextCorridor.cX1 + c, 9);
                            }
                        }
                    }
                }
            }
        }

        public int[,] GetMap()
        {
            return MAP;
        }

        public void SetMapTile(int y, int x, int tile)
        {
            MAP[y, x] = tile;
        }

        /* maybe on the future
         * void ReplaceRooms()
        {
            foreach (Room room in _RoomsL)
            {
                NextRoomPosition(room);
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
        */
    }
}
