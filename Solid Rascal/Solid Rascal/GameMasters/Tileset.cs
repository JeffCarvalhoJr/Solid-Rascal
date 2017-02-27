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
                    return "A";
                case 101:
                    return "B";
                case 102:
                    return "C";
                case 103:
                    return "D";
                case 104:
                    return "E";
                case 105:
                    return "F";
                case 106:
                    return "G";
                case 107:
                    return "H";
                case 108:
                    return "I";
                case 109:
                    return "J";
                case 110:
                    return "K";
                case 111:
                    return "L";
                case 112:
                    return "M";
                case 113:
                    return "N";
                case 114:
                    return "O";
                case 115:
                    return "P";
                case 116:
                    return "Q";
                case 117:
                    return "R";
                case 118:
                    return "S";
                case 119:
                    return "T";
                case 120:
                    return "U";
                case 121:
                    return "V";
                case 122:
                    return "W";
                case 123:
                    return "X";
                case 124:
                    return "Y";
                case 125:
                    return "Z";
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
                ///Collectibles
                //Diamond
                case 250:
                    return "♦";
                //Food
                case 260:
                    return "≈";
                default:
                    return "0";
            }
        }
    }
}
