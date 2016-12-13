using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Characters.Player
{
    class Player : Character
    {

        public Player(string name)
        {
            isPlayer = true;

            charNAME = name;
            charID = 52;

            sSTR = 10;
            sMSTR = 10;
            sARMOR = 1;
            sHP = 50;
            sMHP = 50;
        }

        public void Wear()
        {

        }

        public void Consume()
        {

        }

        public void Wield()
        {

        }

    }
}
