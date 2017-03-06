using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Characters.Enemies
{
    class Rat : Character
    {
        public Rat()
        {
            sDEF = 0;

            cName = "Rat";
            cType = 117;

            sHP = 5;
            sMHP = 5;

            xpDrop = 8;
        }

        public override int GetAttackRoll()
        {
            return _die.Roll(1, 10);
        }
    }
}
