﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Characters.Enemies
{
    class Xorn : Character
    {
        public Xorn()
        {
            sDEF = 0;

            cName = "Xorn";
            cType = 123;

            sHP = 30;
            sMHP = 30;

            xpDrop = 17;
        }

        public override int GetAttackRoll()
        {
            return _die.Roll(2, 10);
        }
    }
}
