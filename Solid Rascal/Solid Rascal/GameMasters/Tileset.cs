using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal
{
    class Tileset
    {
        public string TileType(int type)
        {
            switch (type)
            {
                case 0:
                    return ".";
                case 1:
                    return " ";
                case 2:
                    return "X";
                case 3:
                    return "║";
                case 4:
                    return "╗";
                case 5:
                    return "╝";
                case 6:
                    return "╔";
                case 7:
                    return "╚";
                case 8:
                    return "═";
                case 9:
                    return "▓";
                case 10:
                    return "╬";
                case 11:
                    return "↕";
                ///Characters
                //Player
                case 52:
                    return "@";
                //Enemies
                case 100:
                    return "S";
                case 101:
                    return "P";
                case 102:
                    return "G";
                ///Items
                //Weapons
                case 200:
                    return "↑";
                //Armor
                case 220:
                    return "Δ";
                //Potions
                case 230:
                    return "¿";
                //Collectibles
                //Diamond
                case 250:
                    return "♦";
                //Food
                case 260:
                    return "≈";
                default:
                    return "X";
            }
        }
    }
}
