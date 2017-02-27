using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Characters.Enemies
{
    class Phantom : Character
    {
        public Phantom()
        {
            sDEF = 0;

            cName = "Phantom";
            cType = 115;

            sHP = 25;
            sMHP = 25;
        }

        public override int GetAttackRoll()
        {
            return _die.Roll(1, 6);
        }
    }
}
