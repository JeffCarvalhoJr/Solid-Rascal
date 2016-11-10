using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal
{
    class Dice
    {
        int number;
        int sides;
        Random rand;

        public Dice()
        {
            rand = MainGame.rand;
            number = 0;
            sides = 0;
        }

        public int Roll(int x, int y)
        {
            int result = 0;
            number = x;
            sides = y;

            for (x = 0; x < number; x++)
            {
                result += rand.Next(0, sides + 1);
            }

            return result;
        }


    }
}
