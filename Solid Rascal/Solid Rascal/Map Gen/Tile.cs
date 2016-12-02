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
        public int X { get; set; }
        public int Y { get; set; }

        public Character _Char { get; set; }

        bool isPassable { get; set; }
        bool hasChar;
        bool hasPlayer;
        public bool isExit { get; set; }

        bool isVisible;
        bool isVisited;

        public int value { get; set; }

        public Tile(int x, int y, int id)
        {
            TILESET = new Tileset();

            isVisited = false;

            X = x;
            Y = y;
            TYPE = id;

            value = 0;

        }

        public void UpdateTile(int newTile, int color, int pass)
        {
            TYPE = newTile;
            COLOR = color;
            if(pass == 0)
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
            else if(!isVisible && isVisited) 
            {
                SetTileColor(1);
                Console.SetCursorPosition(X, Y);
                Console.Write(TILESET.TileType(TYPE));
            }
            else
            {
                SetTileColor(0);
            }
        }

        public bool CanPass()
        {
            return isPassable;
        }

        public void SetExit()
        {
            TYPE = 11;
            isExit = true;
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
            isPassable = false;

            if(character.charID == 52)
            {
                hasPlayer = true;
            }else
            {
                hasPlayer = false;
            }
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
            isPassable = true;
            hasPlayer = false;
        }

        public bool HasCharacter()
        {
            return hasChar;
        }

        public bool HasPlayer()
        {
            return hasPlayer;
        }

        void SetTileColor(int id)
        {
            switch (id)
            {
                case 0:
                    //Undiscovered
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case 1:
                    //Visited Tile
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case 2:
                    //Visible Tile
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                default:
                    break;
            }
        }

        public void SetValue(int v)
        {
            value = v;
        }
    }
}
