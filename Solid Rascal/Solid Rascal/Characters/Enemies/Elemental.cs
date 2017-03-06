using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Characters.Enemies
{
    class Elemental : Character
    {
        public Elemental()
        {
            sDEF = 0;

            cName = "Elemental";
            cType = 104;

            sHP = 10;
            sMHP = 10;

            xpDrop = 15;
        }

        public override int GetAttackRoll()
        {
            return _die.Roll(2, 10);
        }

    }
}
