using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal
{
    class Room
    {
        //This is random.
        public static Random rand = new Random();

        //Room variables
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int ROOMID { get; set; }

        public Room(int minX, int maxX, int minY, int maxY, int id)
        {

            Width = rand.Next(4, 25);
            Height = rand.Next(4, 8);

            X = rand.Next(minX, maxX - Width - 1);
            Y = rand.Next(minY, maxY - Height - 1);

            ROOMID = id;
        }
    }
}
