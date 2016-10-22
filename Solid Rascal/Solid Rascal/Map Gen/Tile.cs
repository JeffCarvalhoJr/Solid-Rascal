using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Map_Gen
{
    class Tile
    {
        Tileset TILESET;

        int TYPE {get; set;}
        int X { get; set; }
        int Y { get; set; }

        bool isPassable { get; set; }
        bool hasPlayer;

        public Tile(int x, int y, int id)
        {
            TILESET = new Tileset();

            X = x;
            Y = y;
            TYPE = id;

        }

        public void UpdateTile(int newTile)
        {
            TYPE = newTile;
            if(TYPE != 0 && TYPE != 9 && TYPE != 10)
            {
                isPassable = false;
            }else
            {
                isPassable = true;
            }
        }

        public void PrintTile()
        {
            if (!hasPlayer)
            {
                Console.SetCursorPosition(X, Y);
                Console.Write(TILESET.TileType(TYPE));
            }
            else
            {
                Console.SetCursorPosition(X, Y);
                Console.Write(TILESET.TileType(52));
            }
        }

        public bool CanPass()
        {
            return isPassable;
        }

        public void SetPlayer()
        {
            hasPlayer = true;
        }

        public void RemovePlayer()
        {
            hasPlayer = false;
        }


    }
}
