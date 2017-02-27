using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Characters.Enemies
{
    class Witch : Character
    {
        public Witch()
        {
            sDEF = 0;

            cName = "Witch";
            cType = 122;

            sHP = 10;
            sMHP = 10;
        }

        public override int GetAttackRoll()
        {
            return _die.Roll(1, 6);
        }
    }
}
