using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Rascal.Characters.Enemies
{
    class Nymph : Character
    {
        public Nymph()
        {
            sDEF = 0;

            cName = "Nymph";
            cType = 113;

            sHP = 25;
            sMHP = 25;

            xpDrop = 15;
        }

        public override int GetAttackRoll()
        {
            return _die.Roll(2, 10);
        }
    }
}
