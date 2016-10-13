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
        }

        public void SetMapTile(int y, int x, int tile)
        {
            MAP[y, x] = tile;
        }
    }
}
