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
                //1. Player
                //2. Enemies
                case 52:
                    return "@";
                case 53:
                    return "P";
                case 54:
                    return "S";
                default:
                    return "X";
            }
        }
    }
}
