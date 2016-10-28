using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Characters.Enemies
{
    class Slime : Character
    {
        public Slime(int x, int y)
        {
            charNAME = "Slime";

            _ATK = 1;
            charID = 53;
            xPos = x;
            yPos = y;
            _Health = 5;
        }


    }
}
