using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Characters.Enemies
{
    class Troll : Character
    {
        public Troll()
        {
            sDEF = 0;

            cName = "Troll";
            cType = 119;

            sHP = 70;
            sMHP = 70;

            xpDrop = 28;
        }

        public override int GetAttackRoll()
        {
            return _die.Roll(3, 10);
        }
    }
}
