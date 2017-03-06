using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Characters.Enemies
{
    class Vampire : Character
    {
        public Vampire()
        {
            sDEF = 0;

            cName = "Vampire";
            cType = 121;

            sHP = 25;
            sMHP = 25;

            xpDrop = 19;
        }

        public override int GetAttackRoll()
        {
            return _die.Roll(2, 10);
        }
    }
}
