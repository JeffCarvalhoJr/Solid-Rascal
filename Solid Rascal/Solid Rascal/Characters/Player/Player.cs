using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Characters.Player
{
    class Player : Character
    {

        public Player(int x, int y)
        {

            charNAME = "player";

            _ATK = 1;
            charID = 52;
            xPos = x;
            yPos = y;
            _Health = 1;
        }

    }
}
