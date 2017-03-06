using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Characters.Enemies
{
    class Slime : Character
    {
        public Slime() { 

            sDEF = 0;

            cName = "Slime";
            cType = 118;

            sHP = 20;
            sMHP = 20;

            xpDrop = 12;
        }

        public override int GetAttackRoll()
        {
            return _die.Roll(1, 10);
        }
    }
}
