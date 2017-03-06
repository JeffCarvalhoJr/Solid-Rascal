using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Characters.Enemies
{
    class Kobold : Character
    {
        public Kobold()
        {
            sDEF = 0;

            cName = "Kobold";
            cType = 110;

            sHP = 10;
            sMHP = 10;

            xpDrop = 10;
        }

        public override int GetAttackRoll()
        {
            return _die.Roll(1, 10);
        }
    }
}
