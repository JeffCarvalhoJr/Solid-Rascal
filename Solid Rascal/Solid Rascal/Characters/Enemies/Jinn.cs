using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Characters.Enemies
{
    class Jinn : Character
    {
        public Jinn()
        {
            sDEF = 0;

            cName = "Jinn";
            cType = 109;

            sHP = 10;
            sMHP = 10;
        }

        public override int GetAttackRoll()
        {
            return _die.Roll(2, 6);
        }
    }
}
