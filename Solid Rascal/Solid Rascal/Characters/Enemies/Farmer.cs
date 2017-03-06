using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Characters.Enemies
{
    class Farmer : Character
    {
        public Farmer()
        {
            sDEF = 0;

            cName = "Farmer";
            cType = 105;

            sHP = 2;
            sMHP = 2;

            xpDrop = 6;
        }

        public override int GetAttackRoll()
        {
            return _die.Roll(1, 5);
        }
    }
}
