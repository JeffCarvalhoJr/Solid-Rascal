using System;
using Solid_Rascal.Characters;
using Solid_Rascal.Items;
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

        public int tID {get; set;}
        public int tX { get; set; }
        public int tY { get; set; }

        public Character tChar { get; set; }
        public Item tItem { get; set; }

        public bool isPassable { get; set; }
        public bool hasItem { get; set; }
        public bool hasChar { get; set; }
        public bool hasPlayer { get; set; }
        public bool isExit { get; set; }

        bool isVisible;
        bool isDiscovered;

        public int value { get; set; }

        public Tile(int x, int y, int id)
        {
            TILESET = new Tileset();

            isDiscovered = false;

            tX = x;
            tY = y;
            tID = id;

            value = 0;
        }

        public void UpdateTile(int newTile, int color, int pass)
        {
            tID = newTile;
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

                if (hasChar)
                {
                    Console.SetCursorPosition(tX, tY);
                    Console.Write(TILESET.TileType(tChar.charID));
                }else if (hasItem)
                {
                    //Color blue
                    //print item 
                    SetTileColor(3);
                    Console.SetCursorPosition(tX, tY);
                    Console.Write(TILESET.TileType(tItem.iType));
                }
                else
                {
                    if (isExit)
                    {
                        SetTileColor(4);
                        Console.SetCursorPosition(tX, tY);
                        Console.Write(TILESET.TileType(tID));
                    }
                    else
                    {
                        Console.SetCursorPosition(tX, tY);
                        Console.Write(TILESET.TileType(tID));
                    }
                }
            }
            else if(!isVisible && isDiscovered) 
            {
                SetTileColor(1);
                Console.SetCursorPosition(tX, tY);
                Console.Write(TILESET.TileType(tID));
            }
            else
            {
                SetTileColor(0);
            }
        }

        public void SetExit()
        {
            tID = 11;
            isExit = true;
        }

        public void Reset()
        {
            isVisible = false;
            PrintTile();    
        }

        public void SetCharacter(Character character)
        {
            tChar = character;
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

        public void RemoveChar()
        {
            tChar = null;
            hasChar = false;
            isPassable = true;
            hasPlayer = false;
        }

        public void SetItem(Item item)
        {
            tItem = item;
            hasItem = true;
        }

        public void Removetem()
        {
            tItem = null;
            hasItem = false;
        }

        public void SetVisible()
        {
            isVisible = true;
            isDiscovered = true;
            PrintTile();
        }

        void SetTileColor(int id)
        {
            switch (id)
            {
                case 0:
                    //Undiscovered
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case 1:
                    //Visited Tile
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case 2:
                    //Visible Tile
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case 3:
                    //Tile with item
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case 4:
                    //Tile with special feature
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
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
