﻿using System;
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
            xPos = x;
            yPos = y;
            isPlayer = true;

            charNAME = "player";
            charID = 52;

            sSTR = 10;
            sMSTR = 10;
            sARMOR = 1;
            sHP = 10;
            sMHP = 10;
        }

    }
}
