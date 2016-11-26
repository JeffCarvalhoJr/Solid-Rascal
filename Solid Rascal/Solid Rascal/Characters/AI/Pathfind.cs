using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solid_Rascal.Map_Gen;

namespace Solid_Rascal.Characters.AI
{
    class Pathfind
    {
        Tile[,] pathMap;

        int actualTileX;
        int actualTileY;

        int nextTileX;
        int nextTileY;

        List<int> directions;
        List<Tile> unfinished;

        Character _Actor, _Target;

        bool cReachTarget;
        bool hasPath;

        public Pathfind()
        {
            directions = new List<int>();
            unfinished = new List<Tile>();
        }

        public void CreatePath(Character A, Character T, Tile[,] map)
        {
            _Actor = A;
            _Target = T;
            pathMap = map;
            ResetVal(pathMap);

            directions.Clear();
            unfinished.Clear();

            cReachTarget = false;
            hasPath = false;

            actualTileX = -1;
            actualTileY = -1;

            nextTileX = -1;
            nextTileY = -1;

            unfinished.Add(pathMap[_Actor.yPos, _Actor.xPos]);

            while (unfinished.Count > 0 && !hasPath)
            {
                actualTileX = unfinished[0].X;
                actualTileY = unfinished[0].Y;
                unfinished.RemoveAt(0);

                for (int y = -1; y < 2 && !hasPath; y++)
                {
                    for (int x = -1; x < 2 && !hasPath; x++)
                    {
                        if (x == 0 && y == 0)
                        {
                            //ignores the current tile
                        }
                        else
                        {
                            nextTileX = actualTileX + x;
                            nextTileY = actualTileY + y;

                            if (pathMap[nextTileY, nextTileX]._Char == _Target)
                            {
                                if (pathMap[actualTileY, actualTileX].value == 0)
                                {
                                    hasPath = true;
                                    cReachTarget = true;
                                    directions.Clear();
                                    directions.Add(GetInstantDirection(x, y));
                                }
                                else
                                {
                                    hasPath = true;
                                    cReachTarget = false;
                                    pathMap[nextTileY, nextTileX].SetValue(pathMap[actualTileY, actualTileX].value + 1);

                                    actualTileX = pathMap[nextTileY, nextTileX].X;
                                    actualTileY = pathMap[nextTileY, nextTileX].Y;
                                }
                            }
                            else if (pathMap[nextTileY, nextTileX].CanPass() && pathMap[nextTileY, nextTileX].value == 0 && pathMap[nextTileY, nextTileX]._Char != _Actor)
                            {
                                pathMap[nextTileY, nextTileX].SetValue(pathMap[actualTileY, actualTileX].value + 1);
                                unfinished.Add(pathMap[nextTileY, nextTileX]);
                            }
                        }
                    }
                }
            }//while

            if(unfinished.Count == 0 && !hasPath)
            {
                //Impossible Path
            }else
            {
                while (!cReachTarget)
                {
                    for(int y = -1; y < 2 && !cReachTarget; y++)
                    {
                        for(int x = -1; x < 2 && !cReachTarget; x++)
                        {
                            nextTileX = actualTileX + x;
                            nextTileY = actualTileY + y;

                            if (pathMap[nextTileY, nextTileX].HasCharacter())
                            {
                                if (pathMap[nextTileY, nextTileX]._Char == _Actor)
                                {
                                    cReachTarget = true;
                                    directions.Add(GetNextDirection(x, y));
                                }
                            }
                            else if (pathMap[nextTileY, nextTileX].value == pathMap[actualTileY, actualTileX].value - 1 && pathMap[nextTileY, nextTileX].CanPass())
                            {

                                pathMap[actualTileY, actualTileX].SetValue(-1);
                                directions.Add(GetNextDirection(x, y));
                                actualTileX = pathMap[nextTileY, nextTileX].X;
                                actualTileY = pathMap[nextTileY, nextTileX].Y;
                            }
                        }
                    }
                }//while
            }
        }

        public List<int> GetDirections()
        {
            return directions;
        }

        public int GetNextDirection(int x, int y)
        {

            if (x == -1 && y == -1)
            {
                //Path North West
                //AI South East
                return 7;
            }

            else if (x == 0 && y == -1)
            {
                //Path North
                //AI South
                return 2;
            }
            else if (x == 1 && y == -1)
            {
                //Path North East
                //AI South West
                return 8;
            }
            else if (x == -1 && y == 0)
            {
                //Path West
                //AI East
                return 4;
            }
            else if (x == 1 && y == 0)
            {
                //Path East
                //AI West
                return 3;
            }
            else if (x == -1 && y == 1)
            {
                //Path South West
                //AI North East
                return 6;

            }
            else if (x == 0 && y == 1)
            {
                //Path South
                //AI North
                return 1;
            }
            else if (x == 1 && y == 1)
            {
                //Path South East
                //AI North West
                return 5;
            }
            else
            {
                //null
                //alert.Warning("Error");
                return 0;
            }
        }

        public int GetInstantDirection(int x, int y)
        {

            if (x == -1 && y == -1)
            {
                //Path North West
                //AI South East
                return 5;
            }

            else if (x == 0 && y == -1)
            {
                //Path North
                //AI South
                return 1;
            }
            else if (x == 1 && y == -1)
            {
                //Path North East
                //AI South West
                return 6;
            }
            else if (x == -1 && y == 0)
            {
                //Path West
                //AI East
                return 3;
            }
            else if (x == 1 && y == 0)
            {
                //Path East
                //AI West
                return 4;
            }
            else if (x == -1 && y == 1)
            {
                //Path South West
                //AI North East
                return 8;

            }
            else if (x == 0 && y == 1)
            {
                //Path South
                //AI North
                return 2;
            }
            else if (x == 1 && y == 1)
            {
                //Path South East
                //AI North West
                return 7;
            }
            else
            {
                //null
                // alert.Warning("Error");
                return 0;
            }
        }

        public void ResetVal(Tile[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j].SetValue(0);
                }
            }
        }

    }
}
