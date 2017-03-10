using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Characters.Enemies
{
    class Imp : Character
    {
        public Imp()
        {
            sDEF = 0;

            cName = "Imp";
            cType = 108;

            sHP = 5;
            sMHP = 5;

            xpDrop = 10;
        }

        public override int GetAttackRoll()
        {
            return _die.Roll(1, 10);
        }
    }
}
