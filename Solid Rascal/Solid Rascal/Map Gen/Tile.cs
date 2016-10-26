using System;
using Solid_Rascal.Characters;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Map_Gen
{
    class Tile
    {
        Tileset TILESET;

        int COLOR;

        public int TYPE {get; set;}
        int X { get; set; }
        int Y { get; set; }

        Character _Char;

        bool isPassable { get; set; }
        bool hasChar;

        bool isVisible;
        bool isVisited;

        public Tile(int x, int y, int id)
        {
            TILESET = new Tileset();

            isVisited = false;

            X = x;
            Y = y;
            TYPE = id;

        }

        public void UpdateTile(int newTile, int color)
        {
            TYPE = newTile;
            COLOR = color;
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
            if (isVisible)
            {
                SetTileColor(2);
            }else if(!isVisible && isVisited) 
            {
                SetTileColor(1);
            }else
            {
                SetTileColor(0);
            }


            if (!hasChar)
            {
                Console.SetCursorPosition(X, Y);
                Console.Write(TILESET.TileType(TYPE));
            }
            else
            {
                Console.SetCursorPosition(X, Y);
                Console.Write(TILESET.TileType(_Char.charID));
            }
        }

        public bool CanPass()
        {
            return isPassable;
        }

        public void Reset()
        {
            isVisible = false;
            PrintTile();    
        }

        public void SetCharacter(Character character)
        {
            _Char = character;
            hasChar = true;
        }

        public void SetVisible()
        {
            isVisible = true;
            isVisited = true;
            PrintTile();
        }

        public void RemoveChar()
        {
            _Char = null;
            hasChar = false;
        }

        void SetTileColor(int id)
        {
            switch (id)
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.Black;
                    //black
                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    //Gray
                    break;
                case 2:
                    //yellow
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    break;
            }
        }

    }
}
